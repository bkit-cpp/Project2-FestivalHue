using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalHue.Data.Entities
{
    public class TicketInCategory
    {
        public int TicketId { get; set; }
        public int CategoryId { get; set; }
        public Ticket Ticket { get; set; }
        public Category Category{ get; set; }
    }
}
