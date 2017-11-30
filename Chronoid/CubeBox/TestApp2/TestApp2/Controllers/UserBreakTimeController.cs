using App.Data.Models;
using GeneralClass.DateControl;
using GeneralClass.Generator.String;
using GeneralClass.MobileCrossplatform.Objects;
using Repository.Interface;
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
    public class UserBreakTimeController : ApplicationController
    {
        private IUserBreakTimeService _userBreakTimeService;
        private IUserService _userService;
        private IBreakTypeService _breakTypeService;
        public UserBreakTimeController(IUserService userService, 
                                       IUserBreakTimeService userBreakTimeService, 
                                       IBreakTypeService breakTypeService
                                       ) : base(userService) {
            _userService = userService;
            _userBreakTimeService = userBreakTimeService;
            _breakTypeService = breakTypeService;
        }
        #region HttpPost
        [HttpPost]
        public async Task<JsonResult> Insert(UserBreakTimeVM vm) {
            try
            {
                var list = UserBreakModelUtility.FilterByCompanyID(CurrentUser.CompanyID,_userBreakTimeService.GetAll().Result.ToList());
                list = UserBreakModelUtility.FilterByUserID(CurrentUser.ID, list);
                list = UserBreakModelUtility.FilterByStartDateTime(GetCurrentTime(), list);
                vm.id = CharacterGenerator.NewGUID();
                if (!UserBreakModelUtility.IsBreakTypeExist(list, vm.Type.ID)) {
                    var temp = new UserBreakTime() {
                        ID = vm.id,
                        UserID = CurrentUser.ID,
                        StartDateTime = GetCurrentTime(),
                        Type = vm.Type.ID,
                        IsFinishedBreak = false,
                        Remarks="",
                        CreatedAt=GetCurrentTime(),
                        CreatedBy=CurrentUser.ID,
                    };
                    _userBreakTimeService.Insert(temp);
                    var model = _userBreakTimeService.GetWithAsyncByID(vm.id).Result;
                    return Json(new { success = true, data = UserBreakModelUtility.MToVM(model) });
                }
                return Json(new { success = false });
            } catch { return Json(new { success = false }); }
        }
        [HttpPost]
        public async Task<JsonResult> EndBreak(string type) {
            try {
                var ubreak= UserBreakModelUtility.FilterByType(type,_userBreakTimeService.GetAll().Result.ToList());
                ubreak = UserBreakModelUtility.FilterByUserID(CurrentUser.ID, ubreak);
                var model = UserBreakModelUtility.FilterByStartDateTime(GetCurrentTime(), ubreak).FirstOrDefault();
                model.IsFinishedBreak = true;
                model.EndDateTime = GetCurrentTime();
                var result=_userBreakTimeService.Update(model);
                return Json(new { success = result }, JsonRequestBehavior.AllowGet);
            } catch { return Json(new { success=false }, JsonRequestBehavior.AllowGet); }
        }
        #endregion
        #region HttpGet
        [HttpGet]
        public async Task<JsonResult> GetBreaksToday() {
            try {
                //var list =  _userBreakTimeService.GetAll().Result.ToList();
                var list = UserBreakModelUtility.FilterByStartDateTime(GetCurrentTime(),_userBreakTimeService.GetAll().Result.ToList());
                var vms = UserBreakModelUtility.MsToVMs(list);
                return Json(new { success = true, data = vms }, JsonRequestBehavior.AllowGet);
            } catch { return Json(new { success = false }); }
        }
        [AllowCrossSiteJson]
        [HttpGet]
        public async Task<JsonResult> IsUserOnBreak(){
            try {
                var list = UserBreakModelUtility.FilterByCompanyID(CurrentUser.CompanyID, _userBreakTimeService.GetAll().Result.ToList());
                list = UserBreakModelUtility.FilterByStartDateTime(GetCurrentTime(), list);
                list = UserBreakModelUtility.FilterByUserID(CurrentUser.ID, list);
                list = UserBreakModelUtility.FilterByIsFinished(false, list);
                var isOnBreak = list.FirstOrDefault();
                if (isOnBreak != null) {
                    var vm = UserBreakModelUtility.MToVM(isOnBreak);
                    var timeDifference = TimeCalculator.SubtructTime(isOnBreak.StartDateTime.Value.TimeOfDay, GetCurrentTime().TimeOfDay);
                    //data here is the difference of your break consumed
                    return Json(new { success = true, data = timeDifference, timeLimit= isOnBreak.BreakType.TimeLimit, type= isOnBreak.BreakType.id }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);

            } catch { return Json(new { success = false }, JsonRequestBehavior.AllowGet); }
        }

        #endregion
    }
}