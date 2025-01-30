using Scorety.Server.DTOs;
using Scorety.Server.Models;

namespace Scorety.Server.Services.Interfaces
{
    public interface ISportService
    {
        Task<IEnumerable<SportDto>> GetAllSportsAsync();
        Task<SportDto> GetSportByIdAsync(Guid id);
        Task<Sport> GetSportByNameAsync(string name);
        Task<Sport> CreateSportAsync(CreateSportDto sport);
        Task<Sport> UpdateSportAsync(Guid id, UpdateSportDto sport);
        Task DeleteSportAsync(Guid id);
    }
}