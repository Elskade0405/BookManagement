using BookManagement.DTOs;
using BookManagement.Models;

namespace BookManagement.Services;

public interface IAuthorService
{
    Task<IEnumerable<Author>> GetAuthorsAsync();
    Task<Author?> GetAuthorAsync(int id);
    Task<(bool IsSuccess, Author? Author, string ErrorMessage)> CreateAuthorAsync(AddAuthorDto authorDto);
    Task<(bool IsSuccess, bool IsNotFound, string ErrorMessage)> UpdateAuthorAsync(int id, UpdateAuthorDto updatedAuthor);
    Task<bool> DeleteAuthorAsync(int id);
}