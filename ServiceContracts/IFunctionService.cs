using DYApp.DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYApp.ServiceContracts
{
    public interface IFunctionService
    {
        IList<FunctionDataObject> GetFunctionList();        
    }
}
