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
    public class BreakTypeService:IBreakTypeService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        public BreakTypeService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }
        public async Task<List<BreakType>> GetAll() {
            try {
                using (var uow = _unitOfWorkFactory.Create()) {
                    var result = uow.BreakType.AllWithAsync(b=>b.id == b.id, b=>b.User, b=>b.Company).Result.ToList();
                    return result;
                }
            } catch { return null; }
        }
        public bool Insert(BreakType model) {
            try {
                using (var uow = _unitOfWorkFactory.Create()) {
                    uow.BreakType.Insert(model);
                    uow.SaveChanges();
                    return true;
                }
            } catch { return false; }
        }
        public bool Update(BreakType model)
        {
            try
            {
                using (var uow = _unitOfWorkFactory.Create())
                {
                    uow.BreakType.Update(model);
                    uow.SaveChanges();
                    return true;
                }
            }
            catch { return false; }
        }



    }
}
