using Microsoft.EntityFrameworkCore;
using Scorety.Server.Services.Interfaces;
using Scorety.Server.Data.Repositories.Interfaces;
using Scorety.Server.Models;
using Scorety.Server.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Scorety.Server.Services.Implementations
{
    public class SportService : ISportService
    {
        private readonly ISportRepository _sportRepository;
        private readonly IMapper _mapper;

        public SportService(ISportRepository sportRepository, IMapper mapper)
        {
            _sportRepository = sportRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SportDto>> GetAllSportsAsync()
        {
            var sports = await _sportRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<SportDto>>(sports);
        }

        public async Task<SportDto> GetSportByIdAsync(Guid id)
        {
            var sport = await _sportRepository.GetByIdAsync(id);
            return sport == null ? null : _mapper.Map<SportDto>(sport);
        }

        public async Task<SportDto> CreateSportAsync(CreateSportDto sportDto)
        {
            var sport = _mapper.Map<Sport>(sportDto);

            await _sportRepository.CreateAsync(sport);
            return _mapper.Map<SportDto>(sport);
        }

        public async Task<UpdateSportDto> UpdateSportAsync(Guid id, UpdateSportDto sportDto)
        {
            var sport = await _sportRepository.GetByIdAsync(id);

            if(sport == null)
                return null;

            _mapper.Map(sportDto, sport);

            await _sportRepository.UpdateAsync(sport);
            return _mapper.Map<UpdateSportDto>(sport);
        }

        public async Task<(bool Success, string Message, UpdateSportDto? Data)> PatchSportAsync(Guid id, JsonPatchDocument<UpdateSportDto> patchDoc)
        {
            var sport = await _sportRepository.GetByIdAsync(id);

            if (sport == null)
                return (false, "Sport not found", null);

            var sportDto = _mapper.Map<UpdateSportDto>(sport);
            patchDoc.ApplyTo(sportDto);

            var validationContext = new ValidationContext(sportDto);
            var validationResults = new List<ValidationResult>();
            if (!Validator.TryValidateObject(sportDto, validationContext, validationResults, false))
            {
                return (false, "Invalid patch data.", null);
            }

            _mapper.Map(sportDto, sport);

            await _sportRepository.UpdateAsync(sport);

            return (true, "Sport updated successfully.", _mapper.Map<UpdateSportDto>(sport));
        }

        public async Task<bool> DeleteSportAsync(Guid id)
        {
            return await _sportRepository.DeleteAsync(id);
        }
    }
}