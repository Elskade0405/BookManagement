using System.ComponentModel.DataAnnotations;

namespace BookManagement.DTOs;

public record BookDto
{
    [Required] public required int Id;
    [Required][StringLength(100)] public required string Name;
    [Required] public required string Author;
    [Required] public required string Publisher;
    [Required] public required int AuthorId;
}
