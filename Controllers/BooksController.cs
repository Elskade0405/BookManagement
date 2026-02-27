using BookManagement.Data;
using BookManagement.DTOs;
using BookManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BookManagement.Controllers;

[ApiController]
[Route("books")]
public class BooksController(BookContext context, ILogger<BooksController> logger) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetBooks()
    {
        logger.LogInformation("Đang lấy danh sách sách");
        return Ok(await context.Books.ToListAsync());
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetBook(int id)
    {
        var book = await context.Books.FindAsync(id);
        if (book == null)
        {
            logger.LogInformation("Không tìm thấy sách");
            return NotFound();
        }
        return Ok(book);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBook([FromBody] AddBookDto bookDto)
    {
        var authorExists = await context.Authors.AnyAsync(a => a.Id == bookDto.AuthorId);
        if (!authorExists)
        {
            logger.LogInformation("Không tìm thấy tác giả");
            return NotFound(new { error = "Author not found" });
        }
        var author = await context.Authors.FindAsync(bookDto.AuthorId);
        var book = new Book
        {
            Name = bookDto.Name,
            Author = author!.Name,
            Publisher = bookDto.Publisher
        };
        context.Books.Add(book);
        await context.SaveChangesAsync();
        return Created($"/books/{book.Id}", book);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBook(int id, [FromBody] UpdateBookDto updatedBook)
    {
        var book = await context.Books.FindAsync(id);
        if (book == null)
        {
            logger.LogInformation("Không tìm thấy sách");
            return NotFound();
        }
        var authorExists = await context.Authors.AnyAsync(a => a.Id == updatedBook.AuthorId);
        if (!authorExists)
        {
            logger.LogInformation("Không tìm thấy tác giả");
            return BadRequest(new { error = "Author not found" });
        }
        var author = await context.Authors.FindAsync(updatedBook.AuthorId);
        book.Name = updatedBook.Name;
        book.Author = author!.Name;
        book.Publisher = updatedBook.Publisher;
        await context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var book = await context.Books.FindAsync(id);
        if (book == null)
        {
            logger.LogInformation("Không tìm thấy sách");
            return NotFound();
        }
        logger.LogInformation("Đã xóa sách");
        context.Books.Remove(book);
        await context.SaveChangesAsync();
        return NoContent();
    }
}
