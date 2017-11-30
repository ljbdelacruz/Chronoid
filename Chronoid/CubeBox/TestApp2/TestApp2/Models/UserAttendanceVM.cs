using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApp2.Models
{
    public class UserAttendanceVM
    {   
        public string id { get; set; }
        public string code { get; set; }
        public string profileImage { get; set; }
        public string name { get; set; }
        public string schedule { get; set; }
        public string actualLoginImage{get;set;}
        public string actualLoginTime { get; set; }
        public string actualLogoutImage { get; set; }
        public string actualLogoutTime { get; set; }
        public string TotalWorkHours { get; set; }
        public string TotalBreakTime { get; set; }
        public string ProductiveHours { get; set; }
        public AttendanceStatusViewModel Status { get; set; }
        public string Remarks { get; set; }
        public string DateCreated { get; set; }
        public string AttendanceDate { get; set; }
        public UsersViewModel User { get; set; }
        public ShiftViewModel Shift { get; set; }

    }
}