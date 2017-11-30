using System;
using System.Collections.Generic;

namespace App.Data.Models
{
    public partial class CompanySubscription
    {
        public string id { get; set; }
        public Nullable<int> subscriptionID { get; set; }
        public string companyID { get; set; }
        public Nullable<System.DateTime> dateStarted { get; set; }
        public Nullable<System.DateTime> dateCreated { get; set; }
        public Nullable<bool> isActiveSubscription { get; set; }
    }
}
