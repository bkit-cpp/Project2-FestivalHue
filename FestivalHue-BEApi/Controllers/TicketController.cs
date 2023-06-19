using FestivalHue.Core.Interfaces;
using FestivalHue.Core.Services;
using FestivalHue.ViewModel.Schedules;
using FestivalHue.ViewModel.Tickets;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FestivalHue_BEApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private ITicketService _ticketService;
        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ticket = await _ticketService.GetAllAsync();
            return Ok(ticket);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] TicketCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ticketId = await _ticketService.Create(request);
            if (ticketId == 0)
                return BadRequest();
            return Ok(request);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] TicketUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var affectedReSult = await _ticketService.Update(request);
            if (affectedReSult == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{ticketId}")]
        public async Task<IActionResult> Delete(int ticketId)
        {
            var affectedReSult = await _ticketService.Delete(ticketId);
            if (affectedReSult == 0)
                return BadRequest();
            return Ok();
        }
    }
}
