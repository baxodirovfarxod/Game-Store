using AutoMapper;
using GameStore.Bll.Dtos;
using GameStore.Dal.Entities;
using GameStore.Repository.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Bll.Services
{
    public class PlatformService : IPlatformService
    {
        private readonly IPlatformRepository _platformRepository;
        private readonly IMapper _mapping;

        public PlatformService(IPlatformRepository platformRepository, IMapper mapping)
        {
            _platformRepository = platformRepository;
            _mapping = mapping;
        }

        public async Task CreateAsync(PlatformCreateDto dto)
        {
            try
            {
                var platform = _mapping.Map<Platform>(dto);
                await _platformRepository.CreateAsync(platform);
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
                if (platform == null)
                {
                    throw new Exception("Platform not found");
                }
                await _platformRepository.DeleteAsync(platform);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting platform: {ex.Message}");
            }
        }

        public async Task<IEnumerable<PlatformDto>> GetAllAsync()
        {
            try
            {
                var platforms = await _platformRepository.GetAllAsync(); // bunda ToListAsync bo'lishi kerak
                return _mapping.Map<IEnumerable<PlatformDto>>(platforms);
            }
            catch (Exception ex)
            {
                // Stack trace yo'qolmasligi uchun inner exceptionni qo'shib qaytaramiz
                throw new Exception("Error retrieving platforms.", ex);
            }
        }


        public async Task<IEnumerable<PlatformDto>> GetByGameKeyAsync(string key)
        {
            try
            {
                var platforms = await _platformRepository.GetByGameKeyAsync(key);
                return _mapping.Map<IEnumerable<PlatformDto>>(platforms);
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
                if (platform == null)
                {
                    throw new Exception("Platform not found");
                }
                return _mapping.Map<PlatformDto>(platform);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving platform: {ex.Message}");
            }
        }

        public async Task UpdateAsync(PlatformDto dto)
        {
            try
            {
                var platform = await _platformRepository.GetByIdAsync(dto.Id);
                if (platform == null)
                {
                    throw new Exception("Platform not found");
                }
                platform.Type = dto.Type;
                await _platformRepository.UpdateAsync(platform);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating platform: {ex.Message}");
            }
        }
    }
}
