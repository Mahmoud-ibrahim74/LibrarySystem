using LibrarySystemAPI.DataAccess.Models.Auth;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace LibrarySystemAPI.DataAccess.Context
{
    public class LibrarySystemDbContext(DbContextOptions<LibrarySystemDbContext> options) :
    IdentityDbContext<ApplicationUser, ApplicationRole, string,
             ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin,
             ApplicationRoleClaim, ApplicationUserToken>(options)
    {


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {




            base.OnModelCreating(modelBuilder);
        }

    }
   
}
