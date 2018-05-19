using IM_PJ.Models;
using MB.Extensions;
using NHST.Bussiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebUI.Business;
using System.Text.RegularExpressions;


namespace IM_PJ.Controllers
{
    public class CustomerController
    {
        #region CRUD
        public static string Insert(string CustomerName, string CustomerPhone, string CustomerAddress, string CustomerEmail, int CustomerLevelID, int Status,
            DateTime CreatedDate, string CreatedBy, bool IsHidden, string Zalo, string Facebook, string Note, string Province, string Nick)
        {
            using (var dbe = new inventorymanagementEntities())
            {
                tbl_Customer ui = new tbl_Customer();
                ui.CustomerName = CustomerName;
                ui.CustomerPhone = CustomerPhone;
                ui.CustomerAddress = CustomerAddress;
                if (!string.IsNullOrEmpty(CustomerEmail))
                    ui.CustomerEmail = CustomerEmail;
                ui.CustomerLevelID = CustomerLevelID;
                ui.Status = Status;
                ui.CreatedDate = CreatedDate;
                ui.CreatedBy = CreatedBy;
                ui.IsHidden = IsHidden;
                if (!string.IsNullOrEmpty(Zalo))
                    ui.Zalo = Zalo;
                if (!string.IsNullOrEmpty(Facebook))
                    ui.Facebook = Facebook;
                if (!string.IsNullOrEmpty(Note))
                    ui.Note = Note;
                if (!string.IsNullOrEmpty(Province))
                    ui.ProvinceID = Province.ToInt();
                ui.Nick = Nick;
                dbe.tbl_Customer.Add(ui);
                dbe.SaveChanges();
                int kq = ui.ID;
                return kq.ToString();
            }
        }
        public static string Update(int ID, string CustomerName, string CustomerPhone, string CustomerAddress, string CustomerEmail, int CustomerLevelID, int Status,
           string CreatedBy, DateTime ModifiedDate, string ModifiedBy, bool IsHidden, string Zalo, string Facebook, string Note, string Province, string Nick)
        {
            using (var dbe = new inventorymanagementEntities())
            {
                tbl_Customer ui = dbe.tbl_Customer.Where(a => a.ID == ID).SingleOrDefault();
                if (ui != null)
                {
                    ui.CustomerName = CustomerName;
                    ui.CustomerPhone = CustomerPhone;
                    ui.CustomerAddress = CustomerAddress;
                    ui.CustomerEmail = CustomerEmail;
                    ui.CustomerLevelID = CustomerLevelID;
                    ui.Status = Status;
                    ui.CreatedBy = CreatedBy;
                    ui.ModifiedBy = ModifiedBy;
                    ui.ModifiedDate = ModifiedDate;
                    ui.IsHidden = IsHidden;
                    ui.Zalo = Zalo;
                    ui.Facebook = Facebook;
                    ui.Note = Note;
                    ui.Nick = Nick;
                    if (!string.IsNullOrEmpty(Province))
                        ui.ProvinceID = Province.ToInt();
                    int kq = dbe.SaveChanges();
                    return kq.ToString();
                }
                else
                    return null;
            }
        }
        #endregion
        #region Select
        public static tbl_Customer GetByPhone(string CustomerPhone)
        {
            using (var dbe = new inventorymanagementEntities())
            {
                tbl_Customer ai = dbe.tbl_Customer.Where(a => a.CustomerPhone == CustomerPhone).FirstOrDefault();
                if (ai != null)
                {
                    return ai;
                }
                else return null;

            }
        }
        public static string convertToUnSign(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(System.Text.NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
        public static List<tbl_Customer> Find2(string text)
        {
            string text2 = convertToUnSign(text);
            using (var dbe = new inventorymanagementEntities())
            {
                var a = dbe.tbl_Customer.Where(delegate (tbl_Customer x)
                {
                    if (convertToUnSign(x.CustomerName).IndexOf(text2, StringComparison.CurrentCultureIgnoreCase) >= 0)
                        return true;
                    else
                        return false;
                }).ToList();
                var i = dbe.tbl_Customer.Where(x => x.CustomerName.Contains(text2) || x.CustomerName.Contains(text) || x.Nick.Contains(text) || x.Nick.Contains(text2) || x.CustomerPhone.Contains(text) || x.Zalo.Contains(text)).ToList();
                var ai = a.Concat(i).ToList();
                if (ai.Count() > 0)
                    return ai;
                return null;
            }
        }
        public static List<CustomerOut> Find(string text)
        {
            string textsearch = '"' + text + '"';
            var list = new List<CustomerOut>();
            var sql = @"select c.ID, c.CustomerName, c.Nick, c.CustomerPhone, c.Zalo, c.Facebook, c.CustomerAddress, c.ProvinceID as Province
                        from tbl_Customer c
                         WHERE CONTAINS(c.CustomerName,'" + textsearch + "')  OR CONTAINS(c.Nick,'" + textsearch + "') OR c.CustomerPhone like '%" + text + "%' OR c.Facebook like '%" + text + "%' OR c.Zalo like '%" + text + "%'";

            var reader = (IDataReader)SqlHelper.ExecuteDataReader(sql);
            while (reader.Read())
            {
                var entity = new CustomerOut();
                if (reader["ID"] != DBNull.Value)
                    entity.ID = reader["ID"].ToString().ToInt(0);
                if (reader["CustomerName"] != DBNull.Value)
                    entity.CustomerName = reader["CustomerName"].ToString();
                if (reader["CustomerPhone"] != DBNull.Value)
                    entity.CustomerPhone = reader["CustomerPhone"].ToString();
                if (reader["CustomerAddress"] != DBNull.Value)
                    entity.CustomerAddress = reader["CustomerAddress"].ToString();
                if (reader["Zalo"] != DBNull.Value)
                    entity.Zalo = reader["Zalo"].ToString();
                if (reader["Facebook"] != DBNull.Value)
                    entity.Facebook = reader["Facebook"].ToString();
                if (reader["Nick"] != DBNull.Value)
                    entity.Nick = reader["Nick"].ToString();
                if (reader["Province"] != DBNull.Value)
                {
                    var provinceID = reader["Province"].ToString().ToInt();
                    var pro = ProvinceController.GetByID(provinceID);
                    if (pro != null)
                    {
                        entity.Province = pro.ProvinceName;
                    }
                    else
                    {
                        entity.Province = "";
                    }
                    
                }

                list.Add(entity);
            }
            reader.Close();
            return list;
        }
        public static tbl_Customer GetByID(int ID)
        {
            using (var dbe = new inventorymanagementEntities())
            {
                tbl_Customer ai = dbe.tbl_Customer.Where(a => a.ID == ID).FirstOrDefault();
                if (ai != null)
                {
                    return ai;
                }
                else return null;

            }
        }
        public static List<tbl_Customer> GetAll(string s)
        {
            using (var dbe = new inventorymanagementEntities())
            {
                List<tbl_Customer> ags = new List<tbl_Customer>();
                ags = dbe.tbl_Customer.Where(c => c.CustomerName.Contains(s) || c.CustomerPhone.Contains(s) || c.Zalo.Contains(s) || c.Facebook.Contains(s)).ToList();
                return ags;
            }
        }

        public static List<CustomerOut> Get(string textsearch, int Discount, string by, int Provice)
        {
            var list = new List<CustomerOut>();
            var sql = @"select c.ID, c.CustomerName, c.Nick, c.CustomerPhone, c.Zalo, c.Facebook, c.CreatedBy, c.CreatedDate, dg.DiscountName, dg.ID as DiscountID, c.ProvinceID as Province
                        from tbl_DiscountCustomer dc, tbl_DiscountGroup dg, tbl_Customer c
                        where dc.DiscountGroupID = dg.ID and c.ID = dc.UID";
            if (!string.IsNullOrEmpty(textsearch))
            {
                sql += " And (c.CustomerName like N'%" + textsearch + "%' OR c.CustomerPhone like N'%" + textsearch + "%'OR c.Facebook like N'%" + textsearch + "%'OR c.Zalo like N'%" + textsearch + "%')";
            }
            if (Discount > 0)
            {
                sql += " AND dg.ID  = " + Discount;
            }
            if (Provice > 0)
            {
                sql += " AND c.ProvinceID  = " + Provice;
            }
            if (!string.IsNullOrEmpty(by))
            {
                sql += " And c.CreatedBy = N'" + by + "'";
            }
            var reader = (IDataReader)SqlHelper.ExecuteDataReader(sql);
            while (reader.Read())
            {
                var entity = new CustomerOut();
                if (reader["ID"] != DBNull.Value)
                    entity.ID = reader["ID"].ToString().ToInt(0);
                if (reader["CustomerName"] != DBNull.Value)
                    entity.CustomerName = reader["CustomerName"].ToString();
                if (reader["Nick"] != DBNull.Value)
                    entity.Nick = reader["Nick"].ToString();
                if (reader["CustomerPhone"] != DBNull.Value)
                    entity.CustomerPhone = reader["CustomerPhone"].ToString();
                if (reader["Zalo"] != DBNull.Value)
                    entity.Zalo = reader["Zalo"].ToString();
                if (reader["Facebook"] != DBNull.Value)
                    entity.Facebook = reader["Facebook"].ToString();
                if (reader["CreatedDate"] != DBNull.Value)
                    entity.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                if (reader["CreatedBy"] != DBNull.Value)
                    entity.CreatedBy = reader["CreatedBy"].ToString();
                if (reader["DiscountName"] != DBNull.Value)
                    entity.DiscountName = reader["DiscountName"].ToString();
                if (reader["Province"] != DBNull.Value)
                    entity.Province = reader["Province"].ToString();

                //if (reader["IsHidden"] != DBNull.Value)
                //entity.IsHidden = reader["IsHidden"].ToString();
                list.Add(entity);
            }
            reader.Close();
            return list;
        }

        public static List<CustomerOut> GetKH(string textsearch, string by, int Provice)
        {
            var list = new List<CustomerOut>();
            var sql = @"select c.ID, c.CustomerName, c.Nick, c.CustomerPhone, c.Zalo, c.Facebook, c.CreatedBy, c.CreatedDate, c.ProvinceID as Province
                        from tbl_Customer c
                         WHERE 1 = 1";
            if (!string.IsNullOrEmpty(textsearch))
            {
                sql += " And (c.CustomerName like N'%" + textsearch + "%' OR c.CustomerPhone like N'%" + textsearch + "%'OR c.Facebook like N'%" + textsearch + "%'OR c.Zalo like N'%" + textsearch + "%')";
            }
           
            if (Provice > 0)
            {
                sql += " AND c.ProvinceID  = " + Provice;
            }
            if (!string.IsNullOrEmpty(by))
            {
                sql += " And c.CreatedBy = N'" + by + "'";
            }
            var reader = (IDataReader)SqlHelper.ExecuteDataReader(sql);
            while (reader.Read())
            {
                var entity = new CustomerOut();
                if (reader["ID"] != DBNull.Value)
                    entity.ID = reader["ID"].ToString().ToInt(0);
                if (reader["CustomerName"] != DBNull.Value)
                    entity.CustomerName = reader["CustomerName"].ToString();
                if (reader["CustomerPhone"] != DBNull.Value)
                    entity.CustomerPhone = reader["CustomerPhone"].ToString();
                if (reader["Zalo"] != DBNull.Value)
                    entity.Zalo = reader["Zalo"].ToString();
                if (reader["Facebook"] != DBNull.Value)
                    entity.Facebook = reader["Facebook"].ToString();
                if (reader["CreatedDate"] != DBNull.Value)
                    entity.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                if (reader["CreatedBy"] != DBNull.Value)
                    entity.CreatedBy = reader["CreatedBy"].ToString();
                if (reader["Nick"] != DBNull.Value)
                    entity.Nick = reader["Nick"].ToString();
                if (reader["Province"] != DBNull.Value)
                    entity.Province = reader["Province"].ToString();

                //if (reader["IsHidden"] != DBNull.Value)
                //entity.IsHidden = reader["IsHidden"].ToString();
                list.Add(entity);
            }
            reader.Close();
            return list;
        }
        public static List<CustomerGet> GetNotInGroupByGroupID(int GroupID)
        {
            var list = new List<CustomerGet>();
            var sql = @"SELECT  l.ID, l.CustomerName, l.CustomerPhone FROM tbl_Customer l";
            sql += " LEFT JOIN (Select UID, CustomerName from tbl_DiscountCustomer where DiscountGroupID = " + GroupID + " ) as r ON  r.UID = l.ID";
            sql += " WHERE r.UID IS NULL";

            var reader = (IDataReader)SqlHelper.ExecuteDataReader(sql);
            while (reader.Read())
            {
                var entity = new CustomerGet();
                if (reader["ID"] != DBNull.Value)
                    entity.ID = reader["ID"].ToString().ToInt(0);
                if (reader["CustomerName"] != DBNull.Value)
                    entity.CustomerName = reader["CustomerName"].ToString();
                if (reader["CustomerPhone"] != DBNull.Value)
                    entity.CustomerPhone = reader["CustomerPhone"].ToString();
                list.Add(entity);
            }
            reader.Close();
            return list;
        }
        public static List<tbl_Customer> GetBylevelID(int LevelID)
        {
            using (var dbe = new inventorymanagementEntities())
            {
                List<tbl_Customer> ags = new List<tbl_Customer>();
                ags = dbe.tbl_Customer.Where(a => a.CustomerLevelID == LevelID).ToList();
                return ags;
            }
        }

        public static List<tbl_Customer> TotalCustomer(string fromdate, string todate)
        {
            using (var db = new inventorymanagementEntities())
            {
                List<tbl_Customer> or = new List<tbl_Customer>();
                if (!string.IsNullOrEmpty(fromdate))
                {
                    if (!string.IsNullOrEmpty(todate))
                    {
                        DateTime fd = Convert.ToDateTime(fromdate);
                        DateTime td = Convert.ToDateTime(todate);
                        or = db.tbl_Customer
                            .Where(r => r.CreatedDate >= fd && r.CreatedDate <= td)
                            .OrderByDescending(r => r.ID).ToList();
                    }
                    else
                    {
                        DateTime fd = Convert.ToDateTime(fromdate);
                        or = db.tbl_Customer
                            .Where(r => r.CreatedDate >= fd)
                            .OrderByDescending(r => r.ID).ToList();
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(todate))
                    {
                        DateTime td = Convert.ToDateTime(todate);
                        or = db.tbl_Customer
                            .Where(r => r.CreatedDate <= td)
                            .OrderByDescending(r => r.ID).ToList();
                    }
                    else
                    {
                        or = db.tbl_Customer.ToList();
                    }
                }
                return or;
            }
        }
        #endregion
        #region Class
        public class CustomerGet
        {
            public int ID { get; set; }
            public string CustomerName { get; set; }
            public string CustomerPhone { get; set; }
        }

        public class CustomerOut
        {
            public int ID { get; set; }
            public string CustomerName { get; set; }
            public string CustomerPhone { get; set; }
            public string CustomerAddress { get; set; }
            public string Zalo { get; set; }
            public string Facebook { get; set; }
            public string CreatedBy { get; set; }
            public string DiscountName { get; set; }
            public DateTime CreatedDate { get; set; }
            public string IsHidden { get; set; }
            public string Province { get; set; }

            public string DisID { get; set; }
            public string Nick { get; set; }
        }
        #endregion
    }
}