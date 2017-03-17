namespace CarDealerApp.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using CarDealer.Services;
    using CarDealer.ViewModels.Logs;
    using PagedList;

    [RoutePrefix("logs")]
    public class LogsController : Controller
    {
        private LogsService service;
        private const int pageSize = 3;

        public LogsController()
        {
            this.service = new LogsService();
            ViewBag.IsLogged = this.service.IsLogged();
        }

        // GET: All Logs for given user (optional)
        [Route("all")]
        [HttpGet]
        public ActionResult All(int? page, string user, string currentFilter)
        {
            ViewBag.CurrentSort = user;

            if (page == null)
            {
                page = 1;
            }
            else
            {
                user = currentFilter;
            }

            ViewBag.CurrentFilter = user;
            int pageNumber = page ?? 1;
            IEnumerable<LogViewModel> logVm = this.service.GetAllLogs(user);

            return View(logVm.ToPagedList(pageNumber, pageSize));
        }

        [Route("delete")]
        [HttpGet]
        public ActionResult Delete()
        {
            if (!this.service.IsLogged())
            {
                return Redirect("/account/login");
            }


            return this.View();
        }

        [Route("delete")]
        [HttpPost]
        public ActionResult DeleteConfirmed()
        {
            if (!this.service.IsLogged())
            {
                return Redirect("/account/login");
            }

            this.service.DeleteAllLogs();
            return RedirectToAction("All");
        }
    }
}