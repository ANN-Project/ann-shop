using ann_shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop.Services
{
    public class ANNService
    {
        private MenuItemService _service;

        protected ApplicationDbContext db;

        public ANNService()
        {
            this.db = new ApplicationDbContext();
            this._service = new MenuItemService(db);
        }

        public List<MenuItemModel> GetMenu(string name)
        {
            return this._service.GetMenuItem(name.Trim());
        }
    }
}