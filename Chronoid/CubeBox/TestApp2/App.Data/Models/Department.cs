using System;
using System.Collections.Generic;

namespace App.Data.Models
{
    public partial class Department
    {
        public Department()
        {
            this.JobTitles = new List<JobTitle>();
            this.Users = new List<User>();
        }

        public string ID { get; set; }
        public string Name { get; set; }
        public string CompanyID { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
        public Nullable<bool> isArchived { get; set; }
        public virtual Company Company { get; set; }
        public virtual ICollection<JobTitle> JobTitles { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
