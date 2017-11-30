using App.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface ICompanyService
    {
        Task<List<Company>> GetAll();
        Task<Company> GetByID(string id);
        bool Insert(Company model);
        bool Update(Company model);
    }
}
