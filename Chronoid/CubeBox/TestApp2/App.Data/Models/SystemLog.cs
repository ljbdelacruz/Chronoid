using System;
using System.Collections.Generic;

namespace App.Data.Models
{
    public partial class SystemLog
    {
        public int ID { get; set; }
        public Nullable<int> LogID { get; set; }
        public string CompanyID { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public virtual Company Company { get; set; }
        public virtual LogDescription LogDescription { get; set; }
        public virtual User User { get; set; }
    }
}
