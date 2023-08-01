using FestivalHue.ViewModel.Categories;
using FestivalHue.ViewModel.Common;
using FestivalHue.ViewModel.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalHue.Core.Interfaces
{
    public interface ICategoryOfEventService
    {
        Task<List<CategoryViewModel>> GetAllAsync();
        Task<int> Create(CategoryCreateRequest request);

        Task<CategoryViewModel> GetById(int id);
       Task<bool> UpdateStatus(int id, int status);
    }
}
