using FestivalHue.Core.Interfaces;
using FestivalHue.Data.Entities;
using FestivalHue.ViewModel.Schedules;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FestivalHue_BEApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private IScheduleService _ScheduleService;
        public ScheduleController(IScheduleService ScheduleService)
        {
            _ScheduleService = ScheduleService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sche = await _ScheduleService.GetAllAsync();
            return Ok(sche);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ScheduleCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var productId = await _ScheduleService.Create(request);
            if (productId == 0)
                return BadRequest();
            return Ok(request);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] ScheduleEditRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var affectedReSult = await _ScheduleService.Update(request);
            if (affectedReSult == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            var affectedReSult = await _ScheduleService.Delete(id);
            if (affectedReSult == 0)
                return BadRequest();
            return Ok();
        }
    }
}
