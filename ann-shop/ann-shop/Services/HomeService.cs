using ann_shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop.Services
{
    public class HomeService: ANNService
    {
        private HomeModel model;

        public HomeService()
        {
            model = new HomeModel();
        }

        private void Init()
        {
            base.Init(this.model);
        }

        public HomeModel getIndex()
        {
            this.Init();

            return model;
        }
    }
}