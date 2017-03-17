namespace CarDealer.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using BindingModels;
    using Data;
    using Models;
    using ViewModels;
    using ViewModels.Customers;
    using ViewModels.Logs;
    using ViewModels.Parts;
    using ViewModels.Sales;
    using ViewModels.Suppliers;

    public abstract class Service
    {
        protected Service()
             : this(new CarDealerContext())
        {

        }

        protected Service(CarDealerContext dbContext)
        {
            ConfigureAutomapping();
            this.DbContext = dbContext;
        }

        protected CarDealerContext DbContext { get; set; }

        protected void ConfigureAutomapping()
        {
            Mapper.Initialize(action =>
            {
                action.CreateMap<AddCustomerBindingModel, Customer>()
                    .ForMember(customer => customer.IsYoungDriver,
                        config => config.MapFrom(bm => bm.Birthdate.Year > 1998));
                action.CreateMap<Customer, CustomerViewModel>();
                action.CreateMap<Part, AllPartViewModel>();
                action.CreateMap<Part, EditPartViewModel>();
                action.CreateMap<AddCarBindingModel, Car>()
                    .ForMember(c => c.Parts, config => config.MapFrom(bm =>
                        this.DbContext.Parts.Where(p => bm.Parts.Contains(p.Id))));
                action.CreateMap<RegisterUserBindingModel, User>();
                action.CreateMap<Customer, AddSaleCustomerViewModel>();
                action.CreateMap<Car, AddSaleCarViewModel>();
                action.CreateMap<Sale, AddSaleViewModel>();
                action.CreateMap<AddSaleBindingModel, Sale>()
                    .ForMember(sale => sale.Car, config => config.MapFrom(
                        bm => this.DbContext.Cars.Find(bm.CarId)))
                    .ForMember(sale => sale.Customer, config => config.MapFrom(
                        bm => this.DbContext.Customers.Find(bm.CustomerId)))
                    .ForMember(sale => sale.Discount, config => config.MapFrom(
                        bm => bm.Discount / 100));
                action.CreateMap<Supplier, NewSupplierViewModel>();
                action.CreateMap<Supplier, EditSupplierViewModel>();
                action.CreateMap<Supplier, DeleteSupplierViewModel>();
                action.CreateMap<Log, LogViewModel>()
                    .ForMember(vm => vm.Owner, configExpression => configExpression.MapFrom(log => log.Owner.Username));
            });
        }

        public bool IsLogged()
        {
            return this.DbContext.Logins.Any();
        }

        public User GetCurrentlyLogged()
        {
            return this.DbContext.Logins.First().User;
        }
    }
}
