using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;
using Shared.Exceptions;
using System.Threading.Tasks;

namespace WebAppAirlineDispatcher.Controllers
{
    [Route("api/[controller]")]
    public class CrewController : Controller
    {
        ICrewService crewService;

        public CrewController(ICrewService serv)
        {
            crewService = serv;
        }

        // GET: api/crew
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await crewService.GetEntitiesAsync());
        }

        // GET api/crew/5
        [HttpGet("{id}", Name = "GetCrew")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var crew = await crewService.GetEntityAsync(id);
                return Ok(crew);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }
        }

        [HttpGet("AddFirst10Crew")]
        public async Task<IActionResult> AddFirst10Crew()
        {
            await crewService.Add10CrewIntoDbAndFileAsync();
            return Ok(new { answer = "Data added" });
        }

        // POST api/crew
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CrewDTO crewDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await crewService.CreateEntityAsync(crewDTO);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }

            return Ok(crewDTO);
        }

        // PUT api/crew/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]CrewDTO crewDTO)
        {
            crewDTO.Id = id;
            try
            {
                await crewService.UpdateEntityAsync(id,crewDTO);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }

            return Ok(await crewService.GetEntityAsync(id));
        }

        // DELETE api/crew/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await crewService.DeleteEntityAsync(id);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }
            return NoContent();
        }

        // DELETE api/crew
        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            await crewService.DeleteAllEntitiesAsync();
            return NoContent();
        }
    }
}