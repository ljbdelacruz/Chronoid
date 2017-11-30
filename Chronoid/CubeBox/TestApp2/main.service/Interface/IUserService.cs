using App.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IUserService
    {
        //users
        #region user
        Task<List<User>> GetAll();
        Task<User> GetByID(string id);
        Task<User> GetByIDAsync(string ID);
        bool Insert(User model);
        bool Update(User model);
        #endregion
        #region aspnetuser
        //asp
        Task<List<AspNetUser>> GetAllAsp();
        Task<AspNetUser> GetByIDAsp(string id);
        Task<AspNetUser> GetByIDAspWithAsync(string id);
        bool Update(AspNetUser item);


        #endregion
        #region aspnetuserrole
        Task<AspNetRole> GetRoleByID(string id);
        bool Insert(AspNetUserRole item);

        #endregion

    }
}
