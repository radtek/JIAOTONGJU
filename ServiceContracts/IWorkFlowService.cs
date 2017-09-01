using DYApp.DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYApp.ServiceContracts
{
    public interface IWorkFlowService
    {
        IList<WorkFlowDataObject> GetList();
        WorkFlowDataObject GetWorkFlow(Guid id);
        WorkFlowDataObject AddWorkFlow(WorkFlowDataObject workFlow);
        WorkFlowDataObject UpdateWorkFlow(WorkFlowDataObject workFlow);
        bool RemoveWorkFlow(Guid id);
    }
}
