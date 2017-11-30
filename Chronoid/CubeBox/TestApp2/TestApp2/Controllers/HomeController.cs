using GeneralClass.DateControl;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TestApp2.Models.Utilities;

namespace TestApp2.Controllers
{
    public class HomeController : ApplicationController
    {
        private IUnitOfWorkFactory _uow;
        private IJobTitleService _jobTitleService;
        public HomeController(IUnitOfWorkFactory uow, IUserService userService, IJobTitleService jobTitleService):base(userService) {
            this._uow = uow;
            _jobTitleService = jobTitleService;
        }
        public ActionResult Index()
        {
            ViewBag.ProfileImage = CurrentUser.ProfileImage == null ? "/UPLOADS/ProfileImage/no-image.jpg" : CurrentUser.ProfileImage;
            ViewBag.Username=CurrentUser.FirstName.ToUpper()+" "+CurrentUser.LastName.ToUpper();
            ViewBag.JobTitle = _jobTitleService.GetByID(CurrentUser.JobTitleID).Result.Description;
            ViewBag.Week = TimeConverter.ConvertTimeDDDD(TimeUtility.GetTimeZoneByName(CurrentUser.TimeZone));
            ViewBag.Day = TimeUtility.GetTimeZoneByName(CurrentUser.TimeZone).Day;
            ViewBag.Month = TimeConverter.ConvertTimeMMMM(TimeUtility.GetTimeZoneByName(CurrentUser.TimeZone));
            ViewBag.Year = TimeConverter.ConvertTimeYear(TimeUtility.GetTimeZoneByName(CurrentUser.TimeZone));
            return View();
        }

    }
}