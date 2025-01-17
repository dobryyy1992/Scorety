using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Scorety.Server.Models
{
    public class UserComment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public Guid? MatchId { get; set; }
        public virtual Match Match { get; set; }

        public Guid? TeamId { get; set; }
        public virtual Team Team { get; set; }

        public Guid? PlayerId { get; set; }
        public virtual Player Player { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string Content { get; set; }

        [Column(TypeName = "timestamp with time zone")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column(TypeName = "timestamp with time zone")]
        public DateTime? ModifiedAt { get; set; }

        public int LikesCount { get; set; }
        public bool IsEdited { get; set; }
        public bool IsDeleted { get; set; }
    }
}
