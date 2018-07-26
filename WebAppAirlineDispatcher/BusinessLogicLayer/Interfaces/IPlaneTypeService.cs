using Shared.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IPlaneTypeService
    {
        Task<PlaneTypeDTO> GetEntityAsync(int id);
        Task<IEnumerable<PlaneTypeDTO>> GetEntitiesAsync();
        Task CreateEntityAsync(PlaneTypeDTO entity);
        Task UpdateEntityAsync(int id, PlaneTypeDTO entity);
        Task DeleteEntityAsync(int id);
        Task DeleteAllEntitiesAsync();
    }
}
