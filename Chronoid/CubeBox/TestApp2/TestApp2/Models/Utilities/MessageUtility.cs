using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApp2.Models.Utilities
{
    public static class MessageUtility
    {

        #region Users

        public static string UserLoginIDNONExist() {
            return "User Login ID Non Existent Please use valid Login ID";
        }
        public static string UserLoginWrong() {
            return "Username and Password Incorrect Please Login Existing Account";
        }
        #endregion
        #region Break
        public static string ToSoonToTakeABreak()
        {
            return "Its to soon to take a break";
        }
        public static string BreakFinished()
        {
            return "Break Already Finished";
        }
        public static string BreakTimeUnavailable()
        {
            return "Sorry Break time Unavailable";
        }
        #endregion
        #region Attendance
        public static string UserAlreadyTimedIn()
        {
            return "User Already Timed In";
        }
        public static string UserAlreadyTimedOut()
        {
            return "User Already Timed Out";
        }
        public static string TimeOff()
        {
            return "Sorry You Have No Schedule Today";
        }
        #endregion
        #region Server Errors


        //internal server errors
        public static string ServerError() {
            return "Server Error";
        }


        #endregion
        #region Security
        public static string NoAccessPriviledges() {
            return "Sorry You Have No Rights To Access This";
        }
        #endregion
    }
}