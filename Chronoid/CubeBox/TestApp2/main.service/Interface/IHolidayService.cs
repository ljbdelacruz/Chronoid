using App.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IHolidayService
    {
        List<Holiday> GetAll();
        List<Holiday> GetAllWithAsync();
        Holiday GetByID(string ID);
        Holiday GetByIDWithAsync(string ID);
        bool Update(Holiday model);
        bool Insert(Holiday model);
    }
}
