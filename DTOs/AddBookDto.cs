using System.ComponentModel.DataAnnotations;

namespace BookManagement.DTOs;

public record AddBookDto
{
    [Required] public string Name { get; set; }
    [Required] public string Author { get; set; }
    [Required] public string Publisher { get; set; }
}