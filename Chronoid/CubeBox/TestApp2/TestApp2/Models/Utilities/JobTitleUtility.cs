using App.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApp2.Models.Utilities
{
    public static class JobTitleUtility
    {
        #region Model to ViewModel
        //jobtitle
        public static JobtitleViewModel MToVM(JobTitle model)
        {
            var temp = new JobtitleViewModel()
            {
                ID =  model.ID,
                Description = model.Description,
                Department=new DepartmentViewModel() { ID=model.DepartmentID}
            };
            return temp;
        }
        public static List<JobtitleViewModel> MsToVMs(List<JobTitle> models) {
            var tempList = new List<JobtitleViewModel>();
            foreach (JobTitle model in models) {
                tempList.Add(MToVM(model));
            }
            return tempList;
        }
        #endregion
        #region ViewModel To Model
        public static JobTitle VMToM(JobtitleViewModel model) {
            return new JobTitle() {
                ID=model.ID,
                Description=model.Description,
                CompanyID=model.Company.ID,
                DepartmentID=model.Department.ID
            };
        }
        public static List<JobTitle> VMsToMs(List<JobtitleViewModel> models) {
            var list = new List<JobTitle>();
            foreach (JobtitleViewModel model in models) {
                list.Add(VMToM(model));
            }
            return list;
        }
        #endregion
        #region sorting
        public static List<JobTitle> SortByID(List<JobTitle> list) {
            return list.OrderBy(jb => jb.ID).ToList();
        }

        public static List<JobTitle> SortReverse(List<JobTitle> list, bool isReverse) {
            if (isReverse) {
                return list.OrderByDescending(jb => jb.ID == jb.ID).ToList();
            }
            return list.OrderBy(jb => jb.ID == jb.ID).ToList();
        }
        #endregion
        #region filter
        public static JobTitle FilterByID(string id, List<JobTitle> list) {
            return list.Where(jt => jt.ID == id).FirstOrDefault();
        }
        public static List<JobTitle> FilterByCompanyID(List<JobTitle> list, string companyID) {
            return list.Where(jb => jb.CompanyID == companyID).ToList();
        }
        public static List<JobTitle> FilterByName(List<JobTitle> models, string name, bool isExact) {
            return isExact ? models.Where(j=>j.Description == name).ToList() : models.Where(j => j.Description.Contains(name)).ToList();
        }
        #endregion

    }
}