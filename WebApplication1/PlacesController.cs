using AutoMapper;
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
        private readonly IMapper _mapper;

        public PlacesController(IPlaceService placeService, IMapper mapper)
        {
            _placeService = placeService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<Place>>> GetAllPlaces()
        {
            List<Place> places = await _placeService.GetPlaces();
            return places;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Place>> GetPlaceById(string id)
        {
            Place? place = (await _placeService.GetPlaces()).FirstOrDefault(p => p.Id == id);
            if (place == null)
            {
                throw new NotFoundException();
            }
            return place;
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<List<Place>>> GetAllPlacesByUserId(string userId)
        {
            List<Place> places = (await _placeService.GetPlaces()).Where(place => place.Creator == userId).ToList();
            return places;
        }

        [HttpPost]
        public async Task<ActionResult> AddPlace([FromForm] PlaceDTO placeDto)
        {
            var place = _mapper.Map<Place>(placeDto);

            await _placeService.AddPlace(place, placeDto.Image);
            return CreatedAtAction(nameof(GetPlaceById), new { id = place.Id }, place);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdatePlaceById(string id, [FromForm] PlaceDTO placeDto)
        {
            Place? existingPlace = (await _placeService.GetPlaces()).FirstOrDefault(p => p.Id == id);
            if (existingPlace == null)
            {
                throw new NotFoundException();
            }
            var updatedPlace = _mapper.Map<Place>(placeDto);
            await _placeService.UpdatePlace(id, updatedPlace, placeDto.Image);
            return Ok(existingPlace);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePlaceById(string id)
        {
            Place? place = (await _placeService.GetPlaces()).FirstOrDefault(p => p.Id == id);
            if (place == null)
            {
                throw new NotFoundException();
            }
            await _placeService.DeletePlace(id);
            return NoContent();
        }
    }
}


