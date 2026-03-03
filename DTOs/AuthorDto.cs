using System.ComponentModel.DataAnnotations;
using BookManagement.Models;

namespace BookManagement.DTOs;

public record AuthorDto(
    [Required] int Id,
    [Required][StringLength(100)] string Name,
    [Required] DateTime DateOfBirth,
    [Required] Gender Gender
);