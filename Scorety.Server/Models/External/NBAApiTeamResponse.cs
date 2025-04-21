using System.Text.Json.Serialization;

namespace Scorety.Server.Models.External
{
    public class NBAApiTeamResponse
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string City { get; set; }
        public string Logo { get; set; }
        public bool NbaFranchise { get; set; }
        public bool AllStar { get; set; }
        public LeagueInfo Leagues { get; set; }
    }
}
