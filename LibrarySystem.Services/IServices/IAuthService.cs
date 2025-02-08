using LibrarySystem.Domain.DTOs.Request.Auth;
using LibrarySystem.Domain.DTOs.Response;
using LibrarySystem.Domain.DTOs.Response.Auth;
using LibrarySystemAPI.DataAccess.Models.Auth;
using Microsoft.AspNetCore.Identity;
namespace LibrarySystem.Services.IServices;

public interface IAuthService
{
    public Task<Response<AuthLoginUserResponse>> LoginUserAsync(AuthLoginUserRequest model);
    public Task<Response<CreateUserResponse>> CreateUserAsync(CreateUserRequest model);
    public Task<Response<object>> GetAllUsers();
    public Task<Response<string>> DeleteUser(int id);


    #region Roles
    public Task<Response<string>> CreateRole(string roleName);
    public Task<Response<IEnumerable<object>>> GetAllRolesAsync();
    public Task<Response<object>> UpdateRole(int id, UpdateRole model);
    public Task<Response<string>> DeleteRole(int id);
    #endregion

    #region UsersRoles
    public Task<Response<string>> CreateUserRole(CreateUserRoleRequest model);
    public Task<Response<string>> DeleteUserRole(CreateUserRoleRequest model);
    #endregion

}
