using System;
using System.ComponentModel.DataAnnotations;
using WebApplication1.DTO;

namespace WebApplication1.Models;

public class Place
{
    public Place() { }
    public Place(string? id, string? title, string? description, Location location, string? address, string? creator)
    {
        Id = id ?? Guid.NewGuid().ToString(); // gen uuid4 if id is null
        // validate required title 
        Title = title;
        Description = description;
        Location = location;
        Address = address;
        Creator = creator;
    }

    public string? Id { get; set; }
    [Required(ErrorMessage = "Title is required")]
    public string? Title { get; set; }
    [MinLength(5, ErrorMessage = "Description must be at least 5 characters")]
    public string? Description { get; set; }
    public Location? Location { get; set; }
    [Required(ErrorMessage = "Address is required")]
    public string? Address { get; set; }

    public string? Creator { get; set; }
}