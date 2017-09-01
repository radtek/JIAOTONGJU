using DYApp.DataObject;
using DYApp.Infrastructure;
using DYApp.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace DYApp.WebApi.Controllers
{
    public class CaseHandlingController : ApiController
    {
        private ICaseHandlingService caseHandlingService;

        public CaseHandlingController()
        {
            this.caseHandlingService = ServiceLocator.Instance.GetRef<ICaseHandlingService>();
        }
        [HttpPost]
        public JsonResult<IList<CaseHandlingDataObject>> GetList()
        {
            return Json(this.caseHandlingService.GetList());
        }
        [HttpPost]
        public JsonResult<CaseHandlingDataObject> GetCaseHandling(DataObjectBase obj)
        {
            return Json(this.caseHandlingService.GetCaseHandling(obj.ID));
        }
        [HttpPost]
        public JsonResult<CaseHandlingDataObject> UpdateCaseHandling(CaseHandlingDataObject caseHandling)
        {
            return Json(this.caseHandlingService.UpdateCaseHandling(caseHandling));
        }
        [HttpPost]
        public JsonResult<CaseHandlingDataObject> NextStep(CaseHandlingDataObject caseHandling)
        {
            return Json(this.caseHandlingService.NextStep(caseHandling));
        }
        [HttpPost]
        public JsonResult<CaseHandlingDataObject> PreviousStep(CaseHandlingDataObject caseHandling)
        {
            return Json(this.caseHandlingService.PreviousStep(caseHandling));
        }
    }
}
