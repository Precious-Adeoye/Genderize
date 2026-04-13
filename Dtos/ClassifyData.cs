using System.Text.Json.Serialization;

namespace Genderize.Dtos
{
    public class ClassifyData
    {

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("gender")]
        public string? Gender { get; set; }

        [JsonPropertyName("probability")]
        public double? Probability { get; set; }

        [JsonPropertyName("sample_size")]
        public int? SampleSize { get; set; }

        [JsonPropertyName("is_confident")]
        public bool IsConfident { get; set; }

        [JsonPropertyName("processed_at")]
        public string ProcessedAt { get; set; } = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");
    }
}
