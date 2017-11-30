using App.Data.Models;
using GeneralClass.DateControl;
using GeneralClass.Utility.ImageUpload;
using GeneralClass.Utility.PathChecker;
using Microsoft.AspNet.Identity;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TestApp2.App_Helper;
using TestApp2.Models;
using TestApp2.Models.Utilities;

namespace TestApp2.Controllers
{
    public class UsersController : ApplicationController
    {
        private readonly UserManager _manager = UserManager.Create();
        private readonly IUserService _userService;
        private readonly ICompanyService _companyService;
        public UsersController(IUserService userService, ICompanyService companyService):base(userService) {
            _userService = userService;
            _companyService = companyService;
        }

        #region HttpGet
        [HttpGet]
        public async Task<JsonResult> GetCurrentUser() {
            try {
                return Json(new { success = true, ID = CurrentUser.ID, FirstName = CurrentUser.FirstName, LastName = CurrentUser.LastName, ExtensionName = CurrentUser.ExtensionName }, JsonRequestBehavior.AllowGet);
            } catch { return Json(new { success = false }); }
        }
        //Current UserInformation
        [HttpGet]
        public async Task<JsonResult> GetUserInformation() {
            try {
                var model = UsersUtility.MToVM(CurrentUser);
                return Json(new { success = true, data = model });
            } catch { return Json(new { success = false }); }
        }

        [HttpGet]
        public async Task<JsonResult> GetAll()
        {
            try
            {
                var list = _userService.GetAll().Result.ToList();
                return Json(new { success = true, data = UsersUtility.MsToVMs(list) }, JsonRequestBehavior.AllowGet);
            }
            catch { return Json(new { success = false }, JsonRequestBehavior.AllowGet); }
        }
        [HttpGet]
        public async Task<JsonResult> GetAllByCompanyID() {
            try {
                var list = _userService.GetAll().Result.ToList();
                list = UsersUtility.FilterByCompany(CurrentUser.CompanyID, list);
                list = UsersUtility.FilterByIsArchived(list, false);
                var vms = UsersUtility.MsToVMs(list);
                return Json(new { success = true, data=vms, count=list.Count }, JsonRequestBehavior.AllowGet);
            } catch(Exception e) {
                Console.WriteLine(e);
                return Json(new { success = false });
            }
        }
        [HttpGet]
        public async Task<JsonResult> GetUsersByCompany()
        {
            try
            {
                var result = _companyService.GetByID(CurrentUser.CompanyID).Result.Users.ToList();
                return Json(new { success = true, data = result });
            }
            catch { return Json(new { success = false }); }
        }
        #endregion

        #region HttpPost
        //returns the inserted data to client inorder for the client not to update the whole data when adding users
        [HttpPost]
        public async Task<JsonResult> Insert(UsersViewModel item) {
            try {
                    item.Code = GeneralClass.StringUtility.StringFormatter.figure3DigitBeautify("" + _companyService.GetByID(CurrentUser.CompanyID).Result.Users.Count());
                    item.JobStatus=new JobStatusViewModel() {
                        ID=item.JobStatus.ID
                    };
                    item.Company = new CompanyViewModel()
                    {
                        ID = _currentUser.CompanyID
                    };
                    item.TimeZone = CurrentUser.TimeZone;
                    var model = UsersUtility.VMToM(item);
                    model.CreatedAt = GetCurrentTime();
                    model.CreatedBy = CurrentUser.ID;
                    if (UsersUtility.GenerateUser(model, _userService, _manager, Server, CurrentUser, GetCurrentTime()))
                    {
                        var vm = UsersUtility.MToVM(_userService.GetByID(model.ID).Result);
                        return Json(new { success = true, data = vm });
                    }
                    return Json(new { success = false });
                }
                catch(Exception e) {
                Console.WriteLine(e);
                return Json(new { success = false });
                }
        }
        //returns the updated data to client inorder for the client not to update the whole data when adding users
        [HttpPost]
        public async Task<JsonResult> Update(UsersViewModel item) {
            try {
                var imageFile= item.profileImage.Contains(CurrentUser.CompanyID) ? item.profileImage : "/UPLOADS/SubscriberFiles/" + CurrentUser.CompanyID + "/" + FileManagerUtility.UploadImage(Server, item.profileImage, Server.MapPath("/UPLOADS/SubscriberFiles/") + CurrentUser.CompanyID, "File" + TimeFormatter.DateToString1(GetCurrentTime()));
                if (imageFile != null) {
                    item.profileImage =  imageFile;
                    var realModel = _userService.GetByIDAsync(item.ID).Result;
                    var model = UsersUtility.UVMToUM(realModel, item);
                    model.UpdatedAt = GetCurrentTime();
                    model.UpdatedBy = CurrentUser.ID;
                    model.isArchived = false;
                    _userService.Update(model);
                    return Json(new { success = true, data = model });
                }
                return Json(new { success = false });
            } catch { return Json(new { success = false }); }
        }
        [HttpPost]
        public async Task<JsonResult> UpdateCredentials(AspNetUserVM vm) {
            try {
                var aspUser = _userService.GetByIDAsp(vm.ID).Result;
                aspUser.UserName = vm.Username;
                _userService.Update(aspUser);
                _manager.RemovePassword(vm.ID);
                _manager.AddPassword(vm.ID, vm.Password);
                return Json(new { success = true });
            } catch { return Json(new { success = false }); }
        }
        [HttpPost]
        public async Task<JsonResult> Archive(UsersViewModel vm) {
            try {
                //this method archives and unarchive data
                var realModel = _userService.GetByID(vm.ID).Result;
                realModel.isArchived = !realModel.isArchived;
                _userService.Update(realModel);
                return Json(new { success = true });
            } catch { return Json(new { success = false }); }
        }


        #endregion



    }
}