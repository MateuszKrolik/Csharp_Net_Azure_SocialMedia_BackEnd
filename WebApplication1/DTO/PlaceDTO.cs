using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTO
{
    public class PlaceDTO
    {
        public PlaceDTO() { }

        public PlaceDTO(string? title, string? description, string? address, IFormFile? image)
        {
            Title = title;
            Description = description;
            Address = address;
            Image = image;
        }

        public string? Title { get; set; }
        [MinLength(5, ErrorMessage = "Description must be at least 5 characters")]
        public string? Description { get; set; }
        public string? Address { get; set; }
        public IFormFile? Image { get; set; }
    }
}