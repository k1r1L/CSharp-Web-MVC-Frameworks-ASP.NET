namespace CarDealerApp.Controllers
{
    using System.Web.Mvc;
    using CarDealer.Services;

    [RoutePrefix("home")]
    public class HomeController : Controller
    {
        private HomeService service;

        public HomeController()
        {
            this.service = new HomeService();
            ViewBag.IsLogged = this.service.IsLogged();
        }

        // GET: Home
        [Route("index")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
