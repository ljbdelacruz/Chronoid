using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralClass.DateControl
{
    public class TimeFormatter
    {
        //adds 0 if digit is single ex. 01, 09
        public static string DigitalClock(int value)
        {
            if (("" + value).Length > 1)
            {
                return "" + value;
            }
            else
            {
                return "0" + value;
            }
        }
        public static string DateTime1(DateTime time) {
            //Sample format
            //Friday, August 11, 2017
            return TimeConverter.ConvertTimeDDDD(time) + ", " + TimeConverter.ConvertTimeMMMM(time) + " " + TimeConverter.ConvertTimeDay(time) + ", " + TimeConverter.ConvertTimeYear(time);
        }
        public static string DateToString(DateTime time) {
            //returns mm/dd/yyyy
            return time.Month + "/" + time.Day + "/" + time.Year;
        }
        public static string DateToString1(DateTime time)
        {
            //returns mm/dd/yyyy
            return time.Month + "-" + time.Day + "-" + time.Year;
        }

        public static string PrettyClock(int value)
        {
            if (("" + value).Length > 1)
            {
                return "" + value;
            }
            else
            {
                return "0" + value;
            }
        }
        public static string Extras(int hour)
        {
            return hour > 12 ? "PM" : "AM";
        }

    }
}
