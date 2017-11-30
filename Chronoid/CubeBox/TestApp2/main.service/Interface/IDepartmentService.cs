using App.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IDepartmentService
    {
        Task<List<Department>> GetAll();
        Task<Department> GetByID(string id);
        bool Insert(Department model);
        bool Update(Department model);
    }
}
