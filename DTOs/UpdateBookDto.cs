using System.ComponentModel.DataAnnotations;

namespace BookManagement.DTOs;

public record UpdateBookDto(
    [Required][StringLength(100)] string Name,
    [Required] string Publisher,
    [Required] int AuthorId
);