using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace WebClassic.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Thread.Sleep(5_000);
            return View();
        }

        public ActionResult About()
        {
            Thread.Sleep(5_000);
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            Thread.Sleep(5_000);
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}