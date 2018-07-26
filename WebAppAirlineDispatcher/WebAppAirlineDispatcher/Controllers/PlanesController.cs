using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;
using Shared.Exceptions;
using System.Threading.Tasks;

namespace WebAppAirlineDispatcher.Controllers
{
    [Route("api/[controller]")]
    public class PlanesController : Controller
    {
        IPlaneService planeService;

        public PlanesController(IPlaneService serv)
        {
            planeService = serv;
        }


        // GET: api/planes
        public async Task<IActionResult> Get()
        {
            return Ok(await planeService.GetEntitiesAsync());
        }

        // GET api/planes/5
        [HttpGet("{id}", Name = "GetPlane")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var flight = await planeService.GetEntityAsync(id);
                return Ok(flight);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }
        }

        // POST api/planes
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]PlaneDTO planeDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await planeService.CreateEntityAsync(planeDTO);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }

            return Ok(planeDTO);
        }

        // PUT api/planes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]PlaneDTO planeDTO)
        {
            planeDTO.Id = id;
            try
            {
                await planeService.UpdateEntityAsync(id,planeDTO);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }

            return Ok(await planeService.GetEntityAsync(id));
        }

        // DELETE api/planes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await planeService.DeleteEntityAsync(id);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }
            return NoContent();
        }

        // DELETE api/planes
        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            await planeService.DeleteAllEntitiesAsync();
            return NoContent();
        }
    }
}
