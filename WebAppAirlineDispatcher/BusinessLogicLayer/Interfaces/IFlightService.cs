using Shared.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IFlightService
    {
        Task<FlightDTO> GetEntityAsync(int id);
        Task<IEnumerable<FlightDTO>> GetEntitiesAsync();
        Task CreateEntityAsync(FlightDTO flightDTO);
        Task UpdateEntityAsync(int id, FlightDTO flightDTO);
        Task DeleteAllEntitiesAsync();
        Task DeleteEntityAsync(int id);
    }
}
