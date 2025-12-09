using FootballSystem.Domain.Entities;
using FootballSystem.Domain.Interfaces;
using FootballSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballSystem.Infrastructure.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly FootballContext _context;

        public PlayerRepository(FootballContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Player>> GetAllAsync()
        {
            return await _context.Players.ToListAsync();
        }
        public async Task<Player> GetByIdAsync(int id)
        {
            return await _context.Players.FindAsync(id);
        }

        public async Task<Player> AddAsync(Player player)
        {
            _context.Players.Add(player);
            await _context.SaveChangesAsync();
            return player;
        }

        public async Task<Player> UpdateAsync(Player player)
        {
            _context.Entry(player).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return player;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var player = await _context.Players.FindAsync(id);
            if (player == null) return false;
            _context.Players.Remove(player);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> NumberExistsAsync(int number, int? playerId = null)
        {
            return await _context.Players.AnyAsync(p => p.Number == number && (playerId == null || p.Id != playerId));
        }
    }
}
