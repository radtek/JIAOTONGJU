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
    public class CaseHandlingService : ICaseHandlingService
    {
        private ICaseHandlingRepository caseHandlingRepository;

        public CaseHandlingService(ICaseHandlingRepository caseHandlingRepository)
        {
            this.caseHandlingRepository = caseHandlingRepository;
        }
        public CaseHandlingDataObject AddCaseHandling(CaseHandlingDataObject caseHandling)
        {
            CaseHandling entity = this.caseHandlingRepository.Create();
            entity = DyMapper.Map(caseHandling, entity);
            this.caseHandlingRepository.Add(entity);
            this.caseHandlingRepository.Commit();
            return DyMapper.Map<CaseHandling, CaseHandlingDataObject>(entity);
        }

        public CaseHandlingDataObject GetCaseHandling(Guid id)
        {
            return DyMapper.Map<CaseHandling, CaseHandlingDataObject>(this.caseHandlingRepository.FindByID(id));
        }

        public IList<CaseHandlingDataObject> GetList()
        {
            return DyMapper.Map<IList<CaseHandling>, IList<CaseHandlingDataObject>>(this.caseHandlingRepository.GetAll());
        }

        public CaseHandlingDataObject NextStep(CaseHandlingDataObject caseHandling)
        {
            CaseHandling entity = this.caseHandlingRepository.FindByID(caseHandling.ID);
            entity.WorkFlow = entity.WorkFlow.Next;
            this.caseHandlingRepository.Update(entity);
            this.caseHandlingRepository.Commit();
            return DyMapper.Map<CaseHandling, CaseHandlingDataObject>(entity);
        }

        public CaseHandlingDataObject PreviousStep(CaseHandlingDataObject caseHandling)
        {
            CaseHandling entity = this.caseHandlingRepository.FindByID(caseHandling.ID);
            if (entity.WorkFlow == null)
                return null;
            entity.WorkFlow = entity.WorkFlow.Previous;
            this.caseHandlingRepository.Update(entity);
            this.caseHandlingRepository.Commit();
            return DyMapper.Map<CaseHandling, CaseHandlingDataObject>(entity);
        }

        public CaseHandlingDataObject UpdateCaseHandling(CaseHandlingDataObject caseHandling)
        {
            CaseHandling entity = this.caseHandlingRepository.FindByID(caseHandling.ID);
            entity = DyMapper.Map(caseHandling, entity);
            this.caseHandlingRepository.Add(entity);
            this.caseHandlingRepository.Commit();
            return DyMapper.Map<CaseHandling, CaseHandlingDataObject>(entity);
        }
    }
}
