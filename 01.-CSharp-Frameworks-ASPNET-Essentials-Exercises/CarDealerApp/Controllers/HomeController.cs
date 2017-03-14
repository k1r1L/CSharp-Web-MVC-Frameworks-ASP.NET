namespace CarDealerApp.Controllers
{
    using System.Web.Mvc;

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
