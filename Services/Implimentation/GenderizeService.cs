using Genderize.Models;
using Genderize.Services.Interface;
using System.Text.Json;

namespace Genderize.Services.Implimentation
{
    public class GenderizeService : IGenderizeService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<GenderizeService> _logger;
        private const string BaseUrl = "https://api.genderize.io";

        public GenderizeService(HttpClient httpClient, ILogger<GenderizeService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }
        public async Task<GenderizeResponse?> GetGenderPredictionAsync(string name)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{BaseUrl}?name={Uri.EscapeDataString(name)}");

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError("Genderize API returned {StatusCode}", response.StatusCode);
                    return null;
                }

                var content = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<GenderizeResponse>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return result;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Failed to call Genderize API");
                return null;
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex, "Failed to parse Genderize API response");
                return null;
            }
        }
    }
}

