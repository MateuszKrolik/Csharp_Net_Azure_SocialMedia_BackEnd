using System;
using WebApplication1.Models;

namespace WebApplication1.Services;

public class PlaceServiceImpl : IPlaceService
{
    private readonly List<Place> _places;

    public PlaceServiceImpl()
    {
        _places = new List<Place>
            {
                new Place(
                    id: "p1",
                    title: "Place 1",
                    description: "Description 1",
                    location: new Location(40.7128, -74.0060),
                    address: "123 Main St, New York, NY",
                    creator: "u1"
                ),
                new Place(
                    id: "p2",
                    title: "Place 2",
                    description: "Description 2",
                    location: new Location(34.0522, -118.2437),
                    address: "456 Elm St, Los Angeles, CA",
                    creator: "u1"
                ),
                new Place(
                    id: "p3",
                    title: "Place 3",
                    description: "Description 3",
                    location: new Location(51.5074, -0.1278),
                    address: "789 Oak St, London, UK",
                    creator: "u3"
                )
            };
    }

    public List<Place> GetPlaces()
    {
        return _places;
    }
}
