using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CarDealerApp
{
    using AutoMapper;
    using CarDealer.BindingModels;
    using CarDealer.Models;
    using CarDealer.ViewModels;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
