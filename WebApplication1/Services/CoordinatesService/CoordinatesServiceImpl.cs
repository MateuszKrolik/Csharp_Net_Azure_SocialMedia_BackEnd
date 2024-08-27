using System.Net;
using System.Text.Json;
using WebApplication1.DTO;

namespace WebApplication1.Services.CoordinatesService
{
    public class CoordinatesServiceImpl : ICoordinatesService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public CoordinatesServiceImpl(HttpClient httpClient, IConfiguration configuration, ILogger<CoordinatesServiceImpl> logger)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<Location> GetCoordinatesForAddressAsync(string address)
        {

            string? apiKey = _configuration["GOOGLE_MAPS_API_KEY"];
            string url = $"https://maps.googleapis.com/maps/api/geocode/json?address={Uri.EscapeDataString(address)}&key={apiKey}";

            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var geolocationResponse = JsonSerializer.Deserialize<GeolocationResponseDTO>(responseBody, options);

            if (geolocationResponse == null ||
                geolocationResponse.Status == "ZERO_RESULTS" ||
                geolocationResponse.Results == null ||
                geolocationResponse.Results.Count == 0)
            {
                throw new HttpRequestException("No results found", null, HttpStatusCode.UnprocessableEntity);
            }

            var location = geolocationResponse.Results[0].Geometry.Location;

            return location;
        }
    }
}