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
    public class AddOnService:IAddOnService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        public AddOnService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }
        public async Task<List<AddOn>> GetAll() {
            try {
                using (var uow = _unitOfWorkFactory.Create()) {
                    var result = uow.AddOn.AllWithAsync(a=>a.ID == a.ID, a=>a.Company).Result.ToList();
                    return result;
                } 
            } catch { throw; }
        }
        public async Task<AddOn> GetByID(string id) {
            try {
                using (var uow = _unitOfWorkFactory.Create()) {
                    var result = uow.AddOn.AllWithAsync(a => a.ID ==id, a => a.Company).Result.FirstOrDefault();
                    return result;
                }
            } catch { throw; }
        }

        public bool Insert(AddOn model) {
            try {
                using (var uow = _unitOfWorkFactory.Create()) {
                    uow.AddOn.Insert(model);
                    uow.SaveChanges();
                    return true;
                }
            } catch { return false; }
        }
        public bool Update(AddOn model)
        {
            try
            {
                using (var uow = _unitOfWorkFactory.Create())
                {
                    uow.AddOn.Insert(model);
                    uow.SaveChanges();
                    return true;
                }
            }
            catch { return false; }
        }

    }
}
