using AutoMapper;
using GameStore.Bll.Dtos;
using GameStore.Dal.Entities;
using GameStore.Repository.Repositories.PlatformRepositoy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Bll.Services.PlatformService
{
    public class PlatformService : IPlatformService
    {
        private readonly IPlatformRepository _platformRepository;
        private readonly IMapper _mapper;


        public PlatformService(IPlatformRepository platformRepository, IMapper mapper)
        {
            _platformRepository = platformRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateAsync(PlatformCreateDto dto)
        {
            try
            {
                var platform = _mapper.Map<PlatformCreateDto, Platform>(dto);
                platform.Id = Guid.NewGuid();   
                await _platformRepository.CreateAsync(platform);
                return platform.Id; 
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating platform: {ex.Message}");
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var platform = await _platformRepository.GetByIdAsync(id);
                await _platformRepository.DeleteAsync(platform);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting platform: {ex.Message}");
            }
        }

        public async Task<List<PlatformDto>> GetAllAsync()
        {
            try
            {
                var platforms = await _platformRepository.GetAllAsync();
                return _mapper.Map<List<Platform>, List<PlatformDto>>(platforms);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving platforms: {ex.Message}");
            }
        }

        public async Task<List<PlatformDto>> GetByGameKeyAsync(string key)
        {
            try
            {
                var platforms = await _platformRepository.GetByGameKeyAsync(key);
                return _mapper.Map<List<Platform>, List<PlatformDto>>(platforms);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving platforms by game key: {ex.Message}");
            }
        }

        public async Task<PlatformDto> GetByIdAsync(Guid id)
        {
            try
            {
                var platform = await _platformRepository.GetByIdAsync(id);
                if (platform == null) throw new Exception("Platform not found");
                return _mapper.Map<Platform, PlatformDto>(platform);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving platform by ID: {ex.Message}");
            }
        }

        public async Task UpdateAsync(PlatformCreateDto dto)
        {
            try
            {
                var platform = _mapper.Map<PlatformCreateDto, Platform>(dto);
                await _platformRepository.UpdateAsync(platform);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating platform: {ex.Message}");
            }
        }
    }
}
