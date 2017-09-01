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
    public class WorkFlowService : IWorkFlowService
    {
        private IWorkFlowRepository workFlowRepository;
        private int x=0;
        public WorkFlowService(IWorkFlowRepository workFlowRepository)
        {
            this.workFlowRepository = workFlowRepository;
        }
        public WorkFlowDataObject AddWorkFlow(WorkFlowDataObject workFlow)
        {
            WorkFlow entity = this.workFlowRepository.Create();
            entity = DyMapper.Map(workFlow, entity);
            entity.Previous = this.workFlowRepository.FindByID(workFlow.PreviousID);
            entity.Next = this.workFlowRepository.FindByID(workFlow.NextID);
            this.workFlowRepository.Add(entity);
            this.workFlowRepository.Commit();
            return DyMapper.Map<WorkFlow, WorkFlowDataObject>(entity);
        }

        public IList<WorkFlowDataObject> GetList()
        {
            IList<WorkFlow> list = this.workFlowRepository.GetAll().OrderBy(p => p.Step).ToList();
            return DyMapper.Map<IList<WorkFlow>, IList<WorkFlowDataObject>>(list);
        }

        public WorkFlowDataObject GetWorkFlow(Guid id)
        {
            return DyMapper.Map<WorkFlow, WorkFlowDataObject>(this.workFlowRepository.FindByID(id));
        }

        public bool RemoveWorkFlow(Guid id)
        {
            WorkFlow workFlow = this.workFlowRepository.FindByID(id);
            WorkFlow previous = workFlow.Previous;
            WorkFlow next = workFlow.Next;
            if (previous != null&&next!=null)
                next.Previous = previous;
            this.workFlowRepository.Update(next);
            this.workFlowRepository.Remove(workFlow);
            return this.workFlowRepository.Commit() > 0;                   
        }

        public WorkFlowDataObject UpdateWorkFlow(WorkFlowDataObject workFlow)
        {
            WorkFlow entity = this.workFlowRepository.FindByID(workFlow.ID);
            entity = DyMapper.Map(workFlow, entity);
            entity.Previous = this.workFlowRepository.FindByID(workFlow.PreviousID);
            entity.Next = this.workFlowRepository.FindByID(workFlow.NextID);
            this.workFlowRepository.Add(entity);
            this.workFlowRepository.Commit();
            return DyMapper.Map<WorkFlow, WorkFlowDataObject>(entity);
        }
    }
}
