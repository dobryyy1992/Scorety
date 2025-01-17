using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Scorety.Server.Models
{
    public class Player
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid SportId { get; set; }
        public virtual Sport Sport { get; set; }
        public Guid? TeamId { get; set; }
        public virtual Team Team { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string FirstName { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string LastName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Nickname { get; set; }
        [Column(TypeName = "text")]
        public string ProfilePictureUrl { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string JerseyNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Nationality { get; set; }
        [Column(TypeName = "jsonb")]
        public string Statistics { get; set; }
        // Navigation Properties
        public virtual ICollection<UserFavoritePlayer> FavoritedBy { get; set; }
        public virtual ICollection<UserComment> Comments { get; set; }
    }
}
