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
    public class InvolvedServiceController : ApiController
    {
        private IInvolvedService involvedService;

        public InvolvedServiceController()
        {
            this.involvedService = ServiceLocator.Instance.GetRef<IInvolvedService>();
        }
        [HttpPost]
        public JsonResult<InvolvedDataObject> AddInvolved(InvolvedDataObject involved)
        {
            return Json(this.involvedService.Add(involved));
        }
        [HttpPost]
        public JsonResult<InvolvedDataObject> GetInvolved(DataObjectBase involved)
        {
            return Json(this.involvedService.GetByID(involved.ID));
        }
    }
}
