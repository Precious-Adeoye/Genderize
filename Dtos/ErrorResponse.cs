using System.Text.Json.Serialization;

namespace Genderize.Dtos
{
    public class ErrorResponse
    {
        [JsonPropertyName("status")]
        public string Status { get; set; } = "error";

        [JsonPropertyName("message")]
        public string Message { get; set; } = string.Empty;
    }
}
