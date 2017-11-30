using App.Data.Models;
using Microsoft.AspNet.Identity;
using Service.Interface;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GeneralClass.DateControl;

namespace TestApp2.Controllers
{
    public class ApplicationController : Controller
    {

        private readonly IUserService _usersService;
        public ApplicationController(IUserService usersService)
        {
            this._usersService = usersService;
        }

        public App.Data.Models.User _currentUser;
        public string roleID = "";
        //this will get the system datetime based on the system setting
        //for future use this is where will the system will get time inorder for it to
        //be dynamic and will not rely on ph datetime
        public string roleName;
        public DateTime GetCurrentTime() {
            return TimeUtility.GetTimeZoneByName(CurrentUser.TimeZone);
        }

        public App.Data.Models.User CurrentUser
        {
            get
            {
                var userId = User.Identity.GetUserId();
                if (!string.IsNullOrEmpty(userId))
                {
                    _currentUser = _usersService.GetAll().Result.Where(us => us.AspNetUserID == userId).FirstOrDefault();
                    _currentUser.AspNetUser.IsOnline = true;
                    _usersService.Update(_currentUser.AspNetUser);
                    var role = _usersService.GetByIDAspWithAsync(_currentUser.AspNetUserID).Result.AspNetUserRoles.FirstOrDefault();
                    roleID = role.RoleId;
                    roleName = _usersService.GetRoleByID(roleID).Result.Name;
                    if (_currentUser == null)
                    {
                        RedirectToAction("Index", "Logout");
                    }
                }
                // Hip to be null
                return _currentUser;
            }
        }


        public string SessionUser
        {
            get
            {
                try
                {
                    return Session["user"].ToString();
                }
                catch
                {
                    return "";
                }

            }
        }
        public bool IsLoggedIn
        {
            get
            {
                return (CurrentUser != null && Request.IsAuthenticated);
            }
        }

        //public ActionResult CSV(IEnumerable<dynamic> data, string fileName)
        //{
        //    return new ExportToCSV<>
        //}


        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //string actionName = filterContext.ActionDescriptor.ActionName;
            //string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;

            //if (string.IsNullOrEmpty(actionName) && string.IsNullOrEmpty(controllerName)) {
            //    throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Unauthorized));
            //}
            //var response = filterContext.HttpContext.Response;
            //response.AddHeader("Content-Security-Policy", "default-src http://localhost");

            //DecideResponse(filterContext.HttpContext);

            base.OnActionExecuting(filterContext);
        }

        void DecideResponse(HttpContextBase ctx)
        {
            if (ctx.Request.ContentType == "application/json")
            {
                ctx.Response.Write("Unauthorized");
            }
            else
            {
                ctx.Response.Redirect("/ErrorAccess");
            }
            ctx.Response.End();
        }
    }
}