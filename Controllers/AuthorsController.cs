using BookManagement.Data;
using BookManagement.DTOs;
using BookManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BookManagement.Controllers;

[ApiController]
[Route("authors")]
public class AuthorsController(BookContext context, ILogger<AuthorsController> logger) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetAuthors()
    {
        logger.LogInformation("Đang lấy danh sách tác giả");
        return Ok(await context.Authors.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAuthor(int id)
    {
        var author = await context.Authors.FindAsync(id);
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
        try
        {
            var author = new Author
            {
                Name = authorDto.Name,
                DateOfBirth = new DateTime(authorDto.DateOfBirth, new TimeOnly(0, 0)),
                Gender = authorDto.Gender
            };
            context.Authors.Add(author);
            await context.SaveChangesAsync();
            return Created($"/authors/{author.Id}", author);
        }
        catch (Exception ex)
        {
            logger.LogError("Không thể thêm tác giả", ex);
            return BadRequest(new { title = "Không thể thêm tác giả", detail = ex.Message, statusCode = 400 });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAuthor(int id, [FromBody] UpdateAuthorDto authorDto)
    {
        var author = await context.Authors.FindAsync(id);
        if (author == null)
        {
            logger.LogInformation("Không tìm thấy tác giả");
            return NotFound();
        }
        author.Name = authorDto.Name;
        author.DateOfBirth = new DateTime(authorDto.DateOfBirth, new TimeOnly(0, 0));
        author.Gender = authorDto.Gender;
        await context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAuthor(int id)
    {
        var author = await context.Authors.FindAsync(id);
        if (author == null)
        {
            logger.LogInformation("Không tìm thấy tác giả");
            return NotFound();
        }
        context.Authors.Remove(author);
        await context.SaveChangesAsync();
        return NoContent();
    }
}
