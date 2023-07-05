using FestivalHue.Core.Interfaces;
using FestivalHue.Data.EF;
using FestivalHue.Data.Entities;
using FestivalHue.Utilities.Exceptions;
using FestivalHue.ViewModel.Categories;
using FestivalHue.ViewModel.Customer;
using FestivalHue.ViewModel.NewOfSchedule;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalHue.Core.Services
{
    public class NewsOfScheduleService : INewsOfScheduleService
    {
        private FestivalHueDbContext _context;
        public NewsOfScheduleService(FestivalHueDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(NewOfScheduleCreateRequest request)
        {
            var newschedule = new NewsOfSchedule()
            {
              EndedDate=request.EndedDate,
              CreatedDate=request.CreatedDate,
              TripType=request.TripType,
              Content=request.Content,
              Ticket=new Ticket()
              {
                  Name=request.Name,
                  SeoDescription=request.SeoDescription,
                  Price=request.Price
              }
            };
            _context.NewsOfSchedules.Add(newschedule);
            await _context.SaveChangesAsync();
            return newschedule.Id;
        }

        public async Task<int> Delete(int newsId)
        {
            var news = await _context.NewsOfSchedules.FindAsync(newsId);
            if (news == null)
                throw new FestivalHueException($"Can't find customer with id:{newsId}");
            _context.NewsOfSchedules.Remove(news);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<NewOfScheduleVm>> GetAllAsync()
        {
            var query = from c in _context.NewsOfSchedules
                        join ct in _context.Tickets on c.TicketId equals ct.Id
                        select new { c, ct };//Truy Van LinQ
            return await query.Select(x => new NewOfScheduleVm()
            {
               Id=x.c.Id,
               CreatedDate=x.c.CreatedDate,
               EndedDate=x.c.EndedDate,
               TripType=x.c.TripType,
               SeoDescription=x.ct.SeoDescription,
               Name=x.ct.Name,
               Content=x.c.Content,
               Price=x.ct.Price
               
            }).ToListAsync();
        }

        public async Task<NewOfScheduleVm> GetById(int newsId)
        {
            var query = from c in _context.NewsOfSchedules
                        join ct in _context.Tickets on c.TicketId equals ct.Id
                        where c.Id == newsId
                        select new { c,ct };
            return await query.Select(x => new NewOfScheduleVm()
            {
                Id = x.c.Id,
                Name = x.ct.Name,
                SeoDescription=x.ct.SeoDescription,
                Price=x.ct.Price,
                Content=x.c.Content,
                CreatedDate = DateTime.Now,
                EndedDate=DateTime.Now,
                TripType=x.c.TripType

            }).FirstOrDefaultAsync();
        }

        public async Task<int> Update(NewofScheduleUpdateRequest request)
        {
            var news = await _context.NewsOfSchedules.FindAsync(request.Id);
  
            if (news == null)
                throw new FestivalHueException($"Can't find product with id:{request.Id}");
            news.CreatedDate = request.CreatedDate;
            news.EndedDate = request.EndedDate;
            news.TripType = request.TripType;
            news.Content = request.Content;
           
            return await _context.SaveChangesAsync();
        }
    }
}
