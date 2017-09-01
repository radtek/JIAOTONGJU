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
    public class FunctionService : IFunctionService
    {
        private IFunctionRepository functionRepository;

        public FunctionService(IFunctionRepository functionRepository)
        {
            this.functionRepository = functionRepository;
        }
        public IList<FunctionDataObject> GetFunctionList()
        {
            return DyMapper.Map<IList<Function>, IList<FunctionDataObject>>(this.functionRepository.GetAll());
        }
    }
}
