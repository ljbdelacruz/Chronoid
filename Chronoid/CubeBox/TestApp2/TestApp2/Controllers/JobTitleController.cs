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
    public class JobTitleController : ApplicationController
    {
        private readonly IUserService _userService;
        private readonly IJobTitleService _jobTitleService;

        public JobTitleController(IUserService userService, IJobTitleService jobTitleService):base(userService) {
            _userService = userService;
            _jobTitleService = jobTitleService;
        }

        #region HttpGet
        [HttpGet]
        public async Task<JsonResult> GetAll() {
            try {
                var list = _jobTitleService.GetAll().Result.ToList();
                list = JobTitleUtility.FilterByCompanyID(list, CurrentUser.CompanyID);
                list = JobTitleUtility.SortByID(list);
                var vms = JobTitleUtility.MsToVMs(list);
                return Json(new { success = true, data=vms }, JsonRequestBehavior.AllowGet);
            } catch { return Json(new { success = false }, JsonRequestBehavior.AllowGet); }
        }
        #endregion
        #region HttpPost
        [HttpPost]
        public async Task<JsonResult> Insert(JobtitleViewModel vm) {
            try {
                vm.ID = CharacterGenerator.NewGUID();
                vm.Company = new CompanyViewModel() {
                    ID=CurrentUser.CompanyID
                };
                var model = JobTitleUtility.VMToM(vm);
                _jobTitleService.Insert(model);
                var list = _jobTitleService.GetAll().Result.ToList();
                list = JobTitleUtility.FilterByCompanyID(list, CurrentUser.CompanyID);
                return Json(new { success = true, data = JobTitleUtility.MToVM(model) });
            } catch { return Json(new { success = false }); }
        }
        [HttpPost]
        public async Task<JsonResult> Update(JobtitleViewModel vm) {
            try {
                var model = JobTitleUtility.VMToM(vm);
                _jobTitleService.Update(model);
                return Json(new { success = true, data = vm });
            } catch { return Json(new { success = false }); }
        }

        #endregion

    }
}