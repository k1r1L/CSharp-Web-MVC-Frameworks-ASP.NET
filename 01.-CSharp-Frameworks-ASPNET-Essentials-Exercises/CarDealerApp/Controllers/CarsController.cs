namespace CarDealerApp.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using CarDealer.Data;
    using CarDealer.Models;
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
        [Route("all/{make?}")]
        public ActionResult All(string make)
        {
            IEnumerable<CarViewModel> vm = this.service.GetAllCars(make);

            return View(vm);
        }

        // GET: Car with parts by id (not optional)
        [Route("~/car/{id}/parts")]
        public ActionResult Details(int id)
        {
            CarPartsViewModel cpvm = this.service.GetCarWithParts(id);

            return View(cpvm);
        }
    }
}