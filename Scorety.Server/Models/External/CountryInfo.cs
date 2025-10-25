using System.Text.Json.Serialization;

namespace Scorety.Server.Models.External
{
    public class CountryInfo
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("flag")]
        public string? Flag { get; set; }

        [JsonPropertyName("code")]
        public string? Code { get; set; }
    }
}