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
        private ApplicationDbContext _db;
        private MenuItemService _service;

        public MenuItemController()
        {
            this._db = new ApplicationDbContext();
            this._service = new MenuItemService(this._db);
        }

        // GET: api/MenuItem
        public IHttpActionResult GetMenuItem()
        {

            var menu_items = this._db.tbl_MenuItem.ToList();

            return Ok <List<MenuItemModel>>(this._service.GetTreeMenuItem(menu_items, 0, 0));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbl_MenuItemExists(int id)
        {
            return this._db.tbl_MenuItem.Count(e => e.ID == id) > 0;
        }
    }
}