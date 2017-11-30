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
    public class AddOnController : ApplicationController
    {
        private readonly IUserService _userService;
        private readonly IAddOnService _addOnService;
        public AddOnController(IUserService userService, IAddOnService addOnService):base(userService) {
            _userService = userService;
            _addOnService = addOnService;
        }

        #region HttpGet
        public async Task<JsonResult> GetAllByCompany() {
            try {
                if (APISecurity.IsAllowAPIAccessByKey(roleName, "Admin"))
                {
                    var list = _addOnService.GetAll().Result.ToList();
                    list = AddOnUtility.FilterByCompanyID(CurrentUser.CompanyID, list);
                    return Json(new { success = true, data = AddOnUtility.MsToVMs(list) }, JsonRequestBehavior.AllowGet);
                }
                else {
                    return Json(new { success = false, message = MessageUtility.NoAccessPriviledges() });
                }
            } catch { return Json(new { success = false }, JsonRequestBehavior.AllowGet); }
        }
        #endregion

        #region HttpPost
        [HttpPost]
        public async Task<JsonResult> Insert(AddOnViewModel vm) {
            try {
                if (APISecurity.IsAllowAPIAccessByKey(roleName, "Admin"))
                {
                    vm.ID = Guid.NewGuid().ToString();
                    vm.Company = new CompanyViewModel() { ID = CurrentUser.CompanyID };
                    var model = AddOnUtility.VMToM(vm);
                    _addOnService.Insert(model);
                    return Json(new { success = true });
                }
                else
                {
                    return Json(new { success = false, message = MessageUtility.NoAccessPriviledges() });
                }
            } catch { return Json(new { success = false, message=MessageUtility.ServerError() }); }
        }
        #endregion

    }
}