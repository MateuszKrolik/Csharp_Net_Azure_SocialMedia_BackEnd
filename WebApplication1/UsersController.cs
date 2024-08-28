using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DTO;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IMapper _mapper;

        public UsersController(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<UsersResponseDTO>> GetUsers(int pageNumber = 1, int pageSize = 3)
        {
            var totalUsers = await _userManager.Users.CountAsync();

            var pageCount = Math.Ceiling(totalUsers / (double)pageSize);

            var users = await _userManager.Users
                .Include(u => u.Places)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var userDtos = _mapper.Map<List<UserDTO>>(users);

            var response = new UsersResponseDTO
            {
                Users = userDtos,
                TotalPages = (int)pageCount,
                CurrentPage = pageNumber
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationUser>> GetUserById(string id)
        {
            var user = await _userManager.Users
                .Include(u => u.Places)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            var userDto = _mapper.Map<UserDTO>(user);
            return Ok(userDto);
        }
    }
}