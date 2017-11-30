using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApp2.Models
{
    public class GroupScheduleVM
    {
        public List<UsersViewModel> Users { get; set; }
        public DateTime from { get; set; }
        public DateTime to { get; set; }
        public List<DayVM> Week { get; set; }
        public string shiftID { get; set; }
    }
}