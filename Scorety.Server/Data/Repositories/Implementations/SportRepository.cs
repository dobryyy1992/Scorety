using Scorety.Server.Data.Repositories.Interfaces;
using Scorety.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Scorety.Server.Data.Repositories.Implementations
{
    public class SportRepository : ISportRepository
    {
        private readonly ApplicationDbContext _context;

        public SportRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Sport>> GetAllAsync()
        {
            return await _context.Sports.ToListAsync();
        }

        public async Task<Sport> GetByIdAsync(Guid id)
        {
            return await _context.Sports.FindAsync(id)
                ?? throw new KeyNotFoundException($"Sport with ID {id} not found");
        }

        public async Task<Sport> GetByNameAsync(string name)
        {
            return await _context.Sports
                .FirstOrDefaultAsync(s => s.Name.ToLower() == name.ToLower())
                ?? throw new KeyNotFoundException($"Sport with name {name} not found");
        }

        public async Task<Sport> CreateAsync(Sport sport)
        {
            await _context.Sports.AddAsync(sport);
            await _context.SaveChangesAsync();
            return sport;
        }

        public async Task<Sport> UpdateAsync(Sport sport)
        {
            var existingSport = await GetByIdAsync(sport.Id);
            
            _context.Entry(existingSport).CurrentValues.SetValues(sport);
            await _context.SaveChangesAsync();
            
            return sport;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var sport = await GetByIdAsync(id);

            _context.Sports.Remove(sport);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
