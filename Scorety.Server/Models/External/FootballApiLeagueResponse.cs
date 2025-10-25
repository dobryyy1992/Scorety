using System.Text.Json.Serialization;

namespace Scorety.Server.Models.External
{
    public class FootballApiLeagueResponse
    {
        [JsonPropertyName("league")]
        public FootballLeagueDetails League { get; set; } = new();

        [JsonPropertyName("country")]
        public CountryInfo Country { get; set; } = new();
    }
}