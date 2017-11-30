using System;
using System.Collections.Generic;

namespace App.Data.Models
{
    public partial class LogDescription
    {
        public LogDescription()
        {
            this.SystemLogs = new List<SystemLog>();
        }

        public int ID { get; set; }
        public string Description { get; set; }
        public virtual ICollection<SystemLog> SystemLogs { get; set; }
    }
}
