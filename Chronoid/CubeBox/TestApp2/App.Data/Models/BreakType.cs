using System;
using System.Collections.Generic;

namespace App.Data.Models
{
    public partial class BreakType
    {
        public BreakType()
        {
            this.UserBreakTimes = new List<UserBreakTime>();
        }

        public string id { get; set; }
        public string Description { get; set; }
        public string CompanyID { get; set; }
        public Nullable<System.TimeSpan> EnableTime { get; set; }
        public Nullable<System.TimeSpan> DisableTime { get; set; }
        public string HexColor { get; set; }
        public Nullable<int> OrderNumber { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<int> TimeLimit { get; set; }
        public Nullable<bool> isArchived { get; set; }
        public virtual Company Company { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<UserBreakTime> UserBreakTimes { get; set; }
    }
}
