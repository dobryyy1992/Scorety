using Scorety.Server.Models;

namespace Scorety.Server.Data.Repositories.Interfaces
{
    public interface ITeamRepository
    {
        Task<IEnumerable<Team>> GetAllAsync(Guid sportId);
        Task<Team> GetByIdAsync(Guid id);
        Task<Team> GetByNameAsync(string name);
        Task<Team> CreateAsync(Team team);
        Task<Team> UpdateAsync(Team team);
        Task<bool> DeleteAsync(Guid id);
    }
}
