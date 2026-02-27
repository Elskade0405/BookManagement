namespace BookManagement.Models;

public class Author
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required DateTime DateOfBirth { get; set; }
    public required Gender Gender { get; set; }
}