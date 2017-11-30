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
    public class CompanyService:ICompanyService
    {

        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        public CompanyService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }
        public async  Task<List<Company>> GetAll()
        {
            try
            {
                using (var uow = _unitOfWorkFactory.Create())
                {
                    var result = uow.Company.AllWithAsync(c => c.id == c.id, c => c.Users, c => c.JobTitles).Result.ToList();
                    return result;
                }
            }
            catch { return null; }
        }

        public async Task<Company> GetByID(string id) {
            try {
                using (var uow = _unitOfWorkFactory.Create()) {
                    var result = uow.Company.AllWithAsync(c => c.id == id, c => c.JobTitles, c => c.Users).Result.FirstOrDefault();
                    return result;
                }
            } catch { return null; }
        }
        public bool Insert(Company item) {
            try {
                using (var uow = _unitOfWorkFactory.Create()) {
                    uow.Company.Insert(item);
                    uow.SaveChanges();
                    return true;
                }
            } catch { return false; }
        }

        public bool Update(Company item) {
            try {
                using (var uow = _unitOfWorkFactory.Create()) {
                    uow.Company.Update(item);
                    uow.SaveChanges();
                    return true;
                }
            } catch { return false; }
        }

    }
}
