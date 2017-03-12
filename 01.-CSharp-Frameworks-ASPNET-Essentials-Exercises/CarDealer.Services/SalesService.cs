using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Services
{
    using ViewModels;

    public class SalesService : Service
    {
        public IEnumerable<SaleViewModel> GetAllDiscountedSalesByPercent(int? percent)
        {
            IEnumerable<SaleViewModel> discountedSalesByPercent = this.DbContext.Sales
               .Where(sale => sale.Customer.IsYoungDriver
                 ? (int)(100 * (sale.Discount + 0.05)) == percent
                 : (int)(100 * sale.Discount) == percent)
               .Select(sale => new SaleViewModel()
               {
                   Customer = new CustomerViewModel()
                   {
                       Name = sale.Customer.Name,
                       BirthDate = sale.Customer.BirthDate,
                       IsYoungDriver = sale.Customer.IsYoungDriver
                   },
                   Car = new CarViewModel()
                   {
                       Make = sale.Car.Make,
                       Model = sale.Car.Model,
                       TravelledDistance = sale.Car.TravelledDistance
                   },
                   PriceWithoutDiscount = sale.Car.Parts.Sum(p => p.Price),
                   PriceWithDiscount = sale.Customer.IsYoungDriver
                       ? sale.Car.Parts.Sum(p => p.Price) - (sale.Discount + 0.05) * sale.Car.Parts.Sum(p => p.Price)
                       : sale.Car.Parts.Sum(p => p.Price) - sale.Discount * sale.Car.Parts.Sum(p => p.Price),
                   DiscountPercentage = sale.Customer.IsYoungDriver
                        ? (int)((sale.Discount + 0.05) * 100)
                       : (int)(sale.Discount * 100)
               });

            return discountedSalesByPercent;
        }

        public IEnumerable<SaleViewModel> GetAllDiscountedSales()
        {
            IEnumerable<SaleViewModel> discountedSales = this.DbContext.Sales
               .Where(sale => sale.Customer.IsYoungDriver || sale.Discount > 0)
               .Select(sale => new SaleViewModel()
               {
                   Customer = new CustomerViewModel()
                   {
                       Name = sale.Customer.Name,
                       BirthDate = sale.Customer.BirthDate,
                       IsYoungDriver = sale.Customer.IsYoungDriver
                   },
                   Car = new CarViewModel()
                   {
                       Make = sale.Car.Make,
                       Model = sale.Car.Model,
                       TravelledDistance = sale.Car.TravelledDistance
                   },
                   PriceWithoutDiscount = sale.Car.Parts.Sum(p => p.Price),
                   PriceWithDiscount = sale.Customer.IsYoungDriver
                       ? sale.Car.Parts.Sum(p => p.Price) - (sale.Discount + 0.05) * sale.Car.Parts.Sum(p => p.Price)
                       : sale.Car.Parts.Sum(p => p.Price) - sale.Discount * sale.Car.Parts.Sum(p => p.Price),
                   DiscountPercentage = sale.Customer.IsYoungDriver
                       ? (int)((sale.Discount + 0.05) * 100)
                       : (int)(sale.Discount * 100)
               });

            return discountedSales;
        }

        public IEnumerable<SaleViewModel> GetSaleById(int? id)
        {
            IEnumerable<SaleViewModel> saleById = this.DbContext.Sales
               .Where(s => s.Id == id)
               .Select(sale => new SaleViewModel()
               {
                   Customer = new CustomerViewModel()
                   {
                       Name = sale.Customer.Name,
                       BirthDate = sale.Customer.BirthDate,
                       IsYoungDriver = sale.Customer.IsYoungDriver
                   },
                   Car = new CarViewModel()
                   {
                       Make = sale.Car.Make,
                       Model = sale.Car.Model,
                       TravelledDistance = sale.Car.TravelledDistance
                   },
                   PriceWithoutDiscount = sale.Car.Parts.Sum(p => p.Price),
                   PriceWithDiscount = sale.Customer.IsYoungDriver
                       ? sale.Car.Parts.Sum(p => p.Price) - (sale.Discount + 0.05) * sale.Car.Parts.Sum(p => p.Price)
                       : sale.Car.Parts.Sum(p => p.Price) - sale.Discount * sale.Car.Parts.Sum(p => p.Price),
                   DiscountPercentage = sale.Customer.IsYoungDriver
                       ? (int)((sale.Discount + 0.05) * 100)
                       : (int)(sale.Discount * 100)
               });

            return saleById;
        }

        public IEnumerable<SaleViewModel> GetAllSales()
        {
            return this.DbContext.Sales
                .Select(sale => new SaleViewModel()
                {
                    Customer = new CustomerViewModel()
                    {
                        Name = sale.Customer.Name,
                        BirthDate = sale.Customer.BirthDate,
                        IsYoungDriver = sale.Customer.IsYoungDriver
                    },
                    Car = new CarViewModel()
                    {
                        Make = sale.Car.Make,
                        Model = sale.Car.Model,
                        TravelledDistance = sale.Car.TravelledDistance
                    },
                    PriceWithoutDiscount = sale.Car.Parts.Sum(p => p.Price),
                    PriceWithDiscount = sale.Customer.IsYoungDriver
                        ? sale.Car.Parts.Sum(p => p.Price) - (sale.Discount + 0.05) * sale.Car.Parts.Sum(p => p.Price)
                        : sale.Car.Parts.Sum(p => p.Price) - sale.Discount * sale.Car.Parts.Sum(p => p.Price),
                    DiscountPercentage = sale.Customer.IsYoungDriver
                       ? (int)((sale.Discount + 0.05) * 100)
                       : (int)(sale.Discount * 100)
                });
        }
    }
}
