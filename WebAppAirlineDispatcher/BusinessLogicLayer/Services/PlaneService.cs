using AutoMapper;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Shared.DTO;
using Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class PlaneService: IPlaneService
    {
        IRepository<Plane> planeRepository;
        IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<PlaneDTO, Plane>()).CreateMapper();

        public PlaneService(IRepository<Plane> _planeRepository)
        {
            planeRepository = _planeRepository;
        }

        public async Task<PlaneDTO> GetEntityAsync(int id)
        {
            var plane = await planeRepository.GetAsync(id);

            if (plane == null)
                throw new ValidationException($"Plane with this id {id} not found");

            return mapper.Map<PlaneDTO>(plane);
        }

        public async Task<IEnumerable<PlaneDTO>> GetEntitiesAsync()
        {
            return mapper.Map<IEnumerable<Plane>, List<PlaneDTO>>(await planeRepository.GetAllAsync());
        }

        public async Task CreateEntityAsync(PlaneDTO planeDTO)
        {
            await planeRepository.AddAsync(mapper.Map<Plane>(planeDTO)).ConfigureAwait(false);
        }

        public async Task UpdateEntityAsync(int id, PlaneDTO planeDTO)
        {
            var plane = await planeRepository.GetAsync(id);

            if (plane == null)
                throw new ValidationException($"Plane with this id {id} not found");

            if (planeDTO.PlaneTypeId > 0)
                plane.PlaneTypeId = planeDTO.PlaneTypeId;
            if (planeDTO.Name != null)
                plane.Name = planeDTO.Name;
            if (planeDTO.Lifetime != TimeSpan.Parse("00:00:00"))
                plane.Lifetime = planeDTO.Lifetime;
            if (planeDTO.ReleaseDate != DateTime.MinValue)
                plane.ReleaseDate = planeDTO.ReleaseDate;

            await planeRepository.UpdateAsync(plane).ConfigureAwait(false);
        }

        public async Task DeleteAllEntitiesAsync()
        {
            await planeRepository.DeleteAllAsync();
        }

        public async Task DeleteEntityAsync(int id)
        {
            var plane = await planeRepository.GetAsync(id);

            if (plane == null)
                throw new ValidationException($"Plane with this id {id} not found");

            await planeRepository.DeleteAsync(plane).ConfigureAwait(false);
        }
    }
}
