using DYApp.DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYApp.ServiceContracts
{
    public interface IRoleService
    {
        IList<RoleDataObject> GetRoleList();
        RoleDataObject AddRole(RoleDataObject role);
        RoleDataObject GetRoleByID(Guid id);
        bool RemoveRoleById(Guid id);
        bool UpdateRole(RoleDataObject role);
        bool AddUserRange(Guid roleID,Guid[] userIDList);
        bool AddUser(Guid roleID, Guid userID);
        bool AddFunctionRange(Guid roleID, Guid[] functionIDList);
        bool AddFunction(Guid roleID, Guid functionID);
    }
}
