using System.ComponentModel.DataAnnotations;
using BookManagement.Models;

namespace BookManagement.DTOs;

public record AddAuthorDto
{
    [Required][StringLength(100)] public required string Name { get; set; }
    [Required] public required DateOnly DateOfBirth { get; set; }
    [Required] public required Gender Gender { get; set; }
}