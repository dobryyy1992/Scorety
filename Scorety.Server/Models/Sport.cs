using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Numerics;
using Scorety.Server.Enums;

namespace Scorety.Server.Models
{
    public class Sport
    {   
        // Primary Key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        // Basic Information
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }
        [Column(TypeName = "text")]
        public string Description { get; set; }
        [Column(TypeName = "varchar(50)")]
        public SportCategory Category { get; set; }

        // Additional Details
        [Column(TypeName = "text")]
        public string IconUrl { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsPopular { get; set; }

        // Navigation Properties
        public virtual ICollection<League> Leagues { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
        public virtual ICollection<Season> Seasons { get; set; }
        public virtual ICollection<Player> Players { get; set; }
        public virtual ICollection<UserFavoriteSport> FavoritedBy { get; set; }
    }

}
