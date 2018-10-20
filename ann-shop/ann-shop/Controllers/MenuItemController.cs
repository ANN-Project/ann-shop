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
using ann_shop.Models;

namespace ann_shop.Controllers
{
    public class MenuItemController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/MenuItem
        public IHttpActionResult GetMenuItem()
        {

            var menu_items = db.tbl_MenuItem.ToList();

            return Ok <List<MenuItemViewModels>>(GetTreeMenu(menu_items, 0, 0));
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

        private List<MenuItemViewModels> GetTreeMenu(List<tbl_MenuItem> menu_items, int parent_tree, int level)
        {
            // Get list menu by parent tree
            var tree_menu = menu_items.Where(
                x => x.ParentID == parent_tree
                ).Select(
                x => new MenuItemViewModels()
                {
                    ID = x.ID,
                    MenuID = x.MenuID,
                    ParentID = x.ParentID,
                    Level = level,
                    Name = x.Name,
                    URL = x.URL,
                    Child = new List<MenuItemViewModels>()
                }).ToList();

            // Get child of menu
            foreach(var menu in tree_menu)
            {
                menu.Child = GetTreeMenu(menu_items, menu.MenuID, ++level);
            }

            return tree_menu;
        }
    }
}