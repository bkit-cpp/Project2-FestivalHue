using FestivalHue.Core.Interfaces;
using FestivalHue.Data.EF;
using FestivalHue.Data.Entities;
using FestivalHue.Utilities.Exceptions;
using FestivalHue.ViewModel.Categories;
using FestivalHue.ViewModel.Common;
using FestivalHue.ViewModel.Tickets;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalHue.Core.Services
{
    public class CategoryofEventService : ICategoryOfEventService
    {
        private FestivalHueDbContext _context;
        public CategoryofEventService(FestivalHueDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(CategoryCreateRequest request)
        {
            var category = new CategoryOfEvent()
            {
                Name = request.Name,
                CreatedDate = request.CreatedDate
               
            };
            _context.Add(category);
            await _context.SaveChangesAsync();
            return category.CategoryId;

        }

        public async Task<List<CategoryViewModel>> GetAllAsync()
        {

            var query = from c in _context.Categorys
                        select new { c };
            return await query.Select(x => new CategoryViewModel()
            {
                CategoryId=x.c.CategoryId,
                Name=x.c.Name,
                CreatedDate=DateTime.Now,
                status = Status.Active
            }).ToListAsync();
        }
        public async Task<CategoryViewModel> GetById(int id)
        {
            var query= from c in _context.Categorys
                       where c.CategoryId==id
                       select new { c};
            return await query.Select(x => new CategoryViewModel()
            {
               CategoryId=x.c.CategoryId,
               Name=x.c.Name,
               CreatedDate=DateTime.Now,
               status=Status.Active
            }).FirstOrDefaultAsync();
        }
        public async Task<bool> UpdateStatus(int id, int status)
        {
            try
            {
                var category = await _context.Categorys.FindAsync(id);
                if (category == null)
                {
                    throw new FestivalHueException($"Cannot find status with id: {id}");
                }
                if (status==1)
                {
                    category.status = Data.Enums.Status.Active;
                }
               
                else
                {
                    category.status = Data.Enums.Status.Iactive;
                }
                return await _context.SaveChangesAsync() > 0;
            }catch(Exception ex)
            {
                throw new FestivalHueException(ex.Message);
            }
        }
    }
}
