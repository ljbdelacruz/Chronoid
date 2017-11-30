using System;
using System.Collections.Generic;

namespace App.Data.Models
{
    public partial class User
    {
        public User()
        {
            this.Attendances = new List<Attendance>();
            this.BreakTypes = new List<BreakType>();
            this.SchedulesAddOns = new List<SchedulesAddOn>();
            this.SystemLogs = new List<SystemLog>();
            this.UserBreakTimes = new List<UserBreakTime>();
        }

        public string ID { get; set; }
        public string Code { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string ExtensionName { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string Nationality { get; set; }
        public string Religion { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public string JobTitleID { get; set; }
        public string DepartmentID { get; set; }
        public string Email { get; set; }
        public Nullable<int> RoleID { get; set; }
        public string Token { get; set; }
        public string ContactNumber { get; set; }
        public string ProfileImage { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public string Address { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPersonNumber { get; set; }
        public string JobStatusID { get; set; }
        public string GoogleEmail { get; set; }
        public Nullable<int> ManagerID { get; set; }
        public Nullable<int> HouseID { get; set; }
        public Nullable<System.DateTime> DateHired { get; set; }
        public string AspNetUserID { get; set; }
        public Nullable<System.DateTime> DateEnded { get; set; }
        public Nullable<int> ClientID { get; set; }
        public Nullable<System.DateTime> TrainingStarted { get; set; }
        public Nullable<System.DateTime> TrainingEnded { get; set; }
        public Nullable<int> LoginAccount { get; set; }
        public string OnlineStatus { get; set; }
        public string CompanyID { get; set; }
        public string TimeZone { get; set; }
        public Nullable<bool> isArchived { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<BreakType> BreakTypes { get; set; }
        public virtual Company Company { get; set; }
        public virtual Department Department { get; set; }
        public virtual JobStatu JobStatu { get; set; }
        public virtual JobTitle JobTitle { get; set; }
        public virtual ICollection<SchedulesAddOn> SchedulesAddOns { get; set; }
        public virtual ICollection<SystemLog> SystemLogs { get; set; }
        public virtual ICollection<UserBreakTime> UserBreakTimes { get; set; }
    }
}
