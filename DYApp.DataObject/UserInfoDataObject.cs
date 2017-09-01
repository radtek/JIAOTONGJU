using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYApp.DataObject
{
    public class UserInfoDataObject:DataObjectBase
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Guid RoleID { get; set; }
        public string RoleName { get; set; }
        public Guid WorkFlowID { get; set; }
        public IList<FunctionDataObject> RoleFunctionList { get; set; }
    }
}
