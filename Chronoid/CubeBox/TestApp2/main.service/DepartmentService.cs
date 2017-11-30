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
    public class DepartmentService:IDepartmentService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        public DepartmentService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<List<Department>> GetAll() {
            try {
                using (var uow = _unitOfWorkFactory.Create()) {
                    var list = uow.Department.AllWithAsync(d=>d.ID == d.ID, d=>d.Company).Result.ToList();
                    return list;
                }
            } catch { return null; }
        }
        public async Task<Department> GetByID(string id)
        {
            try
            {
                using (var uow = _unitOfWorkFactory.Create())
                {
                    var list = uow.Department.AllWithAsync(d => d.ID == id, d => d.Company).Result.ToList();
                    return list.FirstOrDefault();
                }
            }
            catch { return null; }
        }

        public bool Insert(Department model) {
            try {
                using (var uow = _unitOfWorkFactory.Create()) {
                    uow.Department.Insert(model);
                    uow.SaveChanges();
                    return true;
                }
            } catch { return false; }
        }
        public bool Update(Department model)
        {
            try
            {
                using (var uow = _unitOfWorkFactory.Create())
                {
                    uow.Department.Update(model);
                    uow.SaveChanges();
                    return true;
                }
            }
            catch { return false; }
        }


    }
}
