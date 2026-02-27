using System.ComponentModel.DataAnnotations;
using BookManagement.Models;

namespace BookManagement.DTOs;

public record AuthorDto
{
    [Required] public required int Id { get; set; }
    [Required][StringLength(100)] public required string Name { get; set; }
    [Required] public required DateTime DateOfBirth { get; set; }
    [Required] public required Gender Gender { get; set; }
}