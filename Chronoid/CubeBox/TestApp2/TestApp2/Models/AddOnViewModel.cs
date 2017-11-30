using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApp2.Models
{
    public class AddOnViewModel
    {
        public string ID { get; set; }
        public string Description { get; set; }
        public CompanyViewModel Company { get; set; }


    }
}