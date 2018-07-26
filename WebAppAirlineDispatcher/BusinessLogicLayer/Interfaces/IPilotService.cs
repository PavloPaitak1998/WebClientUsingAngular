using Shared.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IPilotService
    {
        Task<PilotDTO> GetEntityAsync(int id);
        Task<IEnumerable<PilotDTO>> GetEntitiesAsync();
        Task CreateEntityAsync(PilotDTO entity);
        Task UpdateEntityAsync(int id, PilotDTO entity);
        Task DeleteEntityAsync(int id);
        Task DeleteAllEntitiesAsync();

    }
}
