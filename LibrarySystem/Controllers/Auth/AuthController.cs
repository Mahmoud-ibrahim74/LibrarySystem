using LibrarySystem.Domain.DTOs.Request.Auth;
using LibrarySystem.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static LibrarySystem.Domain.Constants.SD;

namespace LibrarySystem.Controllers.Auth
{
    [Area(Modules.Auth)]
    [ApiController]
    [ApiExplorerSettings(GroupName = Modules.Auth)]
    [Authorize(Roles =Roles.Admin)]
    [Route("api/v1/")]
    public class AuthController(IAuthService service) : ControllerBase
    {
        private readonly IAuthService _service = service;

        
        [HttpPost(ApiRoutes.Users.LoginUser)]
        [AllowAnonymous]
        public async Task<IActionResult> LoginUserAsync(AuthLoginUserRequest model)
        {
            var response = await _service.LoginUserAsync(model);
            if (response.Check)
            {

                return Ok(response);
            }
            else if (!response.Check)
                return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
            return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
        }
        [HttpPost(ApiRoutes.Users.AddUser)]
        public async Task<IActionResult> CreateUser(CreateUserRequest model)
        {
            var response = await _service.CreateUserAsync(model);
            if (response.Check)
                return Ok(response);
            else if (!response.Check)
                return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
            return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
        }

        [HttpDelete(ApiRoutes.Users.DeleteUser)]
        public async Task<IActionResult> DeleteUser([FromRoute]int id)
        {
            var response = await _service.DeleteUser(id);
            if (response.Check)
                return Ok(response);
            else if (!response.Check)
                return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
            return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
        }
        [HttpGet(ApiRoutes.Users.GetAllUsers)]
        public async Task<IActionResult> GetAllUsers()
        {
            var response = await _service.GetAllUsers();
            if (response.Check)
                return Ok(response);
            else if (!response.Check)
                return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
            return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
        }

        [HttpPost(ApiRoutes.Roles.AddRole)]
        
        public async Task<IActionResult> AddRole(CreateRoleRequest model)
        {
            var response = await _service.CreateRole(model.name);
            if (response.Check)
                return Ok(response);
            else if (!response.Check)
                return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
            return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
        }
        [HttpGet(ApiRoutes.Roles.GetAllRoles)]
        public async Task<IActionResult> GetAllRoles()
        {
            var response = await _service.GetAllRolesAsync();
            if (response.Check)
                return Ok(response);
            else if (!response.Check)
                return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
            return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
        }
        [HttpPut(ApiRoutes.Roles.UpdateRole)]
        public async Task<IActionResult> UpdateRole([FromRoute] int id, [FromForm] UpdateRole model)
        {
            var response = await _service.UpdateRole(id,model);
            if (response.Check)
                return Ok(response);
            else if (!response.Check)
                return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
            return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
        }
        [HttpDelete(ApiRoutes.Roles.DeleteRole)]
        public async Task<IActionResult> DeleteRole([FromRoute] int id)
        {
            var response = await _service.DeleteRole(id);
            if (response.Check)
                return Ok(response);
            else if (!response.Check)
                return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
            return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
        }


        [HttpPost(ApiRoutes.UserRoles.AddUserRole)]
        
        public async Task<IActionResult> AddUserRole(CreateUserRoleRequest model)
        {
            var response = await _service.CreateUserRole(model);
            if (response.Check)
                return Ok(response);
            else if (!response.Check)
                return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
            return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
        }
        [HttpDelete(ApiRoutes.UserRoles.DeleteUserRole)]
        public async Task<IActionResult> DeleteUserRole(CreateUserRoleRequest model)
        {
            var response = await _service.DeleteUserRole(model);
            if (response.Check)
                return Ok(response);
            else if (!response.Check)
                return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
            return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
        }
    }
}