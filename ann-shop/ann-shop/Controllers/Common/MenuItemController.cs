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

        public PartialViewResult GetPartialMenuItem(string view_name, string menu_name)
        {
            var model = _service.GetMenuItem(menu_name);
            return PartialView(view_name, model);
        }

    }
}
