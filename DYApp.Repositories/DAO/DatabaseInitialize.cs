using DYApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYApp.Repositories.DAO
{
    public class DatabaseInitialize: CreateDatabaseIfNotExists<DYContext>
    {
        protected override void Seed(DYContext context)
        {
            List<Function> funcList = new List<Function>
            {
                new Function() {Name="系统设置",Url="SystemService" }
            };
            funcList.ForEach((item) =>
            {
                context.Function.Add(item);
            }
            );
            context.SaveChanges();
            List<Role> roleList = new List<Role>
            {
                new Role() { Name="管理员",FunctionList=funcList }
            };
            roleList.ForEach((item)=>
            {
                context.Role.Add(item);
            });
            context.SaveChanges();
            List<UserInfo> userList = new List<UserInfo>
            {
                new UserInfo() { UserName="admin",Password="admin",Role=roleList[0] }
            };
            userList.ForEach((item) =>
            {
                context.UserInfo.Add(item);
            });
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
