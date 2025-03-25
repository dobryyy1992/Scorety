using Scorety.Server.Models;

namespace Scorety.Server.Data.Seeders
{
    public static class LeagueSeeder
    {
        public static readonly League[] Leagues = new League[]
        {
            new League
            {
                Id = Guid.NewGuid(),
                Name = "NBA",
                Description = "National Basketball Association - The premier professional basketball league in North America",
                SportId = SportSeeder.Sports.First(s => s.Name == "Basketball").Id,
                Country = "United States",
                LogoUrl = "https://example.com/logos/nba.png",
                IsActive = true
            }
        };

        public static void Seed(ApplicationDbContext context)
        {
            if (!context.Leagues.Any())
            {
                context.Leagues.AddRange(Leagues);
                context.SaveChanges();
            }
        }
    }
}