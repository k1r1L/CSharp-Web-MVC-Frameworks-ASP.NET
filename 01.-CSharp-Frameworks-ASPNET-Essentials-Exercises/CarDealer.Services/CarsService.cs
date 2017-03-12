namespace CarDealer.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Models;
    using ViewModels;

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
    }
}
