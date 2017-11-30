using App.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface ISystemLogService
    {
        Task<List<SystemLog>> GetAll();
        Task<SystemLog> GetByID(int ID);
        bool Insert(SystemLog model);
        bool Update(SystemLog model);

    }
}
