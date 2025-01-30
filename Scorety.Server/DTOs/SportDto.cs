using Scorety.Server.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Scorety.Server.DTOs
{
    public class SportDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public SportCategory Category { get; set; }
        public string IconUrl { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsPopular { get; set; }
    }
}
