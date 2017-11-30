using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Data.Entity;
using TestApp2.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using TestApp2.Controllers;
using Repository.Interface;
using Repository;
using Service.Interface;
using Service;

namespace TestApp2.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();
            container.RegisterType<DbContext, ApplicationDbContext>(new HierarchicalLifetimeManager())
           .RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(new HierarchicalLifetimeManager())
           .RegisterType<UserManager<ApplicationUser>>(new HierarchicalLifetimeManager())
           .RegisterType<AccountController>(new InjectionConstructor())
           .RegisterType<ManageController>(new InjectionConstructor());

            // TODO: Register your types here
            // container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<IUnitOfWorkFactory, UnitOfWorkFactory>()
            .RegisterType<IAddOnService, AddOnService>()
            .RegisterType<IAttendanceService, AttendanceService>()
            .RegisterType<IBreakTypeService, BreakTypeService>()
            .RegisterType<ICompanyService, CompanyService>()
            .RegisterType<IJobTitleService, JobTitleService>()
            .RegisterType<IUserBreakTimeService, UserBreakTimeService>()
            .RegisterType<IUserService, UserService>()
            .RegisterType<IShiftService, ShiftService>()
            .RegisterType<IDepartmentService, DepartmentService>()
            .RegisterType<IAddOnService, AddOnService>()
            .RegisterType<IHolidayService, HolidayService>();
        }
    }
}
