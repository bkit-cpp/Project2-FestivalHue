using FestivalHue.Data.EF;
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
    public class TicketService
    {
        private FestivalHueDbContext _context;
        public TicketService(FestivalHueDbContext context)
        {
            _context = context;
        }
        public async Task<List<TicketVm>> GetAllAsync()
        {
            var query = from c in _context.Tickets
                        select new { c };//Truy Van LinQ
            return await query.Select(x => new TicketVm()
            {
              IdVe=x.c.IdVe,
              Name=x.c.Name,
              Price=x.c.Price
            }).ToListAsync();
        }
    }
}
