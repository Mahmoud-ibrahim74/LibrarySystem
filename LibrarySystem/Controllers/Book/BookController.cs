using LibrarySystem.Domain.DTOs.Request.Books;
using LibrarySystem.Services.IServices.Books;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static LibrarySystem.Domain.Constants.SD;

namespace LibrarySystem.Controllers.Book
{
    [Area(Modules.Auth)]
    [ApiController]
    [ApiExplorerSettings(GroupName = Modules.Book)]
    [Route("api/v1/")]
    [Authorize(Roles =Roles.Admin)]
    public class BookController(IBookService service) : ControllerBase
    {
        private readonly IBookService _service = service;


        [HttpGet(ApiRoutes.Books.GetAllBook)]
        [AllowAnonymous]    
        public async Task<IActionResult> GetAllBook([FromQuery]GetAllBooksFilteration model)
        {
            var response = await _service.GetAllBooks(model);
            if (response.Check)
            {

                return Ok(response);
            }
            else if (!response.Check)
                return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
            return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
        }
        [HttpGet(ApiRoutes.Books.GetBookById)]
        public async Task<IActionResult> GetBookById([FromRoute] int id)
        {
            var response = await _service.GetBookById(id);
            if (response.Check)
            {

                return Ok(response);
            }
            else if (!response.Check)
                return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
            return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
        }
        [HttpPost(ApiRoutes.Books.AddBook)]
        public async Task<IActionResult> AddBook([FromForm] CreateUpdateBookRequest model)
        {
            var response = await _service.CreateBook(model);
            if (response.Check)
                return Ok(response);
            else if (!response.Check)
                return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
            return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
        }

        [HttpPut(ApiRoutes.Books.UpdateBook)]
        public async Task<IActionResult> UpdateBook([FromRoute] int id, [FromForm] CreateUpdateBookRequest model)
        {
            var response = await _service.UpdateBook(id, model);
            if (response.Check)
                return Ok(response);
            else if (!response.Check)
                return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
            return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
        }

        [HttpDelete(ApiRoutes.Books.DeleteBook)]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            var response = await _service.DeleteBook(id);
            if (response.Check)
                return Ok(response);
            else if (!response.Check)
                return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
            return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
        }
    }
}