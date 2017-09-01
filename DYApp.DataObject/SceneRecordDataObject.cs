using DYApp.Infrastructure.CommonEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYApp.DataObject
{
    public class SceneRecordDataObject:DataObjectBase
    {
        public string Place { get; set; }
        public DateTime Time { get; set; }
        public string Enforcers1 { get; set; }
        public string Certificates1 { get; set; }
        public string Enforcers2 { get; set; }
        public string Certificates2 { get; set; }
        public string Recorder { get; set; }

        public Guid InvolvedID { get; set; }
        public string InvolvedName { get; set; }
        public Sex InvolvedSex { get; set; }
        public string InvolvedIDCode { get; set; }
        public string InvolvedRelation { get; set; }
        public string InvolvedDepartment { get; set; }
        public string InvolvedTelNo { get; set; }
        public string InvolvedAddress { get; set; }

        public string Content { get; set; }
        public DateTime InvolvedSignTime { get; set; }
        public string Memo { get; set; }
        public byte[] EnforcerSign1 { get; set; }
        public byte[] EnforcerSign2 { get; set; }
        public DateTime EnforcerSignTime { get; set; }
    }
}
