using Scorety.Server.DTOs;
using Scorety.Server.Enums;
using Scorety.Server.Models.External;
using Scorety.Server.Services.Interfaces;
using System.Text.Json;

namespace Scorety.Server.Services.Implementations
{
    public class NBAApiService : INBAApiService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly ILogger<NBAApiService> _logger;
        private readonly string _apiKey;
        private const string BASE_URL = "https://api-nba-v1.p.rapidapi.com";

        public NBAApiService(IHttpClientService httpClientService, ILogger<NBAApiService> logger)
        {
            _httpClientService = httpClientService;
            _logger = logger;
            _apiKey = Environment.GetEnvironmentVariable("RAPIDAPI_KEY", EnvironmentVariableTarget.Machine) ?? throw new Exception("RAPIDAPI_NBA_KEY is missing");
        }

        public async Task<IEnumerable<TeamDto>> GetAllNBATeamsAsync()
        {
            try
            {
                var headers = new Dictionary<string, string>
                {
                    { "x-rapidapi-key", _apiKey },
                    { "x-rapidapi-host", "api-nba-v1.p.rapidapi.com" }
                };

                var response = await _httpClientService.GetAsync<NBAApiResponse>($"{BASE_URL}/teams", headers);
                if (response?.TeamsResponse == null)
                {
                    return new List<TeamDto>();
                }

                var teams = response.TeamsResponse
                    .Where(team => team.NbaFranchise == true && team.AllStar == false)
                    .Select(team => new NBATeamDto
                    {
                        Name = team.Name,
                        Code = team.Code,
                        City = team.City,
                        Country = team.Code != "TOR" ? "USA" : "Canada",
                        Type = TeamType.Club,
                        LogoUrl = team.Logo,
                        IsActive = true,
                        Conference = team.Leagues?.Standard.Conference,
                        Division = team.Leagues?.Standard.Division
                    });

                return teams;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting NBA teams");
                return new List<TeamDto>();
            }
        }

        public Task<TeamDto?> GetNBATeamByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
