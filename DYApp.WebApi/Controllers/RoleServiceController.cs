using DYApp.DataObject;
using DYApp.Infrastructure;
using DYApp.ServiceContracts;
using DYApp.WebApi.Msg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace DYApp.WebApi.Controllers
{
    public class RoleServiceController : ApiController
    {
        private IRoleService roleService;

        public RoleServiceController()
        {
            this.roleService = ServiceLocator.Instance.GetRef<IRoleService>();
        }

        [HttpPost]
        public JsonResult<IList<RoleDataObject>> GetRoleList()
        {
            IList<RoleDataObject> roleList = this.roleService.GetRoleList();
            return Json(roleList);
        }
    }
}
