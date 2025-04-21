using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scorety.Server.Models
{
    public class NBATeam : Team
    {
        [Column(TypeName = "varchar(50)")]
        public string? Conference { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? Division { get; set; }
    }
}