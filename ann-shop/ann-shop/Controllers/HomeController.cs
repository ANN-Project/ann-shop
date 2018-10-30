using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ann_shop.Services;
using ann_shop.Models;

namespace ann_shop.Controllers
{
    public class HomeController : Controller
    {
        private HomeService service;

        public HomeController()
        {
            service = new HomeService();
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Bikini Beach";
            var model = service.getIndex();

            return View(model);
        }
    }
}
