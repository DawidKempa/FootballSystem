using FootballSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballSystem.Application.DTOs
{
    public class CreatePlayerDto
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Range(0, 99, ErrorMessage = "Numer zawodnika musi być między 1 a 99.")]
        public int Number {  get; set; }
        [Range(16,60, ErrorMessage ="Wiek zawodnika musi być między 16 a 60")]
        public int Age { get; set; }
        [Required]
        [StringLength(50)]
        public string Nationality { get; set; }
        [Required(ErrorMessage ="Pozycja jest wymagana")]

        public string Position {  get; set; }
        [Range(0,2000)]
        public int Games { get; set; }
        [Range(0, 2000)]
        public int Goals { get; set; }
        [Range(0, 2000)]
        public int Assists { get; set; }
    }
}
