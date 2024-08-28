using System;
using WebApplication1.Models;

namespace WebApplication1.Services;

public interface IPlaceService
{
    public Task<List<Place>> GetPlaces();

    public Task<int> GetPlacesCount();

    public Task<List<Place>> GetPagedPlaces(int pageNumber, int pageSize);
    Task<int> GetPlacesCountByUserId(string userId);
    Task<List<Place>> GetPagedPlacesByUserId(string userId, int pageNumber, int pageSize);
    public Task AddPlace(Place place, IFormFile? image);
    public Task UpdatePlace(string id, Place updatedPlace, IFormFile? image);
    public Task DeletePlace(string id);
}
