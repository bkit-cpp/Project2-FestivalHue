﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalHue.ViewModel.NewOfSchedule
{
    public class NewofScheduleUpdateRequest
    {
        public int Id { get; set; }
        public DateTime EndedDate { get; set; }
        public string TripType { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}