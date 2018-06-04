using IM_PJ.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebUI.Business;

namespace IM_PJ.Controllers
{
    public class StockManagerController
    {
        #region CRUD
        public static string Insert(tbl_StockManager stock)
        {
            using (var dbe = new inventorymanagementEntities())
            {
                tbl_StockManager ui = new tbl_StockManager();
                ui.AgentID = stock.AgentID;
                ui.ProductID = stock.ProductID;
                ui.ProductVariableID = stock.ProductVariableID;
                ui.Quantity = stock.Quantity;
                ui.QuantityCurrent = stock.QuantityCurrent;
                ui.Type = stock.Type;
                ui.NoteID = stock.NoteID;
                ui.OrderID = stock.OrderID;
                ui.Status = stock.Status;
                ui.SKU = stock.SKU;
                ui.ParentID = stock.ParentID;
                ui.CreatedDate = stock.CreatedDate;
                ui.CreatedBy = stock.CreatedBy;
                ui.MoveProID = stock.MoveProID;
                dbe.tbl_StockManager.Add(ui);
                int kq = dbe.SaveChanges();
                return kq.ToString();
            }
        }
        public static string Update(tbl_StockManager stock)
        {
            using (var dbe = new inventorymanagementEntities())
            {
                tbl_StockManager ui = dbe.tbl_StockManager.Where(a => a.ID == stock.ID).SingleOrDefault();
                if (ui != null)
                {
                    ui.AgentID = stock.AgentID;
                    ui.ProductVariableID = stock.ProductVariableID;
                    ui.Quantity = stock.Quantity;
                    ui.QuantityCurrent = stock.QuantityCurrent;
                    ui.Type = stock.Type;
                    ui.NoteID = stock.NoteID;
                    ui.OrderID = stock.OrderID;
                    ui.Status = stock.Status;
                    ui.SKU = stock.SKU;
                    ui.ModifiedBy = stock.ModifiedBy;
                    ui.ModifiedDate = stock.ModifiedDate;
                    int kq = dbe.SaveChanges();
                    return kq.ToString();
                }
                else
                    return null;
            }
        }
        #endregion
        #region Select
        public static tbl_StockManager GetByID(int ID)
        {
            using (var dbe = new inventorymanagementEntities())
            {
                tbl_StockManager ai = dbe.tbl_StockManager.Where(a => a.ID == ID).SingleOrDefault();
                if (ai != null)
                {
                    return ai;
                }
                else return null;

            }
        }
        public static List<tbl_StockManager> GetAll()
        {
            using (var dbe = new inventorymanagementEntities())
            {
                List<tbl_StockManager> ags = new List<tbl_StockManager>();
                ags = dbe.tbl_StockManager.ToList();
                return ags;
            }
        }
        //public static List<tbl_StockManager> GetByProductName(int AgentID,string ProductName)
        //{
        //    using (var dbe = new inventorymanagementEntities())
        //    {
        //        List<tbl_StockManager> ags = new List<tbl_StockManager>();
        //        ags = dbe.tbl_StockManager.Where(i => i.AgentID == AgentID && i.ProductName.Contains(ProductName)).ToList();
        //        return ags;
        //    }
        //}
        public static List<tbl_StockManager> GetBySKU(int AgentID, string SKU)
        {
            using (var dbe = new inventorymanagementEntities())
            {
                List<tbl_StockManager> ags = new List<tbl_StockManager>();
                ags = dbe.tbl_StockManager.Where(i => i.AgentID == AgentID && i.SKU == SKU).ToList();
                return ags;
            }
        }

        public static List<tbl_StockManager> GetBySKU(string SKU)
        {
            using (var dbe = new inventorymanagementEntities())
            {
                List<tbl_StockManager> ags = new List<tbl_StockManager>();
                ags = dbe.tbl_StockManager.Where(i => i.SKU == SKU).ToList();
                return ags;
            }
        }

        public static tbl_StockManager GetStockID(Nullable<int> productID = null, Nullable<int> productVariableID = null) {
            tbl_StockManager stock = new tbl_StockManager();
            bool exists = false;
            String sql = String.Empty;

            sql += " SELECT TOP 1 ";
            sql += "         ID ";
            sql += " ,       AgentID ";
            sql += " ,       ProductID ";
            sql += " ,       ProductVariableID ";
            sql += " ,       Quantity ";
            sql += " ,       QuantityCurrent ";
            sql += " ,       Type ";
            sql += " FROM ";
            sql += "         tbl_StockManager ";
            sql += " WHERE ";
            sql += "         1 = 1 ";

            if (productID != null)
            {
                sql += "         AND ProductID = " + productID.Value.ToString();
            }

            if (productVariableID != null)
            {
                sql += "         AND ProductVariableID = " + productVariableID.Value.ToString();
            }

            sql += " ORDER BY ";
            sql += "     CreatedDate DESC ";

            var reader = (IDataReader)SqlHelper.ExecuteDataReader(sql);

            while (reader.Read()) {
                exists = true;

                stock.ID = Convert.ToInt32(reader["ID"]);

                if(reader["AgentID"] != DBNull.Value) {
                    stock.AgentID = Convert.ToInt32(reader["AgentID"]);
                }

                if (reader["ProductID"] != DBNull.Value)
                {
                    stock.ProductID = Convert.ToInt32(reader["ProductID"]);
                }

                if (reader["ProductVariableID"] != DBNull.Value)
                {
                    stock.ProductVariableID = Convert.ToInt32(reader["ProductVariableID"]);
                }

                if (reader["Quantity"] != DBNull.Value)
                {
                    stock.Quantity = Convert.ToDouble(reader["Quantity"]);
                }

                if (reader["QuantityCurrent"] != DBNull.Value)
                {
                    stock.QuantityCurrent = Convert.ToDouble(reader["QuantityCurrent"]);
                }

                if (reader["Type"] != DBNull.Value)
                {
                    stock.Type = Convert.ToInt32(reader["Type"]);
                }
            }

            reader.Close();

            if (exists)
            {
                return stock;
            }
            else
            {
                return null;
            }
        }
        #endregion
    }
}