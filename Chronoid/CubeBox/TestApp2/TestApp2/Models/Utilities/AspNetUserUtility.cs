using App.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApp2.Models.Utilities
{
    public static class AspNetUserUtility
    {
        #region Model To ViewModel
        public static AspNetUserVM MToVM(AspNetUser model) {
            return new AspNetUserVM()
            {
                ID = model.Id,
                EmailAddress = model.Email,
                Username = model.UserName,
                Password = model.PasswordHash
            };
        }


        #endregion

    }
}