using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services.ImageService; // Add this line

namespace WebApplication1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult> GetImage(string name)
        {
            var (imageStream, contentType) = await _imageService.GetImageAsync(name);
            return File(imageStream, contentType);
        }

    }
}
