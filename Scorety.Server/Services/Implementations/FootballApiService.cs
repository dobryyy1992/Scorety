using Scorety.Server.DTOs;

namespace Scorety.Server.Services.Interfaces
{
    public class FootballApiService : IFootballApiService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly ILogger<FootballApiService> _logger;
        private readonly string _apiKey;
        private const string BASE_URL = "https://api-football-v1.p.rapidapi.com";

        public FootballApiService(IHttpClientService httpClientService, ILogger<FootballApiService> logger)
        {
            _httpClientService = httpClientService;
            _logger = logger;
            _apiKey = Environment.GetEnvironmentVariable("RAPIDAPI_KEY", EnvironmentVariableTarget.Machine) ?? throw new Exception("RAPIDAPI_FOOTBALL_KEY is missing");
        }

        public Task<IEnumerable<LeagueDto>> GetLeaguesAsync()
        {
            throw new NotImplementedException();
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
