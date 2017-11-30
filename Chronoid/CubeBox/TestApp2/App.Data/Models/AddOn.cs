using System;
using System.Collections.Generic;

namespace App.Data.Models
{
    public partial class AddOn
    {
        public AddOn()
        {
            this.Attendances = new List<Attendance>();
            this.SchedulesAddOns = new List<SchedulesAddOn>();
        }

        public string ID { get; set; }
        public string Description { get; set; }
        public string CompanyID { get; set; }
        public virtual Company Company { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<SchedulesAddOn> SchedulesAddOns { get; set; }
    }
}
