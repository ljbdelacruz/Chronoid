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
    public class JobTitleService:IJobTitleService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        public JobTitleService(IUnitOfWorkFactory unitOfWorkFactory) {
            _unitOfWorkFactory = unitOfWorkFactory;
        }
        public async Task<List<JobTitle>> GetAll() {
            try {
                using (var uow = _unitOfWorkFactory.Create()) {
                    var list = uow.JobTitle.AllWithAsync(j => j.ID == j.ID, j => j.Company, j => j.Users).Result.ToList();
                    return list;
                }
            } catch { return null; }
        }
        public async Task<JobTitle> GetByID(string id) {
            try {
                using (var uow = _unitOfWorkFactory.Create()) {
                    var result = uow.JobTitle.AllWithAsync(j => j.ID == id, j=>j.Company, j=>j.Users).Result.FirstOrDefault();
                    return result;
                }
            } catch { return null; }
        }


        public bool Insert(JobTitle model) {
            try {
                using (var uow = _unitOfWorkFactory.Create()) {
                    uow.JobTitle.Insert(model);
                    uow.SaveChanges();
                    return true;
                }
            } catch { return false; }
        }
        public bool Update(JobTitle model)
        {
            try
            {
                using (var uow = _unitOfWorkFactory.Create())
                {
                    uow.JobTitle.Update(model);
                    uow.SaveChanges();
                    return true;
                }
            }
            catch { return false; }
        }
    }
}
