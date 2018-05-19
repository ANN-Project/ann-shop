using IM_PJ.Models;
using MB.Extensions;
using NHST.Bussiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebUI.Business;


namespace IM_PJ.Controllers
{
    public class RefundGoodDetailController
    {
        #region CRUD
        public static int Insert(int RefundGoodsID, int AgentID, int OrderID, string ProductName, int CustomerID, string SKU, double Quantity, double QuantityMax,
            string PriceNotFeeRefund, int ProductType, bool IsCount, int RefundType, string RefundFeePerProduct, string TotalRefundFee, string GiavonPerProduct,
            string DiscountPricePerProduct, string SoldPricePerProduct, string TotalPriceRow, DateTime CreatedDate, string CreatedBy)
        {
            using (var dbe = new inventorymanagementEntities())
            {
                tbl_RefundGoodsDetails a = new tbl_RefundGoodsDetails();
                a.RefundGoodsID = RefundGoodsID;
                a.AgentID = AgentID;
                a.OrderID = OrderID;
                a.ProductName = ProductName;
                a.CustomerID = CustomerID;
                a.SKU = SKU;
                a.Quantity = Quantity;
                a.QuantityMax = QuantityMax;
                a.PriceNotFeeRefund = PriceNotFeeRefund;
                a.ProductType = ProductType;
                a.IsCount = true;
                a.RefundType = RefundType;
                a.RefundFeePerProduct = RefundFeePerProduct;
                a.TotalRefundFee = TotalRefundFee;
                a.GiavonPerProduct = GiavonPerProduct;
                a.DiscountPricePerProduct = DiscountPricePerProduct;
                a.SoldPricePerProduct = SoldPricePerProduct;
                a.TotalPriceRow = TotalPriceRow;
                a.CreatedDate = CreatedDate;
                a.CreatedBy = CreatedBy;
                dbe.tbl_RefundGoodsDetails.Add(a);
                dbe.SaveChanges();
                int kq = a.ID;
                return kq;
            }
        }

    
        #endregion
        #region Select        
        public static List<tbl_RefundGoodsDetails> GetAll(string s)
        {
            using (var dbe = new inventorymanagementEntities())
            {
                List<tbl_RefundGoodsDetails> las = new List<tbl_RefundGoodsDetails>();
                las = dbe.tbl_RefundGoodsDetails.OrderByDescending(r => r.CreatedDate).ToList();
                return las;
            }
        }
        public static List<tbl_RefundGoodsDetails> GetByRefundGoodsID(int RefundGoodsID)
        {
            using (var dbe = new inventorymanagementEntities())
            {
                List<tbl_RefundGoodsDetails> las = new List<tbl_RefundGoodsDetails>();
                las = dbe.tbl_RefundGoodsDetails.Where(r => r.RefundGoodsID == RefundGoodsID).OrderByDescending(r => r.CreatedDate).ToList();
                return las;
            }
        }

        public static List<tbl_RefundGoodsDetails> GetQuantityMax(int CustomerID, int OrderID, string SKU)
        {
            using (var dbe = new inventorymanagementEntities())
            {
                List<tbl_RefundGoodsDetails> las = new List<tbl_RefundGoodsDetails>();
                las = dbe.tbl_RefundGoodsDetails.Where(x => x.CustomerID == CustomerID && x.OrderID == OrderID && x.SKU == SKU).ToList();
                return las;
            }
        }

      
        #endregion
    }
}