using DYApp.DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYApp.ServiceContracts
{
    public interface IEvidenceService
    {
        IList<EvidenceDataObject> GetList();
        EvidenceDataObject GetEvidence(Guid id);
        EvidenceDataObject AddEvidence(EvidenceDataObject evidence);
        EvidenceDataObject UpdateEvidence(EvidenceDataObject evidence);
        bool RemoveEvidence(Guid id);
        EvidenceDataObject AddDetail(EvidenceDetailDataObject detail);
        EvidenceDataObject RemoveDetail(EvidenceDetailDataObject detail);
        IList<EvidenceDetailDataObject> GetDetailList(Guid evidenceID);
    }
}
