using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DYApp.WebUI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SceneRecordTest()
        {
            return View();
        }
        public ActionResult EvidenceManage()
        {
            return View();
        }
    }
}