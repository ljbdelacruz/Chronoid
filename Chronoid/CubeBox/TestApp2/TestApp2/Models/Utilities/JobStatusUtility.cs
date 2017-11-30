using App.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApp2.Models.Utilities
{
    public static class JobStatusUtility
    {
        #region model to ViewModel
        public static JobStatusViewModel MToVM(JobStatu model) {
            return new JobStatusViewModel() {
                ID=model.ID,
                Description=model.Description
            };
        }
        public static List<JobStatusViewModel> MsToVMs(List<JobStatu> models) {
            var list = new List<JobStatusViewModel>();
            foreach (JobStatu model in models) {
                list.Add(MToVM(model));
            }
            return list;
        }

        #endregion


    }
}