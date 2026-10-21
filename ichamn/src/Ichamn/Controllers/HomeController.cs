using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ichamn.Helpers;
using Ichamn.Models;

namespace Ichamn.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "iChamn!";
            ViewBag.SessionId = Guid.NewGuid();
            ViewBag.Username = "REPLACE_WITH_YOUR_VALUE" + MyRandom.GenerateRandomString(4);
            return View();
        }

        public JsonResult Up()
        {
            var lh = new LoggerHelper();
            lh.LogInfo("Executed Server WAKE UP!!!");
           return new JsonResult();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
