using LibrarySystem.DataAccess.Interfaces;
using LibrarySystem.Domain.DTOs.Request.Auth;
using LibrarySystem.Domain.DTOs.Response;
using LibrarySystem.Domain.DTOs.Response.Auth;
using LibrarySystem.Domain.Options;
using LibrarySystem.Services.IServices;
using LibrarySystemAPI.DataAccess.Context;
using LibrarySystemAPI.DataAccess.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static LibrarySystem.Domain.Constants.SD;

namespace LibrarySystem.Services.Services;

public class AuthService(IUnitOfWork unitOfWork,
                   JwtSettings jwt,
                   UserManager<ApplicationUser> userManager,
                   RoleManager<ApplicationRole> roleManager
                ) : IAuthService

{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly RoleManager<ApplicationRole> _roleManager = roleManager;
    private readonly JwtSettings _jwt = jwt;


    #region Authentication

    #region Users
    public async Task<Response<AuthLoginUserResponse>> LoginUserAsync(AuthLoginUserRequest model)
    {
        var normalizedUserName = _userManager.NormalizeName(model.UserName);
        var usernormalize = await _userManager.Users.SingleOrDefaultAsync(u => u.NormalizedUserName == normalizedUserName);
        var user = await _userManager.FindByNameAsync(model.UserName);
        var passwordValid = await _userManager.CheckPasswordAsync(user, model.Password);


        if (!passwordValid)
            return new()
            {
                Data = new()
                {
                    UserName = model.UserName
                },
                Msg = "user name or password incorrect",
                Check = false
            };



        var currentUserRoles = (await _userManager.GetRolesAsync(user)).ToList();

        var jwtSecurityToken = await CreateJwtToken(user);
        var result = new AuthLoginUserResponse
        {
            UserName = user.UserName!,
            Email = user.Email!,
            RoleNames = currentUserRoles,
            Token = "Bearer" + " " + new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
            ExpiresOn = jwtSecurityToken.ValidTo,


        };
        return new Response<AuthLoginUserResponse>
        {
            Check = true,
            Data = result,
            Error = string.Empty,
            Msg = string.Empty,
        };
    }
    private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
    {
        List<Claim> roleClaims = [];
        List<Claim> listOfUserClaims = [];

        var roles = (await _userManager.GetRolesAsync(user)).ToList();

        foreach (var role in roles)
        {
            var dd = await _roleManager.FindByNameAsync(role);

            var ddd = _roleManager.GetClaimsAsync(dd!).Result;
            roleClaims.AddRange(ddd);
        }

        var userClaims = _userManager.GetClaimsAsync(user!).Result;
        listOfUserClaims.AddRange(userClaims);

        for (int i = 0; i < roles.Count; i++)
            roleClaims.Add(new Claim(ClaimTypes.Role, roles[i]));

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName!),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(RequestClaims.UserId, user.Id.ToString()),
            new Claim(RequestClaims.Mobile,user.PhoneNumber),
            new Claim(RequestClaims.FullName,user.FullName),
            new Claim(RequestClaims.Email,user.Email),
        }.Union(roleClaims).Union(listOfUserClaims);

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.SecretKey));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

        return new JwtSecurityToken(
            issuer: _jwt.Issuer,
            claims: claims,
            expires: DateTime.UtcNow.AddDays(Shared.JwtExpirationDaysCount).Add(_jwt.TokenLifetime),
            signingCredentials: signingCredentials);
    }
    public async Task<Response<CreateUserResponse>> CreateUserAsync(CreateUserRequest model)
    {
        if (await _unitOfWork.Users.ExistAsync(x => x.UserName == model.user_name))
        {
            return new Response<CreateUserResponse>
            {
                Check = false,
                Msg = "User is exist",
                Data = null
            };
        }


        try
        {
            ApplicationUser user = new()
            {
                PhoneNumber = model.phone,
                FullName = model.full_name,
                Email = model.email,
                UserName = model.user_name,
            };

            var result = await _userManager.CreateAsync(user, model.password);
            if (!result.Succeeded)
            {
                return new Response<CreateUserResponse>
                {
                    Check = false,
                    Msg = string.Join(',', result.Errors.Select(e => e.Description)),
                    Data = null
                };
            }

            var token = await CreateJwtToken(user); // Implement this method if needed

            var response = new CreateUserResponse
            {
                FullName = model.full_name,
                Email = model.email,
                Token = "Bearer " + new JwtSecurityTokenHandler().WriteToken(token),
                UserName = model.user_name,
            };

            return new Response<CreateUserResponse>
            {
                Check = true,
                Data = response,
            };
        }
        catch (Exception ex)
        {
            return new()
            {
                Check = false,
                Data = null,
                Error = ex.InnerException != null ? ex.InnerException.ToString() : ex.Message
            };
        }

    }
    public async Task<Response<object>> GetAllUsers()
    {

        var totalRecords = await _unitOfWork.Users.CountAsync();


        // Perform the in-memory transformations
        var items = (await _unitOfWork.Users.GetAllAsync()).Select(x => new
        {
            x.Id,
            Phone = x.PhoneNumber,
            x.UserName,
            x.FullName,
            x.Email,
        }).ToList();

        return new()
        {
            Data = items,
            Check = true
        };
    }
    public async Task<Response<string>> DeleteUser(int id)
    {
        var obj = await _userManager.FindByIdAsync(id.ToString());

        if (obj == null)
        {
            return new()
            {
                Data = string.Empty,
                Msg = "User doesn't exist"
            };
        }

        _unitOfWork.Users.Remove(obj);
        await _unitOfWork.CompleteAsync();
        return new()
        {
            Check = true,
            Msg = "deleted sucessfully"
        };
    }
    #endregion

    #region Roles
    public async Task<Response<string>> CreateRole(string roleName)
    {
        var isExist = await _roleManager.RoleExistsAsync(roleName.ToLower());
        if (isExist)
            return new()
            {
                Check = false,
                Msg = "Role is exist"
            };

        var role = new ApplicationRole()
        {
            Name = roleName
        };
        var res = await _roleManager.CreateAsync(role);
        if (res.Succeeded)
            return new()
            {
                Msg = "Role Added Succesfully",
                Check = true,
            };
        return new()
        {
            Error = res.Errors.Select(x => x.Description).First(),
        };
    }
    public async Task<Response<IEnumerable<object>>> GetAllRolesAsync()
    {
        var result =
                await _unitOfWork.Roles.GetSpecificSelectAsync(null!,
                select: x => new
                {
                     x.Id,
                     x.Name
                }, orderBy: x =>
                  x.OrderByDescending(x => x.Id));

        if (!result.Any())
        {
            return new()
            {
                Data = [],
                Msg = "No Roles are found"
            };
        }
        return new()
        {
            Data = result,
            Check = true
        };
    }
    public async Task<Response<object>> UpdateRole(int id,UpdateRole model)
    {
        var role = await _roleManager.FindByIdAsync(id.ToString());
        if (role is null)
            return new()
            {
                Check = false,
                Msg = "Role doesn't exist"
            };
        role.Name = model.name;
        var res = await _roleManager.UpdateAsync(role);
        if (res.Succeeded)
            return new()
            {
                Msg = "Role updated Succesfully",
                Check = true,
            };
        return new()
        {
            Error = res.Errors.Select(x => x.Description).First(),
        };
    }
    public async Task<Response<string>> DeleteRole(int id)
    {
        var role = await _roleManager.FindByIdAsync(id.ToString());
        if (role is null)
            return new()
            {
                Check = false,
                Msg = "Role doesn't exist"
            };
        var res = await _roleManager.DeleteAsync(role);
        if (res.Succeeded)
            return new()
            {
                Msg = "Role deleted Succesfully",
                Check = true,
            };
        return new()
        {
            Error = res.Errors.Select(x => x.Description).First(),
        };
    }
    #endregion

    #region UsersRoles
    public async Task<Response<string>> CreateUserRole(CreateUserRoleRequest model)
    {
        var role = await _roleManager.FindByIdAsync(model.RoleId.ToString());
        if (role is null)
            return new()
            {
                Check = false,
                Msg = "Role doesn't exist"
            };
        var user = await _userManager.FindByIdAsync(model.UserId.ToString());
        if (user is null)
            return new()
            {
                Check = false,
                Msg = "user doesn't exist"
            };

        var res = await _userManager.AddToRoleAsync(user, role?.Name);
        if (res.Succeeded)
            return new()
            {
                Msg = "UserRole Added Succesfully",
                Check = true,
            };
        return new()
        {
            Error = res.Errors.Select(x => x.Description).First(),
        };


    }
    public async Task<Response<string>> DeleteUserRole(CreateUserRoleRequest model)
    {
        var role = await _roleManager.FindByIdAsync(model.RoleId.ToString());
        if (role is null)
            return new()
            {
                Check = false,
                Msg = "Role doesn't exist"
            };
        var user = await _userManager.FindByIdAsync(model.UserId.ToString());
        if (user is null)
            return new()
            {
                Check = false,
                Msg = "user doesn't exist"
            };

        var res = await _userManager.RemoveFromRoleAsync(user, role?.Name);
        if (res.Succeeded)
            return new()
            {
                Msg = "UserRole deleted Succesfully",
                Check = true,
            };
        return new()
        {
            Error = res.Errors.Select(x => x.Description).First(),
        };
    }
    #endregion


    #endregion
}
