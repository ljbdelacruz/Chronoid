using App.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IBreakTypeService
    {
        Task<List<BreakType>> GetAll();
        bool Insert(BreakType model);
        bool Update(BreakType model);

    }
}
