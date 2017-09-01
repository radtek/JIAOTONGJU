using DYApp.DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYApp.ServiceContracts
{
    public interface ISceneRecordService
    {
        IList<SceneRecordDataObject> GetList();
        SceneRecordDataObject GetRecord(Guid id);
        SceneRecordDataObject AddSceneRecord(SceneRecordDataObject sceneRecord);
        SceneRecordDataObject UpdateSceneRecord(SceneRecordDataObject sceneRecord);
    }
}
