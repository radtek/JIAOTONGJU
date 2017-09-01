using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYApp.Domain.Model
{
    public class WorkFlow:AggregateRoot
    {
        public string Name { get; set; }
        public int Step { get; set; }
        public virtual IList<UserInfo> UserInfoList { get; set; }
        public virtual WorkFlow Previous { get; set; }
        public virtual WorkFlow Next { get; set; }
    }
}
