using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYApp.DataObject
{
    public class EvidenceDataObject:DataObjectBase
    {
        public string HandlingPlace { get; set; }
        public string InvolvedSign { get; set; }
        public string Sign1 { get; set; }
        public string Sign2 { get; set; }
        public string Code1 { get; set; }
        public string Code2 { get; set; }
        public Guid FilingID { get; set; }
        public FilingDataObject Filing { get; set; }
        public DateTime HandlingTime { get; set; }
        public DateTime InvolvedSignTime { get; set; }
        public DateTime Time { get; set; }
        public virtual IList<EvidenceDetailDataObject> EvidenceDetail { get; set; }
        public Guid[] EvidenceDetailIDList { get; set; }
    }
}
