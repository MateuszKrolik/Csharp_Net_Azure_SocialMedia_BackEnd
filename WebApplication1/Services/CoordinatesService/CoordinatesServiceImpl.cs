using System.Net;
using System.Text.Json;
using AutoMapper;
using WebApplication1.DTO;

namespace WebApplication1.Services.CoordinatesService
{
    public class CoordinatesServiceImpl : ICoordinatesService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        private readonly IMapper _mapper;

        public CoordinatesServiceImpl(HttpClient httpClient, IConfiguration configuration, IMapper mapper)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<Location> GetCoordinatesForAddressAsync(string address)
        {

            string? apiKey = _configuration["GoogleMaps:ApiKey"];
            string? baseUrl = _configuration["GoogleMaps:BaseUrl"];
            string url = $"{baseUrl}?address={Uri.EscapeDataString(address)}&key={apiKey}";

            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            var location = _mapper.Map<Location>(responseBody);

            return location;
        }
    }
}