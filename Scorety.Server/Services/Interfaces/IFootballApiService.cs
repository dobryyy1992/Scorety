using Scorety.Server.DTOs;
using Scorety.Server.Models;

namespace Scorety.Server.Services.Interfaces
{
    public interface IFootballApiService
    {
        Task<IEnumerable<LeagueDto>> GetLeaguesAsync();
        Task<IEnumerable<LeagueDto>> GetLeaguesByCountryAsync(string countryName);
        Task<LeagueDto?> GetLeagueByIdAsync(string id);

        //Task<IEnumerable<TeamDto>> GetTeamsByLeagueAsync(string league);
        //Task<IEnumerable<TeamDto>> GetTeamsByCountryAsync(string country);
        //Task<IEnumerable<TeamDto>> GetTeamsBySeasonAsync(string season);
    }
}
