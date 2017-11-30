using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralClass.DateControl
{
    public static class TimeConverter
    {
        //Monday, Tuesday, etc...
        public static string ConvertTimeDDDD(DateTime time)
        {
            return time.ToString("dddd");
        }
        //january,february, etc....
        public static string ConvertTimeMMMM(DateTime time)
        {
            return time.ToString("MMMM");
        }
        //day number
        public static int ConvertTimeDay(DateTime time)
        {
            return time.Day;
        }
        //month number
        public static int ConvertTimeMonth(DateTime time) {
            return time.Month;
        }
        //year number
        public static int ConvertTimeYear(DateTime time) {
            return time.Year;
        }
        public static string ConvertDateTimeToTime(DateTime date)
        {
            //1:23:1 AM format
            var extra = "";
            var hour = date.Hour;
            if (date.Hour >= 12)
            {
                extra = "PM";
                hour = date.Hour > 12 ? date.Hour - 12 : 12;
            }
            else
            {
                extra = "AM";
            }
            return hour + ":" + date.Minute + ":" + date.Second + " " + extra;
        }


    }
}
