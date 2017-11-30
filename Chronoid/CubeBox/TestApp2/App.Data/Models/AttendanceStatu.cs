using System;
using System.Collections.Generic;

namespace App.Data.Models
{
    public partial class AttendanceStatu
    {
        public string ID { get; set; }
        public string Description { get; set; }
        public string CompanyID { get; set; }
        public Nullable<bool> IsArchived { get; set; }
        public virtual Company Company { get; set; }
    }
}
