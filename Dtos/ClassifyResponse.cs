using System.Text.Json.Serialization;

namespace Genderize.Dtos
{
    public class ClassifyResponse
    {
        [JsonPropertyName("status")]
        public string Status { get; set; } = "success";

        [JsonPropertyName("data")]
        public ClassifyData Data { get; set; } = new();
    }
}
