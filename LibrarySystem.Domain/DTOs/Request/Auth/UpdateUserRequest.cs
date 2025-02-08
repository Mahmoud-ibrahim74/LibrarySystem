using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Domain.DTOs.Request.Auth
{
    public class UpdateUserRequest
    {
        public required string user_name { get; set; }
        public string? password { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string full_name { get; set; }
    }
}
