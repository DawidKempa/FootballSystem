using FootballSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballSystem.Application.DTOs
{
    public class UpdatePlayerDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [Range(1, 99)]
        public int Number { get; set; }
        [Required]
        [Range(16,60)]
        public int Age { get; set; }
        [Required]
        [StringLength(50)]
        public string Nationality { get; set; } = string.Empty;
        [Required]
        public string Position { get; set; }
        [Range(0,2000)]
        public int Games { get; set; }
        [Range(0, 2000)]
        public int Goals { get; set; }
        [Range(0, 2000)]
        public int Assists { get; set; }
    }
}