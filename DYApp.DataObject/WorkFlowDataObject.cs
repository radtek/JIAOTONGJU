using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYApp.DataObject
{
    public class WorkFlowDataObject:DataObjectBase
    {
        public string Name { get; set; }
        public int Step { get; set; }
        public virtual IList<UserInfoDataObject> UserInfoList { get; set; }
        public virtual Guid[] UserInfoIDList { get; set; }
        public  Guid PreviousID { get; set; }
        public Guid NextID { get; set; }
    }
}
