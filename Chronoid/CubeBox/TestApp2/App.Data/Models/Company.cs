using System;
using System.Collections.Generic;

namespace App.Data.Models
{
    public partial class Company
    {
        public Company()
        {
            this.AddOns = new List<AddOn>();
            this.AttendanceStatus = new List<AttendanceStatu>();
            this.BreakTypes = new List<BreakType>();
            this.Departments = new List<Department>();
            this.Holidays = new List<Holiday>();
            this.JobTitles = new List<JobTitle>();
            this.Shifts = new List<Shift>();
            this.SystemLogs = new List<SystemLog>();
            this.SystemSettings = new List<SystemSetting>();
            this.Users = new List<User>();
        }

        public string id { get; set; }
        public string name { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public virtual ICollection<AddOn> AddOns { get; set; }
        public virtual ICollection<AttendanceStatu> AttendanceStatus { get; set; }
        public virtual ICollection<BreakType> BreakTypes { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<Holiday> Holidays { get; set; }
        public virtual ICollection<JobTitle> JobTitles { get; set; }
        public virtual ICollection<Shift> Shifts { get; set; }
        public virtual ICollection<SystemLog> SystemLogs { get; set; }
        public virtual ICollection<SystemSetting> SystemSettings { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
