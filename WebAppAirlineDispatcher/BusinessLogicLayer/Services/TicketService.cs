using AutoMapper;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Shared.DTO;
using Shared.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class TicketService : ITicketService
    {
        IRepository<Ticket> ticketRepository;
        IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<TicketDTO, Ticket>()).CreateMapper();

        public TicketService(IRepository<Ticket> _ticketRepository)
        {
            ticketRepository = _ticketRepository;
        }

        public async Task<TicketDTO> GetEntityAsync(int id)
        {
            var ticket = await ticketRepository.GetAsync(id);

            if (ticket == null)
                throw new ValidationException($"Ticket with this id {id} not found");

            return mapper.Map<TicketDTO>(ticket);
        }

        public async Task<IEnumerable<TicketDTO>> GetEntitiesAsync()
        {
            return mapper.Map<IEnumerable<Ticket>, List<TicketDTO>>(await ticketRepository.GetAllAsync());
        }

        public async Task CreateEntityAsync(TicketDTO ticketDTO)
        {
            await ticketRepository.AddAsync(mapper.Map<Ticket>(ticketDTO)).ConfigureAwait(false);
        }

        public async Task UpdateEntityAsync(int id, TicketDTO ticketDTO)
        {
            var ticket = await ticketRepository.GetAsync(id);

            if (ticket == null)
                throw new ValidationException($"Ticket with this id {id} not found");
            if (ticketDTO.Price > 0)
                ticket.Price = ticketDTO.Price;
            if (ticketDTO.FlightNumber > 0)
                ticket.FlightNumber = ticketDTO.FlightNumber;
            if (ticketDTO.FlightId > 0)
                ticket.FlightId = ticketDTO.FlightId;

            await ticketRepository.UpdateAsync(ticket).ConfigureAwait(false);
        }

        public async Task DeleteAllEntitiesAsync()
        {
            await ticketRepository.DeleteAllAsync().ConfigureAwait(false);
        }

        public async Task DeleteEntityAsync(int id)
        {
            var ticket = await ticketRepository.GetAsync(id);

            if (ticket == null)
                throw new ValidationException($"Ticket with this id {id} not found");

            await ticketRepository.DeleteAsync(ticket);
        }
    }
}
