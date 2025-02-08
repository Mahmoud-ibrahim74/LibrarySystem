namespace LibrarySystem.Domain.DTOs.Request.Auth
{
    public class CreateUserRoleRequest
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
