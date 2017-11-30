using App.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IUserBreakTimeService
    {
        Task<List<UserBreakTime>> GetAll();
        Task<UserBreakTime> GetWithAsyncByID(string id);
        bool Insert(UserBreakTime model);
        bool Update(UserBreakTime model);

    }
}
