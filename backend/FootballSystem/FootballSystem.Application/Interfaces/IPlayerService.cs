using FootballSystem.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballSystem.Application.Interfaces
{
    public interface IPlayerService
    {
        Task<IEnumerable<PlayerDto>> GetAllAsync();
        Task<PlayerDto?> GetByIdAsync(int id);
        Task<PlayerDto> CreateAsync(CreatePlayerDto player);
        Task<PlayerDto?> UpdateAsync(UpdatePlayerDto player, int id);
        Task<bool> DeleteAsync(int id);
    }
}
