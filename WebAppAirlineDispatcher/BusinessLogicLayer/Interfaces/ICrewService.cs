using Shared.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface ICrewService
    {
        Task<CrewDTO> GetEntityAsync(int id);
        Task<IEnumerable<CrewDTO>> GetEntitiesAsync();
        Task CreateEntityAsync(CrewDTO crewDTO);
        Task UpdateEntityAsync(int id, CrewDTO crewDTO);
        Task DeleteAllEntitiesAsync();
        Task DeleteEntityAsync(int id);
        Task Add10CrewIntoDbAndFileAsync();
    }
}
