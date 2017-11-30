using System;
using System.Collections.Generic;

namespace App.Data.Models
{
    public partial class SystemSetting
    {
        public string id { get; set; }
        public Nullable<int> language { get; set; }
        public Nullable<int> timezone { get; set; }
        public string companyID { get; set; }
        public virtual Company Company { get; set; }
    }
}
