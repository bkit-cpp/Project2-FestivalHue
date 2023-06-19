using FestivalHue.Core.Interfaces;
using FestivalHue.Data.EF;
using FestivalHue.Data.Entities;
using FestivalHue.Utilities.Exceptions;
using FestivalHue.ViewModel.Categories;
using FestivalHue.ViewModel.Tickets;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalHue.Core.Services
{
    public class TicketService:ITicketService
    {
        private FestivalHueDbContext _context;
        public TicketService(FestivalHueDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(TicketCreateRequest request)
        {
            var ticket = new Ticket()
            {
                Name = request.Name,
                SeoDescription = request.SeoDescription,
                Price = request.Price
            };
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();
            return ticket.IdVe;
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
                        select new { c };//Truy Van LinQ
            return await query.Select(x => new TicketVm()
            {
              IdVe=x.c.IdVe,
              Name=x.c.Name,
             SeoDescription=x.c.SeoDescription,
              Price=x.c.Price
            }).ToListAsync();
        }

        public async Task<int> Update(TicketUpdateRequest request)
        {
            var ticket = await _context.Tickets.FindAsync(request.IdVe);
            if (ticket == null)
                throw new FestivalHueException($"Can't find product with id:{request.IdVe}");
            ticket.Name = request.Name;
            ticket.SeoDescription = request.SeoDescription;
            ticket.Price = request.Price;
            return await _context.SaveChangesAsync();
      
        }
    }
}
