using FootballSystem.Application.DTOs;
using FootballSystem.Application.Interfaces;
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
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var player = await _playerService.GetAllAsync();
            return Ok(player);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var player = await _playerService.GetByIdAsync(id);
            if (player == null) return NotFound();
            return Ok(player);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePlayerDto player)
        {
            var createdPlayer = await _playerService.CreateAsync(player);
            return CreatedAtAction(nameof(GetById), new { id = createdPlayer.Id }, createdPlayer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update( int id, UpdatePlayerDto player)
        {
            if (id != player.Id) return BadRequest(); 
            var updatedPlayer = await _playerService.UpdateAsync(player, id);

            if ((updatedPlayer == null))
                return NotFound();
            
            return Ok(updatedPlayer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedPlayer = await _playerService.DeleteAsync(id);
            if (!deletedPlayer) return NotFound();
            return NoContent();
        }
        

    }
}
