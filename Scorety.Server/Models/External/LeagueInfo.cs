using System.Text.Json.Serialization;

namespace Scorety.Server.Models.External
{
    public class LeagueInfo
    {
        [JsonPropertyName("standard")]
        public LeagueDetails Standard { get; set; }
        
        [JsonPropertyName("vegas")]
        public LeagueDetails Vegas { get; set; }
        
        [JsonPropertyName("utah")]
        public LeagueDetails Utah { get; set; }
        
        [JsonPropertyName("sacramento")]
        public LeagueDetails Sacramento { get; set; }
    }
} 