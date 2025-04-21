using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Text.RegularExpressions;
using Scorety.Server.Enums;

namespace Scorety.Server.Models
{
    public class Team
    {
         // Primary Key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        // Relationships
        public Guid SportId { get; set; }
        public virtual Sport Sport { get; set; }
        public Guid LeagueId { get; set; }
        public virtual League League { get; set; }

        // Basic Information
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Code { get; set; }

        [Column(TypeName = "varchar(10)")]
        public TeamType Type { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Country { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string City { get; set; }

        // Additional Details
        [Column(TypeName = "text")]
        public string LogoUrl { get; set; }
        public bool IsActive { get; set; } = true;

        [Column(TypeName = "timestamp with time zone")]
        public DateTime? FoundedDate { get; set; }

        // Navigation Properties
        public virtual ICollection<Player> Players { get; set; }
        public virtual ICollection<Match> HomeMatches { get; set; }
        public virtual ICollection<Match> AwayMatches { get; set; }
        public virtual ICollection<UserFavoriteTeam> FavoritedBy { get; set; }
        public virtual ICollection<UserComment> Comments { get; set; }
    }

}
