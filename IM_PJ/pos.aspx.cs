using IM_PJ.Controllers;
using IM_PJ.Models;
using MB.Extensions;
using Newtonsoft.Json;
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
    public partial class pos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.GetCurrent(this).AsyncPostBackTimeout = 600;

            if (!IsPostBack)
            {

                if (Request.Cookies["userLoginSystem"] != null)
                {
                    string username = Request.Cookies["userLoginSystem"].Value;
                    var acc = AccountController.GetByUsername(username);
                    if (acc != null)
                    {
                        hdfUsernameCurrent.Value = acc.Username;
                        if (acc.RoleID == 0)
                        {

                        }
                        else if(acc.RoleID == 2)
                        {
                            hdfUsername.Value = acc.Username;
                        }
                        else
                        {
                            Response.Redirect("/trang-chu");
                        }

                        Response.Cookies["refund"].Value = "1";

                        var dc = DiscountController.GetAll();
                        if (dc != null)
                        {
                            string list = "";
                            foreach (var item in dc)
                            {
                                list += item.Quantity + "-" + item.DiscountPerProduct + "|";
                            }
                            hdfChietKhau.Value = list;
                        }

                        // get user list (only role 2) to change user when create order
                        var CreateBy = AccountController.GetAllByRoleID(2);
                        if (CreateBy != null)
                        {
                            string listUser = "";
                            foreach (var item in CreateBy)
                            {
                                if(item.Username != acc.Username)
                                {
                                    listUser += item.Username + "|";
                                }
                            }
                            hdfListUser.Value = listUser;
                        }
                    }
                }
                else
                {
                    Response.Redirect("/dang-nhap");
                }
            }
        }

        [WebMethod]
        public static string getProduct(string textsearch)
        {
            List<ProductGetOut> ps = new List<ProductGetOut>();
            string username = HttpContext.Current.Request.Cookies["userLoginSystem"].Value;
            var acc = AccountController.GetByUsername(username);
            if (acc != null)
            {
                int AgentID = Convert.ToInt32(acc.AgentID);
                var product = ProductController.GetBySKU(textsearch.Trim().ToUpper());

                // Kiểm tra sản phẩm có trong table Product không?
                if (product != null) // Nếu sản phẩm có trong table Product thì...
                {
                    var productvariable = ProductVariableController.GetByParentSKU(product.ProductSKU);

                    // Kiểm tra sản phẩm cha là variable hay simple?
                    if (productvariable.Count > 0) // Nếu sản phẩm cha là variable thì...
                    {
                        foreach (var pv in productvariable)
                        {
                            string SKU = pv.SKU.Trim().ToUpper();

                            var variables = ProductVariableValueController.GetByProductVariableSKU(SKU);

                            if (variables.Count > 0)
                            {
                                string variablename = "";
                                string variablevalue = "";
                                string variable = "";
                                string variablesave = "";
                                foreach (var v in variables)
                                {
                                    variable += v.VariableName.Trim() + ": " + v.VariableValue.Trim() + "<br/>";
                                    variablesave += v.VariableName.Trim() + ": " + v.VariableValue.Trim() + "|";
                                    variablename += v.VariableName.Trim() + "|";
                                    variablevalue += v.VariableValue.Trim() + "|";
                                }

                                ProductGetOut p = new ProductGetOut();
                                p.ProductID = 0;
                                p.ProductVariableID = pv.ID;
                                p.ProductName = product.ProductTitle;
                                p.ProductVariable = variable;
                                p.ProductVariableSave = variablesave;
                                p.ProductVariableName = variablename;
                                p.ProductVariableValue = variablevalue;
                                p.ProductType = 2;

                                if (!string.IsNullOrEmpty(pv.Image))
                                {
                                    p.ProductImage = "<img src=\"" + pv.Image + "\" />";
                                    p.ProductImageOrigin = pv.Image;
                                }
                                else if (!string.IsNullOrEmpty(product.ProductImage))
                                {
                                    p.ProductImage = "<img src=\"" + product.ProductImage + "\" />";
                                    p.ProductImageOrigin = product.ProductImage;
                                }
                                else
                                {
                                    p.ProductImage = "<img src=\"/App_Themes/Ann/image/placeholder.png\" />";
                                    p.ProductImageOrigin = "";
                                }

                                p.SKU = SKU;
                                p.Giabansi = Convert.ToDouble(pv.Regular_Price);
                                p.stringGiabansi = string.Format("{0:N0}", pv.Regular_Price);
                                p.Giabanle = Convert.ToDouble(pv.RetailPrice);
                                p.stringGiabanle = string.Format("{0:N0}", pv.RetailPrice);
                                ps.Add(p);
                            }
                        }
                    }
                    else // Nếu sản phẩm cha là simple thì...
                    {
                        string SKU = product.ProductSKU.Trim().ToUpper();

                        ProductGetOut p = new ProductGetOut();
                        p.ProductID = product.ID;
                        p.ProductVariableID = 0;
                        p.ProductName = product.ProductTitle;
                        p.ProductVariable = "";
                        p.ProductVariableSave = "";
                        p.ProductVariableName = "";
                        p.ProductVariableValue = "";
                        p.ProductType = 1;

                        var img = ProductImageController.GetFirstByProductID(product.ID);
                        if (!string.IsNullOrEmpty(product.ProductImage))
                        {
                            p.ProductImage = "<img src=\"" + product.ProductImage + "\" />";
                            p.ProductImageOrigin = product.ProductImage;
                        }
                        else if (img.ProductImage != null)
                        {
                            p.ProductImage = "<img src=\"" + img.ProductImage + "\" />";
                            p.ProductImageOrigin = img.ProductImage;
                        }
                        else
                        {
                            p.ProductImage = "<img src=\"/App_Themes/Ann/image/placeholder.png\" />";
                            p.ProductImageOrigin = "";
                        }

                        p.SKU = SKU;
                        p.Giabansi = Convert.ToDouble(product.Regular_Price);
                        p.stringGiabansi = string.Format("{0:N0}", product.Regular_Price);
                        p.Giabanle = Convert.ToDouble(product.Retail_Price);
                        p.stringGiabanle = string.Format("{0:N0}", product.Retail_Price);
                        ps.Add(p);
                    }
                }
                else // Nếu không nằm trong table Product thì...
                {
                    var productvariable = ProductVariableController.GetBySKU(textsearch.Trim().ToUpper());

                    // Nếu sản phẩm là con (nằm trong table ProductVariable) thì...
                    if (productvariable != null)
                    {
                        string SKU = productvariable.SKU.Trim().ToUpper();

                        var variables = ProductVariableValueController.GetByProductVariableSKU(SKU);

                        if (variables.Count > 0)
                        {
                            string variablename = "";
                            string variablevalue = "";
                            string variable = "";
                            string variablesave = "";

                            foreach (var v in variables)
                            {
                                variable += v.VariableName + ": " + v.VariableValue + "<br/>";
                                variablesave += v.VariableName.Trim() + ": " + v.VariableValue.Trim() + "|";
                                variablename += v.VariableName + "|";
                                variablevalue += v.VariableValue + "|";
                            }

                            ProductGetOut p = new ProductGetOut();
                            p.ProductID = 0;
                            p.ProductVariableID = productvariable.ID;

                            var _product = ProductController.GetBySKU(productvariable.ParentSKU);
                            if (_product != null)
                                p.ProductName = _product.ProductTitle;

                            p.ProductVariable = variable;
                            p.ProductVariableSave = variablesave;
                            p.ProductVariableName = variablename;
                            p.ProductVariableValue = variablevalue;
                            p.ProductType = 2;

                            if (!string.IsNullOrEmpty(productvariable.Image))
                            {
                                p.ProductImage = "<img src=\"" + productvariable.Image + "\" />";
                                p.ProductImageOrigin = productvariable.Image;
                            }
                            else if (!string.IsNullOrEmpty(_product.ProductImage))
                            {
                                p.ProductImage = "<img src=\"" + _product.ProductImage + "\" />";
                                p.ProductImageOrigin = _product.ProductImage;
                            }
                            else
                            {
                                p.ProductImage = "<img src=\"/App_Themes/Ann/image/placeholder.png\" />";
                                p.ProductImageOrigin = "";
                            }

                            p.SKU = SKU;
                            p.Giabansi = Convert.ToDouble(productvariable.Regular_Price);
                            p.stringGiabansi = string.Format("{0:N0}", productvariable.Regular_Price);
                            p.Giabanle = Convert.ToDouble(productvariable.RetailPrice);
                            p.stringGiabanle = string.Format("{0:N0}", productvariable.RetailPrice);
                            ps.Add(p);
                        }
                    }
                }
            }

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(ps);
        }
        [WebMethod]
        public static string searchCustomerByPhone(string phone)
        {
            var customer = CustomerController.GetByPhone(phone);
            if (customer != null)
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                return serializer.Serialize(customer);
            }
            else
            {
                return "0";
            }
        }

        [WebMethod]
        public static string searchCustomerByText(string textsearch, string createdby = "")
        {
            var customer = CustomerController.Find(textsearch, createdby);
            if (customer != null)
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                return serializer.Serialize(customer);
            }
            else
            {
                return "0";
            }
        }

        [WebMethod]
        public static string getReturnOrder(string order, string remove)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            if(remove.ToInt() == 0)
            {
                var or = RefundGoodController.GetOrderByID(order.ToInt());
                if (or != null)
                {
                    HttpContext.Current.Response.Cookies["refund"].Value = or.ID + "|" + or.TotalPrice;
                    return serializer.Serialize(or);
                }
                else
                {
                    return serializer.Serialize(null);
                }
            }
            else
            {
                HttpContext.Current.Response.Cookies["refund"].Value = "1";
                return serializer.Serialize(null);
            }
        }
        [WebMethod]
        public static string getCustomerDetail(int ID)
        {
            var customer = CustomerController.GetByID(ID);
            if (customer != null)
            {
                var ci = new CustomerInfoWithDiscount();
                ci.Customer = customer;
                ci.CreatedDate = customer.CreatedDate.ToString();
                List<DiscountCustomerGet> dc = new List<DiscountCustomerGet>();
                var d = DiscountCustomerController.getbyCustID(ID);
                if (d.Count > 0)
                {
                    dc = d;
                }
                ci.AllDiscount = dc;
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                return serializer.Serialize(ci);
            }
            else
            {
                return "null";
            }
        }
        [WebMethod]
        public static string getCustomerDiscount(int ID)
        {
            var d = DiscountCustomerController.getbyCustID(ID);
            if (d.Count > 0)
            {
                var da = d[0].DiscountAmount;
                return da.ToString();
            }
            else
            {
                return "0";
            }

        }

        public class ProductGetOut
        {
            public int ProductID { get; set; }
            public int ProductVariableID { get; set; }
            public string ProductName { get; set; }
            public string ProductVariable { get; set; }
            public string ProductVariableSave { get; set; }
            public string ProductVariableName { get; set; }
            public string ProductVariableValue { get; set; }
            public int ProductType { get; set; }
            public string ProductImage { get; set; }
            public string ProductImageOrigin { get; set; }
            public string QuantityInstockString { get; set; }
            public double QuantityInstock { get; set; }
            public string SKU { get; set; }
            public double Giabanle { get; set; }
            public string stringGiabanle { get; set; }
            public double Giabansi { get; set; }
            public string stringGiabansi { get; set; }
        }

        public class ProductPOS
        {
            public List<ProductGetOut> productPOS { get; set; }
        }

        public class CustomerInfoWithDiscount
        {
            public tbl_Customer Customer { get; set; }
            public string CreatedDate { get; set; }
            public string ProvinceName { get; set; }
            public List<DiscountCustomerGet> AllDiscount { get; set; }
        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {
            DateTime currentDate = DateTime.Now;
            string username = Request.Cookies["userLoginSystem"].Value;
            var acc = AccountController.GetByUsername(username);
            if (acc != null)
            {
                if (acc.RoleID == 0 || acc.RoleID == 2)
                {
                    string OrderNote = "";
                    // change user
                    if(username != hdfUsernameCurrent.Value)
                    {
                        OrderNote = "Được tính tiền giúp bởi " + username;
                        username = hdfUsernameCurrent.Value;
                    }
                    int AgentID = Convert.ToInt32(acc.AgentID);
                    int OrderType = hdfOrderType.Value.ToInt();
                    string AdditionFee = "0";
                    string DisCount = "0";
                    int CustomerID = 0;
                    int checkCustomer = hdfCheckCustomer.Value.ToInt();

                    string CustomerPhone = txtPhone.Text.Trim();
                    string CustomerName = txtFullname.Text.Trim();
                    string CustomerNick = txtNick.Text.Trim();
                    string CustomerEmail = "";
                    string CustomerAddress = txtAddress.Text.Trim();
                    if (checkCustomer == 0)
                    {
                        var checkphone = CustomerController.GetByPhone(CustomerPhone);
                        if (checkphone != null)
                        {
                            CustomerID = checkphone.ID;
                        }
                        else
                        {
                            string kq = CustomerController.Insert(CustomerName, CustomerPhone, CustomerAddress, CustomerEmail, 0, 0, currentDate, username, false, "", "", "", "", CustomerNick);
                            if (kq.ToInt(0) > 0)
                            {
                                CustomerID = kq.ToInt(0);
                            }
                        }
                    }
                    else
                    {
                        var checkphone = CustomerController.GetByPhone(CustomerPhone);
                        if (checkphone != null)
                        {
                            CustomerID = checkphone.ID;
                        }
                    }

                    string totalPrice = hdfTotalPrice.Value.ToString();
                    string totalPriceNotDiscount = hdfTotalPriceNotDiscount.Value;
                    int PaymentStatus = 3;
                    int ExcuteStatus = 2;
                    int PaymentType = 1;
                    int ShippingType = 1;
                    bool IsHidden = false;
                    int WayIn = 1;

                    double DiscountPerProduct = Convert.ToDouble(pDiscount.Value);

                    double TotalDiscount = Convert.ToDouble(pDiscount.Value) * Convert.ToDouble(hdfTotalQuantity.Value);
                    string FeeShipping = pFeeShip.Value.ToString();
                    double GuestPaid = Convert.ToDouble(pGuestPaid.Value);
                    double GuestChange = Convert.ToDouble(totalPrice) - GuestPaid;
                    string OtherFeeName = txtOtherFeeName.Text;
                    double OtherFeeValue = Convert.ToDouble(pOtherFee.Value);

                    var ret = OrderController.InsertOnSystem(AgentID, OrderType, AdditionFee, DisCount, CustomerID, CustomerName, CustomerPhone, CustomerAddress,
                        CustomerEmail, totalPrice, totalPriceNotDiscount, PaymentStatus, ExcuteStatus, IsHidden, WayIn, currentDate, username, DiscountPerProduct,
                        TotalDiscount, FeeShipping, GuestPaid, GuestChange, PaymentType, ShippingType, OrderNote, DateTime.Now, OtherFeeName, OtherFeeValue, 1);
                    int OrderID = ret.ID;

                    if (OrderID > 0)
                    {
                        ProductPOS POS = JsonConvert.DeserializeObject<ProductPOS>(hdfListProduct.Value);
                        List<tbl_OrderDetail> orderDetails = new List<tbl_OrderDetail>();
                        List<tbl_StockManager> stockManager = new List<tbl_StockManager>();

                        foreach (ProductGetOut item in POS.productPOS)
                        {
                            orderDetails.Add(
                                new tbl_OrderDetail()
                                {
                                    AgentID = AgentID,
                                    OrderID = OrderID,
                                    SKU = item.SKU,
                                    ProductID = item.ProductID,
                                    ProductVariableID = item.ProductVariableID,
                                    ProductVariableDescrition = item.ProductVariableSave,
                                    Quantity = item.QuantityInstock,
                                    Price = item.Giabanle,
                                    Status = 1,
                                    DiscountPrice = 0,
                                    ProductType = item.ProductType,
                                    CreatedDate = currentDate,
                                    CreatedBy = username,
                                    IsCount = true
                                }
                            );


                            stockManager.Add(
                                new tbl_StockManager()
                                {
                                    AgentID = AgentID,
                                    ProductID = item.ProductID,
                                    ProductVariableID = item.ProductVariableID,
                                    Quantity = item.QuantityInstock,
                                    QuantityCurrent = 0,
                                    Type = 2,
                                    NoteID = "Xuất kho bán POS",
                                    OrderID = OrderID,
                                    Status = 3,
                                    SKU = item.SKU,
                                    CreatedDate = currentDate,
                                    CreatedBy = username,
                                    MoveProID = 0,
                                    ParentID = item.ProductID != 0 ? item.ProductID : item.ProductVariableID
                                }
                                );


                        }

                        OrderDetailController.Insert(orderDetails);
                        StockManagerController.Insert(stockManager);

                        string refund = Request.Cookies["refund"].Value;
                        if (refund != "1")
                        {
                            string[] RefundID = refund.Split('|');
                            var update = RefundGoodController.UpdateStatus(RefundID[0].ToInt(), username, 2);
                            var updateor = OrderController.UpdateRefund(OrderID, RefundID[0].ToInt(), username);
                        }

                        Response.Cookies["refund"].Expires = DateTime.Now.AddDays(-1d);
                        Response.Cookies.Add(Response.Cookies["refund"]);

                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "script", "$(function () { printInvoice(" + OrderID + ") });", true);
                    }
                }
            }
        }
    }
}