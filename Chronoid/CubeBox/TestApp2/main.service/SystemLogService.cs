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
    public class SystemLogService : ISystemLogService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        public SystemLogService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }
        public async Task<List<SystemLog>> GetAll() {
            try {
                using (var uow = _unitOfWorkFactory.Create()) {
                    var list = uow.SystemLog.AllWithAsync(sl => sl.ID == sl.ID, sl => sl.LogDescription, sl => sl.Company).Result.ToList();
                    return list;
                }
            } catch { return null; }
        }
        public async Task<SystemLog> GetByID(int ID) {
            try {
                using (var uow = _unitOfWorkFactory.Create()) {
                    var model = uow.SystemLog.AllWithAsync(sl => sl.ID == ID, sl => sl.LogDescription, sl => sl.Company).Result.FirstOrDefault();
                    return model;
                }
            } catch { return null; }
        }

        public bool Insert(SystemLog model) {
            try {
                using (var uow = _unitOfWorkFactory.Create()) {
                    uow.SystemLog.Insert(model);
                    uow.SaveChanges();
                    return true;
                }
            } catch { return false; }
        }
        public bool Update(SystemLog model)
        {
            try
            {
                using (var uow = _unitOfWorkFactory.Create())
                {
                    uow.SystemLog.Update(model);
                    uow.SaveChanges();
                    return true;
                }
            }
            catch { return false; }
        }

    }
}
