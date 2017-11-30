using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TestApp2.App_Helper;
using TestApp2.Models.Utilities;

namespace TestApp2.Controllers
{
    public class LoginController : ApplicationController
    {
        private readonly UserManager _manager = UserManager.Create();
        private readonly IUserService _userService;
        public LoginController(IUserService userService) : base(userService) {
            _userService = userService;
        }
        // GET: 
        public ActionResult Index()
        {
            if (CurrentUser != null)
            {
                var rvm = LoginControllerUtility.IdentifyRouteByLoginAccount(CurrentUser, roleID);
                if (rvm.user == "Login") {
                    return View();
                }
                return RedirectToAction(rvm.path, rvm.user);
            }
            return View();
        }
        public async Task<JsonResult> Authenticate(string username, string password, string accessType) {
            try {
                var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var user = await userManager.FindAsync(username, password);
                Console.Write(user);
                if (user!=null)
                {
                    var signInManager = HttpContext.GetOwinContext().GetUserManager<ApplicationSignInManager>();
                    var result = signInManager.PasswordSignInAsync(username, password, false, shouldLockout: false).Result;
                    switch (result)
                    {
                        case SignInStatus.Success:
                            //var serviceUser = _userService.GetByIDAsp(user.Id).Result;
                            var type = LoginControllerUtility.IdentifyAccessType(Convert.ToInt32(accessType));
                            var rvm = LoginControllerUtility.IdentifyRouteByType(type);
                            if (rvm.user != "Login")
                            {
                                Console.Write(CurrentUser);
                                Console.Write(user.Id);
                                var temp = _userService.GetAll().Result.Where(c => c.AspNetUserID == user.Id).FirstOrDefault();
                                temp.LoginAccount = Convert.ToInt32(accessType);
                                _userService.Update(temp);
                                return Json(new { success = true });
                            }
                            return Json(new { success = false, message=MessageUtility.UserLoginWrong() });
                    }
                }
                return Json(new { success = false, message=MessageUtility.UserLoginWrong() });
            }
            catch(Exception e) {
                Console.Write(e);
                return Json(new { success = false }); }
        }
    }
}