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
            var model = _service.GetIndex(slug);
            return View(model);
        }

        public PartialViewResult GetPartialProductNew(string view_name, int limit)
        {
            var model = _service.GetProductNew();
            return PartialView(view_name, model);
        }

        public PartialViewResult GetPartialProductTop(string view_name, int category_id)
        {
            var model = _service.GetProductTop(category_id);
            return PartialView(view_name, model);
        }

        public PartialViewResult GetPartialProductSame(string view_name, int category_id)
        {
            var model = _service.GetProductSame(category_id);
            return PartialView(view_name, model);
        }

        public PartialViewResult GetPartialProductInCategory(string view_name, string category_slug, int limit)
        {
            var model = _service.GetProductInCategory(category_slug);
            return PartialView(view_name, model);
        }

        public PartialViewResult GetPartialProductInCategories(string view_name, List<string> category_slugs, int limit)
        {
            var model = _service.GetProductInCategories(category_slugs);
            return PartialView(view_name, model);
        }
    }
}