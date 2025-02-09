using LibrarySystem.DataAccess.Interfaces;
using LibrarySystem.DataAccess.Models.Books;
using LibrarySystem.Domain.DTOs.Request.Books;
using LibrarySystem.Domain.DTOs.Response;
using LibrarySystem.Domain.DTOs.Response.Books;
using LibrarySystem.Services.IServices.Books;
using System.Linq.Expressions;

namespace LibrarySystem.Services.Services.Books
{
    public class BookService(IUnitOfWork _unitOfWork) : IBookService
    {
        public async Task<Response<string>> CreateBook(CreateUpdateBookRequest model)
        {
            var book = new Book
            {
                Title = model.Title,
                Author = model.Author,
                Genre = model.Genre,
                PublishedYear = model.PublishedYear,
                IsAvailable = true,
            };
            await _unitOfWork.Books.AddAsync(book);
            await _unitOfWork.CompleteAsync();
            return new()
            {
                Check = true,
                Msg = "Book added Sucessfully"
            };
        }

        public async Task<Response<string>> DeleteBook(int id)
        {
            var obj = await _unitOfWork.Books.GetByIdAsync(id);
            if (obj is null)
                return new()
                {
                    Check = false,
                    Msg = "Books doesn't exist"
                };


            _unitOfWork.Books.Remove(obj);
            await _unitOfWork.CompleteAsync();
            return new()
            {
                Check = true,
                Msg = "Books deleted sucessfully"
            };
        }

        public async Task<Response<GetAllResponse>> GetAllBooks(GetAllBooksFilteration model)
        {
            Expression<Func<Book, bool>> filter = x =>
                                       (string.IsNullOrEmpty(model.Word) ||
                                          x.Author.Contains(model.Word)
                                          || x.Title.Contains(model.Word)
                                       );



            var result = await _unitOfWork.Books.GetSpecificSelectAsync(
                                     filter: filter,
                                     take: model.PageSize,
                                     skip: (model.PageNumber - 1) * model.PageSize,
                                     select: x => new
                                     {
                                         x.Id,
                                         x.Title,
                                         x.Author,
                                         x.Genre,
                                         x.PublishedYear,
                                         x.IsAvailable
                                     }, orderBy: x => x.OrderBy(x => x.Id));


            var response = new GetAllResponse()
            {
                CurrentPage = model.PageNumber,
                Items = result,
                page = model.PageNumber,
                PageNumber = model.PageNumber,
                PageSize = model.PageSize,
                TotalRecords = await _unitOfWork.Books.CountAsync(filter)
            };
            return new()
            {
                Check = true,
                Data = response
            };

        }

        public async Task<Response<GetBookByIdResponse>> GetBookById(int id)
        {
            var obj = await _unitOfWork.Books.GetByIdAsync(id);
            if (obj is null)
            {
                return new()
                {
                    Check = false,
                    Msg = "Book doesn't exist"
                };
            }

            var response = new GetBookByIdResponse()
            {
                Author = obj.Author,
                Genre = obj.Genre,
                IsAvailable = obj.IsAvailable,
                PublishedYear = obj.PublishedYear,
                Title = obj.Title,
            };

            return new()
            {
                Check = true,
                Data = response
            };
        }

        public async Task<Response<string>> UpdateBook(int id, CreateUpdateBookRequest model)
        {
            var obj = await _unitOfWork.Books.GetByIdAsync(id);
            if (obj is null)
                return new()
                {
                    Check = false,
                    Msg = "Books doesn't exist"
                };


            obj.Title = model.Title;
            obj.Author = model.Author;
            obj.Genre = model.Genre;
            obj.PublishedYear = model.PublishedYear;
            _unitOfWork.Books.Update(obj);
            await _unitOfWork.CompleteAsync();
            return new()
            {
                Check = true,
                Msg = "Book Updated Sucessfully"
            };
        }
    }
}
