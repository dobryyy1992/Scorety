using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Scorety.Server.Models
{
    public class UserFavoriteTeam
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public Guid TeamId { get; set; }
        public virtual Team Team { get; set; }

        [Column(TypeName = "timestamp with time zone")]
        public DateTime AddedAt { get; set; } = DateTime.UtcNow;

        public bool NotificationsEnabled { get; set; } = true;
    }
}
