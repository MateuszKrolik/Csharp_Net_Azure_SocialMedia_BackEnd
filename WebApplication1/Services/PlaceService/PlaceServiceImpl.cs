using WebApplication1.DTO;
using WebApplication1.Models;
using WebApplication1.Services.CoordinatesService;

namespace WebApplication1.Services
{
    public class PlaceServiceImpl : IPlaceService
    {
        private readonly List<Place> _places;
        private readonly ICoordinatesService _coordinatesService;

        public PlaceServiceImpl(ICoordinatesService coordinatesService)
        {
            _coordinatesService = coordinatesService;
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

        public async Task AddPlace(Place place)
        {
            if (!string.IsNullOrEmpty(place.Address))
            {
                var geolocationResponse = await _coordinatesService.GetCoordinatesForAddressAsync(place.Address);
                if (geolocationResponse != null)
                {
                    var location = geolocationResponse;
                    place.Location = new Location(location.Lat, location.Lng);
                }
            }

            _places.Add(place);
        }

        public async Task UpdatePlace(string id, Place updatedPlace)
        {
            var place = _places.FirstOrDefault(p => p.Id == id);
            if (place != null)
            {
                place.Title = updatedPlace.Title ?? place.Title;
                place.Description = updatedPlace.Description ?? place.Description;
                place.Location = updatedPlace.Location ?? place.Location;
                place.Address = updatedPlace.Address ?? place.Address;
                place.Creator = updatedPlace.Creator ?? place.Creator;

                if (!string.IsNullOrEmpty(updatedPlace.Address))
                {
                    var geolocationResponse = await _coordinatesService.GetCoordinatesForAddressAsync(updatedPlace.Address);
                    if (geolocationResponse != null)
                    {
                        var location = geolocationResponse;
                        place.Location = new Location(location.Lat, location.Lng);
                    }
                }
            }
        }

        public void DeletePlace(string id)
        {
            var place = _places.FirstOrDefault(p => p.Id == id);
            if (place != null)
            {
                _places.Remove(place);
            }
        }
    }
}