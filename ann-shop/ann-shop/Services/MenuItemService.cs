﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ann_shop.Models;

namespace ann_shop.Services
{
    public class MenuItemService
    {
        private ApplicationDbContext db;

        public MenuItemService(ApplicationDbContext database)
        {
            db = database;
        }

        public List<MenuItemViewModels> GetTreeMenu(List<tbl_MenuItem> menu_items, int parent_tree, int level)
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
            foreach (var menu in tree_menu)
            {
                menu.Child = GetTreeMenu(menu_items, menu.ID, ++level);
            }

            return tree_menu;
        }

        public List<MenuItemViewModels> GetMenu(string name_menu)
        {
            var top_menu = db.tbl_MenuItem.Join(
                db.tbl_Menu,
                item => item.MenuID,
                menu => menu.ID,
                (item, menu) => new { item, menu }
                ).Where(
                    x => x.menu.Name == name_menu
                ).Select(
                    x => x.item
                ).ToList();

            return GetTreeMenu(top_menu, 0, 0);
        }
    }
}