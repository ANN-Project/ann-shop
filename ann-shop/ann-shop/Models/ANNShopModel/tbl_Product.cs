//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ann_shop.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Product
    {
        public int ID { get; set; }
        public Nullable<int> SystemID { get; set; }
        public string SKU { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public string Materials { get; set; }
        public string Type { get; set; }
        public string Slug { get; set; }
        public Nullable<double> WholesalePrice { get; set; }
        public Nullable<double> RetailPrice { get; set; }
        public Nullable<double> CostOfGoods { get; set; }
        public Nullable<int> ManageStock { get; set; }
        public Nullable<int> StockStatus { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<int> CommentSatus { get; set; }
        public string Image { get; set; }
        public Nullable<int> Featured { get; set; }
        public Nullable<int> ViewCount { get; set; }
        public Nullable<int> Export { get; set; }
        public Nullable<int> Hidden { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }
}
