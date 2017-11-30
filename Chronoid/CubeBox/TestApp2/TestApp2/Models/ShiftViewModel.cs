using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApp2.Models
{
    public class ShiftViewModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public double TotalWorkedHours { get; set; }
        public string TimeIn { get; set; }
        public string TimeOut { get; set; }
        public CompanyViewModel Company { get; set; }
        public bool IsArchived { get; set; }

    }
}