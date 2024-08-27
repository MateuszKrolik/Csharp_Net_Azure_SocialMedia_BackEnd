using System;
using WebApplication1.Models;

namespace WebApplication1.Services;

public interface IPlaceService
{
    public List<Place> GetPlaces();
    public void AddPlace(Place place);
    public void UpdatePlace(string id, Place place);
    public void DeletePlace(string id);
}
