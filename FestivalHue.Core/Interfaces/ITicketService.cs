using FestivalHue.ViewModel.Categories;
using FestivalHue.ViewModel.Tickets;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalHue.Core.Interfaces
{
    public interface ITicketService
    {
        Task<List<TicketVm>> GetAllAsync();
        Task<int> Create(TicketCreateRequest request);
        Task<int> Update(TicketUpdateRequest request);
        Task<int> Delete(int ticketId);
        Task<TicketVm> GetById(int ticketId);
        Task<bool> UpdatePrice(int ticketId, decimal price);
        Task<bool> UpdateQuantity(int ticketId, int quantity);
        decimal GetTotalAmount();
       Task< bool> IsTicketAvailable(int ticketId);

    }
}
