using ann_shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop.Services
{
    public class ANNService
    {
        protected ApplicationDbContext db;

        public ANNService()
        {
            db = new ApplicationDbContext();
        }
    }
}