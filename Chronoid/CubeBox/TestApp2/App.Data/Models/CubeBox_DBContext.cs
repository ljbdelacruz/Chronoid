using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using App.Data.Models.Mapping;

namespace App.Data.Models
{
    public partial class CubeBox_DBContext : DbContext
    {
        static CubeBox_DBContext()
        {
            Database.SetInitializer<CubeBox_DBContext>(null);
        }

        public CubeBox_DBContext()
            : base("Name=DefaultConnection")
        {
        }

        public DbSet<AddOn> AddOns { get; set; }
        public DbSet<AspNetRole> AspNetRoles { get; set; }
        public DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public DbSet<AspNetUser> AspNetUsers { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<AttendanceStatu> AttendanceStatus { get; set; }
        public DbSet<AudioWarning> AudioWarnings { get; set; }
        public DbSet<BreakType> BreakTypes { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanySubscription> CompanySubscriptions { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<JobStatu> JobStatus { get; set; }
        public DbSet<JobTitle> JobTitles { get; set; }
        public DbSet<LogDescription> LogDescriptions { get; set; }
        public DbSet<SchedulesAddOn> SchedulesAddOns { get; set; }
        public DbSet<ScheduleWeek> ScheduleWeeks { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<SubscriptionLimitation> SubscriptionLimitations { get; set; }
        public DbSet<SubscriptionType> SubscriptionTypes { get; set; }
        public DbSet<SystemLog> SystemLogs { get; set; }
        public DbSet<SystemSetting> SystemSettings { get; set; }
        public DbSet<TimeZone> TimeZones { get; set; }
        public DbSet<UserBreakTime> UserBreakTimes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Week> Weeks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AddOnMap());
            modelBuilder.Configurations.Add(new AspNetRoleMap());
            modelBuilder.Configurations.Add(new AspNetUserClaimMap());
            modelBuilder.Configurations.Add(new AspNetUserLoginMap());
            modelBuilder.Configurations.Add(new AspNetUserRoleMap());
            modelBuilder.Configurations.Add(new AspNetUserMap());
            modelBuilder.Configurations.Add(new AttendanceMap());
            modelBuilder.Configurations.Add(new AttendanceStatuMap());
            modelBuilder.Configurations.Add(new AudioWarningMap());
            modelBuilder.Configurations.Add(new BreakTypeMap());
            modelBuilder.Configurations.Add(new CompanyMap());
            modelBuilder.Configurations.Add(new CompanySubscriptionMap());
            modelBuilder.Configurations.Add(new DepartmentMap());
            modelBuilder.Configurations.Add(new HolidayMap());
            modelBuilder.Configurations.Add(new JobStatuMap());
            modelBuilder.Configurations.Add(new JobTitleMap());
            modelBuilder.Configurations.Add(new LogDescriptionMap());
            modelBuilder.Configurations.Add(new SchedulesAddOnMap());
            modelBuilder.Configurations.Add(new ScheduleWeekMap());
            modelBuilder.Configurations.Add(new ShiftMap());
            modelBuilder.Configurations.Add(new SubscriptionLimitationMap());
            modelBuilder.Configurations.Add(new SubscriptionTypeMap());
            modelBuilder.Configurations.Add(new SystemLogMap());
            modelBuilder.Configurations.Add(new SystemSettingMap());
            modelBuilder.Configurations.Add(new TimeZoneMap());
            modelBuilder.Configurations.Add(new UserBreakTimeMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new WeekMap());
        }
    }
}
