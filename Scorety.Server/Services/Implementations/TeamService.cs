using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Scorety.Server.Data.Repositories.Interfaces;
using Scorety.Server.DTOs;
using Scorety.Server.Models;
using Scorety.Server.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Scorety.Server.Services.Implementations
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IMapper _mapper;

        public TeamService(ITeamRepository teamRepository, IMapper mapper)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TeamDto>> GetAllTeamsAsync(Guid sportId)
        {
            var teams = await _teamRepository.GetAllAsync(sportId);
            return _mapper.Map<IEnumerable<TeamDto>>(teams);
        }

        public async Task<TeamDto?> GetTeamByIdAsync(Guid id)
        {
            var team = await _teamRepository.GetByIdAsync(id);
            return team == null ? null : _mapper.Map<TeamDto>(team);
        }

        public async Task<TeamDto> CreateTeamAsync(CreateTeamDto teamDto)
        {
            var team = _mapper.Map<Team>(teamDto);

            await _teamRepository.CreateAsync(team);
            return _mapper.Map<TeamDto>(team);
        }

        public async Task<TeamDto?> UpdateTeamAsync(Guid id, UpdateTeamDto teamDto)
        {
            var team = await _teamRepository.GetByIdAsync(id);

            if (team == null)
                return null;

            _mapper.Map(teamDto, team);

            await _teamRepository.UpdateAsync(team);
            return _mapper.Map<TeamDto>(team);
        }

        public async Task<(bool Success, string Message, TeamDto? Data)> PatchTeamAsync(Guid id, JsonPatchDocument<UpdateTeamDto> patchDoc)
        {
            var team = await _teamRepository.GetByIdAsync(id);

            if (team == null)
                return (false, "Team not found", null);

            var teamDto = _mapper.Map<UpdateTeamDto>(team);
            patchDoc.ApplyTo(teamDto);

            var validationContext = new ValidationContext(teamDto);
            var validationResults = new List<ValidationResult>();

            if (!Validator.TryValidateObject(teamDto, validationContext, validationResults, false))
            {
                return (false, "Invalid patch data.", null);
            }

            _mapper.Map(teamDto, team);

            await _teamRepository.UpdateAsync(team);
            return (true, "Team updated successfully", _mapper.Map<TeamDto>(team));
        }

        public async Task<bool> DeleteTeamAsync(Guid id)
        {
            try
            {
                return await _teamRepository.DeleteAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return false;
            }

        }
    }
}