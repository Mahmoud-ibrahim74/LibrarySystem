using LibrarySystemAPI.DataAccess.Models.Auth;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystemAPI.DataAccess.Context
{
    public class LibrarySystemDbContext(DbContextOptions<LibrarySystemDbContext> options) :
    IdentityDbContext<ApplicationUser, ApplicationRole, string,
             ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin,
             ApplicationRoleClaim, ApplicationUserToken>(options)
    {

    }
}
