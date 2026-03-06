using BookManagement.Data;
using BookManagement.DTOs;
using BookManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Services;

public class AuthorService(BookContext context) : IAuthorService
{
    public async Task<IEnumerable<Author>> GetAuthorsAsync()
    {
        return await context.Authors.ToListAsync();
    }

    public async Task<Author?> GetAuthorAsync(int id)
    {
        return await context.Authors.FindAsync(id);
    }

    public async Task<(bool IsSuccess, Author? Author, string ErrorMessage)> CreateAuthorAsync(AddAuthorDto authorDto)
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
            return (true, author, string.Empty);
        }
        catch (Exception ex)
        {
            return (false, null, ex.Message);
        }
    }

    public async Task<(bool IsSuccess, bool IsNotFound, string ErrorMessage)> UpdateAuthorAsync(int id, UpdateAuthorDto updatedAuthor)
    {
        var author = await context.Authors.FindAsync(id);
        if (author == null)
        {
            return (false, true, string.Empty);
        }
        author.Name = updatedAuthor.Name;
        author.DateOfBirth = new DateTime(updatedAuthor.DateOfBirth, new TimeOnly(0, 0));
        author.Gender = updatedAuthor.Gender;
        await context.SaveChangesAsync();
        return (true, false, string.Empty);
    }

    public async Task<bool> DeleteAuthorAsync(int id)
    {
        var author = await context.Authors.FindAsync(id);
        if (author == null)
        {
            return false;
        }
        context.Authors.Remove(author);
        await context.SaveChangesAsync();
        return true;
    }
}