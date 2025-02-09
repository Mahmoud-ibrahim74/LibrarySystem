using LibrarySystem.Domain.DTOs.Response;

namespace LibrarySystem.Services.IServices.Books
{
    public interface IBorrowedBookService
    {
        #region Create
        public Task<Response<string>> CreateBorrowedBook(int bookId);
        #endregion

        #region Update
        public Task<Response<string>> ReturnBorrowedBook(int id);
        #endregion


        #region Read
        public Task<Response<object>> GetAllBorrowedBooksForLoggedUser();
        #endregion
    }
}
