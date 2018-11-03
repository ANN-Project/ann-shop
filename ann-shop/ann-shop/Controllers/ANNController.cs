using ann_shop.Models;
using ann_shop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ann_shop.Controllers
{
    public class ANNController : Controller
    {
        private ANNService _service;

        public ANNController()
        {
            this._service = new ANNService();
        }

        public PartialViewResult GetMobileMenu()
        {
            var model = this._service.GetMenu("Main Menu");
            return PartialView("~/Views/Menu/_MobileMenu.cshtml", model);
        }

        public PartialViewResult GetTopMenu()
        {
            var model = this._service.GetMenu("Top Menu");
            return PartialView("~/Views/Menu/_TopMenu.cshtml", model);
        }

        public PartialViewResult GetHeaderMenu()
        {
            var model = this._service.GetMenu("Main Menu");
            return PartialView("~/Views/Menu/_HeaderMenu.cshtml", model);
        }

        public PartialViewResult GetSupportMenu()
        {
            var model = this._service.GetMenu("Support Menu");
            return PartialView("~/Views/Menu/_SupportMenu.cshtml", model);
        }

        public PartialViewResult GetServiceMenu()
        {
            var model = this._service.GetMenu("Service Menu");
            return PartialView("~/Views/Menu/_ServiceMenu.cshtml", model);
        }

        public PartialViewResult GetServiceSupportMenu()
        {
            var model = this._service.GetMenu("Service Support Menu");
            return PartialView("~/Views/Menu/_ServiceSupportMenu.cshtml", model);
        }
    }
}