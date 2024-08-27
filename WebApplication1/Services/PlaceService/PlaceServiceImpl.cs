using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.DTO;
using WebApplication1.Models;
using WebApplication1.Services.CoordinatesService;

namespace WebApplication1.Services
{
    public class PlaceServiceImpl : IPlaceService
    {
        private readonly DataContext _context;
        private readonly ICoordinatesService _coordinatesService;

        public PlaceServiceImpl(DataContext context, ICoordinatesService coordinatesService)
        {
            _context = context;
            _coordinatesService = coordinatesService;
        }

        public async Task<List<Place>> GetPlaces()
        {
            return await _context.Places.ToListAsync();
        }

        public async Task AddPlace(Place place)
        {
            if (!string.IsNullOrEmpty(place.Address))
            {
                var geolocationResponse = await _coordinatesService.GetCoordinatesForAddressAsync(place.Address);
                if (geolocationResponse != null)
                {
                    var location = geolocationResponse;
                    place.PlaceLocation = new PlaceLocation(location.Lat, location.Lng);
                }
            }

            // _places.Add(place);
            _context.Places.Add(place);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePlace(string id, Place updatedPlace)
        {
            var place = await _context.Places.FindAsync(id);
            if (place != null)
            {
                place.Title = updatedPlace.Title ?? place.Title;
                place.Description = updatedPlace.Description ?? place.Description;
                place.PlaceLocation = updatedPlace.PlaceLocation ?? place.PlaceLocation;
                place.Address = updatedPlace.Address ?? place.Address;
                place.Creator = updatedPlace.Creator ?? place.Creator;

                if (!string.IsNullOrEmpty(updatedPlace.Address))
                {
                    var geolocationResponse = await _coordinatesService.GetCoordinatesForAddressAsync(updatedPlace.Address);
                    if (geolocationResponse != null)
                    {
                        var location = geolocationResponse;
                        place.PlaceLocation = new PlaceLocation(location.Lat, location.Lng);
                    }
                }
                _context.Places.Update(place);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeletePlace(string id)
        {
            var place = await _context.Places.FindAsync(id);
            if (place != null)
            {
                _context.Places.Remove(place);
                await _context.SaveChangesAsync();
            }
        }
    }
}