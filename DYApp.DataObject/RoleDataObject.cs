using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYApp.DataObject
{
    public class RoleDataObject:DataObjectBase
    {
        public string Name { get; set; }
        public IList<UserInfoDataObject> UserList { get; set; }
        public IList<FunctionDataObject> FunctionList { get; set; }
    }
}
