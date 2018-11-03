using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop.Models
{
    public class ProductModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int DiscountRatio { get; set; }
        public decimal DiscountPrice { get; set; }
        public string Image { get; set; }
        public string Slug { get; set; }
    }
}