using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Place
{
    public Place() { }
    public Place(string? id, string? title, string? description, PlaceLocation placeLocation, string? address, string? creator, string? imageUrl)
    {
        Id = id ?? Guid.NewGuid().ToString(); // gen uuid4 if id is null
        Title = title;
        Description = description;
        PlaceLocation = placeLocation;
        Address = address;
        Creator = creator;
        ImageUrl = imageUrl;
    }

    public string? Id { get; set; }
    [Required(ErrorMessage = "Title is required")]
    public string? Title { get; set; }
    [MinLength(5, ErrorMessage = "Description must be at least 5 characters")]
    public string? Description { get; set; }
    public PlaceLocation? PlaceLocation { get; set; }
    [Required(ErrorMessage = "Address is required")]
    public string? Address { get; set; }
    public string? Creator { get; set; }
    public string? ImageUrl { get; set; }
}
