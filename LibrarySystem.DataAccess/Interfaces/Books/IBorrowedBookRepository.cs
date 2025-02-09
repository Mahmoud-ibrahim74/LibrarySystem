using LibrarySystem.DataAccess.Models.Books;
using LibrarySystemAPI.DataAccess.Models.Auth;

namespace LibrarySystem.DataAccess.Interfaces.Books;

public interface IBorrowedBookRepository : IBaseRepository<BorrowedBook>
{
}
