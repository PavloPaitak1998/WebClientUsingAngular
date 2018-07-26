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
    public class PilotService : IPilotService
    {
        IRepository<Pilot> pilotRepository;
        IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<PilotDTO, Pilot>()).CreateMapper();

        public PilotService(IRepository<Pilot> _pilotRepository)
        {
            pilotRepository = _pilotRepository;
        }

        public async Task<PilotDTO> GetEntityAsync(int id)
        {
            var pilot = await pilotRepository.GetAsync(id);

            if (pilot == null)
                throw new ValidationException($"Pilot with this id {id} not found");

            return mapper.Map<PilotDTO>(pilot);
        }

        public async Task<IEnumerable<PilotDTO>> GetEntitiesAsync()
        {
            return mapper.Map<IEnumerable<Pilot>, List<PilotDTO>>(await pilotRepository.GetAllAsync());
        }

        public async Task CreateEntityAsync(PilotDTO pilotDTO)
        {
            await pilotRepository.AddAsync(mapper.Map<Pilot>(pilotDTO)).ConfigureAwait(false);
        }

        public async Task UpdateEntityAsync(int id,PilotDTO pilotDTO)
        {
            var pilot = await pilotRepository.GetAsync(id);

            if (pilot == null)
                throw new ValidationException($"Pilot with this id {id} not found");

            if (pilotDTO.CrewId >0)
                pilot.CrewId  = pilotDTO.CrewId;
            if (pilotDTO.FirstName != null)
                pilot.FirstName = pilotDTO.FirstName;
            if (pilotDTO.LastName != null)
                pilot.LastName = pilotDTO.LastName;
            if (pilotDTO.BirthDate != DateTime.MinValue)
                pilot.BirthDate = pilotDTO.BirthDate;
            if (pilotDTO.Experience != null)
                pilot.Experience = pilotDTO.Experience.Value;

            await pilotRepository.UpdateAsync(pilot).ConfigureAwait(false);
        }

        public async Task DeleteAllEntitiesAsync()
        {
            await pilotRepository.DeleteAllAsync().ConfigureAwait(false);
        }

        public async Task DeleteEntityAsync(int id)
        {
            var pilot = await pilotRepository.GetAsync(id);

            if (pilot == null)
                throw new ValidationException($"Pilot with this id {id} not found");

            await pilotRepository.DeleteAsync(pilot).ConfigureAwait(false);
        }
    }
}
