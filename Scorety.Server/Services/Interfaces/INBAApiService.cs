using Scorety.Server.DTOs;

namespace Scorety.Server.Services.Interfaces
{
    public interface INBAApiService
    {
        Task<IEnumerable<TeamDto>> GetAllNBATeamsAsync();
        Task<TeamDto?> GetNBATeamByIdAsync(string id);
    }
}
