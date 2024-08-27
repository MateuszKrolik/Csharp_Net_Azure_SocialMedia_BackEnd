using System;
using WebApplication1.DTO;

namespace WebApplication1.Services.CoordinatesService;

public interface ICoordinatesService
{
    Task<Location> GetCoordinatesForAddressAsync(string address);
}
