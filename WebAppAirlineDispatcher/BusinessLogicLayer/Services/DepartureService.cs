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
    public class DepartureService : IDepartureService
    {
        private IRepository<Departure> departureRepository;
        IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<DepartureDTO, Departure>()).CreateMapper();

        public DepartureService(IRepository<Departure> _departureRepository)
        {
            departureRepository = _departureRepository;
        }

        public async Task<DepartureDTO> GetEntityAsync(int id)
        {
            var departure = await departureRepository.GetAsync(id);

            if (departure == null)
                throw new ValidationException($"Departure with this id {id} not found");

            return mapper.Map<DepartureDTO>(departure);
        }

        public async Task<IEnumerable<DepartureDTO>> GetEntitiesAsync()
        {
            return mapper.Map<IEnumerable<Departure>, List<DepartureDTO>>(await departureRepository.GetAllAsync());
        }

        public async Task CreateEntityAsync(DepartureDTO departureDTO)
        {
            await departureRepository.AddAsync(mapper.Map<Departure>(departureDTO)).ConfigureAwait(false);
        }

        public async Task UpdateEntityAsync(int id,DepartureDTO departureDTO)
        {
            var departure = await departureRepository.GetAsync(id);

            if (departure == null)
                throw new ValidationException($"Departure with this id {id} not found");

            if (departureDTO.FlightNumber > 0)
                departure.FlightNumber = departureDTO.FlightNumber;
            if (departureDTO.CrewId > 0)
                departure.CrewId = departureDTO.CrewId;
            if (departureDTO.FlightId > 0)
                departure.FlightId = departureDTO.FlightId;
            if (departureDTO.PlaneId > 0)
                departure.PlaneId = departureDTO.PlaneId;
            if (departureDTO.Time != DateTime.MinValue)
                departure.Time = departureDTO.Time;

            await departureRepository.UpdateAsync(departure).ConfigureAwait(false);
        }

        public async Task DeleteAllEntitiesAsync()
        {
            await departureRepository.DeleteAllAsync().ConfigureAwait(false);
        }

        public async Task DeleteEntityAsync(int id)
        {
            var departure = await departureRepository.GetAsync(id);

            if (departure == null)
                throw new ValidationException($"Departure with this id {id} not found");

            await departureRepository.DeleteAsync(departure).ConfigureAwait(false);
        }
    }
}
