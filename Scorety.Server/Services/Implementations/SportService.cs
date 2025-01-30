using Microsoft.EntityFrameworkCore;
using Scorety.Server.Services.Interfaces;
using Scorety.Server.Data.Repositories.Interfaces;
using Scorety.Server.Models;
using Scorety.Server.DTOs;
using AutoMapper;

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

        public async Task<Sport> GetSportByNameAsync(string name)
        {
            return await _sportRepository.GetByNameAsync(name);
        }

        public async Task<Sport> CreateSportAsync(CreateSportDto sportDto)
        {
            var sport = _mapper.Map<Sport>(sportDto);

            await _sportRepository.CreateAsync(sport);
            return sport;
        }

        public async Task<Sport> UpdateSportAsync(Guid id, UpdateSportDto sportDto)
        {
            var sport = await _sportRepository.GetByIdAsync(id);

            sport.Description = sportDto.Description;
            sport.IconUrl = sportDto.IconUrl;
            sport.IsActive = sportDto.IsActive;
            sport.IsPopular = sportDto.IsPopular;

            await _sportRepository.UpdateAsync(sport);
            return sport;
        }

        public async Task DeleteSportAsync(Guid id)
        {
            await _sportRepository.DeleteAsync(id);
        }
    }
}