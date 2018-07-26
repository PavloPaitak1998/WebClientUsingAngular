using Shared.Exceptions;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;
using System.Threading.Tasks;

namespace WebAppAirlineDispatcher.Controllers
{
    [Route("api/[controller]")]
    public class TicketsController : Controller
    {
        ITicketService ticketService;

        public TicketsController(ITicketService serv)
        {
            ticketService = serv;
        }

        // GET: api/tickets
        public async Task<IActionResult> Get()
        {
            return Ok(await ticketService.GetEntitiesAsync());
        }

        // GET api/tickets/5
        [HttpGet("{id}", Name = "GetTicket")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var ticket = await ticketService.GetEntityAsync(id);
                return Ok(ticket);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }
        }

        // POST api/tickets
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TicketDTO ticketDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await ticketService.CreateEntityAsync(ticketDTO);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }

            return Ok(ticketDTO);
        }

        // PUT api/tickets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]TicketDTO ticketDTO)
        {
            ticketDTO.Id = id;
            try
            {
                await ticketService.UpdateEntityAsync(id,ticketDTO);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }

            return Ok(await ticketService.GetEntityAsync(id));
        }

        // DELETE api/tickets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await ticketService.DeleteEntityAsync(id);
            }
            catch (ValidationException e)
            {
                return BadRequest(new { Exception = e.Message });
            }
            return NoContent();
        }

        // DELETE api/tickets
        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            await ticketService.DeleteAllEntitiesAsync();
            return NoContent();
        }
    }
}