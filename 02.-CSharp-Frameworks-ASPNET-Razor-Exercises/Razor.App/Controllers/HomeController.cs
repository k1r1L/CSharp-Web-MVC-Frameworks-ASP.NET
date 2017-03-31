using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Razor.App.Controllers
{
    using Models;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.People = new Person[]
            {
                new Person() {Name = "John Doe", Age = 40, Email = "john@office.com", IsSubscribed = true},
                new Person() {Name = "John Doe Jr.", Email = "johnjr@office.com"},
                new Person() {Name = "Mickey Mouse", Age = 20, IsSubscribed = false},
            };

            return View();
        }
    }
}