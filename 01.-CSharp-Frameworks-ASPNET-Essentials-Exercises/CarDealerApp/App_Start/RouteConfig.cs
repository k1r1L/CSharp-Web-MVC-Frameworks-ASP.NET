using System.Web.Mvc;
using System.Web.Routing;

namespace CarDealerApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();

            //routes.MapRoute(
            //    name: "Home",
            //    url: "Home/Index",
            //    defaults: new {controller = "Home", action = "Index"}
            //);
            //routes.MapRoute(
            // name: "Discounted Sales",
            // url: "Sales/Discounted/{percent}",
            // defaults: new { controller = "Sales", action = "Discounted", percent = UrlParameter.Optional }
            //);
          //  routes.MapRoute(
          //    name: "All Sales",
          //    url: "Sales/{id}",
          //    defaults: new { controller = "Sales", action = "All", id = UrlParameter.Optional }
          //);
           // routes.MapRoute(
           //   name: "Customers order",
           //   url: "Customers/All/{criteria}",
           //   defaults: new { controller = "Customers", action = "All", criteria = "ascending" }
           //);
          //  routes.MapRoute(
          //    name: "Customers sales",
          //    url: "Customers/{id}",
          //    defaults: new { controller = "Customers", action = "Sales", id = "1" }
          //);
            //routes.MapRoute(
            //    name: "Cars from make",
            //    url: "Cars/All/{make}",
            //    defaults: new { controller = "Cars", action = "All", make = UrlParameter.Optional }
            //);
            //routes.MapRoute(
            //    name: "Cars with Their List of Parts",
            //    url: "Cars/{id}/parts",
            //    defaults: new { controller = "Cars", action = "Details", id = "1" }
            //);
            //routes.MapRoute(
            //    name: "Filter suppliers",
            //    url: "Suppliers/{type}",
            //    defaults: new { controller = "Suppliers", action = "Index", type = UrlParameter.Optional }
            //);
        }
    }
}
