using System.Text.Json.Serialization;

namespace Scorety.Server.Models.External
{
    public class NBALeagueInfo
    {
        [JsonPropertyName("standard")]
        public NBALeagueDetails Standard { get; set; }
        
        [JsonPropertyName("vegas")]
        public NBALeagueDetails Vegas { get; set; }
        
        [JsonPropertyName("utah")]
        public NBALeagueDetails Utah { get; set; }
        
        [JsonPropertyName("sacramento")]
        public NBALeagueDetails Sacramento { get; set; }
    }
} 