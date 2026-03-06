using BookManagement.Data;
using BookManagement.DTOs;
using BookManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Services;

public class BookService(BookContext context) : IBookService
{
    public async Task<IEnumerable<Book>> GetBooksAsync()
    {
        return await context.Books.ToListAsync();
    }

    public async Task<Book?> GetBookAsync(int id)
    {
        return await context.Books.FindAsync(id);
    }

    public async Task<(bool IsSuccess, Book? Book, string ErrorMessage)> CreateBookAsync(AddBookDto bookDto)
    {
        var authorExists = await context.Authors.AnyAsync(a => a.Id == bookDto.AuthorId);
        if (!authorExists)
        {
            return (false, null, "Author not found");
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

        return (true, book, string.Empty);
    }

    public async Task<(bool IsSuccess, bool IsNotFound, string ErrorMessage)> UpdateBookAsync(int id, UpdateBookDto updatedBook)
    {
        var book = await context.Books.FindAsync(id);
        if (book == null)
        {
            return (false, true, string.Empty);
        }

        var authorExists = await context.Authors.AnyAsync(a => a.Id == updatedBook.AuthorId);
        if (!authorExists)
        {
            return (false, false, "Author not found");
        }

        var author = await context.Authors.FindAsync(updatedBook.AuthorId);
        book.Name = updatedBook.Name;
        book.Author = author!.Name;
        book.Publisher = updatedBook.Publisher;
        await context.SaveChangesAsync();

        return (true, false, string.Empty);
    }

    public async Task<bool> DeleteBookAsync(int id)
    {
        var book = await context.Books.FindAsync(id);
        if (book == null)
        {
            return false;
        }

        context.Books.Remove(book);
        await context.SaveChangesAsync();
        return true;
    }
}