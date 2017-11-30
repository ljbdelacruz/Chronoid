using GeneralClass.DateControl;
using GeneralClass.Generator.String;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TestApp2.Models;
using TestApp2.Models.Utilities;

namespace TestApp2.Controllers
{
    public class BreakTypeController : ApplicationController
    {
        private readonly IUserService _userService;
        private readonly IBreakTypeService _breakTypeService;
        private readonly IAttendanceService _attendanceService;
        public BreakTypeController(IUserService userService, IBreakTypeService breakTypeService, IAttendanceService attendanceService) : base(userService) {
            _userService = userService;
            _breakTypeService = breakTypeService;
            _attendanceService = attendanceService;
        }
        #region HttpGet
        [HttpGet]
        public async Task<JsonResult> GetAllByCompany() {
            try {
                var time = GetCurrentTime();
                var list = BreakTypeUtility.FilterByCompanyID(CurrentUser.CompanyID, _breakTypeService.GetAll().Result.ToList());
                //list = BreakTypeUtility.FilterByTime(list, time.TimeOfDay, ScheduleUtility.FilterByDate(CurrentUser.Schedules.ToList(), time).TimeIn.Value);
                list = BreakTypeUtility.FilterByIsArchived(list, false);
                list = BreakTypeUtility.SortByOrderNumber(list, false);
                var vms = BreakTypeUtility.MsToVMs(list);


                
                return Json(new { success = true, data = vms }, JsonRequestBehavior.AllowGet);
            } catch (Exception e){
                Console.Write(e);
                return Json(new { success = false }, JsonRequestBehavior.AllowGet); }
        }
        #endregion
        #region HttpPost
        [HttpPost]
        public async Task<JsonResult> Insert(BreakTypeViewModel vm) {
            try {
                vm.ID = CharacterGenerator.NewGUID();
                vm.CompanyID = CurrentUser.CompanyID;
                var model = BreakTypeUtility.VMToM(vm);
                model.isArchived = false;
                _breakTypeService.Insert(model);
                return Json(new { success = true, data = BreakTypeUtility.MToVM(model) });
            } catch { return Json(new { success = false }); }
        }

        [HttpPost]
        public async Task<JsonResult> Update(BreakTypeViewModel vm) {
            try {
                var model = BreakTypeUtility.VMToM(vm);
                model.CreatedAt = TimeUtility.GetTimeZoneByName(CurrentUser.TimeZone);
                model.CreatedBy = CurrentUser.ID;
                model.isArchived = false;
                _breakTypeService.Update(model);
                return Json(new { success = true, data=BreakTypeUtility.MToVM(model) });
            } catch { return Json(new { success = false }); }
        }
        [HttpPost]
        public async Task<JsonResult> Archive(BreakTypeViewModel vm, bool isArchived) {
            try {
                var model = BreakTypeUtility.VMToM(vm);
                model.isArchived = isArchived;
                _breakTypeService.Update(model);
                return Json(new { success = true });
            } catch { return Json(new { success = false }); }
        }


        #endregion



    }
}