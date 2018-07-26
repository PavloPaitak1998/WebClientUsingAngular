using Shared.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IPlaneService
    {
        Task<PlaneDTO> GetEntityAsync(int id);
        Task<IEnumerable<PlaneDTO>> GetEntitiesAsync();
        Task CreateEntityAsync(PlaneDTO entity);
        Task UpdateEntityAsync(int id, PlaneDTO entity);
        Task DeleteEntityAsync(int id);
        Task DeleteAllEntitiesAsync();
    }
}
