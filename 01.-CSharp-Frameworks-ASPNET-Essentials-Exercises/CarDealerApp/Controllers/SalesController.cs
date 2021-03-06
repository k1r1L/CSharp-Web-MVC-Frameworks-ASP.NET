﻿namespace CarDealerApp.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using CarDealer.BindingModels;
    using CarDealer.Services;
    using CarDealer.ViewModels;
    using CarDealer.ViewModels.Sales;

    [RoutePrefix("sales")]
    public class SalesController : Controller
    {
        private SalesService service;

        public SalesController()
        {
            this.service = new SalesService();
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
            AddSaleViewModel saleViewModel = this.service.GetAddSaleViewModel();
            return View(saleViewModel);
        }

        [Route("review")]
        [HttpGet]
        public ActionResult Review([Bind(Include = "CustomerId,CarId,Discount")] AddSaleBindingModel bindingModel)
        {
            ReviewSaleViewModel reviewVm = this.service.GetReviewSaleViewModel(bindingModel);
            return this.View(reviewVm);
        }

        [Route("review")]
        [HttpPost]
        public ActionResult FinalizeSale([Bind(Include = "CarId,CustomerId,Discount")] AddSaleBindingModel asbm)
        {

            this.service.FinalizeSale(asbm);
            return RedirectToAction("All");
        }
    }
}