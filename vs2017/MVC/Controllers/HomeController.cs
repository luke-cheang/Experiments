using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MVC.Modules;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            Common.WriteLog(Session.SessionID, "HomeController", "Index");
            return View();
        }   // Index();

    }   // HomeController
}   // MVC.Controllers