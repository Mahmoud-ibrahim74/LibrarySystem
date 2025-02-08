namespace LibrarySystemAPI.DataAccess.Models.Auth
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FullName { get; set; }
    }
}
