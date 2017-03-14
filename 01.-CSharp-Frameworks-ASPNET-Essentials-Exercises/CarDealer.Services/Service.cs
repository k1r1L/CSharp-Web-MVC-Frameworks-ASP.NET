namespace CarDealer.Services
{
    using System.Linq;
    using AutoMapper;
    using BindingModels;
    using Data;
    using Models;
    using ViewModels;

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
            });
        }
    }
}
