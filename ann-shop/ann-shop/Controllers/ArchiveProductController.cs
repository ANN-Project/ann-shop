using ann_shop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ann_shop.Controllers
{
    public class ArchiveProductController : Controller
    {
        private ArchiveProductService service;

        public ArchiveProductController()
        {
            service = new ArchiveProductService();
        }

        // GET: ArchiveProduct
        public ActionResult Index(int? page)
        {
            ViewBag.Title = "Bikini Beach";

            if (!page.HasValue)
            {
                page = 0;
            }

            var model = service.getIndex(page.Value);

            return View(model);
        }
    }
}
