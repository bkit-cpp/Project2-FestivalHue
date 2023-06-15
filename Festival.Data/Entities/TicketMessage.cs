using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalHue.Data.Entities
{
    public class TicketMessage
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
        
    }
}
