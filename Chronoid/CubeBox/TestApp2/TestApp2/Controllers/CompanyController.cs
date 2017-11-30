using App.Data.Models;
using GeneralClass.Generator.String;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TestApp2.Models.Utilities;

namespace TestApp2.Controllers
{
    public class CompanyController : ApplicationController
    {
        private readonly IUserService _userService;
        private readonly ICompanyService _companyService;
        public CompanyController(IUserService userService, ICompanyService companyService):base(userService) {
            _userService = userService;
            _companyService = companyService;
        }
        #region HTTPOST
        [HttpPost]
        public async Task<JsonResult> Insert(Company data) {
            try {
                data.id = CharacterGenerator.NewGUID();
                var result=_companyService.Insert(data);
                return Json(new { success = result });
            } catch { return Json(new { success = false }); }
        }
        [HttpPost]
        public async Task<JsonResult> Update(Company data) {
            try {
                var result = _companyService.Update(data);
                return Json(new { success = result });
            } catch { return Json(new { success = false }); }
        }
        #endregion
        #region HTTP GET
        [HttpGet]
        public async Task<JsonResult> GetAll()
        {
            //add security module so the user have to login before accessing data from 
            try
            {
                var list = _companyService.GetAll().Result.ToList();
                return Json(new { success = true, data = CompanyUtility.MsToVMs(list) }, JsonRequestBehavior.AllowGet);
            }
            catch { return Json(new { success = false }, JsonRequestBehavior.AllowGet); }
        }


        #endregion


    }
}