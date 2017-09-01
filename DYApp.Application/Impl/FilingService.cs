using DYApp.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DYApp.DataObject;
using DYApp.Domain.Repository;
using DYApp.Application.AutoMap;
using DYApp.Domain.Model;

namespace DYApp.Application.Impl
{
    public class FilingService : IFilingService
    {
        private IFilingRepository filingRepository;

        public FilingService(IFilingRepository filingRepository)
        {
            this.filingRepository = filingRepository;
        }

        public bool AddFiling(FilingDataObject filing)
        {
            Filing entity = this.filingRepository.Create();
            entity = DyMapper.Map(filing, entity);
            entity.Involved = this.filingRepository.Context.DoGet<Involved>(p => p.ID == filing.InvolvedID).FirstOrDefault();
            entity.SceneRecord = this.filingRepository.Context.DoGet<SceneRecord>(p => p.ID == filing.SceneRecordID).FirstOrDefault();
            entity.AskRecord = this.filingRepository.Context.DoGet<AskRecord>(p => p.ID == filing.AskRecordID).FirstOrDefault();

            this.filingRepository.Add(entity);
            return this.filingRepository.Commit() > 0;
        }

        public FilingDataObject GetFiling(Guid id)
        {
            return DyMapper.Map<Filing, FilingDataObject>(this.filingRepository.FindByID(id));
        }

        public IList<FilingDataObject> GetList()
        {
            return DyMapper.Map<IList<Filing>, IList<FilingDataObject>>(this.filingRepository.GetAll());
        }

        public FilingDataObject UpdateFiling(FilingDataObject filing)
        {
            Filing entity = this.filingRepository.FindByID(filing.ID);
            entity = DyMapper.Map(filing, entity);
            entity.Involved = this.filingRepository.Context.DoGet<Involved>(p => p.ID == filing.InvolvedID).FirstOrDefault();
            entity.SceneRecord = this.filingRepository.Context.DoGet<SceneRecord>(p => p.ID == filing.SceneRecordID).FirstOrDefault();
            entity.AskRecord = this.filingRepository.Context.DoGet<AskRecord>(p => p.ID == filing.AskRecordID).FirstOrDefault();
            this.filingRepository.Update(entity);
            this.filingRepository.Commit();
            return DyMapper.Map<Filing, FilingDataObject>(entity);
        }
    }
}
