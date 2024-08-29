using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication1.DTO;
using WebApplication1.Services.UsersService;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public async Task<ActionResult<UsersResponseDTO>> GetUsers(int pageNumber = 1, int pageSize = 3)
        {
            var response = await _usersService.GetUsers(pageNumber, pageSize);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUserById(string id)
        {
            var userDto = await _usersService.GetUserById(id);
            if (userDto == null)
            {
                return NotFound();
            }
            return Ok(userDto);
        }
    }
}