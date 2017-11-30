using App.Data.Models;
using main.repository.Interface;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class LogDescriptionService:ILogDescriptionService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        public LogDescriptionService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<List<LogDescription>> GetAll() {
            try {
                using (var uow = _unitOfWorkFactory.Create()) {
                    var list = uow.LogDescription.AllWithAsync(l => l.ID == l.ID, l=>l.SystemLogs).Result.ToList();
                    return list;
                }
            } catch { return null; }
        }
        public async Task<LogDescription> GetByID(int ID) {
            try {
                using (var uow = _unitOfWorkFactory.Create()) {
                    var model = uow.LogDescription.AllWithAsync(ld => ld.ID == ID, ld => ld.SystemLogs).Result.FirstOrDefault();
                    return model;
                }
            } catch { return null;}
        }
        public bool Insert(LogDescription model) {
            try {
                using (var uow = _unitOfWorkFactory.Create()) {
                    uow.LogDescription.Insert(model);
                    uow.SaveChanges();
                    return true;
                }
            } catch { return false; }
        }
        public bool Update(LogDescription model)
        {
            try
            {
                using (var uow = _unitOfWorkFactory.Create())
                {
                    uow.LogDescription.Update(model);
                    uow.SaveChanges();
                    return true;
                }
            }
            catch { return false; }
        }
    }
}
