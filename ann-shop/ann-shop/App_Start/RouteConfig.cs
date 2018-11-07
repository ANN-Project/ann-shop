using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ann_shop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Categoroy Page",
                url: "category/{slug}/page/{page}",
                defaults: new { controller = "ArchiveProduct", action = "Index", slug=UrlParameter.Optional, page = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Categoroy",
                url: "category/{slug:string}",
                defaults: new { controller = "ArchiveProduct", action = "Index", slug = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Product",
                url: "Product/{slug:string}",
                defaults: new { controller = "Product", action = "Index", slug = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
