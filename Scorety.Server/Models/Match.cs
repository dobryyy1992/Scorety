using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Scorety.Server.Enums;

namespace Scorety.Server.Models
{
    public class Match
    {
        // Primary Key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        // Relationships
        public Guid SeasonId { get; set; }
        public virtual Season Season { get; set; }
        public Guid HomeTeamId { get; set; }
        public virtual Team HomeTeam { get; set; }
        public Guid AwayTeamId { get; set; }
        public virtual Team AwayTeam { get; set; }

        // Basic Information
        [Column(TypeName = "timestamp with time zone")]
        public DateTime ScheduledDate { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Venue { get; set; }

        [Column(TypeName = "varchar(50)")]
        public MatchStatus Status { get; set; }
        public int? HomeScore { get; set; }
        public int? AwayScore { get; set; }
        
        [Column(TypeName = "jsonb")]
        public string Statistics { get; set; }
        public bool IsHighlight { get; set; }
        
        // Navigation Properties
        public virtual ICollection<UserComment> Comments { get; set; }
    }
}
