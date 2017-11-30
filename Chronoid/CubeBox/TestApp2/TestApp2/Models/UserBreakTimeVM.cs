using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApp2.Models
{
    public class UserBreakTimeVM
    {
        public string id { get; set; }
        public UsersViewModel User { get; set; }
        public string timeStarted { get; set; }
        public string timeEnded { get; set; }
        public string TotalTime { get; set; }
        public BreakTypeViewModel Type { get; set; }
        public bool IsFinished { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }


    }
}