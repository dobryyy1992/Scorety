using System.Text.Json.Serialization;

namespace Scorety.Server.Models.External
{
    public class FootballLeagueDetails
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("logo")]
        public string? Logo { get; set; }
    }

}