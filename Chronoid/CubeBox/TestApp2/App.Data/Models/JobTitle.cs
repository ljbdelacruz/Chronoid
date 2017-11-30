using System;
using System.Collections.Generic;

namespace App.Data.Models
{
    public partial class JobTitle
    {
        public JobTitle()
        {
            this.Users = new List<User>();
        }

        public string ID { get; set; }
        public string Description { get; set; }
        public string CompanyID { get; set; }
        public string DepartmentID { get; set; }
        public Nullable<bool> isArchived { get; set; }
        public virtual Company Company { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
