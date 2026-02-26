using System.ComponentModel.DataAnnotations;

namespace BookManagement.DTOs;

public record BookDto
{
    [Required] public required int Id { get; set; }
    [Required] public required string Name { get; set; }
    [Required] public required string Author { get; set; }
    [Required] public required string Publisher { get; set; }
}
