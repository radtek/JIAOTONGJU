using DYApp.DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYApp.ServiceContracts
{
    public interface ICaseHandlingService
    {
        IList<CaseHandlingDataObject> GetList();
        CaseHandlingDataObject GetCaseHandling(Guid id);
        CaseHandlingDataObject AddCaseHandling(CaseHandlingDataObject caseHandling);
        CaseHandlingDataObject UpdateCaseHandling(CaseHandlingDataObject caseHandling);
        CaseHandlingDataObject NextStep(CaseHandlingDataObject caseHandling);
        CaseHandlingDataObject PreviousStep(CaseHandlingDataObject caseHandling);
    }
}
