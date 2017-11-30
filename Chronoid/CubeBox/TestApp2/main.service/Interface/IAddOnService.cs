using App.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IAddOnService
    {
        Task<List<AddOn>> GetAll();
        Task<AddOn> GetByID(string id);
        bool Insert(AddOn model);
        bool Update(AddOn model);
    }
}
