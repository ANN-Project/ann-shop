using ann_shop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ann_shop.Controllers
{
    public class ArchiveProductController : ANNController
    {
        private ArchiveProductService _service;

        public ArchiveProductController()
        {
            _service = new ArchiveProductService();
        }

        // GET: ArchiveProduct
        public ActionResult Index(string slug, int? page)
        {
            ViewBag.Title = "Bikini Beach";

            var model = _service.getIndex(slug, page ?? 0);

            return View(model);
        }
    }
}
