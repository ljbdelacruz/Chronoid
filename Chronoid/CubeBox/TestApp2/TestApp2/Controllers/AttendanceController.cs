using App.Data.Models;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TestApp2.Models;
using GeneralClass.DateControl;
using TestApp2.Models.Utilities;
using GeneralClass.Utility.ImageUpload;
using GeneralClass.Utility.PathChecker;
using GeneralClass.StringUtility;
using System.Text;

namespace TestApp2.Controllers
{
    public class AttendanceController : ApplicationController
    {
        private IUserService _userService;
        private IAttendanceService _attendanceService;
        public AttendanceController(IUserService userService, IAttendanceService attendanceService):base(userService) {
            _userService = userService;
            _attendanceService = attendanceService;
        }
        #region Attendance
        #region HttpGet

        [HttpGet]
        public async Task<JsonResult> GetTimeInToday() {
            try
            {
                var list = AttendanceUtility.FilterByUserID(CurrentUser.ID, _attendanceService.GetAllWithAsync().Result.ToList(),false);
                var model = AttendanceUtility.FilterByDateFromTo(GetCurrentTime(), GetCurrentTime(), list).FirstOrDefault();
                if (model != null)
                {
                    return Json(new { success = true, data = AttendanceUtility.MToVM(model) }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { success = false, data = "" }, JsonRequestBehavior.AllowGet);
            } catch(Exception e) { return Json(new { success = false, data = e}, JsonRequestBehavior.AllowGet); }
        }

        //this one gets the list of user that time ins today
        [HttpGet]
        public async Task<JsonResult> GetAllUsersTimeInToday() {
            try {
                var list = _attendanceService.GetAllWithAsync().Result.ToList();
                list = list != null ? AttendanceUtility.FilterByCompanyID(CurrentUser.CompanyID, list).ToList() : list;
                list = AttendanceUtility.FilterByTimeIn(null, list, true);
                list = AttendanceUtility.FilterByDateFromTo(this.GetCurrentTime(),this.GetCurrentTime(),list).ToList();
                list = AttendanceUtility.SortByActualLoginTime(list, false).ToList();
                list = AttendanceUtility.SortByActualLogoutTime(list, false);
                var vms = AttendanceUtility.MsToVMs(list);
                return Json(new { success = true, data= vms }, JsonRequestBehavior.AllowGet);
            } catch(Exception e) { return Json(new { success = false, message=MessageUtility.ServerError(), exception=e }, JsonRequestBehavior.AllowGet);  }
        }

        [HttpGet]
        public async Task<JsonResult> GetByUserIDDate(string id, DateTime fromDate, DateTime toDate) {
            try
            {
                var list = new List<Attendance>();
                if (id == null || id == "")
                {
                    list = AttendanceUtility.FilterByCompanyID(CurrentUser.CompanyID,_attendanceService.GetAllWithAsync().Result.ToList());
                }
                else {
                    list = AttendanceUtility.FilterByUserID(id, _attendanceService.GetAllWithAsync().Result.ToList(), false).ToList();
                }
                list = AttendanceUtility.FilterByIsArchived(list, false);
                list = AttendanceUtility.FilterByDateFromTo(fromDate, toDate, list).ToList();
                
                list = AttendanceUtility.SortByActualDateTime(list, false);
                return Json(new { success = true, data = AttendanceUtility.MsToVMs(list) }, JsonRequestBehavior.AllowGet);
            } catch(Exception e) {
                return Json(new { success = false, error=e }, JsonRequestBehavior.AllowGet); }
        }


        #endregion

        #region HttpPost
        [HttpPost]
        public async Task<JsonResult> LoginUser(string Code, string imageUri)
        {
            try
            {
                var path = Server.MapPath("/UPLOADS/SubscriberFiles/" + CurrentUser.CompanyID);
                var file = PathChecker.FindAvailableFileName(path, "File");
                var users = UsersUtility.FilterByCompany(CurrentUser.CompanyID, _userService.GetAll().Result.ToList());
                    var user = UsersUtility.FilterByCode(StringFormatter.RemoveStringCharacter(" ", Code), users);
                    if (user.Count > 0)
                    {
                        var attendance = AttendanceUtility.FilterByCompanyID(CurrentUser.CompanyID,_attendanceService.GetAll().Result.ToList());
                        attendance = AttendanceUtility.FilterByUserID(user.FirstOrDefault().ID, attendance, false);
                        attendance = AttendanceUtility.FilterByDateFromTo(GetCurrentTime(), GetCurrentTime(), attendance);

                        if (attendance.Count > 0)
                        {
                            var attendanceData = new Attendance();
                            //checks if there is already a timeins if true then timeout that attendance else time in a user
                            var timeout = AttendanceUtility.FilterTimeIn(attendance, false);
                            if (timeout.Count > 0)
                            {
                                if (ImageUpload.UriToServer(imageUri, path + "/" + file)) {
                                    attendanceData = timeout.FirstOrDefault();
                                    attendanceData.TimeOutImage = "/UPLOADS/SubscriberFiles/" + CurrentUser.CompanyID+"/"+file;
                                    attendanceData.TimeOut = GetCurrentTime().TimeOfDay;
                                    attendanceData.UpdatedAt = GetCurrentTime();
                                }
                            }
                            else
                            {
                                if (ImageUpload.UriToServer(imageUri, path + "/" + file))
                                {
                                    //time in user attendance check if there are timeins already
                                    var timeins = AttendanceUtility.FilterTimeIn(attendance, true);
                                    attendanceData = timeins.FirstOrDefault();
                                    attendanceData.TimeInImage = "/UPLOADS/SubscriberFiles/" + CurrentUser.CompanyID + "/" + file;
                                    attendanceData.TimeIn = GetCurrentTime().TimeOfDay;
                                    attendanceData.UpdatedAt = GetCurrentTime();
                                }
                            }
                            _attendanceService.Update(attendanceData);
                            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { success = false, message = MessageUtility.TimeOff() });
                        }
                    }
                
                return Json(new { success = false, message = MessageUtility.UserLoginIDNONExist() });
            }
            catch (Exception e) { return Json(new { success = false, message = MessageUtility.ServerError(), error = e }); }
        }


        //[HttpPost]
        //public ActionResult LoginUser(string option, string loginID) {
        //    try
        //    {
        //        var users = _userService.GetAll().Result.ToList();
        //        users = UsersUtility.FilterByCompany(CurrentUser.CompanyID, users);
        //        var isAllowLogin = AttendanceUtility.IsUserExistByLoginID(loginID, users);
        //        if (isAllowLogin) {
        //            var result = FileUploadUtility.UploadImageFile(Request, Server, "/UPLOADS/TIMEIN/");
        //            if (result != null) {
        //                var user = UsersUtility.FilterByCode(loginID, users);
        //                    if (AttendanceUtility.IsUserAlreadyLogin(user.ID, _attendanceService, TimeUtility.GetTimeZoneByName(CurrentUser.TimeZone))==false)
        //                    {
        //                        var model = new Attendance()
        //                        {
        //                            UserID = user.ID,
        //                            TimeIn = TimeUtility.GetTimeZoneByName(CurrentUser.TimeZone).TimeOfDay,
        //                            TimeOut = null,
        //                            TimeInImage = result,
        //                            TimeOutImage = null,
        //                            Remarks = null,
        //                            CreatedAt = TimeUtility.GetTimeZoneByName(CurrentUser.TimeZone),
        //                            UpdatedBy = null,
        //                            TotalBreakTime = null,
        //                            TotalLateTime = null,
        //                            TotalUnderTime = null,
        //                            TotalOverBreak = null,
        //                        };
        //                        _attendanceService.Insert(model);
        //                    }
        //                    else {
        //                        return Json(new { success = false, message = MessageUtility.UserAlreadyTimedIn() });
        //                    }
        //                }
        //                else {
        //                    //if (AttendanceUtility.IsUserAlreadyLogout(user.ID, _attendanceService, TimeUtility.GetTimeZoneByName(CurrentUser.TimeZone)) == false)
        //                    //{
        //                    //    var attendance = _attendanceService.GetAll().Result.Where(ass => ass.UserID == user.ID && ass.CreatedAt.Value.Date == TimeUtility.GetTimeZoneByName(CurrentUser.TimeZone)).FirstOrDefault();
        //                    //    attendance.TimeOut = TimeUtility.GetTimeZoneByName(CurrentUser.TimeZone).TimeOfDay;
        //                    //    attendance.TimeOutImage = result;
        //                    //    _attendanceService.Update(attendance);
        //                    //}
        //                    //else {
        //                    //    return Json(new { success = false, message = MessageUtility.UserAlreadyTimedOut() });
        //                    //}
        //                }
        //                return Json(new { success = true });
        //            }
                
        //        return Json(new { success = false, message = MessageUtility.UserLoginIDNONExist() });
        //    }
        //    catch {
        //        return Json(new { success = false, message=MessageUtility.ServerError() });
        //    }
        //}


        [HttpPost]
        public async Task<JsonResult> Insert(AttendanceViewModel vm) {
            try {
                vm.ID = Guid.NewGuid().ToString();
                var time = TimeUtility.GetTimeZoneByName(CurrentUser.TimeZone);
                var model = AttendanceUtility.VMToM(vm);
                model.CreatedAt = time;
                model.CreatedBy = CurrentUser.ID;
                _attendanceService.Insert(model);
                return Json(new { success = true });
            } catch { return Json(new { success = false }); }
        }
        [HttpPost]
        public async Task<JsonResult> Inserts(List<AttendanceViewModel> vms) {
            try {
                var time = TimeUtility.GetTimeZoneByName(CurrentUser.TimeZone);
                var models = AttendanceUtility.VMsToMs(vms).ToList();
                foreach (Attendance model in models) {
                    model.ID = Guid.NewGuid().ToString();
                    model.CreatedAt = time;
                    model.CreatedBy = CurrentUser.ID;
                    _attendanceService.Insert(model);
                }
                return Json(new { success = true });
            } catch { return Json(new { success = false }); }
        }

        [HttpPost]
        public async Task<JsonResult> Update(UserAttendanceVM vm)
        {
            try
            {
                var modelReal = AttendanceUtility.FilterByID(vm.id,_attendanceService.GetAll().Result.ToList()).FirstOrDefault();
                var time = TimeUtility.GetTimeZoneByName(CurrentUser.TimeZone);
                var model = AttendanceUtility.VMToM(vm);
                model.CreatedAt = modelReal.CreatedAt;
                model.CreatedBy = model.CreatedBy;
                model.TotalOverBreak = modelReal.TotalOverBreak;
                model.TotalLateTime = modelReal.TotalLateTime;
                model.TotalUnderTime = modelReal.TotalUnderTime;
                model.UpdatedAt = time;
                model.UpdatedBy = CurrentUser.ID;
                _attendanceService.Update(model);
                return Json(new { success = true });
            }
            catch { return Json(new { success = false }); }
        }
        [HttpPost]
        public async Task<JsonResult> Updates(List<AttendanceViewModel> vms)
        {
            try
            {
                var time = TimeUtility.GetTimeZoneByName(CurrentUser.TimeZone);
                var models = AttendanceUtility.VMsToMs(vms).ToList();
                foreach (Attendance model in models)
                {
                    model.UpdatedAt = time;
                    model.UpdatedBy = CurrentUser.ID;
                    _attendanceService.Update(model);
                }
                return Json(new { success = true });
            }
            catch { return Json(new { success = false }); }
        }
        [HttpPost]
        public async Task<JsonResult> GroupSchedule(GroupScheduleVM vm) {
            try {
                var list = _attendanceService.GetAll().Result.ToList();
                list = AttendanceUtility.FilterByCompanyID(CurrentUser.CompanyID, list);
                list = AttendanceUtility.FilterByDateFromTo(vm.from, vm.to, list);
                for (var date = vm.from; date.Date <= vm.to.Date; date=date.AddDays(1)) {
                    if (DayUtility.IsSelected((int)date.DayOfWeek, vm.Week)) {
                        foreach (UsersViewModel user in vm.Users)
                        {
                            if (!AttendanceUtility.IsScheduleAlreadyExist(AttendanceUtility.FilterByUserID(user.ID, list, false), date)) {
                                var model = new Attendance()
                                {
                                    ID = Guid.NewGuid().ToString(),
                                    UserID = user.ID,
                                    AttendanceStatusID = "10",
                                    AttendanceDate = date,
                                    TimeIn = null,
                                    TimeOut = null,
                                    ShiftID = vm.shiftID,
                                    AddOnID = null,
                                    CreatedAt = GetCurrentTime(),
                                    CreatedBy = CurrentUser.ID
                                };
                                _attendanceService.Insert(model);
                            }
                        }
                    }
                }
                return Json(new { success = true });
            } catch { return Json(new { success = false }); }
        }
        [HttpPost]
        public async Task<JsonResult> Archived(UserAttendanceVM vm, bool isArchived) {
            try {
                var model = _attendanceService.GetByIDWithAsync(vm.id).Result;
                model.IsArchived = isArchived;
                _attendanceService.Update(model);
                return Json(new { success = true });
            } catch { return Json(new { success = false }); }
        }

        [HttpPost]
        public async Task<JsonResult> GenerateReportCSV(List<UserAttendanceVM> list)
        {
            var attendanceStatus = _attendanceService.GetAll1().Result.ToList();

            try {
                string filePath = Server.MapPath("~/UPLOADS/"+CurrentUser.CompanyID+"/"+Guid.NewGuid().ToString()+".csv");
                using (StreamWriter sw = new StreamWriter(filePath, false))
                {
                    foreach (UserAttendanceVM model in list) {
                        sw.WriteLine(attendanceStatus.Where(a => a.ID == model.Status.ID).FirstOrDefault().Description+
                                     ","+model.User.FirstName + " " + model.User.LastName + " " + model.User.ExtensionName
                                     +","+model.DateCreated+","+model.Shift.TimeIn+","+model.Shift.TimeOut);
                    }
                    sw.Close();
                }
                return Json(new { success = true, data= filePath });
            } catch { return Json(new { success = false }); }

        }



        #endregion

        #endregion

    }
}