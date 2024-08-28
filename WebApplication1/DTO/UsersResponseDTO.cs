using System;
using WebApplication1.Models;

namespace WebApplication1.DTO;

public class UsersResponseDTO
{
    public List<UserDTO>? Users { get; set; }
    public int TotalPages { get; set; }
    public int CurrentPage { get; set; }
}
