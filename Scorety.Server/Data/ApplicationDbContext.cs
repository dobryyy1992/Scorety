using Microsoft.EntityFrameworkCore;
using Scorety.Server.Models;

namespace Scorety.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<NBATeam> NBATeams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<UserComment> UserComments { get; set; }
        public DbSet<UserFavoritePlayer> UserFavoritePlayers { get; set; }
        public DbSet<UserFavoriteTeam> UserFavoriteTeams { get; set; }
        public DbSet<UserFavoriteSport> UserFavoriteSports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Team inheritance with a different discriminator column name
            modelBuilder.Entity<Team>()
                .HasDiscriminator<string>("TeamType")
                .HasValue<Team>("Team")
                .HasValue<NBATeam>("NBATeam");

            // Configure many-to-many relationships
            modelBuilder.Entity<UserFavoritePlayer>()
                .HasKey(ufp => ufp.Id);

            modelBuilder.Entity<UserFavoritePlayer>()
                .HasOne(ufp => ufp.User)
                .WithMany(u => u.FavoritePlayers)
                .HasForeignKey(ufp => ufp.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserFavoritePlayer>()
                .HasOne(ufp => ufp.Player)
                .WithMany(p => p.FavoritedBy)
                .HasForeignKey(ufp => ufp.PlayerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserFavoriteTeam>()
                .HasKey(uft => uft.Id);

            modelBuilder.Entity<UserFavoriteTeam>()
                .HasOne(uft => uft.User)
                .WithMany(u => u.FavoriteTeams)
                .HasForeignKey(uft => uft.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserFavoriteTeam>()
                .HasOne(uft => uft.Team)
                .WithMany(t => t.FavoritedBy)
                .HasForeignKey(uft => uft.TeamId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserFavoriteSport>()
                .HasKey(ufs => ufs.Id);

            modelBuilder.Entity<UserFavoriteSport>()
                .HasOne(ufs => ufs.User)
                .WithMany(u => u.FavoriteSports)
                .HasForeignKey(ufs => ufs.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserFavoriteSport>()
                .HasOne(ufs => ufs.Sport)
                .WithMany(s => s.FavoritedBy)
                .HasForeignKey(ufs => ufs.SportId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure Match relationships
            modelBuilder.Entity<Match>()
                .HasOne(m => m.HomeTeam)
                .WithMany(t => t.HomeMatches)
                .HasForeignKey(m => m.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.AwayTeam)
                .WithMany(t => t.AwayMatches)
                .HasForeignKey(m => m.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure cascade delete behavior
            modelBuilder.Entity<League>()
                .HasOne(l => l.Sport)
                .WithMany(s => s.Leagues)
                .HasForeignKey(l => l.SportId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Team>()
                .HasOne(t => t.Sport)
                .WithMany(s => s.Teams)
                .HasForeignKey(t => t.SportId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Player>()
                .HasOne(p => p.Sport)
                .WithMany(s => s.Players)
                .HasForeignKey(p => p.SportId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure indexes
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<Sport>()
                .HasIndex(s => s.Name)
                .IsUnique();

            modelBuilder.Entity<League>()
                .HasIndex(l => new { l.Name, l.SportId })
                .IsUnique();

            modelBuilder.Entity<Team>()
                .HasIndex(t => new { t.Name, t.SportId })
                .IsUnique();

            modelBuilder.Entity<Team>()
                .HasOne(t => t.League)
                .WithMany(l => l.Teams)
                .HasForeignKey(t => t.LeagueId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Season>()
                .HasOne(s => s.Sport)
                .WithMany(sp => sp.Seasons)
                .HasForeignKey(s => s.SportId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Season>()
                .HasOne(s => s.League)
                .WithMany(l => l.Seasons)
                .HasForeignKey(s => s.LeagueId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserComment>()
                .HasOne(uc => uc.Match)
                .WithMany(m => m.Comments)
                .HasForeignKey(uc => uc.MatchId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserComment>()
                .HasOne(uc => uc.Team)
                .WithMany(t => t.Comments)
                .HasForeignKey(uc => uc.TeamId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserComment>()
                .HasOne(uc => uc.Player)
                .WithMany(p => p.Comments)
                .HasForeignKey(uc => uc.PlayerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
} 