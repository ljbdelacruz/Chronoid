using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestApp2.App_Helper;
using TestApp2.Models.Utilities;

namespace TestApp2.Controllers
{
    public class SuperAdminController : ApplicationController
    {
        private readonly UserManager _manager = UserManager.Create();
        private readonly IUserService _userService;
        public SuperAdminController(IUserService userService) : base(userService) {
            _userService = userService;
        }
        // GET: SuperAdmin
        public ActionResult Index()
        {
            if (CurrentUser != null)
            {
                var rvm = LoginControllerUtility.IdentifyRouteByLoginAccount(CurrentUser, roleID);
                if (rvm.user == "SuperAdmin")
                {
                    return View();
                }
                return RedirectToAction(rvm.path, rvm.user);
            }
            return View();
        }
    }
}