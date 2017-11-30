using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralClass.Operators.String
{
    public static class Comparison
    {
        public static bool IsNullOrEmpty(string data) {
            return data == null || data == "" ? true : false;
        }


    }
}
