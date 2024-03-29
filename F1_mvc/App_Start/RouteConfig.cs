﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace F1_mvc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Drivers",
                url: "drivers/{id}",
                defaults: new { controller = "Drivers", action = "Details" }
            );
            routes.MapRoute(
                name: "Seasons",
                url: "seasons/{id}",
                defaults: new { controller = "Seasons", action = "Details" }
            );


            routes.MapRoute(
                name: "Circuits",
                url: "circuits/{id}",
                defaults: new { controller = "Circuits", action = "Details" }
            );

            routes.MapRoute(
                name: "Races",
                url: "races/{id}",
                defaults: new { controller = "Races", action = "Details" }
            );

            routes.MapRoute(
                name: "Constructors",
                url: "constructors/{id}",
                defaults: new { controller = "Constructors", action = "Details" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
