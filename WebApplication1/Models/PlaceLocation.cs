using System;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

[Owned]
public class PlaceLocation
{
    public PlaceLocation(){ }
    public PlaceLocation(double lat, double lng)
    {
        Lat = lat;
        Lng = lng;
    }

    public double Lat { get; set; }
    public double Lng { get; set; }

}
