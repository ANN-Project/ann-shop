using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ann_shop.Services;
using ann_shop.Models;

namespace ann_shop.Controllers
{
    public class MenuItemController : ANNController
    {
        private MenuItemService _service;

        public MenuItemController()
        {
            _service = new MenuItemService();
        }

        public PartialViewResult GetMobileMenu()
        {
            var model = _service.GetMenuItem("Main Menu");
            return PartialView("~/Views/Menu/_MobileMenu.cshtml", model);
        }

        public PartialViewResult GetTopMenu()
        {
            var model = _service.GetMenuItem("Top Menu");
            return PartialView("~/Views/Menu/_TopMenu.cshtml", model);
        }

        public PartialViewResult GetHeaderMenu()
        {
            var model = _service.GetMenuItem("Main Menu");
            return PartialView("~/Views/Menu/_HeaderMenu.cshtml", model);
        }

        public PartialViewResult GetSupportMenu()
        {
            var model = _service.GetMenuItem("Support Menu");
            return PartialView("~/Views/Menu/_SupportMenu.cshtml", model);
        }

        public PartialViewResult GetServiceMenu()
        {
            var model = _service.GetMenuItem("Service Menu");
            return PartialView("~/Views/Menu/_ServiceMenu.cshtml", model);
        }

        public PartialViewResult GetServiceSupportMenu()
        {
            var model = _service.GetMenuItem("Service Support Menu");
            return PartialView("~/Views/Menu/_ServiceSupportMenu.cshtml", model);
        }
    }
}
