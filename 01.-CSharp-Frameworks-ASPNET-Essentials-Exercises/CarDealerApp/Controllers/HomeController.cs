namespace CarDealerApp.Controllers
{
    using System;
    using System.CodeDom;
    using System.Web.Mvc;
    using CarDealer.Services;

    [RoutePrefix("home")]
    public class HomeController : Controller
    {
        private HomeService service;

        public HomeController()
        {
            this.service = new HomeService();
        }

        // GET: Home
        [Route("index")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Exception
        [HttpGet]
        [Route("exception")]
        public ActionResult Exception()
        {
            throw new ArgumentException("Error message!");
        }
    }
}
