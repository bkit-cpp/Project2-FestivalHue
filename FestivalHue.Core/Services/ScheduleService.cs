using FestivalHue.Core.Interfaces;
using FestivalHue.Data.EF;
using FestivalHue.ViewModel.Schedules;
using FestivalHue.ViewModel.Tickets;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalHue.Core.Services
{
    public class ScheduleService : IScheduleService
    {
        private FestivalHueDbContext _context;
        public ScheduleService(FestivalHueDbContext context)
        {
            _context = context;
        }
        public async Task<List<ScheduleVm>> GetAllAsync()
        {
            var query = from c in _context.Schedules
                        select new { c };//Truy Van LinQ
            return await query.Select(x => new ScheduleVm()
            {
                IdSchedule = x.c.IdSchedule,
                Name = x.c.Name,
                Description=x.c.Description,
                CreatedDate=DateTime.Now,
                TicketId=x.c.TicketId
            }).ToListAsync();
        }
    }
}
