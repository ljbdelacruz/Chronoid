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
    public class DepartmentController : ApplicationController
    {
        private IUserService _userService;
        private IDepartmentService _departmentService;
        public DepartmentController(IUserService userService, IDepartmentService departmentService):base(userService) {
            _userService = userService;
            _departmentService = departmentService;
        }
        #region HttpGet
        [HttpGet]
        public async Task<JsonResult> GetAllByCompany() {
            try {
                var list = _departmentService.GetAll().Result.ToList();
                list = DepartmentUtility.FilterByCompanyID(CurrentUser.CompanyID, list);
                return Json(new { success = true, data=DepartmentUtility.MsToVMs(list) }, JsonRequestBehavior.AllowGet);
            } catch { return Json(new { success = false }, JsonRequestBehavior.AllowGet); }
        }

        #endregion


        #region HttpPost
        [HttpPost]
        public async Task<JsonResult> Insert(DepartmentViewModel vm) {
            try {
                vm.ID = Guid.NewGuid().ToString();
                vm.Company = new CompanyViewModel() {
                    ID=CurrentUser.CompanyID
                };
                var model = DepartmentUtility.VMToM(vm);
                model.CreatedAt = GetCurrentTime();
                _departmentService.Insert(model);
                return Json(new { success = true, data = vm });
            } catch { return Json(new { success = false }); }
        }
        [HttpPost]
        public async Task<JsonResult> Inserts(List<DepartmentViewModel> vms) {
            try {
                for (int i = 0; i < vms.Count; i++) {
                    vms[i].ID = Guid.NewGuid().ToString();
                    vms[i].Company = new CompanyViewModel()
                    {
                        ID = CurrentUser.CompanyID
                    };
                    var model = DepartmentUtility.VMToM(vms[i]);
                    model.CreatedAt = GetCurrentTime();
                    _departmentService.Insert(model);
                }
                return Json(new { success = true, data=vms });
            } catch { return Json(new { success = false }); }
        }

        [HttpPost]
        public async Task<JsonResult> Update(DepartmentViewModel vm) {
            try {
                var model = DepartmentUtility.VMToM(vm);
                model.UpdatedAt = GetCurrentTime();
                _departmentService.Update(model);
                return Json(new { success = true, data=DepartmentUtility.MToVM(model) });
            } catch { return Json(new { success = false }); }
        }
        [HttpPost]
        public async Task<JsonResult> Update(List<DepartmentViewModel> vms)
        {
            try
            {
                for (int i = 0; i < vms.Count; i++)
                {
                    var model = DepartmentUtility.VMToM(vms[i]);
                    model.UpdatedAt = GetCurrentTime();
                    _departmentService.Update(model);
                }
                return Json(new { success = true, data = vms });
            }
            catch { return Json(new { success = false }); }
        }

        #endregion

    }
}