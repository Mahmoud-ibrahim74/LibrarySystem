using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Domain.DTOs.Request.Auth
{
    public class AuthLoginUserRequest
    {
        [DefaultValue("admin")]
        public required string UserName { get; set; }
        [DataType(DataType.Password)]
        [DefaultValue("123456")]
        public required string Password { get; set; }

    }
}
