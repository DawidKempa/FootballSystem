using FootballSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballSystem.Infrastructure.Data
{
    public class FootballContext : DbContext
    {
        public FootballContext(DbContextOptions<FootballContext> options) : base(options) { }

        public DbSet<Player> Players { get; set; }

        public static void SeedData(FootballContext context)
        {
            if (!context.Players.Any()) { 
                var players = new List<Player>
                {
                        new Player { Name = "Jan", LastName = "Kowalski", Number = 1, Age = 28, Nationality = "Poland", Position = Position.Goalkeeper, Games = 100, Goals = 0, Assists = 0 },
                        new Player { Name = "Piotr", LastName = "Nowak", Number = 6, Age = 26, Nationality = "Poland", Position = Position.Defender, Games = 80, Goals = 2, Assists = 5 },
                        new Player { Name = "Adam", LastName = "Wiśniewski", Number = 10, Age = 24, Nationality = "Poland", Position = Position.Midfielder, Games = 60, Goals = 10, Assists = 15 },
                        new Player { Name = "Kamil", LastName = "Lewandowski", Number = 9, Age = 27, Nationality = "Poland", Position = Position.Forward, Games = 90, Goals = 50, Assists = 20 },
                        new Player { Name = "Franciszek", LastName = "Gbur", Number = 4, Age = 28, Nationality = "Poland", Position = Position.Goalkeeper, Games = 100, Goals = 0, Assists = 0 },
                        new Player { Name = "Wojciech", LastName = "Szczęsny", Number = 2, Age = 26, Nationality = "England", Position = Position.Defender, Games = 80, Goals = 2, Assists = 5 },
                        new Player { Name = "Bogdan", LastName = "Wiśniewski", Number = 34, Age = 24, Nationality = "Poland", Position = Position.Midfielder, Games = 60, Goals = 10, Assists = 15 },
                        new Player { Name = "Kamil", LastName = "Grabara", Number = 12, Age = 27, Nationality = "Poland", Position = Position.Forward, Games = 90, Goals = 50, Assists = 20 },
                };

                context.Players.AddRange(players);
                context.SaveChanges();
            }
        }
    }
}
