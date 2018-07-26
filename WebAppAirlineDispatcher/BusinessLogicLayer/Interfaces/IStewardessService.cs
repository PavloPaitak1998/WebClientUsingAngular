using Shared.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IStewardessService
    {
        Task<StewardessDTO> GetEntityAsync(int id);
        Task<IEnumerable<StewardessDTO>> GetEntitiesAsync();
        Task CreateEntityAsync(StewardessDTO stewardessDTO);
        Task UpdateEntityAsync(int id, StewardessDTO stewardessDTO);
        Task DeleteEntityAsync(int id);
        Task DeleteAllEntitiesAsync();
    }
}
