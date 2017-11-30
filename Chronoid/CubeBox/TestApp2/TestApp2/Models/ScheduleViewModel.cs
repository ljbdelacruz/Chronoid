using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApp2.Models
{
    public class ScheduleViewModel
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public int FromDay{ get; set; }
        public int ToDay { get; set; }
        public TimeSpan TimeIn { get; set; }
        public TimeSpan TimeOut { get; set; }
        public Double WorkHours { get; set; }
        public string Comments { get; set; }
        public string CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }

}