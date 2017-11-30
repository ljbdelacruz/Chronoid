using App.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApp2.Models.Utilities
{
    public static class DepartmentUtility
    {

        #region Model To ViewModel
        public static DepartmentViewModel MToVM(Department model) {
            return new DepartmentViewModel() {
                ID = model.ID,
                Name = model.Name,
                Company = CompanyUtility.MToVM(model.Company)
            };
        }
        public static List<DepartmentViewModel> MsToVMs(List<Department> models) {
            var list = new List<DepartmentViewModel>();
            foreach (Department model in models) {
                list.Add(MToVM(model));
            }
            return list;
        }
        #endregion

        #region View Model to Model
        public static Department VMToM(DepartmentViewModel model) {
            return new Department() {
                ID=model.ID,
                Name=model.Name,
                CompanyID=model.Company.ID
            };
        }
        public static List<Department> MsToVMs(List<DepartmentViewModel> models)
        {
            var list = new List<Department>();
            foreach (DepartmentViewModel model in models)
            {
                list.Add(VMToM(model));
            }
            return list;
        }

        #endregion

        #region Filter
        public static List<Department> FilterByCompanyID(string ID, List<Department> models) {
            return models.Where(d => d.CompanyID == ID).ToList();
        }
        #endregion



    }
}