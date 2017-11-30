using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApp2.Models
{
    public class DayVM
    {
        public int id { get; set; }
        public string Day { get; set; }
        public bool isSelected { get; set; }
    }
}