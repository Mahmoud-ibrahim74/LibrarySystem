using LibrarySystem.DataAccess.Interfaces;
using LibrarySystemAPI.DataAccess.Models.Auth;

namespace LibrarySystem.DataAccess.Interfaces.Auth
{
    public interface IUserClaimRepository : IBaseRepository<ApplicationUserClaim>
    {
    }
}
