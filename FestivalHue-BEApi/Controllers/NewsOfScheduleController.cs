using FestivalHue.Core.Interfaces;
using FestivalHue.Data.EF;
using FestivalHue.Data.Entities;
using FestivalHue.ViewModel.NewOfSchedule;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FestivalHue_BEApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsOfScheduleController : ControllerBase
    {
        private INewsOfScheduleService _newofscheduleService;
        private FestivalHueDbContext _context;
        public NewsOfScheduleController(INewsOfScheduleService NewsOfScheduleService, FestivalHueDbContext context)
        {
            _newofscheduleService = NewsOfScheduleService;
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var news = await _newofscheduleService.GetAllAsync();
            return Ok(news);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] NewOfScheduleCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var customerId = await _newofscheduleService.Create(request);
            if (customerId == 0)
                return BadRequest();
            return Ok(request);
        }
        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetById(int customerId)
        {
            var cate = await _newofscheduleService.GetById(customerId);
            return Ok(cate);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] NewofScheduleUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var affectedReSult = await _newofscheduleService.Update(request);
            if (affectedReSult == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{customerId}")]
        public async Task<IActionResult> Delete(int customerId)
        {
            var affectedReSult = await _newofscheduleService.Delete(customerId);
            if (affectedReSult == 0)
                return BadRequest();
            return Ok();
        }
     
     
    }
}
