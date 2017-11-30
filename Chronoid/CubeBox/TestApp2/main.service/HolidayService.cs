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
    public class HolidayService : IHolidayService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        public HolidayService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public List<Holiday> GetAll() {
            try {
                using (var uow = _unitOfWorkFactory.Create()) {
                    return uow.Holiday.AllAsync().Result.ToList();
                }
            } catch { return null; }
        }
        public List<Holiday> GetAllWithAsync()
        {
            try
            {
                using (var uow = _unitOfWorkFactory.Create())
                {
                    return uow.Holiday.AllWithAsync(h=>h.ID == h.ID, h=>h.Company).Result.ToList();
                }
            }
            catch { return null; }
        }
        public Holiday GetByID(string ID) {
            try {
                using (var uow = _unitOfWorkFactory.Create()) {
                    return uow.Holiday.All.Where(h => h.ID == ID).FirstOrDefault();
                }
            } catch { return null; }
        }
        public Holiday GetByIDWithAsync(string ID)
        {
            try
            {
                using (var uow = _unitOfWorkFactory.Create())
                {
                    return uow.Holiday.AllWithAsync(h => h.ID == ID, h=>h.Company).Result.FirstOrDefault();
                }
            }
            catch { return null; }
        }
        public bool Insert(Holiday model) {
            try {
                using (var uow = _unitOfWorkFactory.Create()) {
                    uow.Holiday.Insert(model);
                    uow.SaveChanges();
                    return true;
                }
            } catch { return false; }
        }
        public bool Update(Holiday model)
        {
            try
            {
                using (var uow = _unitOfWorkFactory.Create())
                {
                    uow.Holiday.Update(model);
                    uow.SaveChanges();
                    return true;
                }
            }
            catch { return false; }
        }

    }
}
