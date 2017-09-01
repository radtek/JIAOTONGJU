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
    public class AskRecordService : IAskRecordService
    {
        private IAskRecordRepository askRecordRepository;

        public AskRecordService(IAskRecordRepository askRecordRepository)
        {
            this.askRecordRepository = askRecordRepository;
        }
        public AskRecordDataObject AddAskRecord(AskRecordDataObject askRecord)
        {
            AskRecord entity = this.askRecordRepository.Create();
            entity = DyMapper.Map(askRecord, entity);
            entity.Involved = this.askRecordRepository.Context.DoFindByID<Involved>(askRecord.InvolvedID);
            this.askRecordRepository.Add(entity);
            this.askRecordRepository.Commit();
            return DyMapper.Map<AskRecord, AskRecordDataObject>(entity);
        }

        public AskRecordDataObject GetAskRecord(Guid id)
        {
            return DyMapper.Map<AskRecord, AskRecordDataObject>(this.askRecordRepository.FindByID(id));
        }

        public IList<AskRecordDataObject> GetList()
        {
            return DyMapper.Map<IList<AskRecord>, IList<AskRecordDataObject>>(this.askRecordRepository.GetAll());
        }

        public bool RemoveAskRecord(Guid id)
        {
            AskRecord askRecord = this.askRecordRepository.FindByID(id);
            this.askRecordRepository.Remove(askRecord);
            return this.askRecordRepository.Commit() > 0;
        }

        public bool UpdateAskRecord(AskRecordDataObject askRecord)
        {
            AskRecord entity = this.askRecordRepository.FindByID(askRecord.ID);
            entity = DyMapper.Map(askRecord, entity);
            this.askRecordRepository.Update(entity);
            return this.askRecordRepository.Commit() > 0;
        }
    }
}
