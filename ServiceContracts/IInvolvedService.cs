using DYApp.DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYApp.ServiceContracts
{
    public interface IInvolvedService
    {
        IList<InvolvedDataObject> GetList();
        InvolvedDataObject GetByID(Guid id);
        InvolvedDataObject Add(InvolvedDataObject involved);
        InvolvedDataObject Update(InvolvedDataObject involved);

    }
}
