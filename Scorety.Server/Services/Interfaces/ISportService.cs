using Scorety.Server.Models;

namespace Scorety.Server.Services.Interfaces
{
    public interface ISportService
    {
        Task<List<Sport>> GetAllSportsAsync();
        Task<Sport> GetSportByIdAsync(Guid id);
        Task<Sport> GetSportByNameAsync(string name);
        Task<Sport> CreateSportAsync(Sport sport);
        Task<Sport> UpdateSportAsync(Sport sport);
        Task DeleteSportAsync(Guid id);
    }
}