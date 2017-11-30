using System;
using System.Collections.Generic;

namespace App.Data.Models
{
    public partial class SchedulesAddOn
    {
        public string ID { get; set; }
        public string AddOnType { get; set; }
        public string UserID { get; set; }
        public Nullable<System.DateTime> FromDate { get; set; }
        public Nullable<System.DateTime> ToDate { get; set; }
        public Nullable<double> Hours { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public string AttendanceID { get; set; }
        public virtual AddOn AddOn { get; set; }
        public virtual Attendance Attendance { get; set; }
        public virtual User User { get; set; }
    }
}
