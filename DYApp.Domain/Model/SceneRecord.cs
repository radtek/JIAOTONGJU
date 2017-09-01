using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYApp.Domain.Model
{
    public class SceneRecord:AggregateRoot
    {
        public string Place { get; set; }
        public DateTime Time { get; set; }
        public string Enforcers1 { get; set; }
        public string Certificates1 { get; set; }
        public string Enforcers2 { get; set; }
        public string Certificates2 { get; set; }
        public string Recorder { get; set; }
        public virtual Involved Involved { get; set; }
        public string CarNo { get; set; }
        public string CarModel { get; set; }
        public string Content { get; set; }
        public DateTime InvolvedSignTime { get; set; }
        public string Memo { get; set; }
        public byte[] EnforcerSign1 { get; set; }
        public byte[] EnforcerSign2 { get; set; }
        public DateTime EnforcerSignTime { get; set; }
    }
}
