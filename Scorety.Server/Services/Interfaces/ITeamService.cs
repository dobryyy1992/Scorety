using Microsoft.AspNetCore.JsonPatch;
using Scorety.Server.DTOs;

namespace Scorety.Server.Services.Interfaces
{
    public interface ITeamService
        {
        Task<IEnumerable<TeamDto>> GetAllTeamsAsync(Guid sportId);
        Task<TeamDto?> GetTeamByIdAsync(Guid id);
        Task<TeamDto> CreateTeamAsync(CreateTeamDto team);
        Task<TeamDto?> UpdateTeamAsync(Guid id, UpdateTeamDto team);
        Task<(bool Success, string Message, TeamDto? Data)> PatchTeamAsync(Guid id, JsonPatchDocument<UpdateTeamDto> patchDoc);
        Task<bool> DeleteTeamAsync(Guid id);
    }
}