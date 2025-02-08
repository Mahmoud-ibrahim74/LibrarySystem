namespace LibrarySystem.Domain.DTOs.Response.Auth
{
    public class CreateUserResponse
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Token { get; set; }
    }
}
