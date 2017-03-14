namespace CarDealer.Services
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using AutoMapper;
    using BindingModels;
    using Models;
    using ViewModels;

    public class CustomersService : Service
    {
        public IEnumerable<CustomerViewModel> GetAllCustomers(string criteria)
        {
            switch (criteria)
            {
                case "ascending":
                    return DbContext.Customers
                        .OrderBy(c => c.BirthDate)
                        .ThenBy(c => !c.IsYoungDriver)
                        .Select(c => new CustomerViewModel()
                        {
                            BirthDate = c.BirthDate,
                            IsYoungDriver = c.IsYoungDriver,
                            Name = c.Name
                        });
                case "descending":
                    return DbContext.Customers
                        .OrderByDescending(c => c.BirthDate)
                        .ThenBy(c => !c.IsYoungDriver)
                        .Select(c => new CustomerViewModel()
                        {
                            BirthDate = c.BirthDate,
                            IsYoungDriver = c.IsYoungDriver,
                            Name = c.Name
                        });
                default:
                    return DbContext.Customers
                        .Select(c => new CustomerViewModel()
                        {
                            BirthDate = c.BirthDate,
                            IsYoungDriver = c.IsYoungDriver,
                            Name = c.Name
                        });
            }
        }

        public bool CheckIfCustomerExists(int id)
        {
            return this.DbContext.Customers.Any(c => c.Id == id);
        }

        public CustomerDetailsViewModel GetCustomerDetails(int id)
        {
            Customer customerEntity = this.DbContext.Customers.Find(id);
            if (customerEntity.IsYoungDriver)
            {
                CustomerDetailsViewModel csvm = new CustomerDetailsViewModel()
                {
                    Name = customerEntity.Name,
                    BoughtCarsCount = customerEntity.Sales.Count,
                    TotalSpentMoney = customerEntity.Sales
                        .Sum(sale => sale.Car.Parts.Sum(c => c.Price) - (sale.Discount + 0.05) * sale.Car.Parts.Sum(c => c.Price))
                };

                return csvm;
            }
            else
            {
                CustomerDetailsViewModel csvm = new CustomerDetailsViewModel()
                {
                    Name = customerEntity.Name,
                    BoughtCarsCount = customerEntity.Sales.Count,
                    TotalSpentMoney = customerEntity.Sales
                             .Sum(sale => sale.Car.Parts.Sum(c => c.Price) - sale.Discount * sale.Car.Parts.Sum(c => c.Price))
                };

                return csvm;
            }
        }

        public CustomerViewModel GetCustomerViewModelById(int id)
        {
            Customer customerEntity = this.DbContext.Customers.Find(id);

            return Mapper.Map<CustomerViewModel>(customerEntity);
        }

        public void AddCustomer(AddCustomerBindingModel bindingModel)
        {
            Customer customerEntity = Mapper.Map<Customer>(bindingModel);
            this.DbContext.Customers.Add(customerEntity);
            this.DbContext.SaveChanges();
        }

        public void EditCustomer(EditCustomerBindingModel bindingModel)
        {
            Customer customerEntity = this.DbContext.Customers.Find(bindingModel.Id);
            customerEntity.Name = bindingModel.Name;
            customerEntity.BirthDate = bindingModel.Birthdate;
            this.DbContext.Entry(customerEntity).State = EntityState.Modified;
            this.DbContext.SaveChanges();
        }
    }
}
