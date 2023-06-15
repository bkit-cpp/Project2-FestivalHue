using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalHue.Data.Entities
{
    public class Customer
    {
       public int IdCustomer { get; set; }
       public string Name { get; set; }
       public string Address { get; set; }
       public string City { get; set; }
       public Guid UserId { get; set; }
       public AppUser AppUser { get; set; }

    }
}
