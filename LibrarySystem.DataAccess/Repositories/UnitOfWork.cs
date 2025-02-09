using LibrarySystem.DataAccess.Interfaces;
using LibrarySystem.DataAccess.Interfaces.Auth;
using LibrarySystem.DataAccess.Interfaces.Books;
using LibrarySystem.DataAccess.Repositories.Auth;
using LibrarySystem.DataAccess.Repositories.Books;
using LibrarySystemAPI.DataAccess.Context;

namespace LibrarySystem.DataAccess.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly LibrarySystemDbContext _context;
    public IUserRepository Users { get; private set; }
    public IRoleClaimRepository RoleClaims { get; private set; }
    public IUserClaimRepository UserClaims { get; private set; }
    public IRoleRepository Roles { get; private set; }
    public IUserRoleRepository UserRoles { get; private set; }
    public IBookRepository Books { get; private set; }
    public IBorrowedBookRepository BorrowedBooks { get; private set; }

    public UnitOfWork(LibrarySystemDbContext context)
    {
        _context = context;
        Users = new UserRepository(_context);
        RoleClaims = new RoleClaimRepository(_context);
        Roles = new RoleRepository(_context);
        UserRoles = new UserRoleRepository(_context);
        UserClaims = new UserClaimRepository(_context);
        Books = new BookRepository(_context);
        BorrowedBooks = new BorrowedBookRepository(_context);
    }
    public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        _context.Dispose();
    }

    public int Complete() => _context.SaveChanges();
}