using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApp2.Models
{
    public class HolidayViewModel
    {
        public string ID { get; set; }
        public string Event { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public string ComapanyID { get; set; }
        public string Type { get; set; }
    }
}