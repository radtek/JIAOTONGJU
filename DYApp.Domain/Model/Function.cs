using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYApp.Domain.Model
{
    public class Function:AggregateRoot
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public IList<Role> RoleList { get; set; }
    }
}
