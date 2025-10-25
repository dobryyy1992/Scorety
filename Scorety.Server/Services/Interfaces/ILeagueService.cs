using Scorety.Server.DTOs;

namespace Scorety.Server.Services.Interfaces
{
    public interface ILeagueService
    {
        Task<IEnumerable<LeagueDto>> GetAllLeaguesAsync();
        Task<LeagueDto?> GetLeagueByIdAsync(int id);
    }
}
