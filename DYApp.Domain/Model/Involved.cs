using DYApp.Infrastructure.CommonEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYApp.Domain.Model
{
    public class Involved:AggregateRoot
    {
        public string Name { get; set; }
        public Sex Sex { get; set; }
        public string IDCode { get; set; }
        public string Relation { get; set; }
        public string Department { get; set; }
        public string TelNo { get; set; }      
        public string Address { get; set; }
        public virtual IList<SceneRecord> SceneRecordList { get; set; }
    }
}
