using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalHue.ViewModel.Schedules
{
    public class ScheduleEditRequest
    {
        public int IdSchedule { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int TicketId { get; set; }
       
    }
}
