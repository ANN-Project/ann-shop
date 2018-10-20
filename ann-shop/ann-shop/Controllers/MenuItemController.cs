using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ann_shop.Services;
using ann_shop.Models;

namespace ann_shop.Controllers
{
    public class MenuItemController : ApiController
    {
        private ApplicationDbContext db;
        private MenuItemService service;

        public MenuItemController()
        {
            db = new ApplicationDbContext();
            service = new MenuItemService(db);
        }

        // GET: api/MenuItem
        public IHttpActionResult GetMenuItem()
        {

            var menu_items = db.tbl_MenuItem.ToList();

            return Ok <List<MenuItemViewModels>>(service.GetTreeMenu(menu_items, 0, 0));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_MenuItemExists(int id)
        {
            return db.tbl_MenuItem.Count(e => e.ID == id) > 0;
        }
    }
}