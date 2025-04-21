using Scorety.Server.Services.Implementations;
using System.Text.Json.Serialization;

namespace Scorety.Server.Models.External
{
    public class NBAApiResponse
    {
        [JsonPropertyName("response")]
        public List<NBAApiTeamResponse> TeamsResponse { get; set; }
    }
}
