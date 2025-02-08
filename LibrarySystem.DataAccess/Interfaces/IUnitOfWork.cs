using LibrarySystem.DataAccess.Interfaces.Auth;
using LibrarySystem.DataAccess.Interfaces.Books;

namespace LibrarySystem.DataAccess.Interfaces;

public interface IUnitOfWork : IDisposable
{
    public IUserRepository Users { get; }
    public IRoleClaimRepository RoleClaims { get; }
    public IUserClaimRepository UserClaims { get; }
    public IRoleRepository Roles { get; }
    public IUserRoleRepository UserRoles { get; }
    public IBookRepository BookRepository { get; }
    public Task<int> CompleteAsync();
}