using System;
using System.Collections.Generic;

namespace App.Data.Models
{
    public partial class SubscriptionLimitation
    {
        public int ID { get; set; }
        public Nullable<int> Admins { get; set; }
        public Nullable<int> Users { get; set; }
        public string SubscriptionID { get; set; }
        public virtual SubscriptionType SubscriptionType { get; set; }
    }
}
