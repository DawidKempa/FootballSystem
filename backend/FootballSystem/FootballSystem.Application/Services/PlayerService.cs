using AutoMapper;
using FootballSystem.Application.DTOs;
using FootballSystem.Application.Interfaces;
using FootballSystem.Domain.Entities;
using FootballSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballSystem.Application.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IMapper _mapper;

        public PlayerService(IPlayerRepository playerRepository, IMapper mapper)
        {
            _playerRepository = playerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PlayerDto>> GetAllAsync()
        {
            var players = await _playerRepository.GetAllAsync();

           /* return player.Select(x => new PlayerDto
            {
                Id = x.Id,
                Name = x.Name,
                LastName = x.LastName,
                Number = x.Number,
                Age = x.Age,
                Nationality = x.Nationality,
                Position = x.Position.ToString(),
                Games = x.Games,
                Goals = x.Goals,
                Assists = x.Assists,
            });
           */

            return _mapper.Map<IEnumerable<PlayerDto>>(players);
        }
        public async Task<PlayerDto?> GetByIdAsync(int id)
        {
            var player = await _playerRepository.GetByIdAsync(id);
            if (player == null) return null;
            /*
            return new PlayerDto
            {
                Id = player.Id,
                Name = player.Name,
                LastName = player.LastName,
                Number = player.Number,
                Age = player.Age,
                Nationality = player.Nationality,
                Position = player.Position.ToString(),
                Games = player.Games,
                Goals = player.Goals,
                Assists = player.Assists,
            };
            */
            return _mapper.Map<PlayerDto>(player);
        }

        public async Task<PlayerDto> CreateAsync(CreatePlayerDto playerDto)
        {
            if (await _playerRepository.NumberExistsAsync(playerDto.Number))
                throw new Exception("Numer zawodnika juz istnieje");
            /*
            var player = new Player
            {
                Name = playerDto.Name,
                LastName = playerDto.LastName,
                Number = playerDto.Number,
                Age= playerDto.Age,
                Nationality = playerDto.Nationality,
                Position = Enum.Parse<Position>(playerDto.Position),
                Games = playerDto.Games,
                Goals = playerDto.Goals,
                Assists = playerDto.Assists,
            };
            */
            var player = _mapper.Map<Player>(playerDto);
            var created = await _playerRepository.AddAsync(player);

            /*
            return new PlayerDto
            {
                Id = created.Id,
                Name = created.Name,
                LastName = created.LastName,
                Number = created.Number,
                Age = created.Age,
                Nationality = created.Nationality,
                Position = created.Position.ToString(),
                Games = created.Games,
                Goals = created.Goals,
                Assists = created.Assists,
            };
            */
            return _mapper.Map<PlayerDto>(created);
        }

        public async Task<PlayerDto?> UpdateAsync(UpdatePlayerDto playerDto, int id)
        {
            var existingPlayer = await _playerRepository.GetByIdAsync(id);

            if (existingPlayer == null) return null;

            if (await _playerRepository.NumberExistsAsync(playerDto.Number, id))
                throw new ArgumentException("Numer zawodnika jest już zajęty");
            /*
            existingPlayer.Name = playerDto.Name;
            existingPlayer.LastName = playerDto.LastName;
            existingPlayer.Number = playerDto.Number;
            existingPlayer.Age = playerDto.Age;
            existingPlayer.Nationality = playerDto.Nationality;
            existingPlayer.Position = Enum.Parse<Position>(playerDto.Position);
            existingPlayer.Games = playerDto.Games;
            existingPlayer.Goals = playerDto.Goals;
            existingPlayer.Assists = playerDto.Assists;
            */

            _mapper.Map(playerDto, existingPlayer);

            await _playerRepository.UpdateAsync(existingPlayer);

            /*
            return new PlayerDto
            {
                Id = existingPlayer.Id,
                Name = existingPlayer.Name,
                LastName = existingPlayer.LastName,
                Number = existingPlayer.Number,
                Age = existingPlayer.Age,
                Nationality = existingPlayer.Nationality,
                Position = existingPlayer.Position.ToString(),
                Games = existingPlayer.Games,
                Goals = existingPlayer.Goals,
                Assists = existingPlayer.Assists,
            };
            */
            return _mapper.Map<PlayerDto>(existingPlayer);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _playerRepository.DeleteAsync(id);
        }
    }

}
