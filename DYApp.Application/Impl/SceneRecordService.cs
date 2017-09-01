using DYApp.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DYApp.DataObject;
using DYApp.Domain.Repository;
using DYApp.Domain.Model;
using DYApp.Application.AutoMap;

namespace DYApp.Application.Impl
{
    public class SceneRecordService : ISceneRecordService
    {
        private ISceneRecordRepository sceneRecordRepository;

        public SceneRecordService(ISceneRecordRepository sceneRecordRepository)
        {
            this.sceneRecordRepository = sceneRecordRepository;
        }

        public SceneRecordDataObject AddSceneRecord(SceneRecordDataObject sceneRecord)
        {
            SceneRecord entity = this.sceneRecordRepository.Create();
            entity = DyMapper.Map(sceneRecord, entity);
            entity.Involved = this.sceneRecordRepository.Context.DoFindByID<Involved>(sceneRecord.InvolvedID);
            this.sceneRecordRepository.Add(entity);
            this.sceneRecordRepository.Commit();
            return DyMapper.Map<SceneRecord, SceneRecordDataObject>(entity);
        }

        public IList<SceneRecordDataObject> GetList()
        {
            IList<SceneRecord> recordList = this.sceneRecordRepository.GetAll();
            return DyMapper.Map<IList<SceneRecord>, IList<SceneRecordDataObject>>(recordList);
            
        }

        public SceneRecordDataObject GetRecord(Guid id)
        {
            return DyMapper.Map<SceneRecord, SceneRecordDataObject>(this.sceneRecordRepository.FindByID(id)); 
        }

        public SceneRecordDataObject UpdateSceneRecord(SceneRecordDataObject sceneRecord)
        {
            SceneRecord entity = this.sceneRecordRepository.FindByID(sceneRecord.ID);
            entity = DyMapper.Map<SceneRecordDataObject, SceneRecord>(sceneRecord);
            this.sceneRecordRepository.Update(entity);
            this.sceneRecordRepository.Commit();
            return DyMapper.Map<SceneRecord, SceneRecordDataObject>(entity);
        }
    }
}
