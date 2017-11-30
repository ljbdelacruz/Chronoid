using GeneralClass.DateControl;
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
    public class ShiftController : ApplicationController
    {
        private readonly IUserService _userService;
        private readonly IShiftService _shiftService;
        public ShiftController(IUserService userService, IShiftService shiftService):base(userService) {
            _userService = userService;
            _shiftService = shiftService;
        }
        #region HttGet
        [HttpGet]
        public async Task<JsonResult> GetAllByCompany() {
            try {
                var list = _shiftService.GetAll().Result.ToList();
                list = ShiftUtility.FilterByIsArchived(list, false);
                list = ShiftUtility.FilterByCompanyID(CurrentUser.CompanyID, list);
                return Json(new { success = true, data=ShiftUtility.MsToVMs(list) }, JsonRequestBehavior.AllowGet);
            } catch { return Json(new { success = false }, JsonRequestBehavior.AllowGet); }
        }


        #endregion
        #region HttPost
        [HttpPost]
        public async Task<JsonResult> Insert(ShiftViewModel model) {
            try {
                model.ID = Guid.NewGuid().ToString();
                model.Company = new CompanyViewModel() {
                    ID=CurrentUser.CompanyID
                };
                var data = ShiftUtility.VMToM(model);
                data.CreatedAt = TimeUtility.GetTimeZoneByName(CurrentUser.TimeZone);
                data.CreatedBy = CurrentUser.ID;
                _shiftService.Insert(data);
                return Json(new { success = true, data=ShiftUtility.MToVM(data) });
            } catch { return Json(new { success = false }); }
        }
        [HttpPost]
        public async Task<JsonResult> Update(ShiftViewModel model) {
            try {
                model.Company = new CompanyViewModel() { ID = CurrentUser.CompanyID };
                var data = ShiftUtility.VMToM(model);
                data.UpdatedAt = TimeUtility.GetTimeZoneByName(CurrentUser.TimeZone);
                data.UpdatedBy = CurrentUser.ID;
                _shiftService.Update(data);
                return Json(new { success = true,  data=ShiftUtility.MToVM(data)});
            } catch { return Json(new { success = false }); }
        }
        [HttpPost]
        public async Task<JsonResult> Archived(ShiftViewModel model, bool archive) {
            try {
                var data = _shiftService.GetByID(model.ID).Result;
                data.UpdatedAt = TimeUtility.GetTimeZoneByName(CurrentUser.TimeZone);
                data.UpdatedBy = CurrentUser.ID;
                data.IsArchived = archive;
                _shiftService.Update(data);
                return Json(new { success = true });
            } catch { return Json(new { success = false }); }
        }


        #endregion
    }
}