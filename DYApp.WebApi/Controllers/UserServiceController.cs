using DYApp.DataObject;
using DYApp.Infrastructure;
using DYApp.WebApi.Msg;
using ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace DYApp.WebApi.Controllers
{
    public class UserServiceController : ApiController
    {
        private IUserInfoService userInfoService;

        public UserServiceController()
        {
            this.userInfoService = ServiceLocator.Instance.GetRef<IUserInfoService>();
        }


        [HttpPost]
        public JsonResult<IList<UserInfoDataObject>> GetUserInfo()
        {
            IList<UserInfoDataObject> userList = this.userInfoService.GetList();
            return Json(userList);
        }
        [HttpPost]
        public JsonResult<UserInfoMessage> Login(UserInfoDataObject user)
        {
            if(!this.userInfoService.Exists(user.UserName))
            {
                return Json(new UserInfoMessage() { Code = 0, Message = "用户名不存在!" });
            }
            UserInfoDataObject userInfo = this.userInfoService.CheckUser(user.UserName, user.Password);
            if (userInfo == null)
            {
                return Json(new UserInfoMessage() { Code = 1, Message = "用户名密码不匹配!" });
            }
            else
                return Json(new UserInfoMessage() { Code = 2, Data = userInfo });
        }

        [HttpPost]
        public JsonResult<UserInfoMessage> AddUser(UserInfoDataObject user)
        {
            user = this.userInfoService.AddUser(user);
            if(user!=null)
            {
                return Json(new UserInfoMessage() { Code=2,Message="添加用户成功!",Data=user });
            }
            return Json(new UserInfoMessage() { Code = 0, Message = "添加用户失败!" });
        }
        [HttpPost]
        public JsonResult<DyMessage> RemoveUser(UserInfoDataObject user)
        {
            if (this.userInfoService.RemoveUserByID(user.ID))
            {
                return Json(new DyMessage() { Code = 2, Message = "删除用户成功!" });
            }
            else
                return Json(new DyMessage() { Code = 0, Message = "删除用户失败!" });
        }
        [HttpPost]
        public JsonResult<DyMessage> ChangePassword(UserInfoDataObject user)
        {
            if (this.userInfoService.ChangePassword(user))
            {
                return Json(new DyMessage() { Code = 2, Message = "密码修改成功!" });
            }
            else
            {
                return Json(new DyMessage() { Code=0,Message="修改失败!" });
            }
        }
        [HttpPost]
        public JsonResult<DyMessage> UpdateUser(UserInfoDataObject user)
        {
            if (this.userInfoService.UpdateUser(user))
            {
                return Json(new DyMessage() { Code = 2, Message = "修改成功!" });
            }
            else
            {
                return Json(new DyMessage() { Code = 0, Message = "修改失败!" });
            }

        }
    }
}
