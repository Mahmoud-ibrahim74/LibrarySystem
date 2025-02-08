using LibrarySystem.DataAccess.Models.Books;
using LibrarySystemAPI.DataAccess.Models.Auth;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace LibrarySystemAPI.DataAccess.Context
{
    public class LibrarySystemDbContext(DbContextOptions<LibrarySystemDbContext> options) :
    IdentityDbContext<ApplicationUser, ApplicationRole, int,
             ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin,
             ApplicationRoleClaim, ApplicationUserToken>(options)
    {

        public DbSet<Book> Books { get; set; }
        public DbSet<BorrowedBook> BorrowedBooks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }

}
