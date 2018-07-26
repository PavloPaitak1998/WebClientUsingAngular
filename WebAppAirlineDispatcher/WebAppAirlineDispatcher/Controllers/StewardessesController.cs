using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;
using Shared.Exceptions;
using System.Threading.Tasks;

namespace WebAppAirlineDispatcher.Controllers
{
    [Route("api/[controller]")]
    public class StewardessesController : Controller
    {
        IStewardessService stewardessService;

        public StewardessesController(IStewardessService serv)
        {
            stewardessService = serv;
        }

        // GET: api/stewardesses
        public async Task<IActionResult> Get()
        {
            return Ok(await stewardessService.GetEntitiesAsync());
        }

        // GET api/stewardesses/5
        [HttpGet("{id}", Name = "GetStewardess")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var flight = await stewardessService.GetEntityAsync(id);
                return Ok(flight);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }
        }

        // POST api/stewardesses
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]StewardessDTO stewardessDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await stewardessService.CreateEntityAsync(stewardessDTO);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }

            return Ok(stewardessDTO);
        }

        // PUT api/stewardesses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]StewardessDTO stewardessDTO)
        {
            stewardessDTO.Id = id;
            try
            {
                await stewardessService.UpdateEntityAsync(id,stewardessDTO);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }

            return Ok(await stewardessService.GetEntityAsync(id));
        }

        // DELETE api/stewardesses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await stewardessService.DeleteEntityAsync(id);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }
            return NoContent();
        }

        // DELETE api/stewardesses
        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            await stewardessService.DeleteAllEntitiesAsync();
            return NoContent();
        }
    }
}