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
    [Authorize(Roles = Roles.User)]
    public class BorrowedBookController(IBorrowedBookService service) : ControllerBase
    {
        private readonly IBorrowedBookService _service = service;


        [HttpGet(ApiRoutes.BorrowedBook.GetAllBorrowedBook)]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllBorrowedBook()
        {
            var response = await _service.GetAllBorrowedBooksForLoggedUser();
            if (response.Check)
                return Ok(response);

            else if (!response.Check)
                return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
            return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
        }
        [HttpPost(ApiRoutes.BorrowedBook.AddBorrowedBook)]
        public async Task<IActionResult> AddBorrowedBook([FromRoute] int bookId)
        {
            var response = await _service.CreateBorrowedBook(bookId);
            if (response.Check)
                return Ok(response);
            else if (!response.Check)
                return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
            return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
        }

        [HttpPut(ApiRoutes.BorrowedBook.ReturnBorrowedBook)]
        public async Task<IActionResult> ReturnBorrowedBook([FromRoute] int id)
        {
            var response = await _service.ReturnBorrowedBook(id);
            if (response.Check)
                return Ok(response);
            else if (!response.Check)
                return StatusCode(statusCode: StatusCodes.Status400BadRequest, response);
            return StatusCode(statusCode: StatusCodes.Status500InternalServerError, response);
        }
    }
}