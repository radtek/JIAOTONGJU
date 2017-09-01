using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYApp.Domain.Model
{
    public class Evidence:AggregateRoot
    {
        public virtual Filing Filing { get; set; }
        public DateTime HandlingTime { get; set; }
        public string HandlingPlace { get; set; }
        public string InvolvedSign { get; set; }
        public DateTime InvolvedSignTime { get; set; }
        public string Sign1 { get; set; }
        public string Sign2 { get; set; }
        public string Code1 { get; set; }
        public string Code2 { get; set; }
        public DateTime Time { get; set; }
        public virtual IList<EvidenceDetail> EvidenceDetail { get; set; }
         
    }
}
