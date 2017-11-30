using Microsoft.AspNet.Identity;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestApp2.App_Helper;

namespace TestApp2.Controllers
{
    public class TimeZoneController : ApplicationController
    {
        private readonly UserManager _manager = UserManager.Create();
        public TimeZoneController(IUserService userService):base(userService) {
        }
        #region HttpGet



        #endregion
        #region HttpPost

        #endregion

    }
}