using IM_PJ.Controllers;
using IM_PJ.Models;
using MB.Extensions;
using NHST.Bussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using static IM_PJ.Controllers.DiscountCustomerController;

namespace IM_PJ
{
    public partial class them_don_tra_hang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Session["userLoginSystem"] = "admin";
                if (Session["userLoginSystem"] != null)
                {
                    string username = Session["userLoginSystem"].ToString();
                    var acc = AccountController.GetByUsername(username);
                    if (acc != null)
                    {

                    }
                }
                else
                {
                    Response.Redirect("/dang-nhap");
                }
                //LoadData();
            }
        }
        [WebMethod]
        public static string checkphone(string phonefullname)
        {
            RefundCust rf = new RefundCust();
            int AgentID = 0;
            string username = HttpContext.Current.Session["userLoginSystem"].ToString();
            if (!string.IsNullOrEmpty(username))
            {
                var a = AccountController.GetByUsername(username);
                if (a != null)
                {
                    AgentID = Convert.ToInt32(a.AgentID);
                }
            }
            var customer = CustomerController.GetByPhone(phonefullname);
            if (customer != null)
            {

                rf.CustName = customer.CustomerName;
                rf.CustPhone = customer.CustomerPhone;
                rf.CustZalo = customer.Zalo;
                rf.CustFB = customer.Facebook;
                rf.CustAddress = customer.CustomerAddress;


                int custID = customer.ID;
                double FeeRefund = 0;
                double NumOfDateToChangeProduct = 0;
                double NumOfProductCanChange = 0;
                var config = ConfigController.GetByTop1();
                if (config != null)
                {
                    FeeRefund = Convert.ToDouble(config.FeeChangeProduct);
                    NumOfDateToChangeProduct = Convert.ToDouble(config.NumOfDateToChangeProduct);
                    NumOfProductCanChange = Convert.ToDouble(config.NumOfProductCanChange);
                }
                var d = DiscountCustomerController.getbyCustID(custID);
                if (d.Count > 0)
                {
                    FeeRefund = d[0].FeeRefund;
                    NumOfDateToChangeProduct = d[0].NumOfDateToChangeProduct;
                    NumOfProductCanChange = d[0].NumOfProductCanChange;
                }

                DateTime toDate = DateTime.Now.Date;
                var fromDate = toDate.AddDays(-NumOfDateToChangeProduct);

                double totalProductRefund = 0;
                var refundList = RefundGoodController.GetByAgentIDCustomerIDFromDateToDate(AgentID, custID, fromDate, toDate.AddDays(1));
                if (refundList.Count > 0)
                {
                    foreach (var item in refundList)
                    {
                        var rfD = RefundGoodDetailController.GetByRefundGoodsID(item.ID);
                        if (rfD.Count > 0)
                        {
                            foreach (var fd in rfD)
                            {
                                totalProductRefund += Convert.ToDouble(fd.Quantity);
                            }
                        }
                    }
                }
                double leftCanchange = NumOfProductCanChange - totalProductRefund;
                if (leftCanchange > 0)
                {
                    rf.CustleftCanchange = leftCanchange.ToString();

                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    return serializer.Serialize(rf);
                }
                else
                {
                    rf.CustleftCanchange = "full";
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    return serializer.Serialize(rf);
                }
            }
            else
            {
                rf.CustleftCanchange = "nocustomer";
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                return serializer.Serialize(rf);

            }
        }

        public class RefundCust
        {
            public string CustName { get; set; }
            public string CustPhone { get; set; }
            public string CustAddress { get; set; }
            public string CustZalo { get; set; }
            public string CustFB { get; set; }
            public string CustleftCanchange { get; set; }
        }

        [WebMethod]
        public static string getProduct(string textsearch, string phone, int sl, string list)
        {
            int AgentID = 0;
            string username = HttpContext.Current.Session["userLoginSystem"].ToString();
            if (!string.IsNullOrEmpty(username))
            {
                var a = AccountController.GetByUsername(username);
                if (a != null)
                {
                    AgentID = Convert.ToInt32(a.AgentID);
                }
            }
            var customer = CustomerController.GetByPhone(phone);
            if (customer != null)
            {
                int custID = customer.ID;
                double FeeRefund = 0;
                double NumOfDateToChangeProduct = 0;
                double NumOfProductCanChange = 0;
                var config = ConfigController.GetByTop1();
                if (config != null)
                {
                    FeeRefund = Convert.ToDouble(config.FeeChangeProduct);
                    NumOfDateToChangeProduct = Convert.ToDouble(config.NumOfDateToChangeProduct);
                    NumOfProductCanChange = Convert.ToDouble(config.NumOfProductCanChange);
                }
                var d = DiscountCustomerController.getbyCustID(custID);
                if (d.Count > 0)
                {
                    FeeRefund = d[0].FeeRefund;
                    NumOfDateToChangeProduct = d[0].NumOfDateToChangeProduct;
                    NumOfProductCanChange = d[0].NumOfProductCanChange;
                }

                //DateTime toDate = DateTime.Now.Date;
                DateTime toDate = DateTime.Now;
                var fromDate = toDate.AddDays(-NumOfDateToChangeProduct);

                double totalProductRefund = 0;
                var refundList = RefundGoodController.GetByAgentIDCustomerIDFromDateToDate(AgentID, custID, fromDate, toDate);
                if (refundList.Count > 0)
                {
                    foreach (var item in refundList)
                    {
                        var rfD = RefundGoodDetailController.GetByRefundGoodsID(item.ID);
                        if (rfD.Count > 0)
                        {
                            foreach (var fd in rfD)
                            {
                                totalProductRefund += Convert.ToDouble(fd.Quantity);
                            }
                        }
                    }
                }
                List<ProductGetOut> ps = new List<ProductGetOut>();
               
                double leftCanchange = NumOfProductCanChange - totalProductRefund;
                if (leftCanchange > 0)
                {
                    var orders = OrderController.GetByCustomerIDFromDateToDate(AgentID, custID, fromDate, toDate);
                    if (orders.Count > 0)
                    {
                        for (int i = 0; i < orders.Count; i++)
                        {
                            var o = orders[i];
                            double giachietkhautungsanpham = Convert.ToDouble(o.DiscountPerProduct);
                            var orderdetails = OrderDetailController.GetByOrderID(o.ID);
                            if (orderdetails.Count > 0)
                            {
                                foreach (var od in orderdetails)
                                {
                                    string sku = od.SKU;
                                    if (sku == textsearch.ToUpper())
                                    {
                                        ProductGetOut po = new ProductGetOut();
                                        string ProductTitle = "";
                                        double giagoc = 0;
                                        double giabandagiam = 0;
                                        int productType = Convert.ToInt32(od.ProductType);
                                        if (productType == 1)
                                        {
                                            var product = ProductController.GetBySKU(sku);
                                            if (product != null)
                                            {
                                                ProductTitle = product.ProductTitle;
                                            }
                                        }
                                        else
                                        {
                                            var pvdetail = ProductVariableController.GetProductNameSQL(sku);
                                            if (pvdetail.Count > 0)
                                            {
                                                ProductTitle = pvdetail[0].ProductTitle;
                                            }
                                        }
                                        giagoc = Convert.ToDouble(od.Price);
                                        double giabanchuatru = Convert.ToDouble(od.Price);
                                        giabandagiam = giabanchuatru - giachietkhautungsanpham;

                                        po.orderID = o.ID;
                                        po.orderDetailID = od.ID;
                                        po.ProductName = ProductTitle;
                                        po.ProductType = productType;
                                        po.SKU = sku;
                                        po.Giagoc = giagoc;
                                        po.stringGiagoc = string.Format("{0:N0}", giagoc);
                                        po.Giadaban = giabandagiam;
                                        po.stringGiadaban = string.Format("{0:N0}", giabandagiam);
                                        po.TienGiam = giachietkhautungsanpham;
                                        if (giachietkhautungsanpham > 0)
                                        {
                                            po.stringTienGiam = "(CK " + string.Format("{0:N0}", giachietkhautungsanpham) + ")";
                                        }
                                        else
                                        {
                                            po.stringTienGiam = "";
                                        }

                                        var qt = RefundGoodDetailController.GetQuantityMax(custID, o.ID, sku);
                                        int qll = 0;
                                        if (qt != null)
                                        {
                                            foreach (var item in qt)
                                            {
                                                double? q = item.Quantity;
                                                qll += Convert.ToInt32(q);
                                            }
                                        }
                                        po.Soluongtoida = Convert.ToDouble(od.Quantity) - qll;
                                        int check = Convert.ToInt32(od.Quantity) - qll;
                                        po.soluongmax = Convert.ToDouble(od.Quantity);
                                        po.RefundFee = FeeRefund;
                                        po.stringRefundFee = string.Format("{0:N0}", FeeRefund);
                                        if (check > 0)
                                        {
                                            ps.Add(po);
                                        }
                                    }
                                }
                            }
                            if (ps.Count() > 0)
                            {
                                ps = ps.Take(sl + 1).ToList();
                            }
                        }
                    }

                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    return serializer.Serialize(ps);
                }
                else
                {
                    return "full";
                }
            }
            else
            {
                return "nocustomer";
            }
        }


        public class ProductGetOut
        {
            public int ID { get; set; }
            public int orderID { get; set; }
            public int orderDetailID { get; set; }
            public string ProductName { get; set; }
            public int ProductType { get; set; }
            public string SKU { get; set; }
            public double Giagoc { get; set; }
            public string stringGiagoc { get; set; }
            public double Giadaban { get; set; }
            public string stringGiadaban { get; set; }
            public double TienGiam { get; set; }
            public string stringTienGiam { get; set; }
            public string stringSoluongtoida { get; set; }
            public double Soluongtoida { get; set; }
            public double RefundFee { get; set; }
            public string stringRefundFee { get; set; }
            public double soluongmax { get; set; }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DateTime currentDate = DateTime.Now;
            int AgentID = 0;
            string username = Session["userLoginSystem"].ToString();
            if (!string.IsNullOrEmpty(username))
            {
                var a = AccountController.GetByUsername(username);
                if (a != null)
                {
                    AgentID = Convert.ToInt32(a.AgentID);
                    string phone = hdfPhone.Value;
                    if (!string.IsNullOrEmpty(phone))
                    {
                        var cust = CustomerController.GetByPhone(phone);
                        if (cust != null)
                        {
                            int custID = cust.ID;
                            string totalprice = hdfTotalPrice.Value;
                            string totalquantity = hdfTotalQuantity.Value;
                            string totalrefund = hdfTotalRefund.Value;
                            var agent = AgentController.GetByID(AgentID);
                            string agentName = "";
                            if (agent != null)
                            {
                                agentName = agent.AgentName;
                            }
                            //insert ddlstatus, refundnote
                            int status = ddlRefundStatus.SelectedValue.ToInt();
                            string RefundsNote = txtRefundsNote.Text;
                            int rID = RefundGoodController.Insert(AgentID, totalprice, status, custID, Convert.ToDouble(totalquantity),
                                totalrefund, agentName, cust.CustomerName, cust.CustomerPhone, currentDate, username, RefundsNote);
                            if (rID > 0)
                            {
                                string listString = hdfListProduct.Value;
                                string[] items = listString.Split('|');
                                if (items.Length - 1 > 0)
                                {
                                    for (int i = 0; i < items.Length - 1; i++)
                                    {
                                        string[] element = items[i].Split(';');
                                        var sku = element[0];
                                        var orderID = element[1].ToInt(0);
                                        var orderDetailID = element[2];
                                        var ProductName = element[3];
                                        var GiavonPerProduct = Convert.ToDouble(element[5]);
                                        var SoldPricePerProduct = Convert.ToDouble(element[6]);
                                        var DiscountPricePerProduct = Convert.ToDouble(element[7]);
                                        var quantity = Convert.ToDouble(element[10]);
                                        var quantityMax = Convert.ToDouble(element[8]);
                                        var ProductType = element[4].ToInt(1);
                                        var RefundType = element[9].ToInt(1);
                                        var RefundFeePerProduct = Convert.ToDouble(element[11]);
                                        var TotalPriceRow = element[12];
                                        var PriceNotFeeRefund = SoldPricePerProduct * quantity;
                                        var rdTotalRefundFee = RefundFeePerProduct * quantity;

                                        int rdID = RefundGoodDetailController.Insert(rID, AgentID, orderID, ProductName, custID, sku, quantity,
                                            quantityMax, PriceNotFeeRefund.ToString(), ProductType, true, RefundType, RefundFeePerProduct.ToString(),
                                            rdTotalRefundFee.ToString(), GiavonPerProduct.ToString(), DiscountPricePerProduct.ToString(), SoldPricePerProduct.ToString(),
                                            TotalPriceRow, currentDate, username);
                                        if (rdID > 0)
                                        {
                                            if (RefundType < 3)
                                            {
                                                int typeRe = 0;
                                                string note = "";
                                                if (RefundType == 1)
                                                {
                                                    note = "Đổi size";
                                                    typeRe = 8;
                                                }
                                                else if (RefundType == 2)
                                                {
                                                    note = "Đổi sản phẩm";
                                                    typeRe = 9;
                                                }
                                                if (ProductType == 1)
                                                {
                                                    var product = ProductController.GetBySKU(sku);
                                                    if (product != null)
                                                    {
                                                        int productID = product.ID;
                                                        string ProductImageOrigin = "";
                                                        var ProductImage = ProductImageController.GetFirstByProductID(product.ID);
                                                        if (ProductImage != null)
                                                            ProductImageOrigin = ProductImage.ProductImage;
                                                        StockManagerController.Insert(AgentID, productID, 0, "", "", quantity, 0, 1, false, 1,
                                                        note, orderID, 0, typeRe, ProductName, sku, ProductImageOrigin, "", currentDate, username, 0, productID);
                                                    }
                                                }
                                                else
                                                {
                                                    string ProductVariableName = "";
                                                    string ProductVariableValue = "";
                                                    string ProductVariable = "";
                                                    int parentID = 0;
                                                    string parentSKU = "";
                                                    string ProductImageOrigin = "";
                                                    int ID = 0;

                                                    var productvariable = ProductVariableController.GetBySKU(sku);
                                                    if (productvariable != null)
                                                    {
                                                        ID = productvariable.ID;
                                                        ProductImageOrigin = productvariable.Image;
                                                        parentSKU = productvariable.ParentSKU;
                                                        var variables = ProductVariableValueController.GetByProductVariableID(productvariable.ID);
                                                        if (variables.Count > 0)
                                                        {
                                                            foreach (var v in variables)
                                                            {
                                                                ProductVariable += v.VariableName.Trim() + ":" + v.VariableValue.Trim() + "|";
                                                                ProductVariableName += v.VariableName + "|";
                                                                ProductVariableValue += v.VariableValue + "|";
                                                            }
                                                        }
                                                    }
                                                    if (!string.IsNullOrEmpty(parentSKU))
                                                    {
                                                        var product = ProductController.GetBySKU(parentSKU);
                                                        if (product != null)
                                                            parentID = product.ID;
                                                    }


                                                    StockManagerController.Insert(AgentID, 0, ID, ProductVariableName,
                                                        ProductVariableValue, quantity, 0, 1, false, 2, note, orderID, 0, typeRe, ProductName, sku,
                                                        ProductImageOrigin, ProductVariable, currentDate, username, 0, parentID);
                                                }
                                            }
                                        }
                                        PJUtils.ShowMessageBoxSwAlert("Tạo mới đơn trả hàng thành công", "s", true, Page);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}