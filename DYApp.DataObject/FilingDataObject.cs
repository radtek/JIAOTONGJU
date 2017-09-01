using DYApp.Infrastructure.CommonEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYApp.DataObject
{
    public class FilingDataObject:DataObjectBase
    {
        public string Code1 { get; set; }
        public string Code2 { get; set; }
        public string Code3 { get; set; }
        //来源
        public string Source { get; set; }
        //案由
        public string Reason { get; set; }
        //受案时间
        public DateTime AcceptTime { get; set; }
        //嫌疑人信息
        public Guid InvolvedID { get; set; }
        public string InvolvedName { get; set; }
        public Sex InvolvedSex { get; set; }
        public string InvolvedIDCode { get; set; }
        public string InvolvedRelation { get; set; }
        public string InvolvedDepartment { get; set; }
        public string InvolvedTelNo { get; set; }
        public string InvolvedAddress { get; set; }
        //基本情况
        public string PrimaryContent { get; set; }
        //立案依据
        public string Basis { get; set; }
        //受案机构意见
        public string AcceptContent { get; set; }
        public string AcceptSign { get; set; }
        public DateTime AcceptSignTime { get; set; }
        //负责人意见
        public string ManagerContent { get; set; }
        public string ManagerSign { get; set; }
        public DateTime ManageSignTime { get; set; }
        public string Memo { get; set; }
        public Guid SceneRecordID { get; set; }
        public Guid AskRecordID { get; set; }
    }
}
