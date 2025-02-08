using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySystemAPI.DataAccess.Models.Auth;
[Table("Auth_RefreshTokens")]
public class AuthRefreshToken
{
    [Key]
    public int Id { get; set; }
    public string Token { get; set; } = string.Empty;
    public DateTime ExpiresOn { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime? RevokedOn { get; set; }
    public string User_Id { get; set; } = string.Empty;
    [ForeignKey(nameof(User_Id))]
    public ApplicationUser User { get; set; } = default!;
}
