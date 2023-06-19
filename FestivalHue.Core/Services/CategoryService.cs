using FestivalHue.Core.Interfaces;
using FestivalHue.Data.EF;
using FestivalHue.Data.Entities;
using FestivalHue.Utilities.Exceptions;
using FestivalHue.ViewModel.Categories;
using FestivalHue.ViewModel.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalHue.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private FestivalHueDbContext _context;
        public CategoryService(FestivalHueDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(CategoryCreateRequest request)
        {
            var category = new Category()
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
                CreatedDate=DateTime.Now
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
               CreatedDate=DateTime.Now

            }).FirstOrDefaultAsync();
        }
        public async Task<ApiResult<bool>> Update(int id)
        {
            try
            {
                var category = await _context.Categorys.FindAsync(id);
                if (category == null)
                {
                    return new ApiErrorResult<bool>($"Cannot find Id:{id}");
                }
                var sta = category.status;
                if (sta == 0)
                {
                    sta = Data.Enums.Status.Active;
                }
                else
                {
                    sta = Data.Enums.Status.Iactive;
                }
                return new ApiSuccessResult<bool>() ;
            }catch(Exception ex)
            {
                throw new FestivalHueException(ex.Message);
            }
        }
    }
}
