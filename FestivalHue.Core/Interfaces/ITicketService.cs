using FestivalHue.ViewModel.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalHue.Core.Interfaces
{
    public interface ITicketService
    {
        Task<List<TicketVm>> GetAllAsync();
    }
}
