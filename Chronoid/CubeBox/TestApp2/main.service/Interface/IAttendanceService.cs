using App.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IAttendanceService
    {

        #region Attendance
        Task<List<Attendance>> GetAll();
        Task<List<Attendance>> GetAllWithAsync();
        Task<Attendance> GetByIDWithAsync(string id);
        bool Insert(Attendance model);
        bool Update(Attendance model);
        #endregion

        #region Attendance Status
        Task<List<AttendanceStatu>> GetAll1();
        bool Insert1(AttendanceStatu model);
        bool Update1(AttendanceStatu model);

        #endregion
    }
}
