namespace CarDealerApp.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using CarDealer.BindingModels;
    using CarDealer.Models;
    using CarDealer.Services;
    using CarDealer.ViewModels.Suppliers;

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
            IEnumerable<SupplierViewModel> svm = this.service.GetAllSuppliersByType(type);
            return View(svm);
        }

        [Route("new")]
        [HttpGet]
        public ActionResult New()
        {
            IEnumerable<NewSupplierViewModel> allSuppliers = this.service.GetNewSuppliersVm();

            return this.View(allSuppliers);
        }

        // GET Add supplier
        [Route("add")]
        [HttpPost]
        public ActionResult Add([Bind(Include = "Name,IsImporter")] Supplier supplier)
        {
            if (!this.service.IsLogged())
            {
                return Redirect("/account/login");
            }

            if (ModelState.IsValid)
            {
                this.service.AddSupplier(supplier);
            }

            return RedirectToAction("New");
        }

        // GET Edit supplier
        [Route("edit/{id}")]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (!this.service.IsLogged())
            {
                return Redirect("/account/login");
            }

            EditSupplierViewModel vm = this.service.GetEditSupplierViewModel(id);
            return this.View(vm);
        }

        // POST
        [Route("edit/{id}")]
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Name")] EditSupplierBindingModel esbm)
        {
            if (!this.service.IsLogged())
            {
                return Redirect("/account/login");
            }

            if (ModelState.IsValid)
            {
                this.service.EditSupplier(esbm);
            }

            return RedirectToAction("New");
        }

        // GET Delete supplier
        [Route("delete/{id}")]
        [HttpGet]
        public ActionResult Delete(int id)
        {

            if (!this.service.IsLogged())
            {
                return Redirect("/account/login");
            }

            DeleteSupplierViewModel vm = this.service.GetDeleteSupplierViewModel(id);

            return this.View(vm);
        }

        // POST
        [Route("delete/{id}")]
        [HttpPost]
        public ActionResult DeleteConfirmed([Bind(Include = "Id")] int id)
        {

            if (!this.service.IsLogged())
            {
                return Redirect("/account/login");
            }

            this.service.DeleteSupplier(id);
            return RedirectToAction("New");
        }
    }
}