using App.Data.Models;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UserService:IUserService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        public UserService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }
        //Users
        #region user
        public async Task<List<User>> GetAll() {
            try {
                using (var uow = _unitOfWorkFactory.Create()) {
                    var result = uow.User.AllWithAsync(u=>u.ID == u.ID, 
                                                       u=>u.Company, 
                                                       u=>u.Attendances,
                                                       u=>u.UserBreakTimes,
                                                       u=>u.JobTitle,
                                                       u=>u.JobStatu,
                                                       u=>u.AspNetUser,
                                                       u=>u.Department).Result.ToList();
                    return result;
                }
            } catch(Exception e) {
                Console.Write(e); throw; }
        }
        public async Task<User> GetByID(string id) {
            try {
                using (var uow = _unitOfWorkFactory.Create()) {
                    var result = uow.User.AllWithAsync(u => u.ID == id,
                                                       u => u.Company,
                                                       u => u.Attendances,
                                                       u => u.UserBreakTimes,
                                                       u => u.JobTitle,
                                                       u => u.JobStatu,
                                                       u => u.AspNetUser,
                                                       u => u.Department).Result.FirstOrDefault();
                    return result;
                }
            } catch { return null; }
        }
        public async Task<User> GetByIDAsync(string ID) {
            try {
                using (var uow = _unitOfWorkFactory.Create()) {
                    return uow.User.All.Where(u => u.ID == ID).FirstOrDefault();
                }
            } catch { return null; }
        }


        public bool Insert(User user) {
            try {
                using (var uow = _unitOfWorkFactory.Create()) {
                    uow.User.Insert(user);
                    uow.SaveChanges();
                    return true;
                }
            } catch { return false; }
        }
        public bool Update(User user) {
            try {
                using (var uow = _unitOfWorkFactory.Create()) {
                    uow.User.Update(user);
                    uow.SaveChanges();
                    return true;
                }
            } catch { return false; }
        }


        #endregion
        #region aspnetuser
        //AspNetUsers
        public async Task<List<AspNetUser>> GetAllAsp() {
            try {
                using (var uow = _unitOfWorkFactory.Create()) {
                    var result = uow.AspNetUser.AllAsync().Result.ToList();
                    return result;
                }
            } catch { throw; }
        }
        public async Task<AspNetUser> GetByIDAsp(string id) {
            try {
                using (var uow = _unitOfWorkFactory.Create()) {
                    var result = uow.AspNetUser.All.Where(au => au.Id == id).FirstOrDefault();
                    return result;
                }
            } catch { throw; }
        }

        public async Task<AspNetUser> GetByIDAspWithAsync(string id) {
            try {
                using (var uow = _unitOfWorkFactory.Create()) {
                    var result = uow.AspNetUser.AllWithAsync(au => au.Id == id, ar => ar.AspNetUserRoles).Result.FirstOrDefault();
                    return result;
                }
            } catch { return null; }
        }
        public bool Update(AspNetUser item) {
            try {
                using (var uow = _unitOfWorkFactory.Create()) {
                    uow.AspNetUser.Update(item);
                    uow.SaveChanges();
                    return true;
                }
            } catch { return false; }
        }


        #endregion
        #region aspnetuserrole
        public async Task<AspNetRole> GetRoleByID(string id) {
            try {
                using (var uow = _unitOfWorkFactory.Create()) {
                    var model = uow.AspNetRole.All.Where(a => a.Id == id).FirstOrDefault();
                    return model;
                }
            } catch { return null; }
        }
        public bool Insert(AspNetUserRole item) {
            try {
                using (var uow = _unitOfWorkFactory.Create()) {
                    uow.AspNetUserRole.Insert(item);
                    uow.SaveChanges();
                    return true;
                }
            } catch { return false; }
        }

        #endregion
    }
}
