using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApp2.Models
{
    public class AspNetUserViewModel
    {
        public string ID { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public bool IsOnline { get; set; }
        public string passwordHash { get; set; }
    }
}