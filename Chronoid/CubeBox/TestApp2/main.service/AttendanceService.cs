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
    public class AttendanceService:IAttendanceService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        public AttendanceService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        #region Attendance
        public async Task<List<Attendance>> GetAll() {
            try {
                using (var uow = _unitOfWorkFactory.Create()) {
                    var list = uow.Attendance.AllAsync().Result.ToList();
                    return list;
                }
            } catch(Exception e) {
                Console.WriteLine(e);
                return null; }
        }

        public async Task<List<Attendance>> GetAllWithAsync() {
            try {
                using (var uow = _unitOfWorkFactory.Create())
                {
                    var list = uow.Attendance.AllWithAsync(us=>us.ID == us.ID,us=>us.Shift, us=>us.User, us=>us.SchedulesAddOns, us=>us.AddOn).Result.ToList();
                    return list;
                }
            } catch(Exception e) {
                Console.WriteLine(e);
                return null;
            }
        }
        public async Task<Attendance> GetByIDWithAsync(string id) {
            try {
                using (var uow = _unitOfWorkFactory.Create()) {
                    var list = uow.Attendance.AllWithAsync(a=>a.ID == id, a => a.Shift, a => a.User, us => us.AddOn).Result.FirstOrDefault();
                    return list;
                }
            } catch { return null; }
        }
        public bool Insert(Attendance item) {
            try {
                using (var uow = _unitOfWorkFactory.Create()) {
                    uow.Attendance.Insert(item);
                    uow.SaveChanges();
                    return true;
                }
            } catch { return false; }
        }

        public bool Update(Attendance item) {
            try {
                using (var uow = _unitOfWorkFactory.Create()) {
                    uow.Attendance.Update(item);
                    uow.SaveChanges();
                    return true;
                }
            } catch { return false; }
        }
        #endregion

        #region Attendance Status
        public async Task<List<AttendanceStatu>> GetAll1() {
            try {
                using (var uow = _unitOfWorkFactory.Create()) {
                    var list = uow.AttendanceStatu.AllWithAsync(a=>a.ID==a.ID).Result.ToList();
                    return list;
                }
            } catch { return null; }
        }
        public bool Insert1(AttendanceStatu model) {
            try {
                using (var uow = _unitOfWorkFactory.Create()) {
                    uow.AttendanceStatu.Insert(model);
                    uow.SaveChanges();
                    return true;
                }
            } catch { return false; }
        }
        public bool Update1(AttendanceStatu model) {
            try {
                using (var uow = _unitOfWorkFactory.Create()) {
                    uow.AttendanceStatu.Update(model);
                    uow.SaveChanges();
                    return true;
                }
            } catch { return false; }
        }
        #endregion

    }
}
