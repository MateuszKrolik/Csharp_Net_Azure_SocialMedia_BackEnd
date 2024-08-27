namespace WebApplication1.DTO
{
    public record GeolocationResponseDTO(string Status, List<Result>? Results);

    public record Result(Geometry Geometry);

    public record Geometry(Location Location);

    public record Location(double Lat, double Lng);
}