using Shared.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IDepartureService
    {
        Task<DepartureDTO> GetEntityAsync(int id);
        Task<IEnumerable<DepartureDTO>> GetEntitiesAsync();
        Task CreateEntityAsync(DepartureDTO departureDTO);
        Task UpdateEntityAsync(int id, DepartureDTO departureDTO);
        Task DeleteAllEntitiesAsync();
        Task DeleteEntityAsync(int id);

    }
}
