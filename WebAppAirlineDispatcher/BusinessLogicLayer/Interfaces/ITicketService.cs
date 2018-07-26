using Shared.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface ITicketService
    {
        Task<TicketDTO> GetEntityAsync(int id);
        Task<IEnumerable<TicketDTO>> GetEntitiesAsync();
        Task CreateEntityAsync(TicketDTO entity);
        Task UpdateEntityAsync(int id, TicketDTO entity);
        Task DeleteEntityAsync(int id);
        Task DeleteAllEntitiesAsync();
    }
}
