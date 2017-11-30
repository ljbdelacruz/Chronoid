using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApp2.Models.Utilities
{
    public class APISecurity
    {
        public static bool IsAllowAPIAccessByKey(string key, string role) {
            if (key.Contains(role))
            {
                return true;
            }
            return false;
        }


    }
}