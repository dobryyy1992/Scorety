using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Scorety.Server.Models
{
    public class Season
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

        [Column(TypeName = "timestamp with time zone")]
        public DateTime StartDate { get; set; }
        
        [Column(TypeName = "timestamp with time zone")]
        public DateTime EndDate { get; set; }

        // Additional Details
        public bool IsActive { get; set; } = true;
        public bool IsCurrentSeason { get; set; }
        
        // Navigation Properties
        public virtual ICollection<Match> Matches { get; set; }
    }

}
