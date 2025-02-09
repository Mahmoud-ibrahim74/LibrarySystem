using LibrarySystem.DataAccess.Interfaces;
using LibrarySystem.DataAccess.Models.Books;
using LibrarySystem.Domain.DTOs.Request.Books;
using LibrarySystem.Domain.DTOs.Response;
using LibrarySystem.Domain.DTOs.Response.Books;
using LibrarySystem.Services.IServices.AppServices;
using LibrarySystem.Services.IServices.Books;
using System.Linq.Expressions;

namespace LibrarySystem.Services.Services.Books
{
    public class BorrowedBookService(IUnitOfWork _unitOfWork, IUserContextService userContextService) : IBorrowedBookService
    {
        public async Task<Response<string>> CreateBorrowedBook(int bookId)
        {
            var userId = userContextService.UserId;
            var book = await _unitOfWork.Books.GetByIdAsync(bookId);

            #region BorrowedBookValidation
            if (book is null)
                return new()
                {
                    Check = false,
                    Msg = "Book doesn't exist"
                };

            if (!book.IsAvailable)
                return new()
                {
                    Check = false,
                    Msg = "Book doesn't Available"
                };
            #endregion


            var borrowed = new BorrowedBook
            {
                BookId = bookId,
                BorrowedDate = DateTime.Now,
                ReturnDate = DateTime.Now.AddDays(14),
                UserId = (int)userId
            };
            await _unitOfWork.BorrowedBooks.AddAsync(borrowed);
           var res =  await _unitOfWork.CompleteAsync();
            if(res >  0)
            {
                book.IsAvailable = false;
                _unitOfWork.Books.Update(book);
                await _unitOfWork.CompleteAsync();
            }
            return new()
            {
                Check = true,
                Msg = "book is Borrowed sucessfully"
            };


        }

        public async Task<Response<object>> GetAllBorrowedBooksForLoggedUser()
        {
            var userId = userContextService.UserId;
            var res = await _unitOfWork.BorrowedBooks.GetSpecificSelectAsync<object>(
                filter: x => x.UserId == userId,
                select: x => new
                {
                    x.Id,
                    x.User.FullName,
                    x.Book.Title,
                    BorrowedDate = DateOnly.FromDateTime(x.BorrowedDate),
                    ReturnDate = DateOnly.FromDateTime(x.ReturnDate),
                },
                orderBy: x => x.Order()
                );

            return new()
            {
                Check = true,
                Data = res
            };
        }

        public async Task<Response<string>> ReturnBorrowedBook(int id)
        {
            try
            {
                var borrowedBook = await _unitOfWork.BorrowedBooks.GetByIdAsync(id);
                if (borrowedBook is null)
                    return new()
                    {
                        Check = false,
                        Msg = "Borrowed Book doesn't exist"
                    };
                var cuurentDate = DateTime.Now;
                if (cuurentDate > borrowedBook.ReturnDate)
                {
                    var book = await _unitOfWork.Books.GetByIdAsync(borrowedBook.BookId);
                    book.IsAvailable = true;
                    _unitOfWork.Books.Update(book);
                    await _unitOfWork.CompleteAsync();
                    return new()
                    {
                        Check = true,
                        Msg = "Book returned successfully"
                    };
                }
                else
                {
                    return new()
                    {
                        Check = false,
                        Msg = "Book still Borrowing ,please try again after 14 days",
                    };
                }
            }
            catch (Exception ex)
            {

                return new()
                {
                    Check = true,
                    Msg = "Something wrong",
                    Error = ex.Message
                };
            }





        }
    }
}
