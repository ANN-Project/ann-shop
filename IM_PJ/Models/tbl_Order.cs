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
    
    public partial class tbl_Order
    {
        public int ID { get; set; }
        public Nullable<int> AgentID { get; set; }
        public Nullable<int> OrderType { get; set; }
        public string AdditionFee { get; set; }
        public string DisCount { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerEmail { get; set; }
        public string TotalPrice { get; set; }
        public Nullable<int> PaymentStatus { get; set; }
        public Nullable<int> ExcuteStatus { get; set; }
        public Nullable<bool> IsHidden { get; set; }
        public Nullable<int> WayIn { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<double> DiscountPerProduct { get; set; }
        public Nullable<double> TotalDiscount { get; set; }
        public string FeeShipping { get; set; }
        public string TotalPriceNotDiscount { get; set; }
        public Nullable<double> GuestPaid { get; set; }
        public Nullable<double> GuestChange { get; set; }
        public string FeeRefund { get; set; }
        public Nullable<int> PaymentType { get; set; }
        public Nullable<int> ShippingType { get; set; }
        public string OrderNote { get; set; }
        public Nullable<System.DateTime> DateDone { get; set; }
        public Nullable<int> RefundsGoodsID { get; set; }
    }
}
