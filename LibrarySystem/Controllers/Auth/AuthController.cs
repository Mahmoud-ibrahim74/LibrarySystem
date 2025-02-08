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
    [Authorize(Roles.Admin)]
    [Route("api/v1/")]
    public class AuthController(IAuthService service) : ControllerBase
    {
        private readonly IAuthService _service = service;

        [AllowAnonymous]
        [HttpPost(ApiRoutes.Users.LoginUser)]
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
        [AllowAnonymous]
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
        public async Task<IActionResult> DeleteUser(string id)
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
    }
}