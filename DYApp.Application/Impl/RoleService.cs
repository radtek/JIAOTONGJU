using DYApp.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DYApp.DataObject;
using DYApp.Domain.Repository;
using DYApp.Domain.Model;
using DYApp.Application.AutoMap;

namespace DYApp.Application.Impl
{
    public class RoleService : IRoleService
    {
        private IRoleRepository roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        public bool AddFunction(Guid roleID, Guid functionID)
        {
            Role role = this.roleRepository.FindByID(roleID);
            if (role.FunctionList.Any(p => p.ID == functionID))
                return true;
            Function function = this.roleRepository.Context.DoFindByID<Function>(functionID);
            role.FunctionList.Add(function);
            return this.roleRepository.Commit() > 0;
        }

        public bool AddFunctionRange(Guid roleID, Guid[] functionIDList)
        {
            Role role = this.roleRepository.FindByID(roleID);
            Guid[] roleFunctionIDArray = role.FunctionList.Select(p => p.ID).ToArray();
            Guid[] addFunctionIDArray = roleFunctionIDArray.Except(functionIDList).ToArray();
            IList<Function> functionList = this.roleRepository.Context.DoGet<Function>(p => addFunctionIDArray.Contains(p.ID)).ToList();
            foreach (Function item in functionList)
            {
                role.FunctionList.Add(item);
            }
            return this.roleRepository.Commit() > 0;
        }

        public RoleDataObject AddRole(RoleDataObject role)
        {
            Role roleEntity = this.roleRepository.Create();
            roleEntity.Name = role.Name;
            this.roleRepository.Add(roleEntity);
            try
            {
                int result = this.roleRepository.Commit();
                return result > 0 ? DyMapper.Map<Role, RoleDataObject>(roleEntity) : null;
            }
            catch
            {
                return null;
            }
            
        }

        public bool AddUser(Guid roleID, Guid userID)
        {
            Role role = this.roleRepository.FindByID(roleID);
            if (role.UserList.Any(p => p.ID == userID))
                return true;
            UserInfo userInfo = this.roleRepository.Context.DoFindByID<UserInfo>(userID);
            role.UserList.Add(userInfo);
            return this.roleRepository.Commit() > 0;
        }

        public bool AddUserRange(Guid[] userIDList)
        {
            throw new NotImplementedException();
        }

        public bool AddUserRange(Guid roleID, Guid[] userIDList)
        {
            Role role = this.roleRepository.FindByID(roleID);
            Guid[] roleUserIDArray = role.UserList.Select(p => p.ID).ToArray();
            Guid[] addUserIDArray = roleUserIDArray.Except(userIDList).ToArray();
            List<UserInfo> userList = this.roleRepository.Context.DoGet<UserInfo>(p => addUserIDArray.Contains(p.ID)).ToList();
            userList.ForEach((item) =>
            {
                role.UserList.Add(item);
            });
            return this.roleRepository.Commit() > 0;
        }

        public RoleDataObject GetRoleByID(Guid id)
        {
            return DyMapper.Map<Role, RoleDataObject>(this.roleRepository.FindByID(id));
        }
        public IList<RoleDataObject> GetRoleList()
        {
            return DyMapper.Map<IList<Role>, IList<RoleDataObject>>(this.roleRepository.GetAll());
        }
        public bool RemoveRoleById(Guid id)
        {
            if (!this.roleRepository.Exists(p => p.ID == id))
                return false;
            Role role = this.roleRepository.FindByID(id);
            this.roleRepository.Remove(role);
            return this.roleRepository.Commit() > 0;
        }
        public bool UpdateRole(RoleDataObject role)
        {
            Role roleEntity = this.roleRepository.FindByID(role.ID);
            roleEntity.Name = role.Name;
            this.roleRepository.Update(roleEntity);
            return this.roleRepository.Commit() > 0;           
        }
    }
}
