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
    public class SceneRecordServiceController : ApiController
    {
        private ISceneRecordService sceneRecordService;

        public SceneRecordServiceController()
        {
            this.sceneRecordService = ServiceLocator.Instance.GetRef<ISceneRecordService>();
        }
        [HttpPost]
        public JsonResult<IList<SceneRecordDataObject>> GetList()
        {
            return Json(this.sceneRecordService.GetList());
        }
        [HttpPost]
        public JsonResult<SceneRecordDataObject> GetSceneRecord(DataObjectBase obj)
        {
            return Json(this.sceneRecordService.GetRecord(obj.ID));
        }
        [HttpPost]
        public JsonResult<SceneRecordDataObject> AddSceneRecord(SceneRecordDataObject sceneRecord)
        {
            return Json(this.sceneRecordService.AddSceneRecord(sceneRecord));
        }
        [HttpPost]
        public JsonResult<SceneRecordDataObject> UpdateSceneRecord(SceneRecordDataObject sceneRecord)
        {
            return Json(this.sceneRecordService.UpdateSceneRecord(sceneRecord));
        }
    }
}
