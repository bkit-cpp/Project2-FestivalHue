using FestivalHue.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalHue.Data.Entities
{
    public class CategoryOfEvent
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public Status status { get; set; }
        public List<TicketInCategory> TicketInCategories { get; set; }


 }
}
