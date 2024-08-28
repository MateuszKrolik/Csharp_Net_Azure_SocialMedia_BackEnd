using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.DTO;
using WebApplication1.Models;
using WebApplication1.Services.CoordinatesService;
using WebApplication1.Services.ImageService;

namespace WebApplication1.Services
{
    public class PlaceServiceImpl : IPlaceService
    {
        private readonly DataContext _context;
        private readonly ICoordinatesService _coordinatesService;
        private readonly IImageService _imageService;

        public PlaceServiceImpl(DataContext context, ICoordinatesService coordinatesService, IImageService imageService)
        {
            _context = context;
            _coordinatesService = coordinatesService;
            _imageService = imageService;
        }

        public async Task<List<Place>> GetPlaces()
        {
            return await _context.Places.ToListAsync();
        }

        public async Task AddPlace(Place place, IFormFile? image)
        {
            if (image != null)
            {
                string uniqueFileName = Guid.NewGuid().ToString();
                using var fileStream = image.OpenReadStream();
                var imageUrl = await _imageService.UploadImageAsync(uniqueFileName, fileStream, image.ContentType);
                place.ImageUrl = imageUrl;
            }

            if (!string.IsNullOrEmpty(place.Address))
            {
                var geolocationResponse = await _coordinatesService.GetCoordinatesForAddressAsync(place.Address);
                if (geolocationResponse != null)
                {
                    var location = geolocationResponse;
                    place.PlaceLocation = new PlaceLocation(location.Lat, location.Lng);
                }
            }

            _context.Places.Add(place);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePlace(string id, Place updatedPlace, IFormFile? image)
        {
            var place = await _context.Places.FindAsync(id);
            if (place != null)
            {
                place.Title = updatedPlace.Title ?? place.Title;
                place.Description = updatedPlace.Description ?? place.Description;
                place.PlaceLocation = updatedPlace.PlaceLocation ?? place.PlaceLocation;
                place.Address = updatedPlace.Address ?? place.Address;
                place.Creator = updatedPlace.Creator ?? place.Creator;
                place.ImageUrl = updatedPlace.ImageUrl ?? place.ImageUrl;

                if (image != null)
                {
                    // unlink existing image
                    if (!string.IsNullOrEmpty(place.ImageUrl))
                    {
                        var oldImageName = new Uri(place.ImageUrl).Segments.Last();
                        await _imageService.DeleteImageAsync(oldImageName);
                    }
                    // upload new image
                    string uniqueFileName = Guid.NewGuid().ToString();
                    using var fileStream = image.OpenReadStream();
                    var imageUrl = await _imageService.UploadImageAsync(uniqueFileName, fileStream, image.ContentType);
                    place.ImageUrl = imageUrl;
                }

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
                // unlink existing image
                if (!string.IsNullOrEmpty(place.ImageUrl))
                {
                    var oldImageName = new Uri(place.ImageUrl).Segments.Last();
                    await _imageService.DeleteImageAsync(oldImageName);
                }

                _context.Places.Remove(place);
                await _context.SaveChangesAsync();
            }
        }
    }
}