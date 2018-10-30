using ann_shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop.Services
{
    public class ANNService
    {
        private MenuItemService service;

        protected ApplicationDbContext db;

        public ANNService()
        {
            this.db = new ApplicationDbContext();
            this.service = new MenuItemService(db);

        }

        public virtual void Init(ANNModel model)
        {
            model.TopMenu = service.GetMenu("Top Menu");
            model.MainMenu = service.GetMenu("Main Menu");
            model.SupportMenu = service.GetMenu("Support Menu");
            model.ServiceMenu = service.GetMenu("Service Menu");
            model.ServiceSupportMenu = service.GetMenu("Service Support Menu");
        }
    }
}