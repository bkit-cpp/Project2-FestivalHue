using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalHue.Data.Entities
{
    public class NewsOfSchedule
    {
        public int Id { get; set; }
        public DateTime EndedDate { get; set; }
        public string TripType { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }

    }
}
