using Microsoft.AspNetCore.JsonPatch;
using Scorety.Server.DTOs;

namespace Scorety.Server.Services.Interfaces
{
    public interface ISportService
    {
        Task<IEnumerable<SportDto>> GetAllSportsAsync();
        Task<SportDto?> GetSportByIdAsync(Guid id);
        Task<SportDto> CreateSportAsync(CreateSportDto sport);
        Task<UpdateSportDto?> UpdateSportAsync(Guid id, UpdateSportDto sport);
        Task<(bool Success, string Message, UpdateSportDto? Data)> PatchSportAsync(Guid id, JsonPatchDocument<UpdateSportDto> patchDoc);
        Task<bool> DeleteSportAsync(Guid id);
    }
}