using System.Text.Json.Serialization;

namespace Genderize.Models
{
    public class GenderizeResponse
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("gender")]
        public string? Gender { get; set; }

        [JsonPropertyName("probability")]
        public double? Probability { get; set; }

        [JsonPropertyName("count")]
        public int? Count { get; set; }
    }
}
