using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UnobtrusiveTest.Models.Employee;

namespace UnobtrusiveTest.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index2()
        {
            return View();
        }

        [HttpPost]
        public PartialViewResult _PartialName(Employee employee)
        {
            //...
            //db.BookMasters.Add(one);
            //db.SaveChanges();



            return PartialView("_PartialAddress");
        }

        [HttpPost]
        public PartialViewResult _PartialAddress(Employee employee)
        {
            //...
            //db.Publisher.Add(two);
            //db.SaveChanges();
            return PartialView("_PartialAdditional");
        }

        [HttpPost]
        public ActionResult _PartialAdditional(Employee employee)
        {
            //...
            //db.Students.Add(Three);
            //db.SaveChanges();
            return RedirectToAction("Index", "Home");   //done
        }
    }
}