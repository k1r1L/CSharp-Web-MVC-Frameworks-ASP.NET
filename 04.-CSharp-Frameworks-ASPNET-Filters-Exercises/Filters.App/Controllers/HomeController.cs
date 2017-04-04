namespace Filters.App.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Models;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            throw new Exception("Test exception message");
        }

        [HandleError(ExceptionType = typeof(ArgumentOutOfRangeException), View = "RangeError")]
        [HandleError(ExceptionType = typeof(InvalidOperationException), View = "InvalidOperationError")]
        public ActionResult Details(int id)
        {
            Car[] cars = new Car[]
            {
                new Car { Id=  1, Make = "Opel", Model = "Vectra", TravelledDistance = 3223423},
                new Car { Id=  2, Make = "Dacia", Model = "Logan", TravelledDistance = 12323},
                new Car { Id=  3, Make = "Mercedes", Model = "Benz", TravelledDistance = 123},
                new Car { Id=  4, Make = "Porshe", Model = "Carrera", TravelledDistance = 567756757},
            };

            Car car = cars.SingleOrDefault(c => c.Id == id);
            if (car == null)
            {
                throw  new ArgumentOutOfRangeException(nameof(id), id, "There is no such element with provided ID!");
            }

            if (car.TravelledDistance > 1000000)
            {
                throw new InvalidOperationException("The car is too old to be displayed");
            }

            ViewData["car"] = car;

            return this.View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}