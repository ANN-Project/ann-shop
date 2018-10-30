using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop.Models
{
    public class MenuItemViewModels
    {
        public int ID { get; set; }
        public int MenuID { get; set; }
        public int ParentID { get; set; }
        public int Level { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }

        public List<MenuItemViewModels> Child { get; set; }
    }
}