using System;
using System.Collections.Generic;

namespace App.Data.Models
{
    public partial class AspNetUserRole
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public System.Guid id { get; set; }
        public virtual AspNetRole AspNetRole { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }
    }
}
