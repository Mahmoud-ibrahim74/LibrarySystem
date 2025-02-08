using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Domain.DTOs.Request.Auth
{
    public class CreateRoleRequest
    {
        [Required(ErrorMessage = $"{nameof(name)} is Required")]
        public string name {  get; set; }
    }
}
