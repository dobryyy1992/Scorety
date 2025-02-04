using Scorety.Server.Models;

namespace Scorety.Server.Data.Repositories.Interfaces
{
    public interface ISportRepository
    {
        Task<IEnumerable<Sport>> GetAllAsync();
        Task<Sport> GetByIdAsync(Guid id);
        Task<Sport> GetByNameAsync(string name);
        Task<Sport> CreateAsync(Sport sport);
        Task<Sport> UpdateAsync(Sport sport);
        Task<bool> DeleteAsync(Guid id);
    }
}
