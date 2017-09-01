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
    public class WorkFlowServiceController : ApiController
    {
        private IWorkFlowService workFlowService;

        public WorkFlowServiceController()
        {
            this.workFlowService = ServiceLocator.Instance.GetRef<IWorkFlowService>();
        }
        [HttpGet]
        public JsonResult<IList<WorkFlowDataObject>> GetList()
        {
            IList<WorkFlowDataObject> list = this.workFlowService.GetList();
            return Json(list);
        }
        [HttpGet]
        public JsonResult<WorkFlowDataObject> GetWorkFlow(Guid ID)
        {
            return Json(this.workFlowService.GetWorkFlow(ID));
        }
    }
}
