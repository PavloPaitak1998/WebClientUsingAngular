using AutoMapper;
using BusinessLogicLayer.Helper;
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
    public class FlightService:IFlightService
    {
        private IRepository<Flight> flightRepository;
        IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<FlightDTO,Flight > ().ForMember(x=>x.Tickets,opt=>opt.Ignore())).CreateMapper();

        public FlightService(IRepository<Flight> _flightRepository)
        {
            flightRepository = _flightRepository;
        }

        public async Task<FlightDTO> GetEntityAsync(int id)
        {
            var flight = await flightRepository.GetAsync(id);

            if (flight == null)
                throw new ValidationException($"Flight with this id {id} not found");

            return mapper.Map<FlightDTO>(flight);

        }

        public async Task<IEnumerable<FlightDTO>> GetEntitiesAsync()
        {
            //await ClassHelper.MehtodHelperDelay(7000);

            return mapper.Map<IEnumerable<Flight>, List<FlightDTO>>(await flightRepository.GetAllAsync());
        }

        public async Task CreateEntityAsync(FlightDTO flightDTO)
        {
            await flightRepository.AddAsync(mapper.Map<FlightDTO,Flight>(flightDTO));
        }

        public async Task UpdateEntityAsync(int id,FlightDTO flightDTO)
        {
            var flight = await flightRepository.GetAsync(id);

            if (flight == null)
                throw new ValidationException($"Flight with this id {id} not found");

            if (flightDTO.Number >0)
                flight.Number = flightDTO.Number;
            if (flightDTO.PointOfDeparture!=null)
                flight.PointOfDeparture = flightDTO.PointOfDeparture;
            if (flightDTO.Destination != null)
                flight.Destination = flightDTO.Destination;
            if (flightDTO.DepartureTime != DateTime.MinValue)
                flight.DepartureTime = flightDTO.DepartureTime;
            if (flightDTO.DestinationTime != DateTime.MinValue)
                flight.DestinationTime = flightDTO.DestinationTime;

            await flightRepository.UpdateAsync(flight).ConfigureAwait(false);
        }

        public async Task DeleteAllEntitiesAsync()
        {
            await flightRepository.DeleteAllAsync().ConfigureAwait(false);
        }

        public async Task DeleteEntityAsync(int id)
        {
            var flight = await flightRepository.GetAsync(id);

            if (flight == null)
                throw new ValidationException($"Flight with this id {id} not found");

            await flightRepository.DeleteAsync(flight).ConfigureAwait(false);
        }

    }
}
