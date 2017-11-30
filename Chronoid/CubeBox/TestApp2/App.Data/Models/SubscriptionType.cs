using System;
using System.Collections.Generic;

namespace App.Data.Models
{
    public partial class SubscriptionType
    {
        public SubscriptionType()
        {
            this.SubscriptionLimitations = new List<SubscriptionLimitation>();
        }

        public string id { get; set; }
        public string description { get; set; }
        public virtual ICollection<SubscriptionLimitation> SubscriptionLimitations { get; set; }
    }
}
