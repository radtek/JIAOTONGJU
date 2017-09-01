using DYApp.DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYApp.ServiceContracts
{
    public interface IFilingService
    {
        IList<FilingDataObject> GetList();
        FilingDataObject GetFiling(Guid id);
        bool AddFiling(FilingDataObject filing);
        FilingDataObject UpdateFiling(FilingDataObject filing);
    }
}
