using App.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        //add here interface methods here before adding to unit of work class 
        #region Basics
        IRepository<AspNetRole> AspNetRole { get; }
        IRepository<AspNetUser> AspNetUser { get; }
        IRepository<AspNetUserRole> AspNetUserRole { get; }
        #endregion
        #region Schedules
        IRepository<AddOn> AddOn { get; }
        IRepository<Attendance> Attendance { get; }
        IRepository<Shift> Shift { get; }
        IRepository<SchedulesAddOn> SchedulesAddOn { get; }
        IRepository<AttendanceStatu> AttendanceStatu { get; }
        IRepository<SystemLog> SystemLog { get; }
        IRepository<LogDescription> LogDescription { get; }
        IRepository<Holiday> Holiday { get; }
        #endregion

        #region breaks
        IRepository<UserBreakTime> UserBreakTime { get; }
        IRepository<BreakType> BreakType { get; }
        #endregion

        #region Users
        IRepository<User> User { get; }
        IRepository<JobTitle> JobTitle { get; }
        IRepository<Company> Company { get; }
        IRepository<Department> Department { get; }
        IRepository<App.Data.Models.TimeZone> TimeZonesRepo { get; }
        #endregion



        void SaveChanges();
        Task SaveChangesAsync();
    }
}
