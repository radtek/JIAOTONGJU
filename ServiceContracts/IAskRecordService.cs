using DYApp.DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYApp.ServiceContracts
{
    public interface IAskRecordService
    {
        IList<AskRecordDataObject> GetList();
        AskRecordDataObject GetAskRecord(Guid id);
        AskRecordDataObject AddAskRecord(AskRecordDataObject askRecord);
        bool RemoveAskRecord(Guid id);
        bool UpdateAskRecord(AskRecordDataObject askRecord);
    }
}
