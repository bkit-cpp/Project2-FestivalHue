using FestivalHue.ViewModel.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalHue.Core.Interfaces
{
    public  interface ICustomerService
    {
        Task<List<CustomerVm>> GetAllAsync();
        Task<int> Create(CustomerCreateRequest request);
        Task<int> Update(CustomerUpdateRequest request);
        Task<int> Delete(int customerId);
        Task<CustomerVm> GetById(int customerId);
    }
}
