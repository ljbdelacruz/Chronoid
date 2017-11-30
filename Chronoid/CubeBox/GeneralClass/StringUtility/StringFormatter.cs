using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralClass.StringUtility
{
    public static class StringFormatter
    {
        public static string RemoveStringCharacter(string part, string whole) {
            try {
                return whole.Replace(part, "");
            } catch {
                return whole;
            }
        }
        public static string figure3DigitBeautify(string whole) {
            return whole.Length >= 3 ? whole : whole.Length == 2 ? "0" + whole : "00" + whole;  
        }
    }
}
