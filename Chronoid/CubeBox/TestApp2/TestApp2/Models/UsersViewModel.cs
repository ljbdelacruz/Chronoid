using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApp2.Models
{
    public class UsersViewModel
    {
        public string ID { get; set; }
        public string Code { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string FirstName { get; set; }
        public string ExtensionName { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string Nationality { get; set; }
        public string Religion { get; set; }
        public string Address { get; set; }
        public string Birthday { get; set; }
        public JobtitleViewModel Jobtitle { get; set; }
        public JobStatusViewModel JobStatus { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string ContactPerson { get; set; }
        public string ContactNumber { get; set; }
        public string profileImage { get; set; }
        public CompanyViewModel Company { get; set; }
        public AspNetUserViewModel aspNetUser { get; set; }
        public ScheduleViewModel schedule { get; set; }
        public string TimeZone { get; set; }
        public DepartmentViewModel Department { get; set; }
        public AspNetUserVM User { get; set; }
    }
}