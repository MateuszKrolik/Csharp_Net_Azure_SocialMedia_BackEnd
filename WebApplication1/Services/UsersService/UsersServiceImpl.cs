using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DTO;
using WebApplication1.Models;

namespace WebApplication1.Services.UsersService
{
    public class UsersServiceImpl : IUsersService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public UsersServiceImpl(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<UsersResponseDTO> GetUsers(int pageNumber, int pageSize)
        {
            var totalUsers = await _userManager.Users.CountAsync();
            var pageCount = Math.Ceiling(totalUsers / (double)pageSize);

            var users = await _userManager.Users
                .Include(u => u.Places)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var userDtos = _mapper.Map<List<UserDTO>>(users);

            return new UsersResponseDTO
            {
                Users = userDtos,
                TotalPages = (int)pageCount,
                CurrentPage = pageNumber
            };
        }

        public async Task<UserDTO?> GetUserById(string id)
        {
            var user = await _userManager.Users
                .Include(u => u.Places)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return null;
            }

            return _mapper.Map<UserDTO>(user);
        }
    }
}