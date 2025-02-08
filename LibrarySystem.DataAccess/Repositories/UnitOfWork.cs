using LibrarySystem.DataAccess.Interfaces;
using LibrarySystem.DataAccess.Interfaces.Auth;
using LibrarySystem.DataAccess.Repositories.Auth;
using LibrarySystemAPI.DataAccess.Context;

namespace LibrarySystem.DataAccess.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly LibrarySystemDbContext _context;
    public IUserRepository Users { get; }
    public IRoleClaimRepository RoleClaims { get; }
    public IUserClaimRepository UserClaims { get; }
    public IRoleRepository Roles { get; }
    public IUserRoleRepository UserRoles { get; }
    public UnitOfWork(LibrarySystemDbContext context)
    {
        _context = context;
        Users = new UserRepository(_context);
        RoleClaims = new RoleClaimRepository(_context);
        Roles = new RoleRepository(_context);
        UserRoles = new UserRoleRepository(_context);
        UserClaims = new UserClaimRepository(_context);
    }
    public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        _context.Dispose();
    }

    public int Complete() => _context.SaveChanges();
}