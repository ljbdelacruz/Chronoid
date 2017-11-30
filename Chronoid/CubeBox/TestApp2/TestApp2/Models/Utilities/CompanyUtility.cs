using App.Data.Models;
using GeneralClass.DateControl;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApp2.Models.Utilities
{
    public static class CompanyUtility
    {
        public static Company GetByCompanyID(string id, List<Company> list) {
            try {
                return list.Where(c => c.id == id).FirstOrDefault();
            } catch { return null; }
        }

        #region View Model
        public static CompanyViewModel MToVM(Company model)
        {
            var temp = new CompanyViewModel()
            {
                ID = model.id,
                Name = model.name,
                createdAt = model.CreatedAt.HasValue ? TimeFormatter.DateToString(model.CreatedAt.Value) : "N/A",
            };
            return temp;
        }
        public static List<CompanyViewModel> MsToVMs(List<Company> models) {
            var list = new List<CompanyViewModel>();
            foreach (Company model in models) {
                list.Add(MToVM(model));
            }
            return list;
        }

        #endregion


    }
}