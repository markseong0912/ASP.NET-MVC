using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NewVidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapMvcAttributeRoutes();
            //routes.MapRoute( //this is how you would create a custom route
            //   "MoviesByReleaseDate",
            //    "movies/released/{year}/{month}",
            //     new {controller = "Movies", action = "ByReleaseDate"},
            //     new {year = @"2015|2016", month = @"\d{2}"} //contraining the values
            //    );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
