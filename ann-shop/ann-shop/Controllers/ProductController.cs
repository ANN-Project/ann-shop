using ann_shop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ann_shop.Controllers
{
    public class ProductController : ANNController
    {
        private ProductService _service;

        public ProductController()
        {
            _service = new ProductService();
        }

        public ActionResult Index(string slug)
        {
            ViewBag.Title = "Bikini Beach";
            var model = _service.getIndex(slug);
            return View(model);
        }

        public PartialViewResult GetProductTop(int category_id)
        {
            var model = _service.GetProductTop(category_id);
            return PartialView("~/Views/Product/_ProductTop.cshtml", model);
        }

        public PartialViewResult GetProductSame(int category_id)
        {
            var model = _service.GetProductSame(category_id);
            return PartialView("~/Views/Product/_ProductSame.cshtml", model);
        }
    }
}