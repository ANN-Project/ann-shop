using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop.Models
{
    public class ArchiveProductModel: ANNModel
    {
        public List<ProductModel> Products { get; set; }
    }
}