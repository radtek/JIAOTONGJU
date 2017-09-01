using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYApp.DataObject
{
    public class EvidenceDetailDataObject:DataObjectBase
    {
        public string Name { get; set; }
        public string Rule { get; set; }
        public int Quantity { get; set; }
        public string Place { get; set; }
        public virtual Guid EvidenceID { get; set; }
    }
}
