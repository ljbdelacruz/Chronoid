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
    public class UserBreakTimeService:IUserBreakTimeService 
    {
        private IUnitOfWorkFactory _uow;
        public UserBreakTimeService(IUnitOfWorkFactory uow) {
            _uow = uow;
        }
        public async Task<List<UserBreakTime>> GetAll() {
            try {
                using (var uow = _uow.Create()) {
                    var temp = uow.UserBreakTime.AllWithAsync(ub=>ub.ID == ub.ID, ub=>ub.User, ub=>ub.BreakType).Result.ToList();
                    return temp.ToList();
                }
            } catch { return null; }
        }
        public async Task<UserBreakTime> GetWithAsyncByID(string id) {
            try {
                using (var uow = _uow.Create()) {
                    var result=uow.UserBreakTime.AllWithAsync(ub => ub.ID == id, ub => ub.User, ub => ub.BreakType).Result.FirstOrDefault();
                    Console.Write(result.BreakType);
                    return result;
                }
            } catch { return null; }
        }
        public bool Update(UserBreakTime item) {
            try {
                using (var uow = _uow.Create()) {
                    uow.UserBreakTime.Update(item);
                    uow.SaveChanges();
                    return true;
                }
            } catch { return false; }
        }
        public bool Insert(UserBreakTime item) {
            try
            {
                using (var uow = _uow.Create())
                {
                    uow.UserBreakTime.Insert(item);
                    uow.SaveChanges();
                    return true;
                }
            }
            catch { return false; }
        }

    }
}
