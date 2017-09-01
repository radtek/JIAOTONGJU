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
    public class EvidenceServiceController : ApiController
    {
        private IEvidenceService evidenceService;

        public EvidenceServiceController()
        {
            this.evidenceService = ServiceLocator.Instance.GetRef<IEvidenceService>();
        }
        [HttpPost]
        public JsonResult<IList<EvidenceDataObject>> GetList()
        {
            return Json(this.evidenceService.GetList());
        }
        [HttpPost]
        public JsonResult<EvidenceDataObject> AddEvidence(EvidenceDataObject evidence)
        {
            return Json(this.evidenceService.AddEvidence(evidence));
        }
        [HttpPost]
        public JsonResult<EvidenceDataObject> AddDetail(EvidenceDetailDataObject detail)
        {
            return Json(this.evidenceService.AddDetail(detail));
        }
        [HttpPost]
        public JsonResult<IList<EvidenceDetailDataObject>> GetDetailList(EvidenceDetailDataObject detail)
        {
            return Json(this.evidenceService.GetDetailList(detail.EvidenceID));
        }
    }
}
