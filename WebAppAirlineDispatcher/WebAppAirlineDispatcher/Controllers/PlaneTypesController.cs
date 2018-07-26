using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;
using Shared.Exceptions;
using System.Threading.Tasks;

namespace WebAppAirlineDispatcher.Controllers
{
    [Route("api/[controller]")]
    public class PlaneTypesController : Controller
    {
        IPlaneTypeService planeTypeService;

        public PlaneTypesController(IPlaneTypeService serv)
        {
            planeTypeService = serv;
        }

        // GET: api/planetypes
        public async Task<IActionResult> Get()
        {
            return Ok(await planeTypeService.GetEntitiesAsync());
        }

        // GET api/planetypes/5
        [HttpGet("{id}", Name = "GetPlaneType")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var flight = await planeTypeService.GetEntityAsync(id);
                return Ok(flight);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }
        }

        // POST api/planetypes
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]PlaneTypeDTO planeTypeDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await planeTypeService.CreateEntityAsync(planeTypeDTO);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }

            return Ok(planeTypeDTO);
        }

        // PUT api/planetypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]PlaneTypeDTO planeTypeDTO)
        {
            planeTypeDTO.Id = id;
            try
            {
                await planeTypeService.UpdateEntityAsync(id,planeTypeDTO);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }

            return Ok(await planeTypeService.GetEntityAsync(id));
        }

        // DELETE api/planetypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await planeTypeService.DeleteEntityAsync(id);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }
            return NoContent();
        }

        // DELETE api/planetypes
        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            await planeTypeService.DeleteAllEntitiesAsync();
            return NoContent();
        }
    }
}