using App.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IJobTitleService
    {
        Task<List<JobTitle>> GetAll();
        Task<JobTitle> GetByID(string id);
        bool Insert(JobTitle model);
        bool Update(JobTitle model);

    }
}
