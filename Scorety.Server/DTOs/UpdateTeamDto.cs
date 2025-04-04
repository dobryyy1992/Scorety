using System.ComponentModel.DataAnnotations;

namespace Scorety.Server.DTOs
{
    public class UpdateTeamDto
    {
        [StringLength(100, MinimumLength = 10)]
        public string Name { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public string Code { get; set; }

        [StringLength(50, MinimumLength = 10)]
        public string Description { get; set; }
        public string City { get; set; }

        [Url]
        public string LogoUrl { get; set; }
        public bool IsActive { get; set; }
    }
}