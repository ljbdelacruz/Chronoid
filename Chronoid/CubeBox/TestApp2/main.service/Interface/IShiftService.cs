using App.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IShiftService
    {
        Task<List<Shift>> GetAll();
        Task<Shift> GetByID(string id);
        bool Insert(Shift model);
        bool Update(Shift model);


    }
}
