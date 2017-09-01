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
    public class AskRecordServiceController : ApiController
    {
        private IAskRecordService askRecordService;

        public AskRecordServiceController()
        {
            this.askRecordService = ServiceLocator.Instance.GetRef<IAskRecordService>();
        }
        [HttpPost]
        public JsonResult<IList<AskRecordDataObject>> GetAskRecordList()
        {
            return Json(this.askRecordService.GetList());
        }
        [HttpPost]
        public JsonResult<AskRecordDataObject> GetAskRecord(DataObjectBase obj)
        {
            return Json(this.askRecordService.GetAskRecord(obj.ID));
        }
        [HttpPost]
        public JsonResult<AskRecordDataObject> AddAskRecord(AskRecordDataObject askRecord)
        {
            return Json(this.askRecordService.AddAskRecord(askRecord));
        }
        public JsonResult<DyMessage> UpdateAskRecord(AskRecordDataObject askRecord)
        {
            if (this.askRecordService.UpdateAskRecord(askRecord))
                return Json(new DyMessage() { Code = 2, Message = "更新成功!" });
            else
                return Json(new DyMessage() { Code = 0, Message = "更新失败!" });
        }
    }
}
