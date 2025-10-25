using Microsoft.EntityFrameworkCore;
using Scorety.Server.Data.Repositories.Interfaces;
using Scorety.Server.Models;

namespace Scorety.Server.Data.Repositories.Implementations
{
    public class LeagueRepository : ILeagueRepository
    {
        private readonly ApplicationDbContext _context;

        public LeagueRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<League>> GetAllAsync()
        {
            return await _context.Leagues.ToListAsync();
        }

        public async Task<League> GetByIdAsync(Guid id)
        {
            return await _context.Leagues.FindAsync(id)
                ?? throw new KeyNotFoundException($"League with ID {id} not found");
        }

        public async Task<League> GetByNameAsync(string name)
        {
            return await _context.Leagues
                .FirstOrDefaultAsync(l => l.Name.ToLower() == name.ToLower())
                ?? throw new KeyNotFoundException($"League with name {name} not found");
        }

        public async Task<League> CreateAsync(League league)
        {
            await _context.Leagues.AddAsync(league);
            await _context.SaveChangesAsync();
            return league;
        }

        public Task<League> UpdateAsync(League league)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var league = await GetByIdAsync(id);

            _context.Leagues.Remove(league);
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
