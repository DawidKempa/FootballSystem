using FootballSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballSystem.Application.DTOs
{
    public class UpdatePlayerDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Number { get; set; }
        public int Age { get; set; }
        public string Nationality { get; set; } = string.Empty;
        public string Position { get; set; }
        public int Games { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
    }
}