using FootballSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballSystem.Domain.Interfaces
{
    public interface IPlayerRepository
    {
        Task<IEnumerable<Player>> GetAllAsync();
        Task<Player> GetByIdAsync(int id);
        Task<Player> AddAsync(Player player);
        Task<Player> UpdateAsync(Player player);
        Task<bool> DeleteAsync(int id);
        Task<bool> NumberExistsAsync(int number, int? playerId = null);
    }
}
