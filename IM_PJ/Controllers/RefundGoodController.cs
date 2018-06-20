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
    public class RefundGoodController
    {
        #region CRUD
        public static int Insert(int AgentID, string TotalPrice, int Status, int CustomerID, double TotalQuantity, string TotalRefundFee,
            string AgentName, string CustomerName, string CustomerPhone, DateTime CreatedDate, string CreatedBy, string RefundNote)
        {
            using (var dbe = new inventorymanagementEntities())
            {
                tbl_RefundGoods a = new tbl_RefundGoods();
                a.AgentID = AgentID;
                a.TotalPrice = TotalPrice;
                a.Status = Status;
                a.CustomerID = CustomerID;
                a.TotalQuantity = TotalQuantity;
                a.TotalRefundFee = TotalRefundFee;
                a.AgentName = AgentName;
                a.CustomerName = CustomerName;
                a.CustomerPhone = CustomerPhone;
                a.CreatedDate = CreatedDate;
                a.CreatedBy = CreatedBy;
                a.RefundNote = RefundNote;
                dbe.tbl_RefundGoods.Add(a);
                dbe.SaveChanges();
                int kq = a.ID;
                return kq;
            }
        }
        public static string updatestatus(int ID, int status, DateTime ModifiedDate, string ModifiedBy, string Note)
        {
            using (var dbe = new inventorymanagementEntities())
            {

                var a = dbe.tbl_RefundGoods.Where(ac => ac.ID == ID).SingleOrDefault();
                if (a != null)
                {
                    a.Status = status;
                    a.RefundNote = Note;
                    a.ModifiedBy = ModifiedBy;
                    a.ModifiedDate = ModifiedDate;
                    dbe.Configuration.ValidateOnSaveEnabled = false;
                    string kq = dbe.SaveChanges().ToString();
                    return kq;
                }
                else
                    return null;
            }
        }

        #endregion
        #region Select        
        public static List<tbl_RefundGoods> GetAll(string s)
        {
            using (var dbe = new inventorymanagementEntities())
            {
                List<tbl_RefundGoods> las = new List<tbl_RefundGoods>();
                las = dbe.tbl_RefundGoods.OrderByDescending(r => r.CreatedDate).ToList();
                return las;
            }
        }
        public static List<tbl_RefundGoods> GetByCustomerID(int CustomerID)
        {
            using (var dbe = new inventorymanagementEntities())
            {
                List<tbl_RefundGoods> las = new List<tbl_RefundGoods>();
                las = dbe.tbl_RefundGoods.Where(r => r.CustomerID == CustomerID).OrderByDescending(r => r.CreatedDate).ToList();
                return las;
            }
        }

        public static List<tbl_RefundGoods> GetByAgentIDCustomerIDFromDateToDate(int AgentID, int CustomerID, DateTime FromDate, DateTime ToDate)
        {
            using (var dbe = new inventorymanagementEntities())
            {
                List<tbl_RefundGoods> las = new List<tbl_RefundGoods>();
                las = dbe.tbl_RefundGoods.Where(r => r.AgentID == AgentID && r.CustomerID == CustomerID && r.CreatedDate >= FromDate && r.CreatedDate < ToDate).OrderByDescending(r => r.CreatedDate).ToList();
                return las;
            }
        }
        public static List<tbl_RefundGoods> GetByAgentID(int AgentID)
        {
            using (var dbe = new inventorymanagementEntities())
            {
                List<tbl_RefundGoods> las = new List<tbl_RefundGoods>();
                las = dbe.tbl_RefundGoods.Where(r => r.AgentID == AgentID).OrderByDescending(r => r.CreatedDate).ToList();
                return las;
            }
        }
        public static List<tbl_RefundGoods> GetByAgent(int AgentID)
        {
            using (var dbe = new inventorymanagementEntities())
            {
                List<tbl_RefundGoods> las = new List<tbl_RefundGoods>();

                las = dbe.tbl_RefundGoods.Where(r => r.AgentID == AgentID).OrderByDescending(r => r.CreatedDate).ToList();
                var a = las.GroupBy(r => r.CreatedBy).ToList();
                return las;
            }
        }
        public static tbl_RefundGoods GetByID(int ID)
        {
            using (var dbe = new inventorymanagementEntities())
            {
                tbl_RefundGoods acc = dbe.tbl_RefundGoods.Where(a => a.ID == ID).FirstOrDefault();
                if (acc != null)
                    return acc;
                else
                    return null;
            }
        }

        public static tbl_RefundGoods GetOrderByID(int ID)
        {
            using (var dbe = new inventorymanagementEntities())
            {
                tbl_RefundGoods acc = dbe.tbl_RefundGoods.Where(a => a.ID == ID && a.Status == 1).FirstOrDefault();
                if (acc != null)
                    return acc;
                else
                    return null;
            }
        }
        public static tbl_RefundGoods GetByIDAndAgentID(int ID, int AgentID)
        {
            using (var dbe = new inventorymanagementEntities())
            {
                var las = dbe.tbl_RefundGoods.Where(r => r.AgentID == AgentID && r.ID == ID).FirstOrDefault();
                if (las != null)
                    return las;
                else return null;
            }
        }

        public static int UpdateStatus(int ID, string createdby, int status)
        {
            using (var dbe = new inventorymanagementEntities())
            {
                var las = dbe.tbl_RefundGoods.Where(r => r.ID == ID).FirstOrDefault();
                if (las != null)
                {
                    las.Status = status;
                    las.ModifiedBy = createdby;
                    las.ModifiedDate = DateTime.Now;
                   int i = dbe.SaveChanges();
                    return i;
                }
                return 0;
            }
        }

        public static List<tbl_RefundGoods> Search(string s, int n, int status, string by)
        {
            using (var dbe = new inventorymanagementEntities())
            {
                List<tbl_RefundGoods> ags = new List<tbl_RefundGoods>();
                if (!string.IsNullOrEmpty(s))
                {
                    if (n > 0)
                    {
                        if (status > 0)
                        {
                            if (!string.IsNullOrEmpty(by))
                            {
                                ags = dbe.tbl_RefundGoods.Where(x => x.CustomerName.Contains(s) && x.AgentID == n && x.Status == status && x.CreatedBy == by || x.CreatedBy == by && x.CustomerPhone.Contains(s) && x.AgentID == n && x.Status == status).ToList();
                            }
                            else
                            {
                                ags = dbe.tbl_RefundGoods.Where(x => x.CustomerName.Contains(s) && x.AgentID == n && x.Status == status || x.CustomerPhone.Contains(s) && x.AgentID == n && x.Status == status).ToList();

                            }
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(by))
                            {
                                ags = dbe.tbl_RefundGoods.Where(x => x.CustomerName.Contains(s) && x.AgentID == n && x.CreatedBy == by || x.CreatedBy == by && x.CustomerPhone.Contains(s) && x.AgentID == n).ToList();

                            }
                            else
                            {
                                ags = dbe.tbl_RefundGoods.Where(x => x.CustomerName.Contains(s) && x.AgentID == n || x.CustomerPhone.Contains(s) && x.AgentID == n).ToList();

                            }
                        }
                    }
                    else
                    {
                        if (status > 0)
                        {

                            ags = dbe.tbl_RefundGoods.Where(x => x.CustomerName.Contains(s) && x.AgentID == n && x.Status == status || x.CustomerPhone.Contains(s) && x.AgentID == n && x.Status == status).ToList();
                        }
                        else
                        {
                            ags = dbe.tbl_RefundGoods.Where(x => x.CustomerName.Contains(s) || x.CustomerPhone.Contains(s)).ToList();
                        }

                    }
                }
                else
                {
                    if (n > 0)
                    {
                        if (status > 0)
                        {
                            if (!string.IsNullOrEmpty(by))
                            {
                                ags = dbe.tbl_RefundGoods.Where(x => x.AgentID == n && x.Status == status && x.CreatedBy == by).ToList();
                            }
                            else
                            {
                                ags = dbe.tbl_RefundGoods.Where(x => x.AgentID == n && x.Status == status).ToList();
                            }

                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(by))
                            {
                                ags = dbe.tbl_RefundGoods.Where(x => x.AgentID == n && x.CreatedBy == by).ToList();
                            }
                            else
                            {
                                ags = dbe.tbl_RefundGoods.Where(x => x.AgentID == n).ToList();
                            }

                        }
                    }
                    else
                    {
                        if (status > 0)
                        {
                            if (!string.IsNullOrEmpty(by))
                            {
                                ags = dbe.tbl_RefundGoods.Where(x => x.Status == status && x.CreatedBy == by).ToList();
                            }
                            else
                            {
                                ags = dbe.tbl_RefundGoods.Where(x => x.Status == status).ToList();
                            }

                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(by))
                            {
                                ags = dbe.tbl_RefundGoods.Where(x => x.CreatedBy == by).ToList();
                            }
                            else
                            {
                                ags = dbe.tbl_RefundGoods.ToList();
                            }

                        }

                    }
                }
                return ags.OrderByDescending(x => x.CreatedDate).ToList();
            }
        }

        public static List<tbl_RefundGoods> TotalRefund(string fromdate, string todate)
        {
            using (var db = new inventorymanagementEntities())
            {
                List<tbl_RefundGoods> or = new List<tbl_RefundGoods>();
                if (!string.IsNullOrEmpty(fromdate))
                {
                    if (!string.IsNullOrEmpty(todate))
                    {
                        DateTime fd = Convert.ToDateTime(fromdate);
                        DateTime td = Convert.ToDateTime(todate);
                        or = db.tbl_RefundGoods
                            .Where(r => r.CreatedDate >= fd && r.CreatedDate <= td)
                            .OrderByDescending(r => r.ID).ToList();
                    }
                    else
                    {
                        DateTime fd = Convert.ToDateTime(fromdate);
                        or = db.tbl_RefundGoods
                            .Where(r => r.CreatedDate >= fd)
                            .OrderByDescending(r => r.ID).ToList();
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(todate))
                    {
                        DateTime td = Convert.ToDateTime(todate);
                        or = db.tbl_RefundGoods
                            .Where(r => r.CreatedDate <= td)
                            .OrderByDescending(r => r.ID).ToList();
                    }
                    else
                    {
                        or = db.tbl_RefundGoods.ToList();
                    }
                }
                return or;
            }
        }

        public static int GetTotalRefundByAccount(string accountName, DateTime fromdate, DateTime todate)
        {
            using (var db = new inventorymanagementEntities())
            {
                List<tbl_RefundGoods> or = new List<tbl_RefundGoods>();
                or = db.tbl_RefundGoods
                            .Where(x => (fromdate <= x.CreatedDate && x.CreatedDate <= todate)
                                        && x.CreatedBy.Trim().ToUpper() == accountName.Trim().ToUpper())
                            .ToList();
                int tongdoitra = 0;
                if (or != null)
                {
                    foreach (var item in or)
                    {
                        var oddetail = RefundGoodDetailController.GetByRefundGoodsID(item.ID);
                        if (oddetail != null)
                        {
                            foreach (var temp in oddetail)
                            {
                                tongdoitra += Convert.ToInt32(temp.Quantity);
                            }
                        }
                    }
                }
                return tongdoitra;
            }
        }
        #endregion
    }
}