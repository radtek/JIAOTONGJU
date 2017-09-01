using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYApp.Domain.Model
{
    public class UserInfo:AggregateRoot
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public virtual Guid RoleID { get; set; }
        public virtual Role Role { get; set; }
        public virtual WorkFlow WorkFlow { get; set; }
    }
}
