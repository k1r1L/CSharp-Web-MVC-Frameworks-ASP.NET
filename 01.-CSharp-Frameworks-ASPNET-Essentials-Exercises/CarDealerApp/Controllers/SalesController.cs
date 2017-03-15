namespace CarDealerApp.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using CarDealer.BindingModels;
    using CarDealer.Services;
    using CarDealer.ViewModels;

    [RoutePrefix("sales")]
    public class SalesController : Controller
    {
        private SalesService service;

        public SalesController()
        {
            this.service = new SalesService();
            ViewBag.IsLogged = this.service.IsLogged();
        }

        // GET: All sales or individual sale (optional)
        [Route("all/{id?}")]
        [HttpGet]
        public ActionResult All(int? id)
        {
            if (id != null)
            {
                IEnumerable<SaleViewModel> saleByIdVm = this.service.GetSaleById(id);
                return View(saleByIdVm);
            }

            IEnumerable<SaleViewModel> allSalesVm = this.service.GetAllSales();

            return View(allSalesVm);
        }

        // GET: All discounted sales or discounted sales by percentage (optional)
        [Route("discounted/{percent?}")]
        [HttpGet]
        public ActionResult Discounted(int? percent)
        {
            if (percent != null)
            {
                IEnumerable<SaleViewModel> discountedSalesByPercent = this.service.GetAllDiscountedSalesByPercent(percent);
                return View(discountedSalesByPercent);
            }

            IEnumerable<SaleViewModel> discountedSales = this.service.GetAllDiscountedSales();
            return View(discountedSales);
        }

        [Route("add")]
        [HttpGet]
        public ActionResult Add()
        {
            if (!this.service.IsLogged())
            {
                return Redirect("/account/login");
            }

            AddSaleViewModel saleViewModel = this.service.GetAddSaleViewModel();
            return View(saleViewModel);
        }

        [Route("review")]
        [HttpGet]
        public ActionResult Review([Bind(Include = "CustomerId,CarId,Discount")] AddSaleBindingModel bindingModel)
        {
            if (!this.service.IsLogged())
            {
                return Redirect("/account/login");
            }

            ReviewSaleViewModel reviewVm = this.service.GetReviewSaleViewModel(bindingModel);
            return this.View(reviewVm);
        }

        [Route("review")]
        [HttpPost]
        public ActionResult FinalizeSale([Bind(Include = "CarId,CustomerId,Discount")] AddSaleBindingModel asbm)
        {
            if (!this.service.IsLogged())
            {
                return Redirect("/account/login");
            }

            this.service.FinalizeSale(asbm);
            return RedirectToAction("All");
        }
    }
}