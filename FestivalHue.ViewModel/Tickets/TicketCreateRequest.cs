using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalHue.ViewModel.Tickets
{
    public class TicketCreateRequest
    {
        public string Name { get; set; }
        public string SeoDescription { get; set; }
        public decimal Price { get; set; }
        public string TripType { get; set; }
        public int Quantity { get; set; }
        public bool IsBooked { get; set; }
    }
}
