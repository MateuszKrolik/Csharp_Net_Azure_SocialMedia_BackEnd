using System.Security.Claims;
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
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string? _containerName;

        public PlaceServiceImpl(DataContext context, ICoordinatesService coordinatesService, IImageService imageService, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _context = context;
            _coordinatesService = coordinatesService;
            _imageService = imageService;
            _httpContextAccessor = httpContextAccessor;
            _containerName = configuration["AzureBlobStorage:PlacesContainerName"];
        }

        public async Task<List<Place>> GetPlaces()
        {
            return await _context.Places.ToListAsync();
        }

        public async Task<List<Place>> GetPagedPlaces(int pageNumber, int pageSize)
        {
            return await _context.Places
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<int> GetPlacesCount()
        {
            return await _context.Places.CountAsync();
        }

        public async Task<int> GetPlacesCountByUserId(string userId)
        {
            return await _context.Places.CountAsync(p => p.Creator == userId);
        }

        public async Task<List<Place>> GetPagedPlacesByUserId(string userId, int pageNumber, int pageSize)
        {
            return await _context.Places
                .Where(p => p.Creator == userId)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task AddPlace(Place place, IFormFile? image)
        {
            if (_httpContextAccessor.HttpContext != null)
            {
                var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                place.Creator = userId; // assign logged in user as creator
            }

            if (image != null && _containerName != null)
            {
                string uniqueFileName = Guid.NewGuid().ToString();
                using var fileStream = image.OpenReadStream();
                var imageUrl = await _imageService.UploadImageAsync(_containerName, uniqueFileName, fileStream, image.ContentType);
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
                if (_httpContextAccessor.HttpContext != null)
                {
                    var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    // check if logged in user owns the place
                    if (place.Creator == userId)
                    {
                        place.Title = updatedPlace.Title ?? place.Title;
                        place.Description = updatedPlace.Description ?? place.Description;
                        place.PlaceLocation = updatedPlace.PlaceLocation ?? place.PlaceLocation;
                        place.Address = updatedPlace.Address ?? place.Address;
                        place.Creator = updatedPlace.Creator ?? place.Creator;
                        place.ImageUrl = updatedPlace.ImageUrl ?? place.ImageUrl;
                        if (image != null && _containerName != null)
                        {
                            // unlink existing image
                            if (!string.IsNullOrEmpty(place.ImageUrl))
                            {
                                var oldImageName = new Uri(place.ImageUrl).Segments.Last();
                                await _imageService.DeleteImageAsync(_containerName, oldImageName);
                            }
                            // upload new image
                            string uniqueFileName = Guid.NewGuid().ToString();
                            using var fileStream = image.OpenReadStream();
                            var imageUrl = await _imageService.UploadImageAsync(_containerName, uniqueFileName, fileStream, image.ContentType);
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
                    else
                    {
                        throw new UnauthorizedAccessException();
                    }
                }

            }
        }

        public async Task DeletePlace(string id)
        {
            var place = await _context.Places.FindAsync(id);
            if (place != null)
            {
                if (_httpContextAccessor.HttpContext != null)
                {
                    var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    // check if logged in user owns the place
                    if (place.Creator == userId)
                    {
                        // unlink existing image
                        if (!string.IsNullOrEmpty(place.ImageUrl) && _containerName != null)
                        {
                            var oldImageName = new Uri(place.ImageUrl).Segments.Last();
                            await _imageService.DeleteImageAsync(_containerName, oldImageName);
                        }
                        _context.Places.Remove(place);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        throw new UnauthorizedAccessException();
                    }
                }

            }
        }
    }
}