using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTO
{
    public class PlaceUrlDTO
    {
        public PlaceUrlDTO() { }

        public PlaceUrlDTO(string? id, string? title, string? description, double? lat, double? lng, string? address, string? creator, string? imageUrl)
        {
            Id = id;
            Title = title;
            Description = description;
            Lat = lat;
            Lng = lng;
            Address = address;
            Creator = creator;
            ImageUrl = imageUrl;
        }

        public string? Id { get; set; }
        public string? Title { get; set; }
        [MinLength(5, ErrorMessage = "Description must be at least 5 characters")]
        public string? Description { get; set; }
        public double? Lat { get; set; }
        public double? Lng { get; set; }
        public string? Address { get; set; }
        public string? Creator { get; set; }
        public string? ImageUrl { get; set; }
    }
}