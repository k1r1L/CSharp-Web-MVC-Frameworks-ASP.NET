using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealerApp.Controllers
{
    [RoutePrefix("home")]
    public class HomeController : Controller
    {
        // GET: Home
        [Route("index")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
