﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class inventorymanagementEntities : DbContext
    {
        public inventorymanagementEntities()
            : base("name=inventorymanagementEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tbl_Account> tbl_Account { get; set; }
        public virtual DbSet<tbl_AccountInfo> tbl_AccountInfo { get; set; }
        public virtual DbSet<tbl_Agent> tbl_Agent { get; set; }
        public virtual DbSet<tbl_AgentProduct> tbl_AgentProduct { get; set; }
        public virtual DbSet<tbl_AgentProductVariable> tbl_AgentProductVariable { get; set; }
        public virtual DbSet<tbl_Category> tbl_Category { get; set; }
        public virtual DbSet<tbl_CustomerLevel> tbl_CustomerLevel { get; set; }
        public virtual DbSet<tbl_CheckWarehouse> tbl_CheckWarehouse { get; set; }
        public virtual DbSet<tbl_CheckWarehouseDetail> tbl_CheckWarehouseDetail { get; set; }
        public virtual DbSet<tbl_Discount> tbl_Discount { get; set; }
        public virtual DbSet<tbl_DiscountCustomer> tbl_DiscountCustomer { get; set; }
        public virtual DbSet<tbl_DiscountGroup> tbl_DiscountGroup { get; set; }
        public virtual DbSet<tbl_LinkImnage> tbl_LinkImnage { get; set; }
        public virtual DbSet<tbl_MovePro> tbl_MovePro { get; set; }
        public virtual DbSet<tbl_MoveProdDetail> tbl_MoveProdDetail { get; set; }
        public virtual DbSet<tbl_OrderReturnGood> tbl_OrderReturnGood { get; set; }
        public virtual DbSet<tbl_Product> tbl_Product { get; set; }
        public virtual DbSet<tbl_ProductImage> tbl_ProductImage { get; set; }
        public virtual DbSet<tbl_ProductVariable> tbl_ProductVariable { get; set; }
        public virtual DbSet<tbl_ProductVariableImage> tbl_ProductVariableImage { get; set; }
        public virtual DbSet<tbl_ProductVariableValue> tbl_ProductVariableValue { get; set; }
        public virtual DbSet<tbl_Province> tbl_Province { get; set; }
        public virtual DbSet<tbl_RefundGoodsDetails> tbl_RefundGoodsDetails { get; set; }
        public virtual DbSet<tbl_Role> tbl_Role { get; set; }
        public virtual DbSet<tbl_SessionInOu> tbl_SessionInOu { get; set; }
        public virtual DbSet<tbl_Supplier> tbl_Supplier { get; set; }
        public virtual DbSet<tbl_Variable> tbl_Variable { get; set; }
        public virtual DbSet<tbl_VariableValue> tbl_VariableValue { get; set; }
        public virtual DbSet<tbl_WhiteDomain> tbl_WhiteDomain { get; set; }
        public virtual DbSet<View_ProductList> View_ProductList { get; set; }
        public virtual DbSet<tbl_OrderDetail> tbl_OrderDetail { get; set; }
        public virtual DbSet<tbl_StockManager> tbl_StockManager { get; set; }
        public virtual DbSet<tbl_TransportCompany> tbl_TransportCompany { get; set; }
        public virtual DbSet<tbl_Config> tbl_Config { get; set; }
        public virtual DbSet<tbl_Customer> tbl_Customer { get; set; }
        public virtual DbSet<tbl_Order> tbl_Order { get; set; }
        public virtual DbSet<tbl_RefundGoods> tbl_RefundGoods { get; set; }
    }
}
