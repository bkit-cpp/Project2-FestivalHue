using FestivalHue.ViewModel.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalHue.Core.Interfaces
{
    public interface IRoleService
    {
        Task<List<RoleVm>> GetAll();
    }
}
