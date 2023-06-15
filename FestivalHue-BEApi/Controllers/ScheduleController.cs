using FestivalHue.Core.Interfaces;
using FestivalHue.Data.Entities;
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
    }
}
