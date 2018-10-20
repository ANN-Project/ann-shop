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
        private MenuItemService service;
        private HomeModel model;

        public HomeController()
        {
            service = new MenuItemService(new ApplicationDbContext());
            model = new HomeModel();
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Bikini Beach";
            model.TopMenu = service.GetMenu("Top Menu");
            model.MainMenu = service.GetMenu("Main Menu");
            model.SupportMenu = service.GetMenu("Support Menu");
            model.ServiceMenu = service.GetMenu("Service Menu");
            model.ServiceSupportMenu = service.GetMenu("Service Support Menu");

            return View(model);
        }
    }
}
