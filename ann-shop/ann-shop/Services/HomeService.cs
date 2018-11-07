using ann_shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop.Services
{
    public class HomeService: ANNService
    {
        private HomeModel _model;

        public HomeService()
        {
            _model = new HomeModel();
        }

        private void Init()
        {
        }

        public HomeModel getIndex()
        {
            Init();

            return _model;
        }
    }
}