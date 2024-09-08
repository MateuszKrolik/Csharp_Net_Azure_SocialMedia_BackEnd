using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Security.Claims;
using WebApplication1.DTO;
using WebApplication1.Services.UsersService;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UsersController(IUsersService usersService, IHttpContextAccessor httpContextAccessor)
        {
            _usersService = usersService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<UsersResponseDTO>> GetUsers(int pageNumber = 1, int pageSize = 1)
        {
            var response = await _usersService.GetUsers(pageNumber, pageSize);
            return Ok(response);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<UserDTO>> GetUserById(string id)
        {
            var userDto = await _usersService.GetUserById(id);
            if (userDto == null)
            {
                return NotFound();
            }
            return Ok(userDto);
        }

        [HttpGet("currentUserId")]
        [Authorize]
        public ActionResult<string> GetCurrentUserId()
        {
            var userId = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return Unauthorized();
            }
            return Ok(userId);
        }

    }
}