using System;
using System.Collections.Generic;

namespace App.Data.Models
{
    public partial class UserBreakTime
    {
        public string ID { get; set; }
        public string UserID { get; set; }
        public Nullable<System.DateTime> StartDateTime { get; set; }
        public Nullable<System.DateTime> EndDateTime { get; set; }
        public Nullable<System.DateTime> WorkDateTime { get; set; }
        public Nullable<System.TimeSpan> TotalTime { get; set; }
        public string Type { get; set; }
        public Nullable<int> AttendanceID { get; set; }
        public Nullable<bool> IsFinishedBreak { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
        public virtual BreakType BreakType { get; set; }
        public virtual User User { get; set; }
    }
}
