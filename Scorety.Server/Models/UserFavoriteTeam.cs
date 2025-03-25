using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Scorety.Server.Models
{
    public class UserFavoriteTeam
    {
        // Primary Key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        // Relationships
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public Guid TeamId { get; set; }
        public virtual Team Team { get; set; }

        // Additional Details
        [Column(TypeName = "timestamp with time zone")]
        public DateTime AddedAt { get; set; } = DateTime.UtcNow;

        public bool NotificationsEnabled { get; set; } = true;
    }
}
