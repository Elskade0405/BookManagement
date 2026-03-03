using System.ComponentModel.DataAnnotations;

namespace BookManagement.DTOs;

public record BookDto(
    [Required] int Id,
    [Required][StringLength(100)] string Name,
    [Required] string Author,
    [Required] string Publisher,
    [Required] int AuthorId
);
