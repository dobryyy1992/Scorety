using System.Text.Json.Serialization;

namespace Scorety.Server.Models.External
{
    public class FootballApiResponse
    {
        [JsonPropertyName("response")]
        public List<FootballApiLeagueResponse>? LeaguesResponse { get; set; }
    }

}