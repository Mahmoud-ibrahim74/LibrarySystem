using LibrarySystem.DataAccess.Models.Books;
using LibrarySystem.DataAccess.Repositories;
using LibrarySystemAPI.DataAccess.Context;

namespace LibrarySystem.DataAccess.Interfaces.Books;

public class BookRepository(LibrarySystemDbContext context) : BaseRepository<Book>(context), IBookRepository
{
}
