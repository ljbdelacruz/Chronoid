using System;
using System.Collections.Generic;

namespace App.Data.Models
{
    public partial class ScheduleWeek
    {
        public string ID { get; set; }
        public string Week_ID { get; set; }
        public Nullable<int> Schedule_ID { get; set; }
        public virtual Week Week { get; set; }
    }
}
