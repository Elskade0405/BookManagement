using System.ComponentModel.DataAnnotations;

namespace BookManagement.DTOs;

public record UpdateBookDto
{
    [Required] public required string Name { get; set; }
    [Required] public required string Author { get; set; }
    [Required] public required string Publisher { get; set; }
}