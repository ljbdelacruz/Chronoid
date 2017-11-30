using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace TestApp2.Controllers
{
    public class LogoutController : ApplicationController
    {
        private readonly IUserService _usersServices;
        public LogoutController(IUserService usersService) : base(usersService)
        {
            _usersServices = usersService;
        }
        public async Task<ActionResult> Index()
        {
            if (CurrentUser != null)
            {
                CurrentUser.AspNetUser.IsOnline = false;
                _usersServices.Update(CurrentUser.AspNetUser);
            }
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return Redirect("/");
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
    }
}