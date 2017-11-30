using System;
using System.Collections.Generic;

namespace App.Data.Models
{
    public partial class Holiday
    {
        public string ID { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string CompanyID { get; set; }
        public virtual Company Company { get; set; }
    }
}
