using AutoMapper;
using Scorety.Server.Models;
using Scorety.Server.DTOs;

namespace Scorety.Server.Mappers
{
    public class SportProfile : Profile
    {
        public SportProfile() 
        {
            CreateMap<Sport, SportDto>();
            CreateMap<CreateSportDto, Sport>();
            CreateMap<UpdateSportDto, Sport>();
            CreateMap<Sport, CreateSportDto>();
            CreateMap<Sport, UpdateSportDto>();
        }
    }
}
