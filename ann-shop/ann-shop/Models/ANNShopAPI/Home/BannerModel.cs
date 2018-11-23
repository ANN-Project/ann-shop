using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop.Models
{
    public class BannerModel
    {
        public string url { get; set; }
        public ImageModel image { get; set; }
        public string banner_text_1 { get; set; }
        public string banner_text_2 { get; set; }
    }
}