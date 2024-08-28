using System;
using AutoMapper;
using WebApplication1.Models;
using WebApplication1.DTO;
using System.Text.Json;

namespace WebApplication1.RequestHelpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<PlaceDTO, Place>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom<IdResolver>());
        CreateMap<string, Location>()
            .ConvertUsing<GeolocationResponseConverter>();

    }
}
public class IdResolver : IValueResolver<PlaceDTO, Place, string?>
{
    public string Resolve(PlaceDTO source, Place destination, string? destMember, ResolutionContext context)
    {
        return Guid.NewGuid().ToString();
    }
}
public class GeolocationResponseConverter : ITypeConverter<string, Location>
{
    private static readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    };

    public Location Convert(string source, Location destination, ResolutionContext context)
    {
        var geolocationResponse = JsonSerializer.Deserialize<GeolocationResponseDTO>(source, _jsonSerializerOptions);

        if (geolocationResponse == null ||
            geolocationResponse.Status == "ZERO_RESULTS" ||
            geolocationResponse.Results == null ||
            geolocationResponse.Results.Count == 0)
        {
            throw new HttpRequestException("No results found", null, System.Net.HttpStatusCode.UnprocessableEntity);
        }

        return geolocationResponse.Results[0].Geometry.Location;
    }
}
