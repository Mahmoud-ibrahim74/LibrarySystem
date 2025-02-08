using LibrarySystem.Domain.DTOs.Request.Books;
using LibrarySystem.Domain.DTOs.Response;
using LibrarySystem.Domain.DTOs.Response.Books;

namespace LibrarySystem.Services.IServices.Books
{
    public interface IBookService
    {
        #region Create
        public Task<Response<string>> CreateBook(CreateUpdateBookRequest model);
        #endregion

        #region Read
        public Task<Response<GetAllResponse>> GetAllBooks(GetAllBooksFilteration model);
        public Task<Response<GetBookByIdResponse>> GetBookById(int id);
        #endregion

        #region Update
        public Task<Response<string>> UpdateBook(int id, CreateUpdateBookRequest model);
        #endregion

        #region Delete
        public Task<Response<string>> DeleteBook(int id);
        #endregion
    }
}
