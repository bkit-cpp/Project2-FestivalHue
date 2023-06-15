using FestivalHue.ViewModel.Categories;
using FestivalHue.ViewModel.Schedules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalHue.Core.Interfaces
{
    public interface IScheduleService
    {
        Task<List<ScheduleVm>> GetAllAsync();
    }
}
