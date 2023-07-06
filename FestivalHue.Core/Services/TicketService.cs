using FestivalHue.Core.Interfaces;
using FestivalHue.Data.EF;
using FestivalHue.Data.Entities;
using FestivalHue.Utilities.Exceptions;
using FestivalHue.ViewModel.Categories;
using FestivalHue.ViewModel.Tickets;
using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using QRCoder;
using ZXing.Common;
using ZXing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FestivalHue.Core.Services
{
    public class TicketService:ITicketService
    {
        private FestivalHueDbContext _context;
        private readonly EmailSettings emailSettings;
        public TicketService(FestivalHueDbContext context, IOptions<EmailSettings> options)
        {
            _context = context;
            this.emailSettings = options.Value;
        }

        public async Task<int> Create(TicketCreateRequest request)
        {
            var ticket = new Ticket()
            {
                Name = request.Name,
                SeoDescription = request.SeoDescription,
                Price = request.Price,
                Quantity=request.Quantity,
                IsBooked=request.IsBooked,
                Schedules=new List<NewsOfSchedule>()
                {
                    new NewsOfSchedule()
                    {
                        CreatedDate=DateTime.Now,
                        EndedDate=DateTime.Now,
                        TripType=request.TripType,
                        Content=request.Content
                    }
                }
                
            };
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();
            return ticket.Id;
        }

        public async Task<int> Delete(int ticketId)
        {
            var ticket = await _context.Tickets.FindAsync(ticketId);
            if(ticket==null)
            throw new FestivalHueException($"Can't find product with id:{ticketId}");
            _context.Tickets.Remove(ticket);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<TicketVm>> GetAllAsync()
        {
            var query = from c in _context.Tickets
                        join ct in _context.NewsOfSchedules on c.Id equals ct.Id
                        select new { c,ct };//Truy Van LinQ
            return await query.Select(x => new TicketVm()
            {
              Id=x.c.Id,
              Name=x.c.Name,
             SeoDescription=x.c.SeoDescription,
              Price=x.c.Price,
              Quantity=x.c.Quantity,
              TripType=x.ct.TripType,
              Content=x.ct.Content,
              IsBooked=x.c.IsBooked
            }).ToListAsync();
        }

        public async Task<int> Update(TicketUpdateRequest request)
        {
            var ticket = await _context.Tickets.FindAsync(request.Id);
            var schedule= await _context.NewsOfSchedules.
              FirstOrDefaultAsync(x => x.TicketId== request.Id);
            if (ticket == null||schedule==null)
                throw new FestivalHueException($"Can't find product with id:{request.Id}");
            ticket.Name = request.Name;
            ticket.SeoDescription = request.SeoDescription;
            ticket.Price = request.Price;
            ticket.Quantity = request.Quantity;
            ticket.IsBooked = request.IsBooked;
            schedule.TripType = request.TripType;
            return await _context.SaveChangesAsync();
      
        }

        public async Task<bool> UpdatePrice(int ticketId, decimal price)
        {
            var Ticket = await _context.Tickets.FindAsync(ticketId);
            if(Ticket==null)
            throw new FestivalHueException($"Cannot find a product with id: {ticketId}");
            Ticket.Price = price;
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool>UpdateQuantity(int ticketId,int quantity)
        {
            var Ticket = await _context.Tickets.FindAsync(ticketId);
            if (Ticket == null) throw new FestivalHueException($"Cannot find a product with id: {ticketId}");
            Ticket.Quantity += quantity;
            return await _context.SaveChangesAsync() > 0;
        }
        public decimal GetTotalAmount()
        {
            decimal total = _context.Tickets.Sum(order => order.Price * order.Quantity);
            return total;
        }

        public async Task< bool> IsTicketAvailable(int ticketId)
        {
            var Ticket = await _context.Tickets.FindAsync(ticketId);
            
            if (Ticket == null || Ticket.Quantity <= 0)
            {
                Ticket.IsBooked = false;
                throw new FestivalHueException($"Cannot find a product with id: {ticketId}");
            }
            else
            {
                Ticket.IsBooked = true;

            }
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<TicketVm> GetById(int ticketId)
        {
            var query = from c in _context.Tickets
                        join ct in _context.NewsOfSchedules on c.Id equals ct.Id
                        where c.Id==ticketId
                        select new { c,ct };
            return await query.Select(x => new TicketVm()
            {
                Id=x.c.Id,
                Name=x.c.Name,
                SeoDescription=x.c.SeoDescription,
                TripType=x.ct.TripType,
                Price=x.c.Price,
                Quantity=x.c.Quantity,
                Content = x.ct.Content,
                IsBooked =x.c.IsBooked

            }).FirstOrDefaultAsync();
        }
      /*   public async static Task<byte[]>  ImageToByteArray(Image ImageIn)
         {
            MemoryStream ms = new MemoryStream();
            ImageIn.Save(ms, ImageFormat.Jpeg);
            return  ms.ToArray();
         }
     */
    }
}

