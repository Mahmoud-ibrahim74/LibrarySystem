using LibrarySystem.DataAccess.Interfaces.Auth;
using LibrarySystemAPI.DataAccess.Context;
using LibrarySystemAPI.DataAccess.Models.Auth;

namespace LibrarySystem.DataAccess.Repositories.Auth;

public class RoleClaimRepository(LibrarySystemDbContext context) : BaseRepository<ApplicationRoleClaim>(context), IRoleClaimRepository
{
}
