﻿using System;
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
                name: "CategoroyPage",
                url: "danh-muc/{slug}/page/{page}",
                defaults: new { controller = "ArchiveProduct", action = "Index", slug=UrlParameter.Optional, page = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Categoroy",
                url: "danh-muc/{slug}",
                defaults: new { controller = "ArchiveProduct", action = "Index", slug = "" }
            );

            routes.MapRoute(
                name: "Product",
                url: "san-pham/{slug}",
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
