using App.Data.Models;
using GeneralClass.DataVerification.String;
using GeneralClass.DateControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApp2.Models.Utilities
{
    public static class HolidayUtility
    {

        #region Filter
        public static List<Holiday> FilterByCompanyID(string ID, List<Holiday> list) {
            return list.Where(h => h.CompanyID == ID).ToList();
        }
        public static Holiday FilterByID(string ID, List<Holiday> list) {
            return list.Where(h => h.ID == ID).FirstOrDefault();
        }
        #endregion
        #region Sorting
        public static List<Holiday> OrderByStartDate(List<Holiday> list, bool isDesc) {
            return isDesc ? list.OrderByDescending(h=>h.StartDate).ToList() : list.OrderBy(h => h.StartDate).ToList();
        }
        public static List<Holiday> OrderByEndDate(List<Holiday> list, bool isDesc)
        {
            return isDesc ? list.OrderByDescending(h => h.EndDate).ToList() : list.OrderBy(h => h.EndDate).ToList();
        }
        #endregion
        #region Model To ViewModel
        public static HolidayVM MToVM(Holiday vm)
        {
            return new HolidayVM() {
                ID = vm.ID,
                Description = vm.Description,
                StartDate = vm.StartDate.HasValue ? TimeFormatter.DateToString(vm.StartDate.Value) : "N/A",
                EndDate = vm.EndDate.HasValue ? TimeFormatter.DateToString(vm.EndDate.Value) : "N/A",
                Company = new CompanyViewModel() { ID = vm.CompanyID }
            };
        }
        public static List<HolidayVM> MsToVMs(List<Holiday> models) {
            var list = new List<HolidayVM>();
            foreach (Holiday model in models) {
                list.Add(MToVM(model));
            }
            return list;
        }
        #endregion
        #region ViewModel to Model
        public static Holiday VMToM(HolidayVM vm) {
            return new Holiday() {
                ID=vm.ID,
                Description=vm.Description,
                StartDate=DataVerification.IsNull(vm.StartDate) ? new DateTime() : Convert.ToDateTime(vm.StartDate),
                EndDate=DataVerification.IsNull(vm.EndDate) ? new DateTime() : Convert.ToDateTime(vm.EndDate),
                CompanyID=vm.Company.ID
            };
        }
        public static Holiday UVMToUM(HolidayVM vm, Holiday m) {
            m.Description = vm.Description;
            m.StartDate = DataVerification.IsNull(vm.StartDate) ? new DateTime() : Convert.ToDateTime(vm.StartDate);
            m.EndDate = DataVerification.IsNull(vm.EndDate) ? new DateTime() : Convert.ToDateTime(vm.EndDate);
            return m;
        }
        public static List<Holiday> VMsToMs(List<HolidayVM> models) {
            var list = new List<Holiday>();
            foreach (HolidayVM model in models) {
                list.Add(VMToM(model));
            }
            return list;
        }
        #endregion
        #region Functionalities
        public static bool IsHoliday(List<Holiday> holidays, DateTime date) {
            return holidays.Where(h => h.StartDate == date).ToList().Count > 0;  
        }
        #endregion




    }
}