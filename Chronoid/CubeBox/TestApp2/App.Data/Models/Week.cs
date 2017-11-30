using System;
using System.Collections.Generic;

namespace App.Data.Models
{
    public partial class Week
    {
        public Week()
        {
            this.ScheduleWeeks = new List<ScheduleWeek>();
        }

        public string ID { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ScheduleWeek> ScheduleWeeks { get; set; }
    }
}
