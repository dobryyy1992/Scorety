using Scorety.Server.Models;

namespace Scorety.Server.Data.Repositories.Interfaces
{
    public interface ILeagueRepository
    {
        Task<IEnumerable<League>> GetAllAsync();
        Task<League> GetByIdAsync(Guid id);
        Task<League> GetByNameAsync(string name);
        Task<League> CreateAsync(League league);
        Task<League> UpdateAsync(League league);
        Task<bool> DeleteAsync(Guid id);
    }
}
