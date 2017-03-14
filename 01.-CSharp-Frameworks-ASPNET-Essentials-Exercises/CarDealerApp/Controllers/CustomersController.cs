namespace CarDealerApp.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using CarDealer.BindingModels;
    using CarDealer.Services;
    using CarDealer.ViewModels;

    [RoutePrefix("customers")]
    public class CustomersController : Controller
    {
        private CustomersService service;

        public CustomersController()
        {
            this.service = new CustomersService();
        }

        // GET: All Customers
        [Route("all/{criteria:regex(ascending|descending)?}")]
        public ActionResult All(string criteria)
        {
            IEnumerable<CustomerViewModel> allCustomersVm = this.service.GetAllCustomers(criteria);

            return View(allCustomersVm);
        }

        // GET: Customer and details about all sales
        [Route("~/customer/{id}")]
        public ActionResult Details(int id)
        {
            if (!this.service.CheckIfCustomerExists(id))
            {
               return RedirectToAction("All");
            }

            CustomerDetailsViewModel cdvm = this.service.GetCustomerDetails(id);
            return View(cdvm);
        }

        // GET: Add customer page
        [Route("add"), HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        // POST: 
        [Route("add"), HttpPost]
        public ActionResult Add([Bind(Include = "Name,Birthdate")] AddCustomerBindingModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                this.service.AddCustomer(bindingModel);
            }

            return RedirectToAction("All", new {criteria = "descending"});
        }

        // GET: Edit customer page
        [Route("edit/{id}"), HttpGet]
        public ActionResult Edit(int id)
        {
            CustomerViewModel cvm = this.service.GetCustomerViewModelById(id);

            return View(cvm);
        }

        // POST: 
        [Route("edit/{id}"), HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Name,Birthdate")] EditCustomerBindingModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                this.service.EditCustomer(bindingModel);
            }

            return RedirectToAction("Details", new { id = bindingModel.Id });
        }
    }
}
