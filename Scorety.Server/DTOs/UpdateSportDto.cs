using Scorety.Server.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scorety.Server.DTOs
{
    public class UpdateSportDto
    {
        [StringLength(100, MinimumLength = 10)]
        public string Description { get; set; }

        [Url]
        public string IconUrl { get; set; }
        public bool IsActive { get; set; }
        public bool IsPopular { get; set; }
    }
}
