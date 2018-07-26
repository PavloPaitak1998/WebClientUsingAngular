using AutoMapper;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Shared.DTO;
using Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class StewardessService : IStewardessService
    {
        IRepository<Stewardess> stewardessRepository;
        IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<StewardessDTO, Stewardess>()).CreateMapper();

        public StewardessService(IRepository<Stewardess> _stewardessRepository)
        {
            stewardessRepository = _stewardessRepository;
        }

        public async Task<StewardessDTO> GetEntityAsync(int id)
        {
            var stewardess = await stewardessRepository.GetAsync(id);

            if (stewardess == null)
                throw new ValidationException($"Stewardess with this id {id} not found");

            return mapper.Map<StewardessDTO>(stewardess);
        }

        public async Task<IEnumerable<StewardessDTO>> GetEntitiesAsync()
        {
            return mapper.Map<IEnumerable<Stewardess>, List<StewardessDTO>>(await stewardessRepository.GetAllAsync());
        }

        public async Task CreateEntityAsync(StewardessDTO stewardessDTO)
        {
            await stewardessRepository.AddAsync(mapper.Map<Stewardess>(stewardessDTO)).ConfigureAwait(false);
        }

        public async Task UpdateEntityAsync(int id, StewardessDTO stewardessDTO)
        {
            var stewardess = await stewardessRepository.GetAsync(id);

            if (stewardess == null)
                throw new ValidationException($"Flight with this number {id} not found");

            if (stewardessDTO.FirstName != null)
                stewardess.FirstName = stewardessDTO.FirstName;
            if (stewardessDTO.LastName != null)
                stewardess.LastName = stewardessDTO.LastName;
            if (stewardessDTO.BirthDate != DateTime.MinValue)
                stewardess.BirthDate = stewardessDTO.BirthDate;
            if (stewardessDTO.CrewId >0)
                stewardess.CrewId = stewardessDTO.CrewId;

            await stewardessRepository.UpdateAsync(stewardess).ConfigureAwait(false);
        }

        public async Task DeleteAllEntitiesAsync()
        {
            await stewardessRepository.DeleteAllAsync().ConfigureAwait(false);
        }

        public async Task DeleteEntityAsync(int id)
        {
            var stewardess = await stewardessRepository.GetAsync(id);

            if (stewardess == null)
                throw new ValidationException($"Stewardess with this id {id} not found");

            await stewardessRepository.DeleteAsync(stewardess).ConfigureAwait(false);
        }
    }
}
