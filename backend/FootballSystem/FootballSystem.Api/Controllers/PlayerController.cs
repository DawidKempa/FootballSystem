using FootballSystem.Domain.Entities;
using FootballSystem.Domain.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FootballSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController : Controller
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerController(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var player = await _playerRepository.GetAllAsync();
            return Ok(player);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var player = await _playerRepository.GetByIdAsync(id);
            if (player == null) return NotFound();
            return Ok(player);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Player player)
        {
            var createdPlayer = await _playerRepository.AddAsync(player);
            return CreatedAtAction(nameof(GetById), new { id = createdPlayer.Id }, createdPlayer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Player player)
        {
            if (id != player.Id) return BadRequest(); 
            var updatedPlayer = await _playerRepository.UpdateAsync(player);
            return Ok(player);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedPlayer = await _playerRepository.DeleteAsync(id);
            if (!deletedPlayer) return NotFound();
            return NoContent();
        }
        

    }
}
