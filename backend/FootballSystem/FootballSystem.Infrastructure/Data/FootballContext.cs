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
    }
}
