using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcRoutingDemo_deguzman
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "StudentDetails",
                url: "student/{id}",
                defaults: new { controller = "Student", action = "Details", id = UrlParameter.Optional }
                );

            routes.MapRoute(
               name: "StudentCourse",
               url: "student/course/{course}",
               defaults: new { controller = "Student", action = "Course", id = UrlParameter.Optional }
               );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Student", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
