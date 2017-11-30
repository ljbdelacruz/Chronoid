using App.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace TestApp2.Models.Utilities
{
    public static class LoginControllerUtility
    {

        //this will identify the user role and redirect him/her to the right path
        public static RouteViewModel IdentifyRouteByUserID(string userId) {
            var rvm = new RouteViewModel();
            if (!string.IsNullOrEmpty(userId))
            {
                using (var ctx = new App.Data.Models.CubeBox_DBContext())
                {
                    var userRole = ctx.AspNetUserRoles.Where(i => i.UserId == userId);
                    var result = userRole.FirstOrDefault();
                    if (result != null)
                    {
                        var role = ctx.AspNetRoles.SingleOrDefault(r => r.Id == result.RoleId);
                        if (role != null)
                        {
                            if (role.Name.Contains("Administrator")) {
                                rvm.user = "Home";
                                rvm.path = "Index";
                                return rvm;
                            }
                        }
                    }
                    else
                    {
                        rvm.user = "Login";
                        rvm.path = "Index";
                        return rvm;
                    }
                }
            }
            rvm.user = "Login";
            rvm.path = "Index";
            return rvm;
        }
        //identify route by Type
        public static RouteViewModel IdentifyRouteByType(string type) {
            var rvm = new RouteViewModel();
            rvm.user = "Login";
            rvm.path = "Index";
            try {
                using (var ctx = new App.Data.Models.CubeBox_DBContext())
                {
                    if (type == "TimeClock")
                    {
                        rvm.user = "TimeClock";
                        rvm.path = "Index";
                    }
                    else if (type == "Employee")
                    {
                        rvm.user = "Home";
                        rvm.path = "Index";
                    }
                    else if (type == "Administrator")
                    {
                        rvm.user = "Administrator";
                        rvm.path = "Index";
                    }
                    else if (type == "Super Admin") {
                        rvm.user = "SuperAdmin";
                        rvm.path = "Index";
                    }
                    return rvm;
                    //var userRole = ctx.AspNetUserRoles.Where(i => i.AspNetRole.Name == type);
                    //if (userRole == null)
                    //{
                    //    return rvm;
                    //}
                    //else {
                    //    var result = userRole.FirstOrDefault();
                    //    var role = ctx.AspNetRoles.SingleOrDefault(r => r.Id == result.RoleId);
                    //    if (role != null)
                    //    {
                    //        if (role.Name.Contains("Administrator"))
                    //        {
                    //            rvm.user = "Home";
                    //            rvm.path = "Index";
                    //            return rvm;
                    //        }
                    //        else {
                    //            return rvm;
                    //        }
                    //    }
                    //}
                }
                return rvm;
            } catch { return rvm; }
        }
        //this Identify Route by LoginAccount
        public static RouteViewModel IdentifyRouteByLoginAccount(User currentUser, string roleID) {
            var rvm = new RouteViewModel();
            rvm.user = "Login";
            rvm.path = "Index";
            try
            {
                using (var ctx = new App.Data.Models.CubeBox_DBContext())
                {
                    var role = ctx.AspNetRoles.SingleOrDefault(r => r.Id == roleID);
                    var type = role.Name.Contains("Super Admin") ? IdentifyAccessType(Convert.ToInt32(4)) : IdentifyAccessType(Convert.ToInt32(currentUser.LoginAccount));
                    if (role.Name.Contains("Administrator"))
                    {
                        if (currentUser.LoginAccount == 1)
                        {
                            rvm = IdentifyRouteByType(type);
                            return rvm;
                        }
                        else if (currentUser.LoginAccount == 2)
                        {
                            rvm = IdentifyRouteByType(type);
                            return rvm;
                        }
                        else if (currentUser.LoginAccount == 3)
                        {
                            rvm = IdentifyRouteByType(type);
                            return rvm;
                        }
                    }
                    else if (role.Name.Contains("Employee"))
                    {
                        if (currentUser.LoginAccount == 2)
                        {
                            rvm = IdentifyRouteByType(type);
                            return rvm;
                        }
                        else
                        {
                            return rvm;
                        }
                    }
                    else if (role.Name.Contains("Super Admin")) {
                            rvm = IdentifyRouteByType(type);
                            return rvm;
                    }
                }
                return rvm;
            }
            catch { return rvm; }
        }


        public static string IdentifyAccessType(int type) {
            switch (type) {
                case 1:
                    return "Administrator";
                case 2:
                    return "Employee";
                case 3:
                    return "TimeClock";
                case 4:
                    return "Super Admin";
            }
            return null;
        }

    }
}