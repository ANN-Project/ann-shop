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
    public class ProductController
    {
        #region CRUD
        public static string Insert(int CategoryID, int ProductOldID, string ProductTitle, string ProductContent, string ProductSKU, double ProductStock,
            int StockStatus, bool ManageStock, double Regular_Price, double CostOfGood, double Retail_Price, string ProductImage, int ProductType,
            bool IsHidden, DateTime CreatedDate, string CreatedBy, int SupplierID, string SupplierName, string Materials,
            double MinimumInventoryLevel, double MaximumInventoryLevel, int ProductStyle)
        {
            using (var dbe = new inventorymanagementEntities())
            {
                tbl_Product ui = new tbl_Product();
                ui.CategoryID = CategoryID;
                ui.ProductOldID = ProductOldID;
                ui.ProductTitle = ProductTitle;
                ui.ProductContent = ProductContent;
                ui.ProductSKU = ProductSKU;
                ui.ProductStock = ProductStock;
                ui.StockStatus = StockStatus;
                ui.ManageStock = ManageStock;
                ui.Regular_Price = Regular_Price;
                ui.CostOfGood = CostOfGood;
                ui.Retail_Price = Retail_Price;
                ui.ProductImage = ProductImage;
                ui.ProductType = ProductType;
                ui.IsHidden = IsHidden;
                ui.CreatedDate = CreatedDate;
                ui.CreatedBy = CreatedBy;
                ui.SupplierID = SupplierID;
                ui.SupplierName = SupplierName;
                ui.Materials = Materials;
                ui.MinimumInventoryLevel = MinimumInventoryLevel;
                ui.MaximumInventoryLevel = MaximumInventoryLevel;
                ui.ProductStyle = ProductStyle;
                dbe.tbl_Product.Add(ui);
                dbe.SaveChanges();
                int kq = ui.ID;
                return kq.ToString();
            }
        }
        public static string Update(int ID, int CategoryID, int ProductOldID, string ProductTitle, string ProductContent, string ProductSKU, double ProductStock,
            int StockStatus, bool ManageStock, double Regular_Price, double CostOfGood, double Retail_Price, string ProductImage, int ProductType,
            bool IsHidden, DateTime ModifiedDate, string ModifiedBy, int SupplierID, string SupplierName, string Materials,
            double MinimumInventoryLevel, double MaximumInventoryLevel)
        {
            using (var dbe = new inventorymanagementEntities())
            {
                tbl_Product ui = dbe.tbl_Product.Where(a => a.ID == ID).SingleOrDefault();
                if (ui != null)
                {
                    ui.CategoryID = CategoryID;
                    ui.ProductOldID = ProductOldID;
                    ui.ProductTitle = ProductTitle;
                    ui.ProductContent = ProductContent;
                    ui.ProductSKU = ProductSKU;
                    if (ProductStock > 0)
                        ui.ProductStock = ProductStock;
                    if (StockStatus > 0)
                        ui.StockStatus = StockStatus;
                    ui.ManageStock = ManageStock;
                    ui.Regular_Price = Regular_Price;
                    ui.CostOfGood = CostOfGood;
                    ui.Retail_Price = Retail_Price;
                    ui.ProductImage = ProductImage;
                    ui.ProductType = ProductType;
                    ui.IsHidden = IsHidden;
                    ui.ModifiedBy = ModifiedBy;
                    ui.ModifiedDate = ModifiedDate;
                    ui.SupplierID = SupplierID;
                    ui.SupplierName = SupplierName;
                    ui.Materials = Materials;
                    ui.MinimumInventoryLevel = MinimumInventoryLevel;
                    ui.MaximumInventoryLevel = MaximumInventoryLevel;
                    int kq = dbe.SaveChanges();
                    return kq.ToString();
                }
                else
                    return null;
            }
        }

        public static string UpdateStockStatus(string SKU, int StockStatus, bool IsHidden, DateTime ModifiedDate, string ModifiedBy)
        {
            using (var dbe = new inventorymanagementEntities())
            {
                tbl_Product ui = dbe.tbl_Product.Where(a => a.ProductSKU == SKU).SingleOrDefault();
                if (ui != null)
                {

                    ui.StockStatus = StockStatus;
                    ui.IsHidden = IsHidden;
                    ui.ModifiedBy = ModifiedBy;
                    ui.ModifiedDate = ModifiedDate;
                    int kq = dbe.SaveChanges();
                    return kq.ToString();
                }
                else
                    return null;
            }
        }
        #endregion
        #region Select
        public static List<tbl_Product> GetByTextSearchIsHidden(string s, bool IsHidden)
        {
            using (var dbe = new inventorymanagementEntities())
            {
                List<tbl_Product> ags = new List<tbl_Product>();
                ags = dbe.tbl_Product.Where(p => p.ProductTitle.Contains(s) && p.IsHidden == IsHidden).OrderByDescending(o => o.ID).ToList();
                return ags;
            }
        }
        public static tbl_Product GetByID(int ID)
        {
            using (var dbe = new inventorymanagementEntities())
            {
                tbl_Product ai = dbe.tbl_Product.Where(a => a.ID == ID).SingleOrDefault();
                if (ai != null)
                {
                    return ai;
                }
                else return null;

            }
        }
        public static tbl_Product GetBySKU(string SKU)
        {
            using (var dbe = new inventorymanagementEntities())
            {
                tbl_Product ai = dbe.tbl_Product.Where(a => a.ProductSKU == SKU).SingleOrDefault();
                if (ai != null)
                {
                    return ai;
                }
                else return null;

            }
        }
        public static List<tbl_Product> GetAll(string s)
        {
            using (var dbe = new inventorymanagementEntities())
            {
                List<tbl_Product> ags = new List<tbl_Product>();
                ags = dbe.tbl_Product.Where(p => p.ProductTitle.Contains(s)).OrderByDescending(o => o.ID).ToList();
                return ags;
            }
        }
        public static List<tbl_Product> GetByCategoryID(int CategoryID)
        {
            using (var dbe = new inventorymanagementEntities())
            {
                List<tbl_Product> ags = new List<tbl_Product>();
                ags = dbe.tbl_Product.Where(p => p.CategoryID == CategoryID).OrderByDescending(o => o.ID).ToList();
                return ags;
            }
        }
        public static List<View_ProductList> View_GetByCategoryID(string s, int CategoryID)
        {
            using (var dbe = new inventorymanagementEntities())
            {
                List<View_ProductList> ags = new List<View_ProductList>();
                ags = dbe.View_ProductList.Where(p => p.ProductTitle.Contains(s) && p.CategoryID == CategoryID).OrderByDescending(o => o.ID).ToList();
                return ags;
            }
        }

        public static List<ProductSQL> GetAllSql(int categoryID, string textsearch)
        {
            var list = new List<ProductSQL>();
            String sql = String.Empty;

            sql += " BEGIN ";
            sql += "  ";
            sql += "     SELECT ";
            sql += "             PRD.* ";
            sql += "     INTO #Product ";
            sql += "     FROM ";
            sql += "             tbl_product AS PRD ";
            sql += "     WHERE ";
            sql += "             1 = 1 ";

            if (!string.IsNullOrEmpty(textsearch))
            {
                sql += " AND (PRD.ProductSKU like N'%" + textsearch + "%' OR PRD.ProductTitle like N'%" + textsearch + "%')";
            }

            if (categoryID > 0)
            {
                sql += " AND PRD.CategoryID = " + categoryID;
            }

            sql += "     ORDER BY ";
            sql += "             PRD.ID ";
            sql += "     ; ";
            sql += "  ";
            sql += "     CREATE INDEX [ID_PROCDUCT] ON #Product([ID]) ";
            sql += "  ";
            sql += "     SELECT ";
            sql += "             STM.ProductID ";
            sql += "     ,       STM.Quantity ";
            sql += "     ,       STM.QuantityCurrent ";
            sql += "     ,       STM.Type ";
            sql += "     ,       STM.CreatedDate ";
            sql += "     INTO #StockProduct ";
            sql += "     FROM ";
            sql += "             #Product AS PRD ";
            sql += "     INNER JOIN tbl_StockManager AS STM ";
            sql += "         ON  PRD.ID = STM.ProductID ";
            sql += "     ORDER BY ";
            sql += "             STM.ProductID ";
            sql += "     ,       STM.CreatedDate ";
            sql += "     ; ";
            sql += "  ";
            sql += "     CREATE INDEX [ID_PROCDUCT] ON #StockProduct( ";
            sql += "             [ProductID] ASC ";
            sql += "     ,       [CreatedDate] DESC ";
            sql += "     ) ";
            sql += "  ";
            sql += "     SELECT ";
            sql += "             STP.ProductID ";
            sql += "     ,       ( ";
            sql += "                 CASE STP.Type ";
            sql += "                     WHEN 1 ";
            sql += "                         THEN STP.QuantityCurrent + STP.Quantity ";
            sql += "                     WHEN 2 ";
            sql += "                         THEN STP.QuantityCurrent - STP.Quantity ";
            sql += "                     ELSE ";
            sql += "                         0 ";
            sql += "                 END ";
            sql += "             ) AS QuantityLeft ";
            sql += "     INTO #ProductQuantity ";
            sql += "     FROM ";
            sql += "             #StockProduct AS STP ";
            sql += "     INNER JOIN ( ";
            sql += "             SELECT ";
            sql += "                     ProductID ";
            sql += "             ,       MAX(CreatedDate) AS CreatedDate ";
            sql += "             FROM ";
            sql += "                     #StockProduct ";
            sql += "             GROUP BY ";
            sql += "                     ProductID ";
            sql += "         ) AS SPM ";
            sql += "         ON  STP.ProductID = SPM.ProductID ";
            sql += "         AND STP.CreatedDate = SPM.CreatedDate ";
            sql += "     ; ";
            sql += "  ";
            sql += "     CREATE INDEX [ID_PROCDUCT] ON #ProductQuantity([ProductID]) ";
            sql += "  ";
            sql += "     SELECT ";
            sql += "             p.ProductStyle AS ProductStyle ";
            sql += "     ,       c.CategoryName ";
            sql += "     ,       p.* ";
            sql += "     ,       PRQ.QuantityLeft ";
            sql += "     FROM ";
            sql += "             #Product AS p ";
            sql += "     LEFT JOIN #ProductQuantity AS PRQ ";
            sql += "         ON  p.ID = PRQ.ProductID ";
            sql += "     LEFT JOIN ( ";
            sql += "             SELECT ";
            sql += "                     ID ";
            sql += "             ,       CategoryName ";
            sql += "             FROM ";
            sql += "                     dbo.tbl_Category ";
            sql += "     ) AS c ";
            sql += "     ON c.ID = p.CategoryID ";
            sql += "     ORDER BY ";
            sql += "             p.ID ";
            sql += "     ; ";
            sql += "  ";
            sql += " END ";

            var reader = (IDataReader)SqlHelper.ExecuteDataReader(sql);

            while (reader.Read())
            {
                double quantityLeft = 0;

                var entity = new ProductSQL();

                entity.ID = Convert.ToInt32(reader["ID"]);

                if (!string.IsNullOrEmpty(reader["ProductImage"].ToString()))
                {
                    entity.ProductImage = reader["ProductImage"].ToString();
                }
                else
                {
                    entity.ProductImage = "/App_Themes/Ann/image/placeholder.png";
                }

                if (reader["ProductTitle"] != DBNull.Value)
                    entity.ProductTitle = reader["ProductTitle"].ToString();
                if (reader["ProductSKU"] != DBNull.Value)
                    entity.ProductSKU = reader["ProductSKU"].ToString();


                if (reader["QuantityLeft"] != DBNull.Value)
                {
                    quantityLeft = Convert.ToDouble(reader["QuantityLeft"]);

                    if (quantityLeft > 0)
                    {
                        entity.ProductInstockStatus = "<span class=\"bg-green\">Còn hàng</span>";
                        entity.StockStatus = 1;
                    }
                    else
                    {
                        entity.ProductInstockStatus = "<span class=\"bg-red\">Hết hàng</span>";
                        entity.StockStatus = 2;
                    }
                }
                else
                {
                    entity.ProductInstockStatus = "<span class=\"bg-yellow\">Nhập hàng</span>";
                    entity.StockStatus = 3;
                }

                entity.TotalProductInstockQuantityLeft = quantityLeft;
                if (reader["Regular_Price"] != DBNull.Value)
                    entity.RegularPrice = Convert.ToDouble(reader["Regular_Price"].ToString());
                if (reader["CostOfGood"] != DBNull.Value)
                    entity.CostOfGood = Convert.ToDouble(reader["CostOfGood"].ToString());
                if (reader["Retail_Price"] != DBNull.Value)
                    entity.RetailPrice = Convert.ToDouble(reader["Retail_Price"].ToString());
                if (reader["CategoryName"] != DBNull.Value)
                    entity.CategoryName = reader["CategoryName"].ToString();
                if (reader["CategoryID"] != DBNull.Value)
                    entity.CategoryID = reader["CategoryID"].ToString().ToInt(0);
                if (reader["CreatedDate"] != DBNull.Value)
                    entity.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                if (reader["ProductContent"] != DBNull.Value)
                    entity.ProductContent = reader["ProductContent"].ToString();
                if (reader["ProductStyle"] != DBNull.Value)
                    entity.ProductStyle = reader["ProductStyle"].ToString().ToInt(0);

                list.Add(entity);
            }
            reader.Close();
            return list.OrderByDescending(x => x.CreatedDate).ToList();
        }

        
        public static ProductStock GetStock(int ProductVariableID)
        {
            var entity = new ProductStock();
            var sql = @"select t.ID,t.SKU,t.ID, d.quantiyIN as InProduct, k.quantiyIN as OutProduct, (d.quantiyIN - k.quantiyIN) as leftProduct from tbl_ProductVariable as t";
            sql += " left outer join (select  ProductVariableID, sum(quantity) as quantiyIN from tbl_StockManager where [Type]= 1 group by ProductVariableID) as d ON t.ID = d.ProductVariableID ";
            sql += " left outer join (select ProductVariableID, sum(quantity) as quantiyIN from tbl_StockManager where [Type]= 2 group by ProductVariableID) as k ON t.ID = k.ProductVariableID ";
            if (ProductVariableID > 0)
            {
                sql += " Where t.ID = " + ProductVariableID;
            }
            var reader = (IDataReader)SqlHelper.ExecuteDataReader(sql);

            while (reader.Read())
            {
                int quantityIn = reader["InProduct"].ToString().ToInt(0);
                int quantityOut = reader["OutProduct"].ToString().ToInt(0);
                int quantityLeft = quantityIn - quantityOut;


                if (quantityIn > 0)
                {
                    if (quantityLeft > 0)
                    {
                        entity.ProductInstockStatus = "<span class=\"bg-green\">Còn hàng</span>";

                    }
                    else
                    {
                        entity.ProductInstockStatus = "<span class=\"bg-red\">Hết hàng</span>";
                    }
                }
                else
                {
                    entity.ProductInstockStatus = "<span class=\"bg-yellow\">Nhập hàng</span>";

                }
                entity.quantityLeft = quantityLeft;
            }
            reader.Close();
            return entity;
        }
        #endregion
        #region Class
        public class ProductSQL
        {
            public int ID { get; set; }
            public string ProductImage { get; set; }
            public string ProductTitle { get; set; }
            public string ProductSKU { get; set; }
            public string ProductInstockStatus { get; set; }
            public double TotalProductInstockQuantityIn { get; set; }
            public double TotalProductInstockQuantityOut { get; set; }
            public double TotalProductInstockQuantityLeft { get; set; }
            public string ProductContent { get; set; }
            public double RegularPrice { get; set; }
            public double CostOfGood { get; set; }
            public double RetailPrice { get; set; }
            public int CategoryID { get; set; }
            public string CategoryName { get; set; }
            public DateTime CreatedDate { get; set; }
            public int StockStatus { get; set; }
            public int ProductStyle { get; set; }
        }

        public class ProductStock
        {
            public string ProductInstockStatus { get; set; }
            public int quantityLeft { get; set; }
        }
        #endregion
    }
}