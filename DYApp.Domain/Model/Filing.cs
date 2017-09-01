using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYApp.Domain.Model
{
    public class Filing:AggregateRoot
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
        public virtual Involved Involved { get; set; }
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
        public virtual SceneRecord SceneRecord { get; set; }
        public virtual AskRecord AskRecord { get; set; }
        public virtual Evidence Evidence { get; set; }
    }
}
