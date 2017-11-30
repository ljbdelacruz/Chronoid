using App.Data.Models;
using GeneralClass.DataVerification.String;
using GeneralClass.DateControl;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

namespace TestApp2.Models.Utilities
{
    public static class AttendanceUtility
    {

        #region Attendance
        #region Model to ViewModel
        public static UserAttendanceVM MToVM(Attendance item) {
            var temp = new UserAttendanceVM()
            {
                id = item.ID,
                profileImage = item.User.ProfileImage == null ? "/Assets/images/no-image.jpg" : item.User.ProfileImage,
                name = item.User.FirstName + " " + item.User.LastName + " " + item.User.ExtensionName,
                actualLoginImage = item.TimeInImage == null ? "/Assets/images/no-image.jpg" : item.TimeInImage,
                actualLoginTime = item.TimeIn.HasValue ? item.TimeIn.Value.Hours + ":" + item.TimeIn.Value.Minutes : "not yet",
                actualLogoutImage = item.TimeOutImage == null ? "/Assets/images/no-image.jpg" : item.TimeOutImage,
                actualLogoutTime = item.TimeOut != null ? item.TimeOut.Value.Hours + ":" + item.TimeOut.Value.Minutes : "not yet",
                TotalWorkHours = item.HrsWork.HasValue ? item.HrsWork.Value.ToString() : "N/A",
                TotalBreakTime = item.TotalBreakTime.HasValue ? item.TotalBreakTime.Value.ToString() : "N/A",
                ProductiveHours = item.ProductiveHrs.HasValue ? item.ProductiveHrs.Value.ToString() : "N/A",
                Remarks = item.Remarks == "" || item.Remarks == null ? "N/A" : item.Remarks,
                DateCreated = TimeFormatter.DateToString(item.CreatedAt.Value),
                AttendanceDate = TimeFormatter.DateToString(item.AttendanceDate.Value),
                User = new UsersViewModel() { ID = item.User.ID, FirstName=item.User.FirstName, LastName=item.User.LastName, MiddleName=item.User.MiddleName, ExtensionName=item.User.ExtensionName },
                Shift = new ShiftViewModel() { ID = item.ShiftID, TimeIn=item.Shift.TimeIn.HasValue ? item.Shift.TimeIn.Value.ToString() : "00:00:00",TimeOut=item.Shift.TimeOut.HasValue ? item.Shift.TimeOut.Value.ToString() : "00:00:00" },
                Status = new AttendanceStatusViewModel() { ID = item.AttendanceStatusID }
            };
            return temp;
        }
        public static List<UserAttendanceVM> MsToVMs(List<Attendance> items) {
            var templist = new List<UserAttendanceVM>();
            foreach (Attendance item in items) {
                var temp = MToVM(item);
                templist.Add(temp);
            }
            return templist;
        }
        #endregion
        #region ViewModel to Model
        public static Attendance VMToM(UserAttendanceVM model) {
            return new Attendance() {
                ID=model.id,
                UserID=model.User.ID,
                AttendanceStatusID=model.Status.ID,
                AttendanceDate=Convert.ToDateTime(model.AttendanceDate),
                TimeIn= !DataVerification.IsNull(DataVerification.VerifyData(model.actualLogoutTime)) ? TimeSpan.Parse(model.actualLoginTime) : new TimeSpan(),
                TimeOut= !DataVerification.IsNull(DataVerification.VerifyData(model.actualLogoutTime)) ? TimeSpan.Parse(model.actualLogoutTime) : new TimeSpan(),
                TimeInImage=model.actualLoginImage,
                TimeOutImage=model.actualLogoutImage,
                Remarks=model.Remarks,
                HrsWork= !DataVerification.IsNull(DataVerification.VerifyData(model.TotalWorkHours)) ? TimeSpan.Parse(model.TotalWorkHours) : new TimeSpan(),
                ProductiveHrs= !DataVerification.IsNull(DataVerification.VerifyData(model.ProductiveHours)) ? TimeSpan.Parse(model.ProductiveHours) : new TimeSpan(),
                TotalBreakTime= !DataVerification.IsNull(DataVerification.VerifyData(model.ProductiveHours)) ? TimeSpan.Parse(model.TotalBreakTime) : new TimeSpan(),
                ShiftID=model.Shift.ID
            };
        }
        public static Attendance VMToM(AttendanceViewModel model) {
            return new Attendance() {
                ID=model.ID,
                UserID=model.UserID,
                AttendanceStatusID=model.AttendanceStatusID,
                AttendanceDate=model.AttendanceDate,
                TimeIn=model.timeIn,
                TimeOut=model.timeOut,
                TimeInImage=model.timeInImage,
                TimeOutImage=model.timeOutImage,
                Remarks=model.remarks,
                CreatedAt=model.createdAt,
                CreatedBy=model.CreatedBy,
                UpdatedAt=model.UpdatedAt,
                UpdatedBy=model.updatedBy,
                Shift=ShiftUtility.VMToM(model.Shift)
            };
        }
        public static List<Attendance> VMsToMs(List<AttendanceViewModel> models) {
            var list = new List<Attendance>();
            foreach (AttendanceViewModel model in models) {
                list.Add(VMToM(model));
            }
            return list;
        }



        #endregion

        #region Verification
        public static bool IsScheduleAlreadyExist(List<Attendance> list, DateTime date) {
            return list.Where(a => a.AttendanceDate == date).ToList().Count > 0 ? true : false;
        }
        #endregion
        #region Functionalities
        public static Attendance GetAttendanceNowByUserID(string id, IAttendanceService _attendanceService, DateTime time)
        {
            try
            {
                var result = _attendanceService.GetAll().Result.Where(ats => ats.UserID == id
                                                                      && ats.AttendanceDate.Value.Day == time.Day
                                                                      && ats.AttendanceDate.Value.Month == time.Month
                                                                      && ats.AttendanceDate.Value.Year == time.Year).FirstOrDefault();
                return result;
            }
            catch (Exception e) { Console.WriteLine(e); throw; }
        }
        public static string GetTimeInOutString(string id, IAttendanceService _attendanceService, int type, DateTime time) {
            var result = type == 1 ? GetAttendanceNowByUserID(id, _attendanceService, time).TimeIn : GetAttendanceNowByUserID(id, _attendanceService, time).TimeOut;
            if (result != null)
            {
                var extra = TimeCalculator.IdentifyMeridiem(result.Value.Hours);
                var hour = result.Value.Hours > 12 ? result.Value.Hours - 12 : result.Value.Hours;
                return hour + ":" + result.Value.Minutes + " " + extra;
            }
            return null;
        }
        public static List<Attendance> GetUserAttendanceByDate(DateTime fromDate, DateTime toDate, IAttendanceService _attendanceService) {
            try {
                var list = _attendanceService.GetAllWithAsync().Result.Where(ats => ats.AttendanceDate.Value.Date >= fromDate.Date
                                                                    && ats.AttendanceDate.Value.Date <= toDate.Date).ToList();
                return list;
            } catch(Exception e) { return null; }
        }
        public static bool IsUserExistByLoginID(string loginID, List<User> list) {

            var result = list.Where(us => us.Code == loginID).FirstOrDefault();
            if (result == null) {
                return false;
            }
            return true;
        }
        public static string UploadImage(HttpRequestBase request, HttpServerUtilityBase server, string path) {
            try {
                var result = FileUploadUtility.UploadImageFile(request, server, path);
                return result;
            } catch { return null; }
        }
        #endregion
        #region identify if user is login or logout
        public static bool IsUserAlreadyLogin(string userID, IAttendanceService _attendanceService, DateTime time) {
            var result = _attendanceService.GetAll().Result.Where(ass => ass.UserID == userID && ass.AttendanceDate.Value.Date >= time.Date).FirstOrDefault();
            if (result != null) {
                return true;
            }
            return false;
        }
        public static bool IsUserAlreadyLogout(string userID, IAttendanceService _attendanceService, DateTime time)
        {
            var result = _attendanceService.GetAll().Result.Where(ass => ass.UserID == userID && ass.AttendanceDate.Value.Date >= time.Date && ass.TimeOutImage == null).FirstOrDefault();
            if (result == null)
            {
                return true;
            }
            return false;
        }
        #endregion
        #region sorting
        public static List<Attendance> SortByActualLogoutTime(List<Attendance> list, bool isReverse) {
            try {
                if (isReverse) {
                    return list.OrderByDescending(a => a.TimeOut).ToList();
                }
                return list.OrderBy(a => a.TimeOut).ToList();
            } catch { return list; }
        }
        public static List<Attendance> SortByActualLoginTime(List<Attendance> list, bool isReverse) {
            try
            {
                if (isReverse)
                {
                    return list.OrderByDescending(a => a.TimeIn).ToList();
                }
                return list.OrderBy(a => a.TimeIn).ToList();
            }
            catch { return list; }
        }
        public static List<Attendance> SortByActualDateTime(List<Attendance> list, bool isReverse) {
            return isReverse ? list.OrderByDescending(a => a.AttendanceDate).ToList() : list.OrderBy(a => a.AttendanceDate).ToList();
        }

        #endregion
        #region Filter
        public static List<Attendance> FilterByID(string id, List<Attendance> models) {
            return models.Where(a => a.ID == id).ToList();
        }
        public static List<Attendance> FilterByCompanyID(string id, List<Attendance> list) {
            try {
                return list.Where(a => a.User.CompanyID == id).ToList();
            } catch { return list; }
        }
        public static List<Attendance> FilterByUserID(string id, List<Attendance> list, bool opposite) {
            return opposite ? list.Where(a=>a.UserID != id).ToList() : list.Where(a => a.UserID == id).ToList();
        }
        public static List<Attendance> FilterByDateFromTo(DateTime fromDate, DateTime toDate, List<Attendance> list) {
            return list.Where(ats => ats.AttendanceDate.Value.Date >= fromDate.Date
                                     && ats.AttendanceDate.Value.Date <= toDate.Date).ToList();
        }
        public static List<Attendance> FilterByTimeIn(dynamic time, List<Attendance> models, bool opposite) {
            return opposite ? models.Where(a=>a.TimeIn != time).ToList() : models.Where(a => a.TimeIn == time).ToList();
        }
        public static List<Attendance> FilterTimeIn(List<Attendance> models, bool isNull)
        {
            return isNull ? models.Where(a => a.TimeIn == null).ToList() : models.Where(a => a.TimeIn != null).ToList();
        }
        public static List<Attendance> FilterByIsArchived(List<Attendance> list, bool isArchived) {
            return list.Where(a => a.IsArchived == isArchived).ToList();
        }

        #endregion
        #region subfunction
        public static string BreakIdentify(string type)
        {
            switch (type)
            {
                case "1":
                    return "Morning";
                case "2":
                    return "Lunch";
                case "3":
                    return "Afternoon";
                case "4":
                    return "Side-By-Side";
                case "5":
                    return "One-on-One";
                case "6":
                    return "BIO";
                case "7":
                    return "AFK";
            }
            return "Unspecified";
        }

        #endregion

        #endregion

    }
}