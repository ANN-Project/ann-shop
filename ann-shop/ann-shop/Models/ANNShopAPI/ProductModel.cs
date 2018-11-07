using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop.Models
{
    public class ProductModel
    {
        public int ID { get; set; }
        public string SKU { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int DiscountRatio { get; set; }
        public decimal DiscountPrice { get; set; }
        public string Avartar { get; set; }
        public string Slug { get; set; }
        public List<ImageModel> Images { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public int Number { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Tage { get; set; }
        public string Description { get; set; }
    }
}