namespace CarDealerApp.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using CarDealer.BindingModels;
    using CarDealer.Services;
    using CarDealer.ViewModels;
    using CarDealer.ViewModels.Parts;
    using CarDealer.ViewModels.Suppliers;

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
            AllPartViewModel partVm = this.service.GetAllPartById(id);

            return View(partVm);
        }

        // POST:
        [Route("part/delete/{id}"), HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            this.service.DeletePart(id);
            return RedirectToAction("All");
        }

        [Route("part/edit/{id}"), HttpGet]
        public ActionResult Edit(int id)
        {
            EditPartViewModel vm = this.service.GetEditPartById(id);

            return View(vm);
        }

        [Route("part/edit/{id}"), HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Price,Quantity")] EditPartBindingModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                this.service.EditPart(bindingModel);
                return RedirectToAction("All");
            }

            return RedirectToAction("Edit", new { id = bindingModel.Id });
        }
    }
}