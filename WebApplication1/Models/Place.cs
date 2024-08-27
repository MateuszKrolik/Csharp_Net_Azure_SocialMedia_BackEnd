using System;

namespace WebApplication1.Models;

public class Place
{
    public Place(string? id, string? title, string? description, Location location, string? address, string? creator)
    {
        Id = id ?? Guid.NewGuid().ToString(); // gen uuid4 if id is null
        Title = title;
        Description = description;
        Location = location;
        Address = address;
        Creator = creator;
    }

    public string? Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }

    public Location Location { get; set; }

    public string? Address { get; set; }

    public string? Creator { get; set; }


}
