using FestivalHue.Core.Interfaces;
using FestivalHue.Data.EF;
using FestivalHue.Data.Entities;
using FestivalHue.Utilities.Exceptions;
using FestivalHue.ViewModel.Categories;
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

        public async Task<int> Create(ScheduleCreateRequest request)
        {
            var schedule = new Schedule()
            {
                Name=request.Name,
                Description=request.Description,
                CreatedDate=DateTime.Now
            };
            _context.Schedules.Add(schedule);
            await _context.SaveChangesAsync();
            return schedule.IdSchedule;
        }

        public async Task<int> Delete(int id)
        {
            var schedule = await _context.Schedules.FindAsync(id);
            if (schedule == null)
                throw new FestivalHueException($"Can't find product with id:{id}");
            _context.Schedules.Remove(schedule);
            return await _context.SaveChangesAsync();
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

        public async Task<int> Update(ScheduleEditRequest request)
        {
            var schedule = await _context.Schedules.FindAsync(request.IdSchedule);
            if (schedule == null)
                throw new FestivalHueException($"Can't find product with id:{request.IdSchedule}");
            schedule.Name = request.Name;
            schedule.Description = request.Description;
            schedule.CreatedDate = request.CreatedDate;
            return await _context.SaveChangesAsync();
        }
    }
}
