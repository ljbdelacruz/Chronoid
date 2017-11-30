using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralClass.DataVerification.String
{
    public static class DataVerification
    {
        public static dynamic VerifyData(dynamic data)
        {
            if (data == "not yet" || data == "N/A")
            {
                return null;
            }
            return data;
        }
        public static bool IsNull(dynamic data) {
            if (data == null) {
                return true;
            }
            return false;
        }
    }
}
