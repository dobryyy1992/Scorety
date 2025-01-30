using Scorety.Server.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scorety.Server.DTOs
{
    public class CreateSportDto
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 10)]
        public string Description { get; set; }

        [Required]
        public SportCategory Category { get; set; }

        [Required]
        [Url]
        public string IconUrl { get; set; }

        [Required]
        public bool IsPopular { get; set; }
    }
}
