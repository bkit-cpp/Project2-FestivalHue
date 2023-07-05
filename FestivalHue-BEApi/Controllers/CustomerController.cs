using ClosedXML.Excel;
using FestivalHue.Core.Interfaces;
using FestivalHue.Core.Services;
using FestivalHue.Data.EF;
using FestivalHue.ViewModel.Customer;
using FestivalHue.ViewModel.NewOfSchedule;
using FestivalHue.ViewModel.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace FestivalHue_BEApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        private ICustomerService _customerService;
        private FestivalHueDbContext _context;
        public CustomerController(ICustomerService customerService, FestivalHueDbContext context)
        {
            _customerService = customerService;
            _context = context;
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
        [NonAction]
        private DataTable GetData()
        {
            DataTable dt = new DataTable();
            dt.TableName = "dbo.Customer";
            dt.Columns.Add("IdCustomer", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Address", typeof(string));
            dt.Columns.Add("City", typeof(string));
            dt.Columns.Add("UserId", typeof(Guid));
            var list = _context.Customers.ToList();
            if (list.Count > 0)
            {
                list.ForEach(item =>
                {
                    dt.Rows.Add(item.IdCustomer, item.Name, item.Address, item.City, item.UserId);
                });
            }
            return dt;
        }
        [HttpGet("generateExcel")]
        public async Task<IActionResult> GenerateExcel()
        {
            var ticketdt = GetData();
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.AddWorksheet(ticketdt, "CustomerRecord");
                using (MemoryStream ms = new MemoryStream())
                {
                    wb.SaveAs(ms);
                    return File(ms.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Customer.xlsx");
                }
            }
        }
    }
}
