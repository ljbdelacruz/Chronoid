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
    public class AdministratorController : ApplicationController
    {
        private readonly IUserService _userService;
        public AdministratorController(IUserService userService):base(userService) {
            _userService = userService;
        }
        // GET: Administrator
        public ActionResult Index()
        {
            if (CurrentUser != null)
            {
                var rvm = LoginControllerUtility.IdentifyRouteByLoginAccount(CurrentUser, roleID);
                if (rvm.user == "Administrator")
                {
                    return View();
                }
                else {
                    return RedirectToAction(rvm.path, rvm.user);
                }
            }
            return RedirectToAction("Index", "Login");
        }
        //this one gets the current user information
        [HttpGet]
        public async Task<JsonResult> CurrentUserInfo()
        {
            try
            {
                return Json(new { success = true, ID = CurrentUser.ID, firstname = CurrentUser.FirstName, lastname = CurrentUser.LastName, data= UsersUtility.MToVM1(CurrentUser) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e) { return Json(new { success = false, message = e }, JsonRequestBehavior.AllowGet); }
        }



        /*
         Post data
        */

    }
}