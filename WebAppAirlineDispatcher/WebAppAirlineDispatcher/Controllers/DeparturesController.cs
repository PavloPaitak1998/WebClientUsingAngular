using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;
using Shared.Exceptions;
using System.Threading.Tasks;

namespace WebAppAirlineDispatcher.Controllers
{
    [Route("api/[controller]")]
    public class DeparturesController : Controller
    {
        IDepartureService departureService;


        public DeparturesController(IDepartureService serv)
        {
            departureService = serv;
        }

        // GET: api/departures
        public async Task<IActionResult> Get()
        {
            return Ok(await departureService.GetEntitiesAsync());
        }

        // GET api/departures/5
        [HttpGet("{id}", Name = "GetDeparture")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var departure = await departureService.GetEntityAsync(id);
                return Ok(departure);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }
        }

        // POST api/departures
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]DepartureDTO departureDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await departureService.CreateEntityAsync(departureDTO);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }

            return Ok(departureDTO);
        }

        // PUT api/departures/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]DepartureDTO departureDTO)
        {
            departureDTO.Id = id;
            try
            {
                await departureService.UpdateEntityAsync(id,departureDTO);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }

            return Ok(await departureService.GetEntityAsync(id));
        }

        // DELETE api/departures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await departureService.DeleteEntityAsync(id);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }
            return NoContent();
        }

        // DELETE api/departures
        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            await departureService.DeleteAllEntitiesAsync();
            return NoContent();
        }
    }
}