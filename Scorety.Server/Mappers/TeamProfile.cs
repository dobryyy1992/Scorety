using AutoMapper;
using Scorety.Server.DTOs;
using Scorety.Server.Models;

namespace Scorety.Server.Mappers
{
    public class TeamProfile : Profile
    {
        public TeamProfile()
        {
            CreateMap<Team, TeamDto>();
            CreateMap<CreateTeamDto, Team>();
            CreateMap<UpdateTeamDto, Team>();
            CreateMap<Team, CreateTeamDto>();
            CreateMap<Team, UpdateSportDto>();

            // NBA Team mappings
            CreateMap<NBATeam, NBATeamDto>();
            CreateMap<NBATeamDto, NBATeam>();
        }
    }
}
