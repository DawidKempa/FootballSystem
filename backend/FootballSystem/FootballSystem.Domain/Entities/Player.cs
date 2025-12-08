using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballSystem.Domain.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Number {  get; set; }
        public int Age { get; set; }
        public string Nationality { get; set; }
        public Position Position { get; set; }
        public int Games { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
    }
}
