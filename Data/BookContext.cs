using BookManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Data;

public class BookContext(DbContextOptions<BookContext> options) : DbContext(options)
{
    public DbSet<Book> Books => Set<Book>();
    public DbSet<Author> Authors => Set<Author>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>()
            .Property(a => a.Gender)
            .HasConversion<string>();
    }
}