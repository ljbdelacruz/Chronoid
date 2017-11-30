using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApp2.Models
{
    public class WeeklySequenceViewModel
    {
        public int ID { get; set; }
        public int WeekID { get; set; }
        public UsersViewModel User { get; set; }
        public CompanyViewModel Company { get; set; }

    }
}