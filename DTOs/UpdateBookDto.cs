using System.ComponentModel.DataAnnotations;

namespace BookManagement.DTOs;

public record UpdateBookDto
{
    [Required][StringLength(100)] public required string Name { get; set; }
    [Required] public required string Publisher { get; set; }
    [Required] public required int AuthorId { get; set; }
}