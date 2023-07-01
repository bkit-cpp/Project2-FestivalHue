using FestivalHue.Core.Interfaces;
using FestivalHue.Core.Services;
using FestivalHue.Utilities.Exceptions;
using FestivalHue.ViewModel.Tickets;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QRCoder;
using System.Drawing;
using ZXing.Common;
using ZXing;

namespace FestivalHue_BEApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
        [HttpGet("{ticketId}")]
        public async Task<IActionResult> GetById(int ticketId)
        {
            var cate = await _ticketService.GetById(ticketId);
            return Ok(cate);
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
        [HttpPut("{ticketId}/{price}")]
        public async Task<IActionResult>UpdatePrice(int ticketId,decimal price)
        {
            var IsSuccessFull = await _ticketService.UpdatePrice(ticketId, price);
            if (IsSuccessFull)
                return Ok();
            return BadRequest();
        }
        [HttpPut("{ticketId}/{quantity}")]
        public async Task<IActionResult>UpdateQuantity(int ticketId, int quantity)
        {
            var IsSuccessFull = await _ticketService.UpdateQuantity(ticketId, quantity);
            if (IsSuccessFull)
                return Ok();
            return BadRequest();
        }
        [HttpGet("total-amount")]
        public IActionResult GetTotalAmount()
        {
            decimal totalAmount =_ticketService.GetTotalAmount();
            return Ok( totalAmount);
        }
       [HttpPut("{ticketId}/book")]
        public async Task<IActionResult> BookTicket(int ticketId)
        {
            var IsBookTicket =await _ticketService.IsTicketAvailable(ticketId);
            if (IsBookTicket)
                return Ok("Ticket booked successfully.");
            return BadRequest();
        }
        [HttpGet("{ticketId}/check")]
        public async Task<IActionResult> CheckTicketAvailable(int ticketId)
        {
            var isAvailable = await _ticketService.GetById(ticketId);
            if (isAvailable.IsBooked==true)
            {
                return Ok("Ticket is available");
            }
            else
            {
                return BadRequest("Ticket is unavailable");
            }
        }
        /*
        private bool ValidateQRCode(string qrCodeContent)
        {
            // Tạo một đối tượng BarcodeReader từ thư viện ZXing
            var barcodeReader = new BarcodeReader();

            // Đặt cấu hình cho mã QR code (nếu cần)
            barcodeReader.Options = new ZXing.Common.DecodingOptions
            {
                PossibleFormats = new List<BarcodeFormat> { BarcodeFormat.QR_CODE },
                TryHarder = true
            };

            // Chuyển đổi chuỗi QR code thành ảnh Bitmap
            var qrCodeBitmap = GetQRCodeBitmap(qrCodeContent);

            // Thực hiện giải mã QR code
            var barcodeResult = barcodeReader.Decode(qrCodeBitmap);

            // Kiểm tra kết quả giải mã và so sánh với qrCodeContent
            return barcodeResult != null && barcodeResult.Text == qrCodeContent;
        }

        private Bitmap GetQRCodeBitmap(string qrCodeContent)
        {
            // Tạo một đối tượng BarcodeWriter từ thư viện ZXing
            var barcodeWriter = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new EncodingOptions
                {
                    Width = 200,
                    Height = 200,
                    Margin = 0
                }
            };

            // Tạo mã QR code thành ảnh Bitmap
            var qrCodeBitmap = barcodeWriter.Write(qrCodeContent);

            return qrCodeBitmap;
        }
    }
        */
}
}
