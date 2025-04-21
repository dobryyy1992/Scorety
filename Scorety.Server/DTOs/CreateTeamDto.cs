using Scorety.Server.Enums;
using System.ComponentModel.DataAnnotations;

namespace Scorety.Server.DTOs
{
    public class CreateTeamDto
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Code { get; set; }

        [Required]
        public TeamType Type { get; set; }

        [StringLength(1000, MinimumLength = 10)]
        public string Description { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Country { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string City { get; set; }

        [Required]
        [Url]
        public string LogoUrl { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [DataType(DataType.Date)]
        public DateTime FoundedDate { get; set; }
    }
}