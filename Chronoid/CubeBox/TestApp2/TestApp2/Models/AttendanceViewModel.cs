using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApp2.Models
{
    public class AttendanceViewModel
    {
        public string ID { get; set; }
        public string UserID { get; set; }
        public int ScheduleID { get; set; }
        public string AttendanceStatusID { get; set; }
        public DateTime AttendanceDate { get; set; }
        public DateTime date { get; set; }
        public TimeSpan timeIn { get; set; }
        public TimeSpan timeOut { get; set; }
        public TimeSpan HoursWorked { get; set; }
        public TimeSpan ProductiveHours { get; set; }
        public TimeSpan TotalBreakTime { get; set; }
        public TimeSpan TotalLate { get; set; }
        public TimeSpan TotalUnderTime { get; set; }
        public TimeSpan TotalOverBreak { get; set; }
        public string timeInImage { get; set; }
        public string timeOutImage { get; set; }
        public string remarks { get; set; }
        public DateTime createdAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string updatedBy { get; set; }
        public ShiftViewModel Shift { get; set; }
    }
}