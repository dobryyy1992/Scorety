using Scorety.Server.DTOs;
using Scorety.Server.Services.Interfaces;

namespace Scorety.Server.Services.Implementations
{
    public class LeagueService : ILeagueService
    {
        public Task<IEnumerable<LeagueDto>> GetAllLeaguesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<LeagueDto?> GetLeagueByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
