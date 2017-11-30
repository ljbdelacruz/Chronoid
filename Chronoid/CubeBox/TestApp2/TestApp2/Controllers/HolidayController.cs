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
    public class HolidayController : ApplicationController
    {
        private IUserService _userService;
        private IHolidayService _holidayService;
        public HolidayController(IUserService userService, IHolidayService holidayService):base(userService) {
            _userService = userService;
            _holidayService = holidayService;
        }
        #region HttpGet
        [HttpGet]
        public async Task<JsonResult> GetAllByCompany() {
            try {
                var list = _holidayService.GetAll();
                list = HolidayUtility.FilterByCompanyID(CurrentUser.CompanyID, list);
                list = HolidayUtility.OrderByStartDate(list, false);
                return Json(new { success = true, data=HolidayUtility.MsToVMs(list) }, JsonRequestBehavior.AllowGet);
            } catch { return Json(new { success = false }, JsonRequestBehavior.AllowGet); }
        }
        #endregion
        #region HttpPost
        [HttpPost]
        public async Task<JsonResult> Update(HolidayVM vm) {
            try {
                var list = _holidayService.GetAll();
                list = HolidayUtility.FilterByCompanyID(CurrentUser.CompanyID, list);
                //verify if conflict with other holidays
                var model = _holidayService.GetByID(vm.ID);
                model = HolidayUtility.UVMToUM(vm, model);
                _holidayService.Update(model);
                return Json(new { success = true, data=HolidayUtility.MToVM(model) });
            } catch { return Json(new { success = false }); }
        }
        [HttpPost]
        public async Task<JsonResult> Insert(HolidayVM vm) {
            try {
                var list = _holidayService.GetAll();
                list = HolidayUtility.FilterByCompanyID(CurrentUser.CompanyID, list);
                //verify if conflict with other holidays

                vm.ID = Guid.NewGuid().ToString();
                vm.Company = new CompanyViewModel() { ID = CurrentUser.CompanyID };
                var model = HolidayUtility.VMToM(vm);
                _holidayService.Insert(model);
                return Json(new { success = true });
            } catch { return Json(new { success = false }); }
        }
        #endregion
    }
}