using Microsoft.EntityFrameworkCore;
using Scorety.Server.Data.Repositories.Interfaces;
using Scorety.Server.Models;

namespace Scorety.Server.Data.Repositories.Implementations
{
    public class TeamRepository : ITeamRepository
    {
        private readonly ApplicationDbContext _context;

        public TeamRepository(ApplicationDbContext context)
        {
            _context = context;
        }  

        public async Task<IEnumerable<Team>> GetAllAsync(Guid sportId)
        {
            return await _context.Teams.Where(t => t.SportId == sportId).ToListAsync();
        }

        public async Task<Team> GetByIdAsync(Guid id)
        {
            return await _context.Teams.FindAsync(id) 
                ?? throw new KeyNotFoundException($"Team with ID {id} not found");
        }

        public async Task<Team> GetByNameAsync(string name)
        {
            return await _context.Teams
                .FirstOrDefaultAsync(t => t.Name.ToLower() == name.ToLower())
                ?? throw new KeyNotFoundException($"Team with name {name} not found");
        }

        public async Task<Team> CreateAsync(Team team)
        {
            await _context.Teams.AddAsync(team);
            await _context.SaveChangesAsync();
            return team;
        }

        public async Task<Team> UpdateAsync(Team team)
        {
            var existingTeam = await GetByIdAsync(team.Id);

            _context.Entry(existingTeam).CurrentValues.SetValues(team);
            await _context.SaveChangesAsync();

            return team;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var team = await GetByIdAsync(id);

            if (team == null)
                return false;

            _context.Teams.Remove(team);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
