using System;
using System.Collections.Generic;

namespace App.Data.Models
{
    public partial class Shift
    {
        public Shift()
        {
            this.Attendances = new List<Attendance>();
        }

        public string ID { get; set; }
        public string Name { get; set; }
        public Nullable<System.TimeSpan> TimeIn { get; set; }
        public Nullable<System.TimeSpan> TimeOut { get; set; }
        public Nullable<double> TotalHoursWorked { get; set; }
        public string CompanyID { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<bool> IsArchived { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual Company Company { get; set; }
    }
}
