using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Scorety.Server.Models
{
    public class UserFavoritePlayer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public Guid PlayerId { get; set; }
        public virtual Player Player { get; set; }

        [Column(TypeName = "timestamp with time zone")]
        public DateTime AddedAt { get; set; } = DateTime.UtcNow;

        public bool NotificationsEnabled { get; set; } = true;
    }
}
