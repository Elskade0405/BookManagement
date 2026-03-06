using BookManagement.DTOs;
using BookManagement.Models;

namespace BookManagement.Services;

public interface IBookService
{
    Task<IEnumerable<Book>> GetBooksAsync();
    Task<Book?> GetBookAsync(int id);
    Task<(bool IsSuccess, Book? Book, string ErrorMessage)> CreateBookAsync(AddBookDto bookDto);
    Task<(bool IsSuccess, bool IsNotFound, string ErrorMessage)> UpdateBookAsync(int id, UpdateBookDto updatedBook);
    Task<bool> DeleteBookAsync(int id);
}
