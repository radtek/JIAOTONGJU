using ServiceContracts;
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
    public class UserInfoService : IUserInfoService
    {
        private IUserInfoRepository userInfoRepository;

        public UserInfoService(IUserInfoRepository userInfoRepository)
        {
            this.userInfoRepository = userInfoRepository;
        }

        public UserInfoDataObject AddUser(UserInfoDataObject user)
        {
            UserInfo userInfo = this.userInfoRepository.Create();
            userInfo.UserName = user.UserName;
            userInfo.Password = user.Password;
            userInfo.RoleID = user.RoleID;
            this.userInfoRepository.Add(userInfo);
            int result = this.userInfoRepository.Commit();
            if (result > 0)
                return DyMapper.Map<UserInfo, UserInfoDataObject>(userInfo);
            return null;
        }

        public bool ChangePassword(UserInfoDataObject user)
        {
            UserInfo userInfo = this.userInfoRepository.FindByID(user.ID);
            userInfo.Password = user.Password;
            return this.userInfoRepository.Commit() > 0;
        }

        public UserInfoDataObject CheckUser(string userName, string password)
        {
            UserInfo userInfo = this.userInfoRepository.Get(p => p.UserName == userName && p.Password == password).FirstOrDefault();
            return DyMapper.Map<UserInfo, UserInfoDataObject>(userInfo);
        }

        public bool Exists(string userName)
        {
            return this.userInfoRepository.Exists(p => p.UserName == userName);
        }

        public IList<UserInfoDataObject> GetList()
        {
            IList<UserInfo> userList = this.userInfoRepository.GetAll();
            return DyMapper.Map<IList<UserInfo>, IList<UserInfoDataObject>>(userList);
        }

        public bool RemoveUserByID(Guid id)
        {
            UserInfo userInfo = this.userInfoRepository.FindByID(id);
            this.userInfoRepository.Remove(userInfo);
            return this.userInfoRepository.Commit() > 0;
        }

        public bool UpdateUser(UserInfoDataObject user)
        {
            UserInfo userInfo = this.userInfoRepository.FindByID(user.ID);
            userInfo = DyMapper.Map(user, userInfo);
            this.userInfoRepository.Update(userInfo);
            return this.userInfoRepository.Commit() > 0;
        }
    }
}
