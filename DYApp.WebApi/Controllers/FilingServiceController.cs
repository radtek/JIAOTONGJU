using DYApp.DataObject;
using DYApp.Infrastructure;
using DYApp.ServiceContracts;
using DYApp.WebApi.Msg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace DYApp.WebApi.Controllers
{
    public class FilingServiceController : ApiController
    {
        private IFilingService filingService;

        public FilingServiceController()
        {
            this.filingService = ServiceLocator.Instance.GetRef<IFilingService>();
        }
        [HttpPost]
        public JsonResult<IList<FilingDataObject>> GetList()
        {
            return Json(this.filingService.GetList());
        }
        [HttpPost]
        public JsonResult<FilingDataObject> GetFiling(DataObjectBase obj)
        {
            return Json(this.filingService.GetFiling(obj.ID));
        }
        [HttpPost]
        public JsonResult<DyMessage> Add(FilingDataObject filing)
        {
            if (this.filingService.AddFiling(filing))
                return Json(new DyMessage() { Code = 2, Message = "立案成功!" });
            else
                return Json(new DyMessage() { Code = 0, Message = "立案失败!" });
        }
        [HttpPost]
        public JsonResult<FilingDataObject> UpdateFiling(FilingDataObject filing)
        {
            return Json(this.filingService.UpdateFiling(filing));
        }
    }
}
