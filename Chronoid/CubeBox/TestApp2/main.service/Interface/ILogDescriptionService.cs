using App.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main.repository.Interface
{
    public interface ILogDescriptionService
    {
        Task<List<LogDescription>> GetAll();
        Task<LogDescription> GetByID(int ID);
        bool Insert(LogDescription model);
        bool Update(LogDescription model);
    }
}
