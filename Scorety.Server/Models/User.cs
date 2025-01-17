using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Scorety.Server.Enums;

namespace Scorety.Server.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Username { get; set; }
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Email { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string PasswordHash { get; set; }
        [Column(TypeName = "varchar(20)")]
        public UserRole Role { get; set; } = UserRole.User;
        // Profile Information
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string FirstName { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [Column(TypeName = "text")]
        public string ProfilePictureUrl { get; set; }
        [Column(TypeName = "text")]
        public string Bio { get; set; }
        // Location Information
        [Column(TypeName = "varchar(100)")]
        public string Country { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string City { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Timezone { get; set; }
        [Column(TypeName = "varchar(20)")]
        public NotificationType PreferredNotificationType { get; set; } = NotificationType.Email;
        [Column(TypeName = "varchar(20)")]
        public SubscriptionType SubscriptionType { get; set; } = SubscriptionType.Free;
        // Navigation Properties
        public virtual ICollection<UserFavoriteSport> FavoriteSports { get; set; }
        public virtual ICollection<UserFavoriteTeam> FavoriteTeams { get; set; }
        public virtual ICollection<UserFavoritePlayer> FavoritePlayers { get; set; }
        public virtual ICollection<UserComment> Comments { get; set; }
        // Timestamps
        [Column(TypeName = "timestamp with time zone")]
        public DateTime LastLogin { get; set; }
        [Column(TypeName = "timestamp with time zone")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Column(TypeName = "timestamp with time zone")]
        public DateTime? LastModifiedAt { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsVerified { get; set; } = false;
    }


}
