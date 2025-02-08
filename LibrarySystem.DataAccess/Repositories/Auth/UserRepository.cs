using LibrarySystem.DataAccess.Interfaces.Auth;
using LibrarySystemAPI.DataAccess.Context;
using LibrarySystemAPI.DataAccess.Models.Auth;

namespace LibrarySystem.DataAccess.Repositories.Auth;

public class UserRepository(LibrarySystemDbContext context) : BaseRepository<ApplicationUser>(context), IUserRepository
{
}
