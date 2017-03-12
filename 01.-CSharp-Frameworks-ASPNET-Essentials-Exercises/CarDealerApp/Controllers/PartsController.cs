namespace CarDealerApp.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using CarDealer.BindingModels;
    using CarDealer.Services;
    using CarDealer.ViewModels;

    public class PartsController : Controller
    {
        private PartsService service;

        public PartsController()
        {
            this.service = new PartsService();
        }
      
        // GET: Add a part
        [Route("part/add"), HttpGet]
        public ActionResult Add()
        {
            IEnumerable<SupplierViewModel> allSuppliers = this.service.GetAllSuppliers();

            return View(allSuppliers);
        }

        //POST: 
        [Route("part/add"), HttpPost]
        public ActionResult Add([Bind(Include = "Name,Price,Quantity,Supplier")] AddPartBindingModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                this.service.AddPart(bindingModel);
                return Redirect("/home/index");
            }

            return RedirectToAction("Add");
        }

        // GET: All parts
        [Route("parts/all"), HttpGet]
        public ActionResult All()
        {
            IEnumerable<AllPartViewModel> allParts = this.service.GetAllParts();

            return View(allParts);
        }

        // GET: Part delete (by id)
        [Route("part/delete/{id}"), HttpGet]
        public ActionResult Delete(int id)
        {
            AllPartViewModel partVm = this.service.GetPartById(id);

            return View(partVm);
        }

        // POST:
        [Route("part/delete/{id}"), HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            this.service.DeletePart(id);
            return RedirectToAction("All");
        }
    }
}