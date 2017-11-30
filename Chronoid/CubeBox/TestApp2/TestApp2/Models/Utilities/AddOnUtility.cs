using App.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApp2.Models.Utilities
{
    public static class AddOnUtility
    {
        #region Model to ViewModel
        public static AddOnViewModel MToVM(AddOn model) {
            return new AddOnViewModel() {
                ID=model.ID,
                Description=model.Description,
                Company=CompanyUtility.MToVM(model.Company)
            };
        }

        public static List<AddOnViewModel> MsToVMs(List<AddOn> models) {
            var list = new List<AddOnViewModel>();
            foreach (AddOn model in models) {
                list.Add(MToVM(model));
            }
            return list;
        }

        #endregion

        #region ViewModel to Model
        public static AddOn VMToM(AddOnViewModel model)
        {
            return new AddOn()
            {
                ID = model.ID,
                Description = model.Description,
                CompanyID = model.Company.ID
            };
        }

        public static List<AddOn> VMsToMs(List<AddOnViewModel> models)
        {
            var list = new List<AddOn>();
            foreach (AddOnViewModel model in models)
            {
                list.Add(VMToM(model));
            }
            return list;
        }
        #endregion


        #region Filter
        public static List<AddOn> FilterByCompanyID(string id, List<AddOn> models) {
            return models.Where(a => a.CompanyID == id).ToList();
        }

        #endregion

    }
}