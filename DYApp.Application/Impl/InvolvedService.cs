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
    public class InvolvedService : IInvolvedService
    {
        private IInvolvedRepository involvedRepository;

        public InvolvedService(IInvolvedRepository involvedRepository)
        {
            this.involvedRepository = involvedRepository;
        }
        public InvolvedDataObject Add(InvolvedDataObject involved)
        {
            Involved entity = this.involvedRepository.Create();
            entity = DyMapper.Map(involved, entity);
            this.involvedRepository.Add(entity);
            int result = this.involvedRepository.Commit();
            if (result > 0)
                return DyMapper.Map<Involved, InvolvedDataObject>(entity);
            else
                return null;

        }

        public InvolvedDataObject GetByID(Guid id)
        {
            return DyMapper.Map<Involved, InvolvedDataObject>(this.involvedRepository.FindByID(id));
        }

        public IList<InvolvedDataObject> GetList()
        {
            return DyMapper.Map<IList<Involved>, IList<InvolvedDataObject>>(this.involvedRepository.GetAll());
        }

        public InvolvedDataObject Update(InvolvedDataObject involved)
        {
            Involved entity = this.involvedRepository.FindByID(involved.ID);
            entity = DyMapper.Map(involved, entity);
            this.involvedRepository.Update(entity);
            int result = this.involvedRepository.Commit();
            if (result > 0)
                return DyMapper.Map<Involved, InvolvedDataObject>(entity);
            else
                return null;
        }
    }
}
