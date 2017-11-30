using GeneralClass.MobileCrossplatform.Objects;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using GeneralClass.DateControl;

namespace TestApp2.Controllers
{
    public class UtilityController : ApplicationController
    {
        private readonly IUserService _userService;
        public UtilityController(IUserService userService):base(userService) {
            _userService = userService;
        }

        [AllowCrossSiteJson]
        [HttpGet]
        public async Task<JsonResult> GetServerTime() {
            try {
                var time = TimeUtility.GetTimeZoneByName(CurrentUser.TimeZone);
                return Json(new
                {
                    success=true,
                    hours = time.TimeOfDay.Hours,
                    minutes = time.TimeOfDay.Minutes,
                    seconds = time.TimeOfDay.Seconds,
                    Day = TimeConverter.ConvertTimeDDDD(time),
                    day = time.Day,
                    Month = TimeConverter.ConvertTimeMMMM(time),
                    month = time.Month,
                    Year = TimeConverter.ConvertTimeYear(time)
                }, JsonRequestBehavior.AllowGet);
            } catch { return Json(new { success = false }); }
        }



    }
}