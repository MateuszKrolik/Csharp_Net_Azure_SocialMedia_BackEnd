using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public record PlaceDTO(
    string? Id,
    string? Title,
    [MinLength(5, ErrorMessage = "Description must be at least 5 characters")] string? Description,
    double? Lat,
    double? Lng,
    string? Address,
    string? Creator,
    IFormFile? Image
);