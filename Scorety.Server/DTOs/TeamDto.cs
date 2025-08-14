using Scorety.Server.Enums;

namespace Scorety.Server.DTOs
{
    public class TeamDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public TeamType Type { get; set; }
        public string? Description { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string LogoUrl { get; set; }
        public bool IsActive { get; set; }
        public DateTime? FoundedDate { get; set; }
    }
}
