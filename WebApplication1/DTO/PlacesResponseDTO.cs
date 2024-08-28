using System;
using WebApplication1.Models;

namespace WebApplication1.DTO;

public class PlacesResponseDTO
{
    public List<Place>? Places { get; set; }
    public int CurrentPage { get; set; }
    public double TotalPages { get; set; }

}
