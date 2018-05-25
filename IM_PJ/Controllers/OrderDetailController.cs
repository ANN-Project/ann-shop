using IM_PJ.Models;
using NHST.Bussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IM_PJ.Controllers
{
    public class OrderDetailController
    {
        #region CRUD
        public static string Insert(int AgentID, int OrderID, string SKU, int ProductID, int ProductVariableID, string ProductVariableDescrition, double Quantity,
            double Price, int Status, double DiscountPrice, int ProductType, DateTime CreatedDate, string CreatedBy, bool IsCount)
        {
            using (var dbe = new inventorymanagementEntities())
            {
                tbl_OrderDetail ui = new tbl_OrderDetail();
                ui.AgentID = AgentID;
                ui.OrderID = OrderID;
                ui.SKU = SKU;
                ui.ProductID = ProductID;
                ui.ProductVariableID = ProductVariableID;
                ui.ProductVariableDescrition = ProductVariableDescrition;
                ui.Quantity = Quantity;
                ui.Price = Convert.ToDouble(Price);
                ui.Status = Status;
                ui.DiscountPrice = DiscountPrice;
                ui.ProductType = ProductType;
                ui.CreatedDate = CreatedDate;
                ui.CreatedBy = CreatedBy;
                ui.IsCount = IsCount;
                dbe.tbl_OrderDetail.Add(ui);
                int kq = dbe.SaveChanges();
                return kq.ToString();
            }
        }
        public static string UpdateQuantity(int ID, double Quantity, DateTime CreatedDate, string CreatedBy)
        {
            using (var dbe = new inventorymanagementEntities())
            {
                var ui = dbe.tbl_OrderDetail.Where(o => o.ID == ID).FirstOrDefault();
                if (ui != null)
                {
                    ui.Quantity = Quantity;
                    ui.CreatedDate = CreatedDate;
                    ui.CreatedBy = CreatedBy;
                    int kq = dbe.SaveChanges();
                    return kq.ToString();
                }
                return "0";
            }
        }
        public static string UpdateIsCount(int ID, bool isCount)
        {
            using (var dbe = new inventorymanagementEntities())
            {
                var ui = dbe.tbl_OrderDetail.Where(o => o.ID == ID).FirstOrDefault();
                if (ui != null)
                {
                    ui.IsCount = isCount;
                    int kq = dbe.SaveChanges();
                    return kq.ToString();
                }
                return "0";
            }
        }
        public static string Delete(int ID,string SKU)
        {
            using (var dbe = new inventorymanagementEntities())
            {
                var ui = dbe.tbl_OrderDetail.Where(o => o.ID == ID && o.SKU == SKU).FirstOrDefault();
                var od = dbe.tbl_OrderDetail.ToList();
                if (ui != null)
                {
                    //for (int i = 0; i < od.Count; i++)
                    //{
                    //    if(od[i].ID == ui.ID)
                    //    {
                    //        od.Remove(ui);
                    //    }
                    //}
                    dbe.tbl_OrderDetail.Remove(ui);
                    int kq = dbe.SaveChanges();
                    return kq.ToString();
                }
                return "0";
            }
        }
        #endregion
        #region Select
        public static tbl_OrderDetail GetByID(int ID)
        {
            using (var dbe = new inventorymanagementEntities())
            {
                tbl_OrderDetail ai = dbe.tbl_OrderDetail.Where(a => a.ID == ID).SingleOrDefault();
                if (ai != null)
                {
                    return ai;
                }
                else return null;

            }
        }
        public static List<tbl_OrderDetail> GetAll()
        {
            using (var dbe = new inventorymanagementEntities())
            {
                List<tbl_OrderDetail> ags = new List<tbl_OrderDetail>();
                ags = dbe.tbl_OrderDetail.OrderByDescending(o => o.ID).ToList();
                return ags;
            }
        }
        public static List<tbl_OrderDetail> GetAllByAgentID(int AgentID)
        {
            using (var dbe = new inventorymanagementEntities())
            {
                List<tbl_OrderDetail> ags = new List<tbl_OrderDetail>();
                ags = dbe.tbl_OrderDetail.Where(o => o.AgentID == AgentID).OrderByDescending(o => o.ID).ToList();
                return ags;
            }
        }
        public static List<tbl_OrderDetail> GetByOrderID(int OrderID)
        {
            using (var dbe = new inventorymanagementEntities())
            {
                List<tbl_OrderDetail> ags = new List<tbl_OrderDetail>();
                ags = dbe.tbl_OrderDetail.Where(o => o.OrderID == OrderID).OrderByDescending(o => o.ID).ToList();
                return ags;
            }
        }
        public static List<tbl_OrderDetail> GetByIDSortBySKU(int OrderID)
        {
            using (var dbe = new inventorymanagementEntities())
            {
                List<tbl_OrderDetail> ags = new List<tbl_OrderDetail>();
                ags = dbe.tbl_OrderDetail.Where(o => o.OrderID == OrderID).OrderBy(o => o.SKU).ThenByDescending(o => o.Price).ToList();
                return ags;
            }
        }
        public static List<tbl_Order> GetByPaymentStatus(int PaymentStatus)
        {
            using (var dbe = new inventorymanagementEntities())
            {
                List<tbl_Order> ags = new List<tbl_Order>();
                ags = dbe.tbl_Order.Where(o => o.PaymentStatus == PaymentStatus).OrderByDescending(o => o.ID).ToList();
                return ags;
            }
        }
        #endregion
    }
}