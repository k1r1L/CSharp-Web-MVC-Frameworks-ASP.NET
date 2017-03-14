namespace CarDealerApp.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using CarDealer.Services;
    using CarDealer.ViewModels;

    [RoutePrefix("suppliers")]
    public class SuppliersController : Controller
    {
        private SuppliersService service;

        public SuppliersController()
        {
            this.service = new SuppliersService();
            ViewBag.IsLogged = this.service.IsLogged();
        }

        // GET: Suppliers by type (optional)
        [Route("{type:regex(importers|local)?}")]
        public ActionResult All(string type)
        {
            IEnumerable<SupplierViewModel> svm = this.service.GetAllSuppliers(type);
            return View(svm);
        }
    }
}