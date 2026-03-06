using BookManagement.Data;
using BookManagement.DTOs;
using BookManagement.Models;
using BookManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BookManagement.Controllers;

[ApiController]
[Route("authors")]
public class AuthorsController(IAuthorService authorService, ILogger<AuthorsController> logger) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetAuthors()
    {
        logger.LogInformation("Đang lấy danh sách tác giả");
        var authors = await authorService.GetAuthorsAsync();
        return Ok(authors);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAuthor(int id)
    {
        var author = await authorService.GetAuthorAsync(id);
        if (author != null)
        {
            logger.LogInformation("Đang lấy dữ liệu của tác giả");
            return Ok(author);
        }
        return NotFound(new { title = "Không tìm thấy tác giả", detail = "Không tìm thấy tác giả", statusCode = 404 });
    }

    [HttpPost]
    public async Task<IActionResult> CreateAuthor([FromBody] AddAuthorDto authorDto)
    {
        var result = await authorService.CreateAuthorAsync(authorDto);
        if (!result.IsSuccess)
        {
            logger.LogError("Không thể thêm tác giả", result.ErrorMessage);
            return BadRequest(new { title = "Không thể thêm tác giả", detail = result.ErrorMessage, statusCode = 400 });
        }

        return Created($"/authors/{result.Author!.Id}", result.Author);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAuthor(int id, [FromBody] UpdateAuthorDto authorDto)
    {
        var result = await authorService.UpdateAuthorAsync(id, authorDto);
        if (result.IsNotFound)
        {
            logger.LogInformation("Không tìm thấy tác giả");
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAuthor(int id)
    {
        var success = await authorService.DeleteAuthorAsync(id);
        if (!success)
        {
            logger.LogInformation("Không tìm thấy tác giả");
            return NotFound();
        }

        return NoContent();
    }
}
