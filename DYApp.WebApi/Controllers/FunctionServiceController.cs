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
    public class FunctionServiceController : ApiController
    {
        private IFunctionService functionService;

        public FunctionServiceController()
        {
            this.functionService = ServiceLocator.Instance.GetRef<IFunctionService>();
        }

        [HttpPost]
        public JsonResult<IList<FunctionDataObject>> GetFunctionList()
        {
            return Json(this.functionService.GetFunctionList());
        }
    }
}
