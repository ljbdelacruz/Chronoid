using App.Data.Models;
using GeneralClass.DateControl;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApp2.Models.Utilities
{
    public class AttendanceTaggerUtility
    {
        //this is the one that checks the status that will be tagged on your attendance status
        public static void CheckTimeIn(string uid, IAttendanceService _attendanceService, DateTime time) {
            var result = _attendanceService.GetAll().Result.Where(ass => ass.UserID == uid && ass.AttendanceDate.Value.Date >= time).FirstOrDefault();
        }
    }
}