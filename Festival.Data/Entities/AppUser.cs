using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalHue.Data.Entities
{
    public class AppUser:IdentityUser<Guid>
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime Dob { get; set; }
    }
}
