using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1
{

    [Route("api/[controller]")]
    [ApiController]
    public class PlacesController : ControllerBase
    {
        private readonly IPlaceService _placeService;

        public PlacesController(IPlaceService placeService)
        {
            _placeService = placeService;
        }

        [HttpGet]
        public ActionResult<List<Place>> GetAllPlaces()
        {
            List<Place> places = _placeService.GetPlaces();
            return places;
        }

        [HttpGet("{id}")]
        public ActionResult<Place> GetPlaceById(string id)
        {
            Place? place = _placeService.GetPlaces().FirstOrDefault(p => p.Id == id);
            if (place == null)
            {
                throw new NotFoundException();
            }
            return place;
        }

        [HttpGet("user/{userId}")]
        public ActionResult<List<Place>> GetPlacesByUserId(string userId)
        {
            List<Place> places = _placeService.GetPlaces().Where(place => place.Creator == userId).ToList();
            return places;
        }

    }
}


