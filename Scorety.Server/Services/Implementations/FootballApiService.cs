using Scorety.Server.DTOs;
using Scorety.Server.Models.External;

namespace Scorety.Server.Services.Interfaces
{
    public class FootballApiService : IFootballApiService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly ILogger<FootballApiService> _logger;
        private readonly string _apiKey;
        private const string BASE_URL = "https://api-football-v1.p.rapidapi.com/v3";

        public FootballApiService(IHttpClientService httpClientService, ILogger<FootballApiService> logger)
        {
            _httpClientService = httpClientService;
            _logger = logger;
            _apiKey = Environment.GetEnvironmentVariable("RAPIDAPI_KEY", EnvironmentVariableTarget.Machine) ?? throw new Exception("RAPIDAPI_KEY is missing");
        }

        public async Task<IEnumerable<LeagueDto>> GetLeaguesAsync()
        {
            try
            {
                var headers = new Dictionary<string, string>
                {
                    { "x-rapidapi-key", _apiKey },
                    { "x-rapidapi-host", "api-football.p.rapidapi.com" },
                };

                var response = await _httpClientService.GetAsync<FootballApiResponse>($"{BASE_URL}/leagues", headers);
                if (response?.LeaguesResponse == null)
                {
                    return new List<LeagueDto>();
                }

                var leagues = response.LeaguesResponse
                    .Where(league => new[] { 39, 140, 135 }.Contains(league.League.Id))
                    .Select(league => new LeagueDto
                    {
                        Name = league.League.Name,
                        Country = league.Country.Name,
                        LogoUrl = league.League.Logo ?? string.Empty
                    });

                return leagues;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting football leagues.");
                return new List<LeagueDto>();
            }
        }

        public Task<IEnumerable<LeagueDto>> GetLeaguesByCountryAsync(string countryName)
        {
            throw new NotImplementedException();
        }

        public Task<LeagueDto?> GetLeagueByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
