using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop.Models
{
    public class ArchiveProductModel: ANNModel
    {
        public int Page { get; set; }
        public int PageSize { get; private set; } = 12;
        public int TotalPage { get; set; }
        public int TotalProduct { get; set; }
        public string Slug { get; set; }
        public List<ProductModel> Products { get; set; }
    }
}