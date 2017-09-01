using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYApp.Domain.Model
{
    public class Role:AggregateRoot
    {
        public string Name { get; set; }
        public virtual IList<UserInfo> UserList { get; set; }
        public virtual IList<Function> FunctionList { get; set; }

    }
}
