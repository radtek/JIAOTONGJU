using DYApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYApp.Domain.Model
{
    public class EvidenceDetail:AggregateRoot
    {
        public string Name { get; set; }
        public string Rule { get; set; }
        public int Quantity { get; set; }
        public string Place { get; set; }
        public virtual Evidence Evidence { get; set; }
    }
}
