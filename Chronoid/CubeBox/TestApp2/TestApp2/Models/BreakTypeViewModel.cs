using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApp2.Models
{
    public class BreakTypeViewModel
    {
        public string ID { get; set; }
        public string Description { get; set; }
        public int TimeLimit { get; set; }
        public int OrderNumber { get; set; }
        public string CompanyID { get; set; }
        public string HexColor { get; set; }
        public string EnableTime { get; set; }
        public string DisableTime { get; set; }
    }
}