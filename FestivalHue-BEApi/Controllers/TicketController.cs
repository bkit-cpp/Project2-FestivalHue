using FestivalHue.Core.Interfaces;
using FestivalHue.Core.Services;
using FestivalHue.Utilities.Exceptions;
using FestivalHue.ViewModel.Tickets;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.IO.Pipelines;
using System.Xml.Linq;
using QRCoder;
using ZXing.QrCode.Internal;
using FestivalHue.Data.Entities;
using System.Data;
using FestivalHue.Data.EF;
using ClosedXML.Excel;
using MailKit.Security;
using MimeKit;
using Org.BouncyCastle.Asn1.Ocsp;
using Microsoft.Extensions.Options;

namespace FestivalHue_BEApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TicketController : ControllerBase
    {
        private ITicketService _ticketService;
        private FestivalHueDbContext _context;
        private readonly EmailSettings emailSettings;
        public TicketController(ITicketService ticketService, FestivalHueDbContext context, IOptions<EmailSettings> options)
        {
            _ticketService = ticketService;
            _context = context;
            this.emailSettings = options.Value;
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
        [HttpPut("{ticketId}/quantity")]
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
                var email = new MimeMessage();
                email.Sender = MailboxAddress.Parse(emailSettings.Email);
                email.To.Add(MailboxAddress.Parse("bakhaipth@gmail.com"));
                email.Subject = isAvailable.SeoDescription;
                var builder = new BodyBuilder();
                builder.HtmlBody = "Ticket is available";
                email.Body = builder.ToMessageBody();
                using var smtp = new MailKit.Net.Smtp.SmtpClient();
                smtp.Connect(emailSettings.Host, emailSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(emailSettings.Email, emailSettings.Password);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode("Ticket is available", QRCodeGenerator.ECCLevel.Q);
                QRCoder.QRCode qrCode = new QRCoder.QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(10);
                return File(BitmapToBytes(qrCodeImage), "image/jpeg");
            }
            else
            {
                return BadRequest("Ticket is unavailable");
            }
        }
        private static Byte[] BitmapToBytes(Bitmap img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }
        [HttpGet]
        [Route("qenerate/{ticketId}")]
        public async Task< IActionResult> GetQrCode(int ticketId)
        {
            var ticket = await _ticketService.GetById(ticketId);
            if (ticket == null)
            {
                return NotFound();
            }
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(ticket.Name, QRCodeGenerator.ECCLevel.Q);
            QRCoder.QRCode qrCode = new QRCoder.QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(10);
            return File(BitmapToBytes(qrCodeImage), "image/jpeg");
        }
        [NonAction]
        private DataTable GetData()
        {
            DataTable dt = new DataTable();
            dt.TableName = "dbo.Tickets";
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("SeoDescription", typeof(string));
            dt.Columns.Add("Price", typeof(decimal));
            dt.Columns.Add("Quantity", typeof(int));
            dt.Columns.Add("IsBooked", typeof(bool));
            var list = _context.Tickets.ToList();
            if (list.Count > 0)
            {
                list.ForEach(item =>
                {
                    dt.Rows.Add(item.Id, item.Name, item.SeoDescription, item.Price, item.Quantity, item.IsBooked);
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
                wb.AddWorksheet(ticketdt, "TicketRecord");
                using(MemoryStream ms=new MemoryStream())
                {
                    wb.SaveAs(ms);
                    return File(ms.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Ticket.xlsx");
                }
            }
        }
        /* public byte[] ImageToByteArray(System.Drawing.Image ImageIn)
           {
               MemoryStream ms = new MemoryStream();
               ImageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
               return ms.ToArray();
           }
           [HttpGet("GeneratedQrCode")]
           public async Task<IActionResult> GenerateQrcode(string QrCodeText)
           {
               QRCodeGenerator qrGenerator = new QRCodeGenerator();
               QRCodeData qrCodeData = qrGenerator.CreateQrCode(QrCodeText, QRCodeGenerator.ECCLevel.Q);
               QRCoder.QRCode qrCode = new QRCoder.QRCode(qrCodeData);
               System.Drawing.Image qrCodeImage = qrCode.GetGraphic(20);
               var bytes = ImageToByteArray(qrCodeImage);
               return File(bytes, "image/png");

           }
        */
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
