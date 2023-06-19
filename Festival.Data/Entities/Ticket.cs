using FestivalHue.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalHue.Data.Entities
{
    public class Ticket
    {
        public int IdVe { get; set; }
        public string Name { get; set; }
        public string SeoDescription { get; set; }
        public decimal Price { get; set; }

        public List<TicketInCategory> TicketInCategories { get; set; }
        public List<TicketMessage> TicketMessages { get; set; }
        public List<Schedule> Schedules { get; set; }
    }
}
