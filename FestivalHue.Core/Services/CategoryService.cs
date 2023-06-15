using FestivalHue.Core.Interfaces;
using FestivalHue.Data.EF;
using FestivalHue.ViewModel.Categories;
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
        public async Task<List<CategoryViewModel>> GetAllAsync()
        {
            var query = from c in _context.Categorys
                        select new { c };
            return await query.Select(x => new CategoryViewModel()
            {
                CategoryId=x.c.CategoryId,
                Name=x.c.Name,
                CreatedDate=x.c.CreatedDate
            }).ToListAsync();
        }
    }
}
