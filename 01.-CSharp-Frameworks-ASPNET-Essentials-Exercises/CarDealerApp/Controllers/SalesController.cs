namespace CarDealerApp.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using CarDealer.Data;
    using CarDealer.Services;
    using CarDealer.ViewModels;

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

        
    }
}