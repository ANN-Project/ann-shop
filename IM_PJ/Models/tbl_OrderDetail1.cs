//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IM_PJ.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_OrderDetail1
    {
        public int ID { get; set; }
        public Nullable<int> AgentID { get; set; }
        public Nullable<int> OrderID { get; set; }
        public string SKU { get; set; }
        public Nullable<int> ProductID { get; set; }
        public Nullable<int> ProductVariableID { get; set; }
        public string ProductVariableDescrition { get; set; }
        public Nullable<double> Quantity { get; set; }
        public string Price { get; set; }
        public Nullable<int> Status { get; set; }
        public string DiscountPrice { get; set; }
        public Nullable<int> ProductType { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<bool> IsCount { get; set; }
    }
}
