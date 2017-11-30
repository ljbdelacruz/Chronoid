using System;
using System.Collections.Generic;

namespace App.Data.Models
{
    public partial class AspNetRole
    {
        public AspNetRole()
        {
            this.AspNetUserRoles = new List<AspNetUserRole>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<AspNetUserRole> AspNetUserRoles { get; set; }
    }
}
