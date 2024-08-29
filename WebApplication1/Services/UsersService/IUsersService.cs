using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.DTO;
using WebApplication1.Models;

namespace WebApplication1.Services.UsersService
{
    public interface IUsersService
    {
        public Task<UsersResponseDTO> GetUsers(int pageNumber, int pageSize);
        public Task<UserDTO?> GetUserById(string id);
    }
}