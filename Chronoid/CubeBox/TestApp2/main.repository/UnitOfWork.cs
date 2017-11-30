using App.Data.Models;
using Repository.Interface;
using System.Threading.Tasks;
using App.Data;


namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private CubeBox_DBContext _dbContext;
        public UnitOfWork()
        {
            _dbContext = new CubeBox_DBContext();
        }

        #region Basics
        private Repository<AspNetRole> _aspNetRole;
        public IRepository<AspNetRole> AspNetRole
        {
            get
            {
                if (_aspNetRole == null)
                    _aspNetRole = new Repository<AspNetRole>(_dbContext);
                return _aspNetRole;
            }
        }
        private Repository<AspNetUser> _aspNetUser;
        public IRepository<AspNetUser> AspNetUser
        {
            get
            {
                if (_aspNetUser == null)
                    _aspNetUser = new Repository<AspNetUser>(_dbContext);
                return _aspNetUser;
            }
        }
        private Repository<AspNetUserRole> _aspNetUserRole;
        public IRepository<AspNetUserRole> AspNetUserRole
        {
            get
            {
                if (_aspNetUserRole == null)
                    _aspNetUserRole = new Repository<AspNetUserRole>(_dbContext);
                return _aspNetUserRole;
            }
        }

        #endregion

        #region Schedules
        private Repository<AddOn> _addOn;
        public IRepository<AddOn> AddOn
        {
            get
            {
                if (_addOn == null)
                    _addOn = new Repository<AddOn>(_dbContext);
                return _addOn;
            }
        }
        private Repository<Attendance> _attendance;
        public IRepository<Attendance> Attendance
        {
            get
            {
                if (_attendance == null)
                    _attendance = new Repository<Attendance>(_dbContext);
                return _attendance;
            }
        }
        private Repository<Shift> _shift;
        public IRepository<Shift> Shift
        {
            get
            {
                if (_shift == null)
                    _shift = new Repository<Shift>(_dbContext);
                return _shift;
            }
        }
        private Repository<SchedulesAddOn> _scheduleAddOn;
        public IRepository<SchedulesAddOn> SchedulesAddOn
        {
            get
            {
                if (_scheduleAddOn == null)
                    _scheduleAddOn = new Repository<SchedulesAddOn>(_dbContext);
                return _scheduleAddOn;
            }
        }
        private Repository<AttendanceStatu> _attendanceStatu;
        public IRepository<AttendanceStatu> AttendanceStatu
        {
            get
            {
                if (_attendanceStatu == null)
                    _attendanceStatu = new Repository<AttendanceStatu>(_dbContext);
                return _attendanceStatu;
            }
        }
        private Repository<SystemLog> _systemLog;
        public IRepository<SystemLog> SystemLog
        {
            get
            {
                if (_systemLog == null)
                    _systemLog = new Repository<SystemLog>(_dbContext);
                return _systemLog;
            }
        }
        private Repository<LogDescription> _logDescription;
        public IRepository<LogDescription> LogDescription
        {
            get
            {
                if (_logDescription == null)
                    _logDescription = new Repository<LogDescription>(_dbContext);
                return _logDescription;
            }
        }
        private Repository<Holiday> _holiday;
        public IRepository<Holiday> Holiday
        {
            get
            {
                if (_holiday == null)
                    _holiday = new Repository<Holiday>(_dbContext);
                return _holiday;
            }
        }
        #endregion

        #region Breaks
        private Repository<UserBreakTime> _userBreakTime;
        public IRepository<UserBreakTime> UserBreakTime
        {
            get
            {
                if (_userBreakTime == null)
                    _userBreakTime = new Repository<UserBreakTime>(_dbContext);
                return _userBreakTime;
            }
        }
        private Repository<BreakType> _breakType;
        public IRepository<BreakType> BreakType
        {
            get
            {
                if (_breakType == null)
                    _breakType = new Repository<BreakType>(_dbContext);
                return _breakType;
            }
        }
        #endregion

        #region Users
        private Repository<User> _user;
        public IRepository<User> User
        {
            get
            {
                if (_user == null)
                    _user = new Repository<User>(_dbContext);
                return _user;
            }
        }

        private Repository<JobTitle> _jobTitle;
        public IRepository<JobTitle> JobTitle
        {
            get
            {
                if (_jobTitle == null)
                    _jobTitle = new Repository<JobTitle>(_dbContext);
                return _jobTitle;
            }
        }

        private Repository<Company> _company;
        public IRepository<Company> Company
        {
            get
            {
                if (_company == null)
                    _company = new Repository<Company>(_dbContext);
                return _company;
            }
        }
        private Repository<Department> _department;
        public IRepository<Department> Department
        {
            get
            {
                if (_department == null)
                    _department = new Repository<Department>(_dbContext);
                return _department;
            }
        }
        private Repository<App.Data.Models.TimeZone> _timeZones;
        public IRepository<App.Data.Models.TimeZone> TimeZonesRepo
        {
            get
            {
                if (_timeZones == null)
                    _timeZones = new Repository<App.Data.Models.TimeZone>(_dbContext);
                return _timeZones;
            }
        }
        #endregion

        //basically this is where we add the functionality if we add new database in our tables in the database
        public void Dispose()
        {
            _dbContext.Dispose();
        }
        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
        public Task SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }



    }
}
