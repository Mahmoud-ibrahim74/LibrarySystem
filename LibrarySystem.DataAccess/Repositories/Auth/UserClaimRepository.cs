using LibrarySystem.DataAccess.Interfaces.Auth;
using LibrarySystemAPI.DataAccess.Context;
using LibrarySystemAPI.DataAccess.Models.Auth;

namespace LibrarySystem.DataAccess.Repositories.Auth
{
    public class UserClaimRepository(LibrarySystemDbContext context) : BaseRepository<ApplicationUserClaim>(context), IUserClaimRepository
    {
    }
}
