using IM_PJ.Models;
using NHST.Bussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IM_PJ.Controllers
{
    public class InOutProductVariableController
    {
        #region CRUD
        public static string Insert(int AgentID, int ProductID, int ProductVariableID, string ProductVariableName, string ProductVariableValue, double Quantity,
            double QuantityCurrent, int Type, bool IsHidden, int ProductType, string Note, int OrderID, int SessionInOutID, int Status,
            string ProductName, string SKU, string ProductImage, string ProductVariable, DateTime CreatedDate, string CreatedBy,int MoveProID,
            int ParentID)
        {
            using (var dbe = new inventorymanagementEntities())
            {
                tbl_InOutProductVariable ui = new tbl_InOutProductVariable();
                ui.AgentID = AgentID;
                ui.ProductID = ProductID;
                ui.ProductVariableID = ProductVariableID;
                ui.ProductVariableName = ProductVariableName;
                ui.ProductVariableValue = ProductVariableValue;
                ui.Quantity = Quantity;
                ui.QuantityCurrent = QuantityCurrent;
                ui.Type = Type;
                ui.IsHidden = IsHidden;
                ui.ProductType = ProductType;
                ui.Note = Note;
                ui.OrderID = OrderID;
                ui.SessionInOutID = SessionInOutID;
                ui.Status = Status;
                ui.ProductName = ProductName;
                ui.SKU = SKU;
                ui.ProductImage = ProductImage;
                ui.ProductVariable = ProductVariable;
                ui.ParentID = ParentID;
                ui.CreatedDate = CreatedDate;
                ui.CreatedBy = CreatedBy;
                ui.MoveProID = MoveProID;
                dbe.tbl_InOutProductVariable.Add(ui);
                int kq = dbe.SaveChanges();
                return kq.ToString();
            }
        }
        public static string Update(int ID, int AgentID, int ProductVariableID, string ProductVariableName, string ProductVariableValue, double Quantity,
            double QuantityCurrent, int Type, bool IsHidden, string Note, int OrderID, int SessionInOutID, int Status,
            string ProductName, string SKU, string ProductImage, string ProductVariable, DateTime ModifiedDate, string ModifiedBy)
        {
            using (var dbe = new inventorymanagementEntities())
            {
                tbl_InOutProductVariable ui = dbe.tbl_InOutProductVariable.Where(a => a.ID == ID).SingleOrDefault();
                if (ui != null)
                {
                    ui.AgentID = AgentID;
                    ui.ProductVariableID = ProductVariableID;
                    ui.ProductVariableName = ProductVariableName;
                    ui.ProductVariableValue = ProductVariableValue;
                    ui.Quantity = Quantity;
                    ui.QuantityCurrent = QuantityCurrent;
                    ui.Type = Type;
                    ui.IsHidden = IsHidden;
                    ui.Note = Note;
                    ui.OrderID = OrderID;
                    ui.SessionInOutID = SessionInOutID;
                    ui.Status = Status;
                    ui.ProductName = ProductName;
                    ui.SKU = SKU;
                    ui.ProductImage = ProductImage;
                    ui.ProductVariable = ProductVariable;
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
        public static tbl_InOutProductVariable GetByID(int ID)
        {
            using (var dbe = new inventorymanagementEntities())
            {
                tbl_InOutProductVariable ai = dbe.tbl_InOutProductVariable.Where(a => a.ID == ID).SingleOrDefault();
                if (ai != null)
                {
                    return ai;
                }
                else return null;

            }
        }
        public static List<tbl_InOutProductVariable> GetAll()
        {
            using (var dbe = new inventorymanagementEntities())
            {
                List<tbl_InOutProductVariable> ags = new List<tbl_InOutProductVariable>();
                ags = dbe.tbl_InOutProductVariable.ToList();
                return ags;
            }
        }
        public static List<tbl_InOutProductVariable> GetByProductName(int AgentID,string ProductName)
        {
            using (var dbe = new inventorymanagementEntities())
            {
                List<tbl_InOutProductVariable> ags = new List<tbl_InOutProductVariable>();
                ags = dbe.tbl_InOutProductVariable.Where(i => i.AgentID == AgentID && i.ProductName.Contains(ProductName)).ToList();
                return ags;
            }
        }
        public static List<tbl_InOutProductVariable> GetBySKU(int AgentID, string SKU)
        {
            using (var dbe = new inventorymanagementEntities())
            {
                List<tbl_InOutProductVariable> ags = new List<tbl_InOutProductVariable>();
                ags = dbe.tbl_InOutProductVariable.Where(i => i.AgentID == AgentID && i.SKU == SKU).ToList();
                return ags;
            }
        }

        public static List<tbl_InOutProductVariable> GetBySKU(string SKU)
        {
            using (var dbe = new inventorymanagementEntities())
            {
                List<tbl_InOutProductVariable> ags = new List<tbl_InOutProductVariable>();
                ags = dbe.tbl_InOutProductVariable.Where(i => i.SKU == SKU).ToList();
                return ags;
            }
        }
        #endregion
    }
}