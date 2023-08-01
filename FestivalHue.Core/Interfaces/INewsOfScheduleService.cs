
using FestivalHue.ViewModel.NewOfSchedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalHue.Core.Interfaces
{
    public interface INewsOfScheduleService
    {
        Task<List<NewOfScheduleVm>> GetAllAsync();
        Task<int> Create(NewOfScheduleCreateRequest request);
        Task<int> Update(NewofScheduleUpdateRequest request);
        Task<int> Delete(int newsId);
        Task<NewOfScheduleVm> GetById(int newsId);
    }
}
