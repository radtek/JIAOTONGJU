using DYApp.Domain.Model;
using DYApp.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DYApp.Domain;

namespace DYApp.Repositories.Repository
{
    public class WorkFlowRepository : RepositoryBase<WorkFlow>, IWorkFlowRepository
    {
        public WorkFlowRepository(IRepositoryContext context) : base(context)
        {
        }
    }
}
