using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CarDealerApp
{
    using AutoMapper;
    using CarDealer.BindingModels;
    using CarDealer.Data;
    using CarDealer.Models;
    using CarDealer.ViewModels;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ConfigureAutomapping();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void ConfigureAutomapping()
        {
            Mapper.Initialize(action =>
            {
                action.CreateMap<AddCustomerBindingModel, Customer>()
                    .ForMember(customer => customer.IsYoungDriver,
                        config => config.MapFrom(bm => bm.Birthdate.Year > 1998));
                action.CreateMap<Customer, CustomerViewModel>();
                action.CreateMap<Part, AllPartViewModel>();
            });
        }
    }
}
