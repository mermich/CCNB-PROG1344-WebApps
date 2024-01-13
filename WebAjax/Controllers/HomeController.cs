using System.Collections.Generic;
using System.Threading;
using System.Web.Mvc;
using WebAjax.Models;

namespace WebAjax.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Thread.Sleep(1_000);
            return View();
        }


        public ActionResult Employees()
        {
            Thread.Sleep(1_000);
            var employees = new List<Employee>
            {
                new Employee { Id = 1, Name = "John", Age = 31 },
                new Employee { Id = 2, Name = "Mary", Age = 27 },
                new Employee { Id = 3, Name = "Bob", Age = 41 },
                new Employee { Id = 4, Name = "Sue", Age = 24 },
                new Employee { Id = 5, Name = "Greg", Age = 35 },
                new Employee { Id = 6, Name = "Jerry", Age = 39 }
            };

            return PartialView(employees);
        }

        public ActionResult About()
        {
            Thread.Sleep(1_000);
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            Thread.Sleep(1_000);
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}