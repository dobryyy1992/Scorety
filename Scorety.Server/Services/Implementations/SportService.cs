using Microsoft.EntityFrameworkCore;
using Scorety.Server.Services.Interfaces;
using Scorety.Server.Data.Repositories.Interfaces;
using Scorety.Server.Models;
    
namespace Scorety.Server.Services.Implementations
{
    public class SportService : ISportService
    {
        private readonly ISportRepository _sportRepository;

        public SportService(ISportRepository sportRepository)
        {
            _sportRepository = sportRepository;
        }

        public async Task<List<Sport>> GetAllSportsAsync()
        {
            var sports = await _sportRepository.GetAllAsync();
            return sports.ToList();
        }

        public async Task<Sport> GetSportByIdAsync(Guid id)
        {
            return await _sportRepository.GetByIdAsync(id);
        }

        public async Task<Sport> GetSportByNameAsync(string name)
        {
            return await _sportRepository.GetByNameAsync(name);
        }

        public async Task<Sport> CreateSportAsync(Sport sport)
        {
            await _sportRepository.CreateAsync(sport);
            return sport;
        }

        public async Task<Sport> UpdateSportAsync(Sport sport)
        {
            await _sportRepository.UpdateAsync(sport);
            return sport;
        }

        public async Task DeleteSportAsync(Guid id)
        {
            await _sportRepository.DeleteAsync(id);
        }
    }
}