using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using App.Data.Models;
using Service.Interface;
using GeneralClass.DateControl;
using GeneralClass.DataVerification.String;

namespace TestApp2.Models.Utilities
{
    public static class UserBreakModelUtility
    {
        #region model to viewModel
        public static UserBreakTimeVM MToVM(UserBreakTime item) {
            var temp = new UserBreakTimeVM()
            {
                id = "" + item.ID,
                User = new UsersViewModel() { ID = item.UserID },
                timeStarted = TimeConverter.ConvertDateTimeToTime(item.StartDateTime.Value),
                timeEnded =  item.EndDateTime.HasValue ? TimeConverter.ConvertDateTimeToTime(item.EndDateTime.Value) : "00:00:00",
                TotalTime = item.TotalTime.HasValue ? item.TotalTime.Value.ToString() : "N/A",
                Type = BreakTypeUtility.MToVM(item.BreakType),
                IsFinished = item.IsFinishedBreak.HasValue ? item.IsFinishedBreak.Value : false,
                Remarks = item.Remarks
            };
            return temp;
        }
        public static List<UserBreakTimeVM> MsToVMs(List<UserBreakTime> items) {
            var tempList = new List<UserBreakTimeVM>();
            foreach (UserBreakTime item in items) {
                var temp = MToVM(item);
                tempList.Add(temp);
            }
            return tempList;
        }
        #endregion

        #region ViewModel to Model
        public static UserBreakTime VMToM(UserBreakTimeVM model) {
            return new UserBreakTime() {
                ID = model.id,
                StartDateTime = DataVerification.IsNull(DataVerification.VerifyData(model.timeStarted)) ? new DateTime() : Convert.ToDateTime(model.timeStarted),
                EndDateTime = DataVerification.IsNull(DataVerification.VerifyData(model.timeEnded)) ? new DateTime() : Convert.ToDateTime(model.timeEnded)
            };
        }
        public static List<UserBreakTime> VMsToMs(List<UserBreakTimeVM> models) {
            var list = new List<UserBreakTime>();
            foreach (UserBreakTimeVM model in models) {
                list.Add(VMToM(model));
            }
            return list;
        }

        #endregion


        //checks if user is still on break or not
        //returns a boolean if not on break
        //returns a UserBreakTime object if it is on break
        public static UserBreakTime IsUserOnBreak(string id, IUserBreakTimeService _userBreakTimeService) {
            try {
                var breaks = _userBreakTimeService.GetAll().Result.Where(ubs => ubs.IsFinishedBreak == false && ubs.UserID == id).LastOrDefault();
                if (breaks != null)
                {
                    return breaks;
                }
                else {
                    return null;
                }
            } catch { return null; }
        }
        //gets the userbreaktime and its breaktype data
        public static UserBreakTime GetUserBreakTimeTypeByID(string id, IUserBreakTimeService _userBreakTimeService) {
            try {
                var item = _userBreakTimeService.GetWithAsyncByID(id).Result;
                Console.WriteLine(item);
                return item;
            } catch { return null; }
        }

        //update UserBreak
        public static bool Update(UserBreakTime item, IUserBreakTimeService _userBreakTimeService) {
            try {
                _userBreakTimeService.Update(item);
                return true;
            } catch { return false; }
        }
        //gets the specific breaktime of users today
        public static UserBreakTime GetBreakTypeUserIDToday(string type, string uid, IUserBreakTimeService _userBreakTimeService, DateTime time) {
            try {
                var result = _userBreakTimeService.GetAll().Result.Where(ubs => ubs.Type == type && ubs.UserID == uid
                                                                         && ubs.StartDateTime.Value.Day == time.Day
                                                                         && ubs.StartDateTime.Value.Month == time.Month
                                                                         && ubs.StartDateTime.Value.Year == time.Year).FirstOrDefault();
                return result;
            } catch {
                return null;
            }
        }
        //checks if the user is done with this break
        public static bool IsBreakTypeDoneToday(string type, string uid, IUserBreakTimeService _userBreakTimeService, DateTime time) {
            try {
                var userBreak = GetBreakTypeUserIDToday(type, uid, _userBreakTimeService, time);
                if (userBreak != null) {
                    return true;
                }
                return false;
            } catch { return false; }
        }
        //this will determine if the user can take a break on this time
        //public static ResponseBreak IsBreakEnableTimeByType(int type, string uid, IScheduleService _scheduleService, DateTime time) {
        //    try {
        //        var response = new ResponseBreak() { message="", enabled=false};
        //        //var usched = AttendanceUtility.GetUserSchedule(uid, _scheduleService);
        //        var breaktime=new TimeSpan();
        //        var disabled=new TimeSpan();
        //        var currTime = time.TimeOfDay;
        //        switch (type) {
        //            case 1:
        //                breaktime = TimeCalculator.AddTime(usched.TimeIn.Value, new TimeSpan(1, 0, 0));
        //                disabled = TimeCalculator.AddTime(usched.TimeIn.Value, new TimeSpan(3, 0, 0));
        //                if (TimeCalculator.CheckIfWithinTheTime(breaktime,disabled, 
        //                                                     currTime)) {
        //                    response.enabled = true;
        //                }
        //                break;
        //            case 2:
        //                breaktime = TimeCalculator.AddTime(usched.TimeIn.Value, new TimeSpan(3, 30, 0));
        //                disabled = TimeCalculator.AddTime(usched.TimeIn.Value, new TimeSpan(5, 0, 0));
        //                if (TimeCalculator.CheckIfWithinTheTime(breaktime,disabled,
        //                                                     currTime)){
        //                    response.enabled = true;
        //                }
        //                break;
        //            case 3:
        //                breaktime = TimeCalculator.AddTime(usched.TimeIn.Value, new TimeSpan(6, 0, 0));
        //                disabled = TimeCalculator.AddTime(usched.TimeIn.Value, new TimeSpan(8, 0, 0));

        //                if (TimeCalculator.CheckIfWithinTheTime(breaktime,disabled,
        //                                                     currTime)){
        //                    response.enabled = true;
        //                }
        //                break;
        //            default:
        //                response.enabled = true;
        //                break;
        //        }
        //        response.message = IsBreakLessOrGreatResponse(breaktime, disabled, currTime);
        //        return response;

        //    } catch { return null; }
        //}

        private static string IsBreakLessOrGreatResponse(TimeSpan basetime, TimeSpan ceilingTime, TimeSpan time) {
            if (TimeCalculator.CheckTimeIfGreater(time, ceilingTime)) {
                return MessageUtility.BreakTimeUnavailable();
            } else if (TimeCalculator.CheckTimeIfLess(time, basetime)) {
                return MessageUtility.ToSoonToTakeABreak();
            }
            return "";
        }
        #region Sorting
        public static List<UserBreakTime> SortByUpdatedAt(List<UserBreakTime> list, bool isReverse) {
            try {
                if (isReverse) {
                    return list.OrderByDescending(ub => ub.UpdatedAt).ToList();
                }
                return list.OrderBy(ub => ub.UpdatedAt).ToList();
            } catch { return list; }
        }
        #endregion

        #region Filter
        public static List<UserBreakTime> FilterByUserID(string id, List<UserBreakTime> models) {
            return models.Where(ub => ub.UserID == id).ToList();
        }
        public static List<UserBreakTime> FilterByStartDateTime(DateTime date, List<UserBreakTime> models) {
            return models.Where(ub => ub.StartDateTime.Value.Date == date.Date).ToList();
        }
        public static List<UserBreakTime> FilterByEndDateTime(DateTime date, List<UserBreakTime> models) {
            return models.Where(ub => ub.EndDateTime.Value.Date == date).ToList();
        }
        public static List<UserBreakTime> FilterByCompanyID(string companyID, List<UserBreakTime> list)
        {
            return list.Where(ub => ub.User.CompanyID == companyID).ToList();
        }
        public static List<UserBreakTime> FilterBreaksByCreatedAt(DateTime from, DateTime to, List<UserBreakTime> models)
        {
            return models.Where(ub => ub.CreatedAt.Value.Date >= from.Date && to.Date <= ub.CreatedAt.Value.Date).ToList();
        }
        public static List<UserBreakTime> FilterBreaksByUpdatedAt(DateTime from, DateTime to, List<UserBreakTime> models) {
            return models.Where(ub => ub.UpdatedAt.Value.Date >= from.Date && to.Date <= ub.UpdatedAt.Value.Date).ToList();
        }
        public static List<UserBreakTime> FilterByType(string type, List<UserBreakTime> models)
        {
            return models.Where(ub => ub.Type == type).ToList();
        }
        public static List<UserBreakTime> FilterByAttendanceID(int id, List<UserBreakTime> models) {
            return models.Where(ub => ub.AttendanceID == id).ToList();
        }
        public static List<UserBreakTime> FilterByIsFinished(bool choice, List<UserBreakTime> models) {
            return models.Where(ub => ub.IsFinishedBreak == choice).ToList();
        }
        #endregion

        #region Functionality
        public static bool IsBreakTypeExist(List<UserBreakTime> models, string type) {
            return models.Where(ub => ub.Type == type).ToList().Count > 0 ? true : false;
        }
        #endregion




    }
}