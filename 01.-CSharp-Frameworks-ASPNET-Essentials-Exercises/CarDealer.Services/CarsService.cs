namespace CarDealer.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using BindingModels;
    using Models;
    using ViewModels;
    using ViewModels.Cars;
    using ViewModels.Parts;

    public class CarsService : Service
    {
        public IEnumerable<CarViewModel> GetAllCars(string make)
        {
            if (make != null)
            {
                IEnumerable<CarViewModel> cars = this.DbContext.Cars
                    .Select(c => new CarViewModel()
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TravelledDistance = c.TravelledDistance
                    })
                    .Where(c => c.Make.ToLower() == make.ToLower())
                    .OrderBy(c => c.Model)
                    .ThenByDescending(c => c.TravelledDistance);

                return cars;
            }

            return this.DbContext.Cars.Select(c => new CarViewModel()
            {
                Make = c.Make,
                Model = c.Model,
                TravelledDistance = c.TravelledDistance
            });
        }

        public CarPartsViewModel GetCarWithParts(int id)
        {

            Car carEntity = this.DbContext.Cars.Find(id);
            CarPartsViewModel cpvm = new CarPartsViewModel()
            {
                Make = carEntity.Make,
                Model = carEntity.Model,
                TravelledDistance = carEntity.TravelledDistance,
                Parts = carEntity.Parts.Select(p => new PartViewModel()
                {
                    Name = p.Name,
                    Price = p.Price
                }).ToList()
            };

            return cpvm;
        }

        public void AddCar(AddCarBindingModel acbm)
        {
            Car carEntity = Mapper.Map<Car>(acbm);
            this.DbContext.Cars.Add(carEntity);
            this.DbContext.Logs.Add(new Log()
            {
                ModifiedTable = "Car",
                Operation = "Add",
                TimeLogged = DateTime.Now,
                Owner = this.GetCurrentlyLogged()
            });
            this.DbContext.SaveChanges();
        }

        public IEnumerable<AllPartViewModel> GetAllParts()
        {
            return this.DbContext.Parts.Select(p => new AllPartViewModel()
            {
                Id = p.Id,
                Name = p.Name
            });

        }
    }
}
