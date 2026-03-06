using BookManagement.Data;
using BookManagement.DTOs;
using BookManagement.Models;
using BookManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BookManagement.Controllers;

[ApiController]
[Route("books")]
public class BooksController(IBookService bookService, ILogger<BooksController> logger) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetBooks()
    {
        logger.LogInformation("Đang lấy danh sách sách");
        var books = await bookService.GetBooksAsync();
        return Ok(books);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetBook(int id)
    {
        var book = await bookService.GetBookAsync(id);
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
        var result = await bookService.CreateBookAsync(bookDto);
        if (!result.IsSuccess)
        {
            logger.LogInformation("Không tìm thấy tác giả");
            return NotFound(new { error = result.ErrorMessage });
        }

        return Created($"/books/{result.Book!.Id}", result.Book);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBook(int id, [FromBody] UpdateBookDto updatedBook)
    {
        var result = await bookService.UpdateBookAsync(id, updatedBook);
        if (result.IsNotFound)
        {
            logger.LogInformation("Không tìm thấy sách");
            return NotFound();
        }

        if (!result.IsSuccess)
        {
            logger.LogInformation("Không tìm thấy tác giả");
            return BadRequest(new { error = result.ErrorMessage });
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var success = await bookService.DeleteBookAsync(id);
        if (!success)
        {
            logger.LogInformation("Không tìm thấy sách");
            return NotFound();
        }
        logger.LogInformation("Đã xóa sách");
        return NoContent();
    }
}
