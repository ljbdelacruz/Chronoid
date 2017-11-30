using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralClass.DateControl
{
    public class TimeCalculator
    {
        //Utilities
        //returns am or pm based on the time
        #region Utility
        public static string IdentifyMeridiem(int hour)
        {
            return hour > 12 ? "PM" : "AM";
        }
        #endregion

        #region MDAS
        public static TimeSpan SubtructTime(TimeSpan timeStarted, TimeSpan timeNow)
        {
            try
            {
                var total = timeNow - timeStarted;
                return total;
            }
            catch { throw; }
        }
        public static TimeSpan SubtructTime(DateTime dateStarted, DateTime dateNow) {
            return dateNow-dateStarted;
        }

        public static TimeSpan AddTime(TimeSpan timeStarted, TimeSpan addOns)
        {
            return timeStarted + addOns;
        }

        #endregion

        #region Comparison
        public static bool CheckTimeIfLess(TimeSpan current, TimeSpan breaktime)
        {
            if (current < breaktime)
            {
                return true;
            }
            return false;
        }
        public static bool CheckTimeIfGreater(TimeSpan current, TimeSpan breaktime)
        {
            if (current > breaktime)
            {
                return true;
            }
            return false;
        }
        public static bool CheckIfEqual(TimeSpan current, TimeSpan breaktime)
        {
            if (current == breaktime)
            {
                return true;
            }
            return false;
        }
        public static bool CheckIfWithinTheTime(TimeSpan baseTime, TimeSpan ceilingTime, TimeSpan time)
        {
            if (time >= baseTime && time <= ceilingTime)
            {
                return true;
            }
            return false;
        }
        #endregion


    }
}
