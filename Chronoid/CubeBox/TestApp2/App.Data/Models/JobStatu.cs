using System;
using System.Collections.Generic;

namespace App.Data.Models
{
    public partial class JobStatu
    {
        public JobStatu()
        {
            this.Users = new List<User>();
        }

        public string ID { get; set; }
        public string Description { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
