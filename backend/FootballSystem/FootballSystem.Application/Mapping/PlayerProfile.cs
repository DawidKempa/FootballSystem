using AutoMapper;
using FootballSystem.Application.DTOs;
using FootballSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballSystem.Application.Mapping
{
    public class PlayerProfile : Profile
    {
        public PlayerProfile()
        {
            CreateMap<Player, PlayerDto>().ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position.ToString()));

            CreateMap<CreatePlayerDto, Player>().ForMember(dest => dest.Position, opt => opt.MapFrom(src => Enum.Parse<Position>(src.Position)));

            CreateMap<UpdatePlayerDto, Player>().ForMember(dest => dest.Position, opt => opt.MapFrom(src => Enum.Parse<Position>(src.Position)));
        }
    }
}
