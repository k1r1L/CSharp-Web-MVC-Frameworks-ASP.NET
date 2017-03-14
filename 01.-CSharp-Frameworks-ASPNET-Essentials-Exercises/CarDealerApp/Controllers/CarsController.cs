namespace CarDealerApp.Controllers
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using CarDealer.BindingModels;
    using CarDealer.Services;
    using CarDealer.ViewModels;

    [RoutePrefix("cars")]
    public class CarsController : Controller
    {
        private readonly CarsService service;

        public CarsController()
        {
            this.service = new CarsService();
        }

        // GET: Cars
        [Route("")] // sets default action
        [Route("all/{make?}"), HttpGet]
        public ActionResult All(string make)
        {
            IEnumerable<CarViewModel> vm = this.service.GetAllCars(make);

            return View(vm);
        }

        // GET: Car with parts by id (not optional)
        [Route("~/car/{id}/parts"), HttpGet]
        public ActionResult Details(int id)
        {
            CarPartsViewModel cpvm = this.service.GetCarWithParts(id);

            return View(cpvm);
        }

        // GET: Add car
        [Route("~/car/create"), HttpGet]
        public ActionResult Add()
        {
            IEnumerable<AllPartViewModel> allParts = this.service.GetAllParts();
            return View(allParts);
        }

        // POST:
        [Route("~/car/create"), HttpPost]
        public ActionResult Add([Bind(Include = "Model,Make,TravelledDistance,Parts")] AddCarBindingModel acbm)
        {
            if (ModelState.IsValid)
            {
                this.service.AddCar(acbm);
                return RedirectToAction("All");
            }

            return View();
        }
    }
}