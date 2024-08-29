using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.DTO;
using WebApplication1.Services;

namespace WebApplication1
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
        public async Task<ActionResult<PlacesResponseDTO>> GetAllPlaces(int pageNumber = 1, int pageSize = 3)
        {
            var totalPlaces = await _placeService.GetPlacesCount();
            var pageCount = Math.Ceiling(totalPlaces / (double)pageSize);
            var places = await _placeService.GetPagedPlaces(pageNumber, pageSize);

            var response = new PlacesResponseDTO
            {
                Places = places,
                CurrentPage = pageNumber,
                TotalPages = pageCount
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Place>> GetPlaceById(string id)
        {
            Place? place = (await _placeService.GetPlaces()).FirstOrDefault(p => p.Id == id);
            if (place == null)
            {
                throw new NotFoundException("Place not found");
            }
            return place;
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<PlacesResponseDTO>> GetAllPlacesByUserId(string userId, int pageNumber = 1, int pageSize = 3)
        {
            var totalPlaces = await _placeService.GetPlacesCountByUserId(userId);
            var pageCount = Math.Ceiling(totalPlaces / (double)pageSize);
            var places = await _placeService.GetPagedPlacesByUserId(userId, pageNumber, pageSize);

            var response = new PlacesResponseDTO
            {
                Places = places,
                CurrentPage = pageNumber,
                TotalPages = pageCount
            };

            return Ok(response);
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
                throw new NotFoundException("Place not found");
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
                throw new NotFoundException("Place not found");
            }

            await _placeService.DeletePlace(id);

            return NoContent();
        }
    }
}


