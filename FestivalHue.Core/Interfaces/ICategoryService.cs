using FestivalHue.ViewModel.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalHue.Core.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryViewModel>> GetAllAsync();
    }
}
