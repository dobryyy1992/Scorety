﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Scorety.Server.Models
{
    public class League
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid SportId { get; set; }
        public virtual Sport Sport { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }
        [Column(TypeName = "text")]
        public string Description { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Country { get; set; }
        [Column(TypeName = "text")]
        public string LogoUrl { get; set; }
        public bool IsActive { get; set; } = true;
        // Navigation Properties
        public virtual ICollection<Team> Teams { get; set; }
        public virtual ICollection<Season> Seasons { get; set; }
    }
}
