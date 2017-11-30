using App.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApp2.Models.Utilities
{
    public static class ShiftUtility
    {
        #region ViewModel to Model
        public static Shift VMToM(ShiftViewModel model) {
            return new Shift() {
                ID=model.ID,
                Name=model.Name,
                TimeIn=TimeSpan.Parse(model.TimeIn),
                TimeOut=TimeSpan.Parse(model.TimeOut),
                TotalHoursWorked=model.TotalWorkedHours,
                CompanyID=model.Company.ID
            };
        }
        public static List<Shift> VMsToMs(List<ShiftViewModel> models) {
            var list = new List<Shift>();
            foreach (ShiftViewModel model in models) {
                list.Add(VMToM(model));
            }
            return list;
        }
        #endregion
        #region Model To ViewModel
        public static ShiftViewModel MToVM(Shift model) {
            return new ShiftViewModel() {
                ID=model.ID,
                Name=model.Name,
                TimeIn=model.TimeIn.ToString(),
                TimeOut=model.TimeOut.ToString(),
                TotalWorkedHours=model.TotalHoursWorked.Value,
            };
        }
        public static List<ShiftViewModel> MsToVMs(List<Shift> models) {
            var list = new List<ShiftViewModel>();
            foreach (Shift model in models) {
                list.Add(MToVM(model));
            }
            return list;
        }
        #endregion
        #region Filter
        public static List<Shift> FilterByCompanyID(string companyID, List<Shift> models) {
            return models.Where(s => s.CompanyID == companyID).ToList();
        }
        public static List<Shift> FilterByName(string name, List<Shift> models) {
            return models.Where(s => s.Name == name).ToList();
        }
        public static List<Shift> FilterByIsArchived(List<Shift> models, bool isArchived) {
            return models.Where(s => s.IsArchived == isArchived).ToList();
        }

        #endregion
    }
}