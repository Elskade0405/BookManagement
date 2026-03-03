using System.ComponentModel.DataAnnotations;
using BookManagement.Models;

namespace BookManagement.DTOs;

public record UpdateAuthorDto(
    [Required][StringLength(100)] string Name,
    [Required] DateOnly DateOfBirth,
    [Required] Gender Gender
);
