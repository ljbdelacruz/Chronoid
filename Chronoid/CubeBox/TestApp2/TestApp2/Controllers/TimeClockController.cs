using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestApp2.Models.Utilities;

namespace TestApp2.Controllers
{
    public class TimeClockController : ApplicationController
    {
        private readonly IUserService _userService;

        public TimeClockController(IUserService userService) : base(userService) {
            _userService = userService;
        }
        // GET: TimeClock
        public ActionResult Index()
        {
            if (CurrentUser != null)
            {
                var rvm = LoginControllerUtility.IdentifyRouteByLoginAccount(CurrentUser, roleID);
                if (rvm.user == "Login")
                {
                    return RedirectToAction(rvm.path, rvm.user);
                }
                return View();
            }
            return View();
        }
    }
}