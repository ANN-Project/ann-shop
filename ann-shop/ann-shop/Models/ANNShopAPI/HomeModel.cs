using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ann_shop.Models
{
    public class HomeModel
    {
        public List<MenuItemViewModels> TopMenu { get; set; }
        public List<MenuItemViewModels> MainMenu { get; set; }
        public List<MenuItemViewModels> SupportMenu { get; set; }
        public List<MenuItemViewModels> ServiceMenu { get; set; }
        public List<MenuItemViewModels> ServiceSupportMenu { get; set; }
    }
}