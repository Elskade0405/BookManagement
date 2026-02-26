using System.ComponentModel.DataAnnotations;

namespace BookManagement.DTOs;

public record BookDto
{
    [Required] public int Id { get; set; }
    [Required] public string Name { get; set; }
    [Required] public string Author { get; set; }
    [Required] public string Publisher { get; set; }
}
