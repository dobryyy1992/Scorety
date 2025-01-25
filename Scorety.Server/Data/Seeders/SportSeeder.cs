using Scorety.Server.Enums;
using Scorety.Server.Models;

namespace Scorety.Server.Data.Seeders
{
    public static class SportSeeder
    {
        public static readonly Sport[] Sports = new Sport[]
        {
            new Sport
            {
                Id = Guid.NewGuid(),
                Name = "Football",
                Description = "Association football, commonly known as football or soccer",
                Category = SportCategory.TeamSport,
                IconUrl = "https://example.com/icons/football.png",
                IsActive = true,
                IsPopular = true
            },
            new Sport
            {
                Id = Guid.NewGuid(),
                Name = "Basketball",
                Description = "Basketball is a team sport in which two teams compete to score points by throwing a ball through a hoop",
                Category = SportCategory.TeamSport,
                IconUrl = "https://example.com/icons/basketball.png",
                IsActive = true,
                IsPopular = true
            },
            new Sport
            {
                Id = Guid.NewGuid(),
                Name = "Tennis",
                Description = "Tennis is a racket sport that can be played individually or between two teams",
                Category = SportCategory.IndividualSport,
                IconUrl = "https://example.com/icons/tennis.png",
                IsActive = true,
                IsPopular = true
            },
            new Sport
            {
                Id = Guid.NewGuid(),
                Name = "Snooker",
                Description = "Snooker is a cue sport played on a table covered with a green cloth, using a white cue ball and colored balls",
                Category = SportCategory.IndividualSport,
                IconUrl = "https://example.com/icons/snooker.png",
                IsActive = true,
                IsPopular = false
            }
        };

        public static void Seed(ApplicationDbContext context)
        {
            if (!context.Sports.Any())
            {
                context.Sports.AddRange(Sports);
                context.SaveChanges();
            }
        }
    }
} 