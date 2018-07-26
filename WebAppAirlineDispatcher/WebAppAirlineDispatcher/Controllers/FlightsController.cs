using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;
using Shared.Exceptions;
using System.Threading.Tasks;

namespace WebAppAirlineDispatcher.Controllers
{
    [Route("api/[controller]")]
    public class FlightsController : Controller
    {
       IFlightService flightService;

        public FlightsController(IFlightService serv)
        {
            flightService = serv;
        }

        // GET: api/flights
        public async Task<IActionResult> Get()
        {
            return Ok(await flightService.GetEntitiesAsync());
        }

        // GET api/flights/5
        [HttpGet("{id}", Name = "GetFlight")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var flight = await flightService.GetEntityAsync(id);
                return Ok(flight);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }        
        }

        // POST api/flights
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]FlightDTO flightDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await flightService.CreateEntityAsync(flightDTO);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }

            return Ok(flightDTO);
        }

        // PUT api/flights/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]FlightDTO flightDTO)
        {
            flightDTO.Id = id;
            try
            {
               await  flightService.UpdateEntityAsync(id,flightDTO);            
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }

            return Ok(await flightService.GetEntityAsync(id));
        }

        // DELETE api/flights/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await flightService.DeleteEntityAsync(id);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }
            return NoContent();
        }

        // DELETE api/flights
        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            await flightService.DeleteAllEntitiesAsync();
            return NoContent();
        }
    }
}