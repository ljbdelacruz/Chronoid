using App.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApp2.Models.Utilities
{
    public static class AttendanceStatusUtility
    {
        #region Model to ViewModel
        public static AttendanceStatusViewModel MToVM(AttendanceStatu model) {
            return new AttendanceStatusViewModel()
            {
                ID = model.ID,
                Description = model.Description,
                Company = new CompanyViewModel() { ID=model.CompanyID}
            };
        }
        public static List<AttendanceStatusViewModel> MsToVMs(List<AttendanceStatu> models) {
            var list = new List<AttendanceStatusViewModel>();
            foreach (AttendanceStatu model in models) {list.Add(MToVM(model));}
            return list;
        }
        #endregion

        #region ViewModel to Model
        public static AttendanceStatu VMToM(AttendanceStatusViewModel model) {
            return new AttendanceStatu() {
                ID=model.ID,
                Description=model.Description,
                CompanyID=model.Company.ID
            };
        }
        public static List<AttendanceStatu> VMsToMs(List<AttendanceStatusViewModel> models) {
            var list = new List<AttendanceStatu>();
            foreach (AttendanceStatusViewModel model in models) {list.Add(VMToM(model));}
            return list;
        }

        #endregion

        #region Filter
        public static List<AttendanceStatu> FilterByCompanyID(string id, List<AttendanceStatu> models) {
            return models.Where(a => a.CompanyID == id).ToList();
        }
        public static List<AttendanceStatu> FilterByDescription(string name, List<AttendanceStatu> models)
        {
            return models.Where(a => a.Description == name).ToList();
        }

        #endregion
    }
}