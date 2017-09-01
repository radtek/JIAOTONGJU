using DYApp.DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts
{
    public interface IUserInfoService
    {
        IList<UserInfoDataObject> GetList();
        bool Exists(string userName);
        UserInfoDataObject CheckUser(string userName, string password);
        UserInfoDataObject AddUser(UserInfoDataObject user);
        bool RemoveUserByID(Guid id);
        bool ChangePassword(UserInfoDataObject user);
        bool UpdateUser(UserInfoDataObject user);

    }
}
