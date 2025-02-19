﻿using LibrarySystem.DataAccess.Interfaces.Books;
using LibrarySystem.DataAccess.Models.Books;
using LibrarySystemAPI.DataAccess.Context;

namespace LibrarySystem.DataAccess.Repositories.Books;

public class BookRepository(LibrarySystemDbContext context) : BaseRepository<Book>(context), IBookRepository
{
}
