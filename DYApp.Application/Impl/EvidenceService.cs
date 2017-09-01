using DYApp.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DYApp.DataObject;
using DYApp.Domain.Model;
using DYApp.Domain.Repository;
using DYApp.Application.AutoMap;

namespace DYApp.Application.Impl
{
    public class EvidenceService : IEvidenceService
    {
        private IEvidenceRepository evidenceRepository;

        public EvidenceService(IEvidenceRepository evidenceRepository)
        {
            this.evidenceRepository = evidenceRepository;
        }

        public EvidenceDataObject AddDetail(EvidenceDetailDataObject detail)
        {
            Evidence evidence = this.evidenceRepository.FindByID(detail.EvidenceID);
            EvidenceDetail entity = this.evidenceRepository.Context.DoCreate<EvidenceDetail>();
            entity = DyMapper.Map(detail, entity);
            evidence.EvidenceDetail.Add(entity);
            this.evidenceRepository.Update(evidence);
            this.evidenceRepository.Commit();
            return DyMapper.Map<Evidence, EvidenceDataObject>(evidence);
        }

        public EvidenceDataObject AddEvidence(EvidenceDataObject evidence)
        {
            Evidence entity = this.evidenceRepository.Create();
            entity = DyMapper.Map(evidence, entity);
            entity.Filing = this.evidenceRepository.Context.DoGet<Filing>(p => p.ID == evidence.FilingID).FirstOrDefault();
            this.evidenceRepository.Add(entity);
            this.evidenceRepository.Commit();
            return DyMapper.Map<Evidence, EvidenceDataObject>(entity);
        }

        public IList<EvidenceDetailDataObject> GetDetailList(Guid evidenceID)
        {
            Evidence evidence = this.evidenceRepository.FindByID(evidenceID);
            return DyMapper.Map<IList<EvidenceDetail>, IList<EvidenceDetailDataObject>>(evidence.EvidenceDetail);
        }

        public EvidenceDataObject GetEvidence(Guid id)
        {
            return DyMapper.Map<Evidence, EvidenceDataObject>(this.evidenceRepository.FindByID(id));
        }

        public IList<EvidenceDataObject> GetList()
        {
            return DyMapper.Map<IList<Evidence>, IList<EvidenceDataObject>>(this.evidenceRepository.GetAll());
        }

        public EvidenceDataObject RemoveDetail(EvidenceDetailDataObject detail)
        {
            Evidence evidence = this.evidenceRepository.FindByID(detail.EvidenceID);
            EvidenceDetail entity = evidence.EvidenceDetail.Where(p => p.ID == detail.ID).FirstOrDefault();
            evidence.EvidenceDetail.Remove(entity);
            this.evidenceRepository.Update(evidence);
            return DyMapper.Map<Evidence, EvidenceDataObject>(evidence);
        }

        public bool RemoveEvidence(Guid id)
        {
            Evidence evidence = this.evidenceRepository.FindByID(id);
            this.evidenceRepository.Remove(evidence);
            return this.evidenceRepository.Commit() > 0;
        }

        public EvidenceDataObject UpdateEvidence(EvidenceDataObject evidence)
        {
            Evidence entity = this.evidenceRepository.FindByID(evidence.ID);
            entity = DyMapper.Map(evidence, entity);
            entity.EvidenceDetail.Clear();
            List<EvidenceDetail> detailList = this.evidenceRepository.Context.DoGet<EvidenceDetail>(p => evidence.EvidenceDetailIDList.Contains(p.ID)).ToList();
            detailList.ForEach((item) =>
            {
                entity.EvidenceDetail.Add(item);
            });
            this.evidenceRepository.Update(entity);
            this.evidenceRepository.Commit();
            return DyMapper.Map<Evidence, EvidenceDataObject>(entity);
        }
    }
}
