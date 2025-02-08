using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Domain.DTOs.Request.Auth
{
    public class AuthLoginUserRequest
    {
        [Required(ErrorMessage = $"{nameof(UserName)} is Required")]
        public  string UserName { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = $"{nameof(Password)} is Required")]
        public  string Password { get; set; }

    }
}
