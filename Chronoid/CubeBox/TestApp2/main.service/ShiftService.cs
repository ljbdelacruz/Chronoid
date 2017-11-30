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
    public class ShiftService: IShiftService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        public ShiftService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<List<Shift>> GetAll() {
            try {
                using (var uow = _unitOfWorkFactory.Create()) {
                    var list = uow.Shift.AllWithAsync(s=>s.ID == s.ID, s=>s.Company, s=>s.Attendances).Result.ToList();
                    return list;
                }
            } catch { return null; }
        }
        public async Task<Shift> GetByID(string id) {
            try {
                using (var uow = _unitOfWorkFactory.Create()) {
                    var list = uow.Shift.AllWithAsync(s => s.ID == id, s => s.Company, s => s.Attendances).Result.FirstOrDefault();
                    return list;
                }
            } catch { return null; }
        }
        public bool Insert(Shift model) {
            try {
                using (var uow = _unitOfWorkFactory.Create()) {
                    uow.Shift.Insert(model);
                    uow.SaveChanges();
                    return true;
                }
            } catch { return false; }
        }
        public bool Update(Shift model)
        {
            try
            {
                using (var uow = _unitOfWorkFactory.Create())
                {
                    uow.Shift.Update(model);
                    uow.SaveChanges();
                    return true;
                }
            }
            catch { return false; }
        }


    }
}
