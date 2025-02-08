using LibrarySystem.Domain.DTOs.Request.Auth;
using LibrarySystem.Domain.DTOs.Response;
using LibrarySystem.Domain.DTOs.Response.Auth;
namespace LibrarySystem.Services.IServices;

public interface IAuthService
{
    public Task<Response<AuthLoginUserResponse>> LoginUserAsync(AuthLoginUserRequest model);
    public Task<Response<CreateUserResponse>> CreateUserAsync(CreateUserRequest model);
    public Task<Response<object>> GetAllUsers();
    public Task<Response<string>> DeleteUser(string id);


}
