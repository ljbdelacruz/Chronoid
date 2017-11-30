using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TestApp2.Models;
using TestApp2.Models.Utilities;
using GeneralClass.Generator.String;
using GeneralClass.FileExporter;
using System.Text;
using System.IO;

namespace TestApp2.Controllers
{
    public class AttendanceStatusController : ApplicationController
    {
        private readonly IUserService _userService;
        private readonly IAttendanceService _attendanceService;
        public AttendanceStatusController(IUserService userService, IAttendanceService attendanceService):base(userService) {
            _userService = userService;
            _attendanceService = attendanceService;
        }
        #region HttpGet
        public async Task<JsonResult> GetAllByCompany() {
            try {
                var list = AttendanceStatusUtility.FilterByCompanyID(CurrentUser.CompanyID,_attendanceService.GetAll1().Result.ToList());
                return Json(new { success = true, data=AttendanceStatusUtility.MsToVMs(list) }, JsonRequestBehavior.AllowGet);
            } catch { return Json(new { success = false }, JsonRequestBehavior.AllowGet); }
        }
        #endregion
        #region HttpPost
        [HttpPost]
        public async Task<JsonResult> Insert(AttendanceStatusViewModel vm) {
            try {
                vm.ID = CharacterGenerator.NewGUID();
                _attendanceService.Insert1(AttendanceStatusUtility.VMToM(vm));
                var list = AttendanceStatusUtility.FilterByCompanyID(CurrentUser.CompanyID,_attendanceService.GetAll1().Result.ToList());
                var model = AttendanceStatusUtility.FilterByDescription(vm.Description, list).FirstOrDefault();
                return Json(new { success = true, data = AttendanceStatusUtility.MToVM(model) });
            } catch { return Json(new { success = false }); }
        }


        [HttpPost]
        public async Task<JsonResult> Update(AttendanceStatusViewModel vm) {
            try {
                _attendanceService.Update1(AttendanceStatusUtility.VMToM(vm));
                return Json(new { success = true, data=vm });
            } catch { return Json(new { success = false }); }
        }
        #endregion


    }
}