using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralClass.DateControl
{
    public static class TimeUtility
    {
        public static DateTime GetChinaStandardDateTime()
        {
            var newTime = TimeZoneInfo.ConvertTime(DateTimeOffset.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("China Standard Time"));
            return newTime.DateTime;
        }
        public static DateTime GetManilaStandardTime() {
            var timezone = TimeZoneInfo.ConvertTime( DateTimeOffset.UtcNow,TimeZoneInfo.FindSystemTimeZoneById("Taipei Standard Time"));
            return timezone.DateTime;
        }
        public static DateTime GetCentralStandardTime()
        {
            var timezone = TimeZoneInfo.ConvertTime(DateTimeOffset.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"));
            return timezone.DateTime;
        }
        public static DateTime GetTimeZoneByName(string name) {
            switch (name) {
                case "CH":
                    return GetChinaStandardDateTime();
                case "PH":
                    return GetManilaStandardTime();
                case "USC":
                    return GetCentralStandardTime();
                default:
                    break;
            }
            return DateTime.Now;
        }





    }
}
