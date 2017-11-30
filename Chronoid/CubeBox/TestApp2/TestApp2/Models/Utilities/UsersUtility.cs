using App.Data.Models;
using GeneralClass.DataVerification.String;
using GeneralClass.DateControl;
using GeneralClass.Operators.String;
using GeneralClass.Utility.ImageUpload;
using GeneralClass.Utility.PathChecker;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestApp2.App_Helper;
using TestApp2.Models;
using TestApp2.Models.Utilities;

namespace TestApp2.Models.Utilities
{
    public static class UsersUtility
    {
        public static User GetUsersByAspNetUserID(IUserService _userService, string aspID) {
            return _userService.GetAll().Result.Where(us => us.AspNetUserID == aspID).FirstOrDefault();
        }
        #region Sorting
        public static List<User> SortByCreatedAt(List<User> list, bool isReverse) {
            try {
                if (isReverse) {
                    return list.OrderByDescending(u => u.CreatedAt).ToList();
                }
                return list.OrderBy(u => u.CreatedAt).ToList();
            } catch { return list; }
        }
        #endregion
        #region Filtering
        public static List<User> FilterByCompany(string companyID, List<User> list)
        {
            try
            {
                return list.Where(c => c.CompanyID == companyID).ToList();
            }
            catch { return list; }
        }
        public static List<User> FilterByCode(string code, List<User> list) {
            return list.Where(u => u.Code == code).ToList();
        }
        public static List<User> FilterByIsArchived(List<User> models, bool isArchived) {
            return models.Where(u => u.isArchived == isArchived).ToList();
        }
        //gets the number of days from now to the day its updated
        public static List<User> FilterByNumberOfDaysUpdated(DateTime time, int days,  List<User> list) {
            return list.Where(u => TimeCalculator.SubtructTime(u.UpdatedAt.Value, time).Days >= days).ToList();
        }
        #endregion
        #region User
        #region Model to View Model
        public static UsersViewModel MToVM(User user) {
            var temp = new UsersViewModel() {
                ID = user.ID,
                Code = Comparison.IsNullOrEmpty(user.Code) ? "" : user.Code,
                LastName = Comparison.IsNullOrEmpty(user.LastName) ? "" : user.LastName,
                MiddleName = Comparison.IsNullOrEmpty(user.MiddleName) ? "" : user.MiddleName,
                FirstName = Comparison.IsNullOrEmpty(user.FirstName) ? "" : user.FirstName,
                ExtensionName = Comparison.IsNullOrEmpty(user.ExtensionName) ? "" : user.ExtensionName,
                Gender = Comparison.IsNullOrEmpty(user.Gender) ? "N/A" : user.Gender,
                MaritalStatus = Comparison.IsNullOrEmpty(user.MaritalStatus) ? "N/A" : user.MaritalStatus,
                Nationality = Comparison.IsNullOrEmpty(user.Nationality) ? "N/A" : user.Nationality,
                Religion = Comparison.IsNullOrEmpty(user.Religion) ? "N/A" : user.Religion,
                Address = Comparison.IsNullOrEmpty(user.Address) ? "N/A" : user.Address,
                Birthday = TimeFormatter.DateToString(user.Birthday.Value),
                Jobtitle = JobTitleUtility.MToVM(user.JobTitle),
                Email = Comparison.IsNullOrEmpty(user.Email) ? "N/A" : user.Email,
                ContactPerson = Comparison.IsNullOrEmpty(user.ContactPerson) ? "N/A" : user.ContactPerson,
                ContactNumber = Comparison.IsNullOrEmpty(user.ContactNumber) ? "N/A" : user.ContactNumber,
                profileImage = Comparison.IsNullOrEmpty(user.ProfileImage) ? "/Assets/images/no-image.jpg" : user.ProfileImage,
                Company = CompanyUtility.MToVM(user.Company),
                aspNetUser = MToVM(user.AspNetUser),
                Department=DataVerification.IsNull(user.Department) ? new DepartmentViewModel() { Name="N/A" } : DepartmentUtility.MToVM(user.Department),
                JobStatus=JobStatusUtility.MToVM(user.JobStatu),
                User=AspNetUserUtility.MToVM(user.AspNetUser),
                TimeZone=user.TimeZone
            };
            return temp;
        }
        public static List<UsersViewModel> MsToVMs(List<User> models)
        {
            var templist = new List<UsersViewModel>();
            foreach (User model in models)
            {
                templist.Add(MToVM(model));
            }
            return templist;
        }
        public static UserInformationViewModel MToVM1(User model) {
            return new UserInformationViewModel() {
                ID=model.ID,
                FirstName=model.FirstName,
                LastName=model.LastName
            };
        }

        #endregion


        #region View Model to Model
        public static User VMToM(UsersViewModel vm) {
            var temp = new User() {
                ID = vm.ID,
                Code = vm.Code,
                LastName = vm.LastName,
                FirstName = vm.FirstName,
                MiddleName = vm.MiddleName,
                ExtensionName = vm.ExtensionName,
                Gender = vm.Gender,
                MaritalStatus = vm.MaritalStatus,
                Nationality = vm.Nationality,
                Religion = vm.Religion,
                Birthday = Convert.ToDateTime(vm.Birthday),
                Address = vm.Address,
                ContactPerson = vm.ContactPerson,
                ContactNumber = vm.ContactNumber,
                Email = vm.Email,
                JobTitleID = vm.Jobtitle.ID,
                JobStatusID = vm.JobStatus.ID,
                CompanyID=vm.Company.ID,
                ProfileImage=vm.profileImage,
                TimeZone=vm.TimeZone
            };
            return temp;
        }
        //this model is used for updating existing model data
        public static User UVMToUM(User rModel, UsersViewModel vm) {
            rModel.FirstName = vm.FirstName;
            rModel.LastName = vm.LastName;
            rModel.MiddleName = vm.MiddleName;
            rModel.ExtensionName = vm.ExtensionName == null ? "" : vm.ExtensionName;
            rModel.Gender = vm.Gender;
            rModel.MaritalStatus = vm.MaritalStatus;
            rModel.Nationality = vm.Nationality;
            rModel.Religion = vm.Religion;
            rModel.Birthday = Convert.ToDateTime(vm.Birthday);
            rModel.Address = vm.Address;
            rModel.ContactNumber = vm.ContactNumber;
            rModel.Email = vm.Email;
            rModel.ProfileImage = vm.profileImage;
            rModel.JobTitleID = vm.Jobtitle.ID;
            return rModel;
        }



        public static List<User> VMsToMs(List<UsersViewModel> vms) {
            var models = new List<User>();
            foreach (UsersViewModel vm in vms) {
                models.Add(VMToM(vm));
            }
            return models;
        }
        #endregion
        #endregion
        #region aspnetuser
        public static AspNetUserViewModel MToVM(AspNetUser model) {
            var temp = new AspNetUserViewModel() {
                ID = model.Id,
                Email = model.Email,
                UserName = model.UserName,
                IsOnline = false
            };
            return temp;
        }
        #endregion
        #region adding new user
        public static bool GenerateUser(User model, IUserService _userService, UserManager _manager, HttpServerUtilityBase server, User CurrentUser, DateTime currTime) {
            try {
                var path = server.MapPath("/UPLOADS/SubscriberFiles/" + CurrentUser.CompanyID);
                if (!PathChecker.IsExist(path)) {
                    PathChecker.GenerateFolderOnPath(server.MapPath("/UPLOADS/SubscriberFiles"), CurrentUser.CompanyID);
                }
                var file = PathChecker.FindAvailableFileName(path, "File"+currTime.Date.ToString());
                if (ImageUpload.UriToServer(model.ProfileImage, path + "/" + file)) {
                    file = "/UPLOADS/SubscriberFiles/" + CurrentUser.CompanyID + "/" + file;
                    model.ProfileImage = file;
                    var newUser = new IdentityUser()
                    {
                        UserName = model.Email,
                        Email = model.Email
                    };
                    var aspResult = _manager.CreateAsync(newUser).Result;
                    model.AspNetUserID = _userService.GetAllAsp().Result.Where(us => us.Email == model.Email).FirstOrDefault().Id;
                    _manager.AddPassword(model.AspNetUserID, model.FirstName + DateTime.Now.Year);
                    if (Insert(model, _userService))
                    {
                        return true;
                    }
                }
                return false;
            } catch { return false; }
        }
        private static bool Insert(User model, IUserService _userService) {
            try {
                var uid = Guid.NewGuid().ToString();
                model.ID = uid;
                _userService.Insert(model);
                if (AspNetUserRoleUtility.InsertNewUserRole(_userService, model.AspNetUserID, "229f6569-d02f-4164-b1ce-170e35196048")) {
                    return true;
                }
                return false;
            } catch { return false; }
        }
        #endregion
    }
}