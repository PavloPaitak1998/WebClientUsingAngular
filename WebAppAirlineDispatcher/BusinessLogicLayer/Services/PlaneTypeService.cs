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
    public class PlaneTypeService: IPlaneTypeService
    {
        IRepository<PlaneType> planeTypeRepository;
        IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<PlaneTypeDTO, PlaneType>()).CreateMapper();

        public PlaneTypeService(IRepository<PlaneType> _planeTypeRepository)
        {
            planeTypeRepository = _planeTypeRepository;
        }

        public async Task<PlaneTypeDTO> GetEntityAsync(int id)
        {
            var planeType = await planeTypeRepository.GetAsync(id);

            if (planeType == null)
                throw new ValidationException($"Plane Type with this id {id} not found");

            return mapper.Map<PlaneTypeDTO>(planeType);
        }

        public async Task<IEnumerable<PlaneTypeDTO>> GetEntitiesAsync()
        {
            return mapper.Map<IEnumerable<PlaneType>, List<PlaneTypeDTO>>(await planeTypeRepository.GetAllAsync());
        }

        public async Task CreateEntityAsync(PlaneTypeDTO planeTypeDTO)
        {
            await planeTypeRepository.AddAsync(mapper.Map<PlaneType>(planeTypeDTO)).ConfigureAwait(false);
        }

        public async Task UpdateEntityAsync(int id, PlaneTypeDTO planeTypeDTO)
        {
            var planeType = await planeTypeRepository.GetAsync(id);

            if (planeType == null)
                throw new ValidationException($"Plane Type with this id {id} not found");

            if (planeTypeDTO.Model != null)
                planeType.Model = planeTypeDTO.Model;
            if (planeTypeDTO.Seats >0)
                planeType.Seats = planeTypeDTO.Seats;
            if (planeTypeDTO.Carrying >0)
                planeType.Carrying = planeTypeDTO.Carrying;

           await  planeTypeRepository.UpdateAsync(planeType).ConfigureAwait(false);
        }

        public async Task DeleteAllEntitiesAsync()
        {
            await planeTypeRepository.DeleteAllAsync().ConfigureAwait(false);
        }

        public async Task DeleteEntityAsync(int id)
        {
            var planeType = await planeTypeRepository.GetAsync(id);

            if (planeType == null)
                throw new ValidationException($"Plane Type with this id {id} not found");

            await planeTypeRepository.DeleteAsync(planeType).ConfigureAwait(false);
        }
    }
}
