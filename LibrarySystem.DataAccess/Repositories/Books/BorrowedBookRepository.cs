using LibrarySystem.DataAccess.Interfaces.Books;
using LibrarySystem.DataAccess.Models.Books;
using LibrarySystemAPI.DataAccess.Context;

namespace LibrarySystem.DataAccess.Repositories.Books;

public class BorrowedBookRepository(LibrarySystemDbContext context) : BaseRepository<BorrowedBook>(context), IBorrowedBookRepository
{
}
