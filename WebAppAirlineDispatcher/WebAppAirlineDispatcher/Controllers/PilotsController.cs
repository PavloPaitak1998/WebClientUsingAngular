using Shared.Exceptions;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;
using System.Threading.Tasks;

namespace WebAppAirlineDispatcher.Controllers
{
    [Route("api/[controller]")]
    public class PilotsController : Controller
    {
        IPilotService pilotService;

        public PilotsController(IPilotService serv)
        {
            pilotService = serv;
        }

        // GET: api/pilots
        public async Task<IActionResult> Get()
        {
            return Ok(await pilotService.GetEntitiesAsync());
        }

        // GET api/pilots/5
        [HttpGet("{id}", Name = "GetPilot")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var pilot = await pilotService.GetEntityAsync(id);
                return Ok(pilot);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }
        }

        // POST api/pilots
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]PilotDTO pilotDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await pilotService.CreateEntityAsync(pilotDTO);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }

            return Ok(pilotDTO);
        }

        // PUT api/pilots/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]PilotDTO pilotDTO)
        {
            pilotDTO.Id = id;
            try
            {
                await pilotService.UpdateEntityAsync(id,pilotDTO);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }

            return Ok(await pilotService.GetEntityAsync(id));
        }

        // DELETE api/pilots/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await pilotService.DeleteEntityAsync(id);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }
            return NoContent();
        }

        // DELETE api/pilots
        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            await pilotService.DeleteAllEntitiesAsync();
            return NoContent();
        }
    }
}