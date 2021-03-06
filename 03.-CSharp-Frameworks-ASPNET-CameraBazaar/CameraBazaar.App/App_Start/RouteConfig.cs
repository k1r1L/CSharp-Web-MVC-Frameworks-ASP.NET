﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CameraBazaar.App
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
               name: "User Profile",
               url: "User/Profile/{name}",
               defaults: new { controller = "User", action = "Profile" }
           );
            routes.MapRoute(
               name: "User Edit Profile",
               url: "User/EditProfile/{username}",
               defaults: new { controller = "User", action = "EditProfile" }
           );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
