using App.Data.Models;
using GeneralClass.DateControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApp2.Models.Utilities
{
    public static class BreakTypeUtility
    {
        #region Model to ViewModel
        public static BreakTypeViewModel MToVM(BreakType model) {
            return new BreakTypeViewModel() {
                ID=""+model.id,
                Description=model.Description,
                CompanyID=model.CompanyID,
                OrderNumber=model.OrderNumber.Value,
                HexColor=model.HexColor,
                EnableTime=model.EnableTime.Value.ToString(),
                DisableTime=model.DisableTime.Value.ToString(),
                TimeLimit=model.TimeLimit.HasValue ? model.TimeLimit.Value : 0
            };
        }
        public static List<BreakTypeViewModel> MsToVMs(List<BreakType> models) {
            var list = new List<BreakTypeViewModel>();
            foreach (BreakType model in models) {
                list.Add(MToVM(model));
            }
            return list;
        }
        #endregion
        #region Model To ViewModel
        public static BreakType VMToM(BreakTypeViewModel vm) {
            return new BreakType() {
                id=vm.ID,
                Description=vm.Description,
                OrderNumber=vm.OrderNumber,
                CompanyID=vm.CompanyID,
                HexColor=vm.HexColor,
                EnableTime= TimeSpan.Parse(vm.EnableTime),
                DisableTime=TimeSpan.Parse(vm.DisableTime),
                TimeLimit=vm.TimeLimit
            };
        }
        public static List<BreakType> VMsToMs(List<BreakTypeViewModel> vms) {
            var list = new List<BreakType>();
            foreach (BreakTypeViewModel vm in vms) {
                list.Add(VMToM(vm));
            }
            return list;
        }
        #endregion
        #region Filter
        public static List<BreakType> FilterByCompanyID(string ID, List<BreakType> models) {
            return models.Where(b => b.CompanyID == ID).ToList();
        }
        public static BreakType FilterByBreakDescriptionCompanyID(string description, string companyID, List<BreakType> models) {
            return models.Where(b => b.CompanyID == companyID && b.Description == description).FirstOrDefault();
        }
        //public static BreakType FilterAvailableBreaks(TimeSpan time, List<BreakType> models) {
        //    return models.Where(b=>b.)
        //}
        public static List<BreakType> FilterByTime(List<BreakType> models, TimeSpan CurrentTime, TimeSpan userTimeIn) {
            return models.Where(b => TimeCalculator.AddTime(userTimeIn, b.DisableTime.Value) < CurrentTime).ToList();
        }
        public static List<BreakType> FilterByIsArchived(List<BreakType> models, bool isArchived) {
            return models.Where(bt => bt.isArchived == isArchived).ToList();
        }


        #endregion
        #region Sort
        public static List<BreakType> SortByOrderNumber(List<BreakType> models, bool isDesc) {
            return isDesc ? models.OrderByDescending(b => b.OrderNumber).ToList() : models.OrderBy(b => b.OrderNumber).ToList();
        }
        public static List<BreakTypeViewModel> SortByOrderNumber(List<BreakTypeViewModel> models, bool isDesc)
        {
            return isDesc ? models.OrderByDescending(b => b.OrderNumber).ToList() : models.OrderBy(b => b.OrderNumber).ToList();
        }
        public static List<BreakType> SortByDescription(List<BreakType> models, bool isDesc) {
            return isDesc ? models.OrderByDescending(b => b.Description).ToList() : models.OrderBy(b => b.Description).ToList();
        }

        #endregion
        #region functionality
        //functionality to check wether this type of break is allowable or not
        public static bool isAllowBreak(string type, List<UserBreakTime> myBreakToday, DateTime timeIn, DateTime CurrentTime) {
            if (myBreakToday.Count > 0) {
                var count=myBreakToday.Where(ubt => ubt.Type == type).ToList().Count;
                return true;
            }
            return false;
        }
        #endregion





    }
}