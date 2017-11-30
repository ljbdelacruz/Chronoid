using App.Data.Models;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApp2.Models.Utilities
{
    public static class AspNetUserRoleUtility
    {
        #region inserting data
        public static bool InsertNewUserRole(IUserService _userService, string aspUserID, string roleID ) {
            try {
                var id = Guid.NewGuid();
                var item = new AspNetUserRole() {
                    id = id,
                    UserId= aspUserID,
                    RoleId= roleID
                };
                _userService.Insert(item);
                return true;
            } catch { return false; }
        }


        #endregion


    }
}