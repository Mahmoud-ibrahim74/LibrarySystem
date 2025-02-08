using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Domain.DTOs.Request.Auth
{
    public class CreateUserRequest
    {
        [Required(ErrorMessage = $"{nameof(user_name)} is Required")]
        public string user_name { get; set; }
        [Required(ErrorMessage = $"{nameof(password)} is Required")]
        public string password { get; set; }
        [Required(ErrorMessage = $"{nameof(phone)} is Required")]
        public  string phone { get; set; }
        [Required(ErrorMessage = $"{nameof(email)} is Required")]
        public string email { get; set; }
        [Required(ErrorMessage = $"{nameof(full_name)} is Required")]
        public string full_name { get; set; }
    }
}
