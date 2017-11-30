using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApp2.Models
{
    public class DepartmentViewModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public CompanyViewModel Company { get; set; }
        public string CreatedAt { get; set; }
        public UsersViewModel CreatedBy { get; set; }
        public string UpdatedAt { get; set; }
        public UsersViewModel UpdatedBy { get; set; }
    }
}