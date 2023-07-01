using FestivalHue.Core.Interfaces;
using FestivalHue.Core.Services;
using FestivalHue.ViewModel.Tickets;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FestivalHue_BEApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        private ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customer = await _customerService.GetAllAsync();
            return Ok(customer);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CustomerCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var customerId = await _customerService.Create(request);
            if (customerId == 0)
                return BadRequest();
            return Ok(request);
        }
        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetById(int customerId)
        {
            var cate = await _customerService.GetById(customerId);
            return Ok(cate);
        }
      
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] CustomerUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var affectedReSult = await _customerService.Update(request);
            if (affectedReSult == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{customerId}")]
        public async Task<IActionResult> Delete(int customerId)
        {
            var affectedReSult = await _customerService.Delete(customerId);
            if (affectedReSult == 0)
                return BadRequest();
            return Ok();
        }
    }
}
