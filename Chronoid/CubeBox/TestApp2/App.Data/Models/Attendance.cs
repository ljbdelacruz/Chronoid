using System;
using System.Collections.Generic;

namespace App.Data.Models
{
    public partial class Attendance
    {
        public Attendance()
        {
            this.SchedulesAddOns = new List<SchedulesAddOn>();
        }

        public string ID { get; set; }
        public string UserID { get; set; }
        public string AttendanceStatusID { get; set; }
        public Nullable<System.DateTime> AttendanceDate { get; set; }
        public Nullable<System.TimeSpan> TimeIn { get; set; }
        public Nullable<System.TimeSpan> TimeOut { get; set; }
        public string TimeInImage { get; set; }
        public string TimeOutImage { get; set; }
        public string Remarks { get; set; }
        public Nullable<System.TimeSpan> HrsWork { get; set; }
        public Nullable<System.TimeSpan> ProductiveHrs { get; set; }
        public Nullable<System.TimeSpan> TotalBreakTime { get; set; }
        public Nullable<System.TimeSpan> TotalLateTime { get; set; }
        public Nullable<System.TimeSpan> TotalUnderTime { get; set; }
        public Nullable<System.TimeSpan> TotalOverBreak { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public string ShiftID { get; set; }
        public string AddOnID { get; set; }
        public Nullable<bool> IsArchived { get; set; }
        public virtual AddOn AddOn { get; set; }
        public virtual Shift Shift { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<SchedulesAddOn> SchedulesAddOns { get; set; }
    }
}
