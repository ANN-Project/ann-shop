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

namespace IM_PJ
{
    public partial class them_moi_don_hang : System.Web.UI.Page
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
                        if (acc.RoleID == 0)
                        {

                        }
                        else if (acc.RoleID == 2)
                        {
                            hdfUsername.Value = acc.Username;
                        }
                        else
                        {
                            Response.Redirect("/trang-chu");
                        }

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
                        var agent = acc.AgentID;

                        Response.Cookies["refundt"].Value = "1";

                        if (agent == 1)
                        {
                            hdfIsMain.Value = "1";
                        }
                        else
                        {
                            hdfIsMain.Value = "0";
                        }
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
        public static string checkPrepayTransport(int ID, int SubID)
        {
            var a = TransportCompanyController.GetReceivePlaceByID(ID, SubID);
            if(a != null)
            {
                if(a.Prepay == true)
                {
                    return "yes";
                }
                else
                {
                    return "no";
                }
            }
            return "null";
        }
        [WebMethod]
        public static string getReturnOrder(string order, string remove)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            if (remove.ToInt() == 0)
            {
                var or = RefundGoodController.GetOrderByID(order.ToInt());
                if (or != null)
                {
                    HttpContext.Current.Response.Cookies["refundt"].Value = or.ID + "|" + or.TotalPrice;
                    return serializer.Serialize(or);
                }
                else
                {
                    return serializer.Serialize(null);
                }
            }
            else
            {
                HttpContext.Current.Response.Cookies["refundt"].Value = "1";
                return serializer.Serialize(null);
            }
        }
        [WebMethod]
        public static string getProduct(string textsearch, int gettotal)
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
                                p.ID = pv.ID;
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

                                if (gettotal == 1)
                                {
                                    var mainstock = PJUtils.TotalProductQuantityInstock(1, SKU);
                                    p.QuantityMainInstock = mainstock;
                                    p.QuantityMainInstockString = string.Format("{0:N0}", mainstock);
                                    p.QuantityInstock = mainstock;
                                    p.QuantityInstockString = string.Format("{0:N0}", mainstock);
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
                        double mainstock = PJUtils.TotalProductQuantityInstock(1, SKU);

                        ProductGetOut p = new ProductGetOut();
                        p.ID = product.ID;
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
                        p.QuantityMainInstock = mainstock;
                        p.QuantityMainInstockString = string.Format("{0:N0}", mainstock);
                        p.QuantityInstock = mainstock;
                        p.QuantityInstockString = string.Format("{0:N0}", mainstock);
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

                            double mainstock = PJUtils.TotalProductQuantityInstock(1, SKU);

                            ProductGetOut p = new ProductGetOut();
                            p.ID = productvariable.ID;

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
                            p.QuantityMainInstock = mainstock;
                            p.QuantityMainInstockString = string.Format("{0:N0}", mainstock);
                            p.QuantityInstock = mainstock;
                            p.QuantityInstockString = string.Format("{0:N0}", mainstock);
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
        public class ProductGetOut
        {
            public int ID { get; set; }
            public string ProductName { get; set; }
            public string ProductVariable { get; set; }
            public string ProductVariableSave { get; set; }
            public string ProductVariableName { get; set; }
            public string ProductVariableValue { get; set; }
            public int ProductType { get; set; }
            public string ProductImage { get; set; }
            public string ProductImageOrigin { get; set; }
            public string QuantityMainInstockString { get; set; }
            public double QuantityMainInstock { get; set; }
            public string QuantityInstockString { get; set; }
            public double QuantityInstock { get; set; }
            public string SKU { get; set; }
            public double Giabanle { get; set; }
            public string stringGiabanle { get; set; }
            public double Giabansi { get; set; }
            public string stringGiabansi { get; set; }
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
                    int AgentID = Convert.ToInt32(acc.AgentID);
                    int OrderType = hdfOrderType.Value.ToInt();
                    string AdditionFee = "0";
                    string DisCount = "0";
                    int CustomerID = 0;
                    int checkCustomer = hdfCheckCustomer.Value.ToInt();

                    string CustomerPhone = txtPhone.Text.Trim();
                    string CustomerName = txtFullname.Text.Trim();
                    string Nick = txtNick.Text.Trim();
                    string CustomerAddress = txtAddress.Text.Trim();
                    string Zalo = txtZalo.Text.Trim();
                    string Facebook = txtFacebook.Text.Trim();
                    int PaymentStatus = hdfPaymentStatus.Value.ToInt(1);
                    int ExcuteStatus = hdfExcuteStatus.Value.ToInt(1);
                    int PaymentType = hdfPaymentType.Value.ToInt(1);
                    int ShippingType = hdfShippingType.Value.ToInt(1);

                    if (checkCustomer == 0)
                    {
                        var checkphone = CustomerController.GetByPhone(CustomerPhone);
                        if (checkphone != null)
                        {
                            CustomerID = checkphone.ID;
                        }
                        else
                        {
                            string kq = CustomerController.Insert(CustomerName, CustomerPhone, CustomerAddress, "", 0, 0, currentDate, username, false, Zalo, Facebook, "","", Nick, "", ShippingType, PaymentType);
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

                    var Customer = CustomerController.GetByID(CustomerID);

                    int TransportCompanyID = 0;
                    int TransportCompanySubID = 0;
                    if (Customer.ShippingType == ShippingType)
                    {
                        TransportCompanyID = Convert.ToInt32(Customer.TransportCompanyID);
                        TransportCompanySubID = Convert.ToInt32(Customer.TransportCompanySubID);
                    }

                    string totalPrice = hdfTotalPrice.Value.ToString();
                    string totalPriceNotDiscount = hdfTotalPriceNotDiscount.Value;
                    

                    double DiscountPerProduct = Convert.ToDouble(pDiscount.Value);

                    double TotalDiscount = Convert.ToDouble(pDiscount.Value) * Convert.ToDouble(hdfTotalQuantity.Value);
                    string FeeShipping = pFeeShip.Value.ToString();

                    string OtherFeeName = txtOtherFeeName.Text;
                    double OtherFeeValue = Convert.ToDouble(pOtherFee.Value);

                    bool IsHidden = false;
                    int WayIn = 1;

                    string datedone = "";
                    if(ExcuteStatus == 2)
                    {
                        datedone = DateTime.Now.ToString();
                    }

                    var ret = OrderController.Insert(AgentID, OrderType, AdditionFee, DisCount, CustomerID, CustomerName, CustomerPhone, CustomerAddress,
                        "", totalPrice, totalPriceNotDiscount, PaymentStatus, ExcuteStatus, IsHidden, WayIn, currentDate, username, Convert.ToDouble(pDiscount.Value),
                        TotalDiscount, FeeShipping, PaymentType, ShippingType, datedone, 0, 0, TransportCompanyID, TransportCompanySubID, OtherFeeName, OtherFeeValue, 1);

                    int OrderID = ret.ID;

                    double totalQuantity = 0;
                    if (OrderID > 0)
                    {
                        string list = hdfListProduct.Value;
                        string[] items = list.Split(';');
                        if (items.Length - 1 > 0)
                        {
                            for (int i = 0; i < items.Length - 1; i++)
                            {

                                var item = items[i];
                                string[] itemValue = item.Split(',');

                                int ProductID = 0;
                                int ProductVariableID = 0;

                                int ID = itemValue[0].ToInt();
                                int parentID = ID;
                                var parent = ProductVariableController.GetBySKU(itemValue[1].ToString());
                                if (parent != null)
                                {
                                    parentID = Convert.ToInt32(parent.ProductID);
                                }
                                string SKU = itemValue[1];

                                int producttype = itemValue[2].ToInt();
                                if (producttype == 1)
                                {
                                    ProductID = ID;
                                    ProductVariableID = 0;
                                }
                                else
                                {
                                    ProductID = 0;
                                    ProductVariableID = ID;
                                }

                                string ProductVariableName = itemValue[3];
                                string ProductVariableValue = itemValue[4];
                                double Quantity = Convert.ToDouble(itemValue[5]);
                                string ProductName = itemValue[6];
                                string ProductImageOrigin = itemValue[7];
                                string ProductVariable = itemValue[8];
                                double Price = Convert.ToDouble(itemValue[9]);
                                string ProductVariableSave = itemValue[10];

                                OrderDetailController.Insert(AgentID, OrderID, SKU, ProductID, ProductVariableID, ProductVariableSave, Quantity, Price, 1, 0,
                                    producttype, currentDate, username, true);

                                if (producttype == 1)
                                {
                                    StockManagerController.Insert(
                                        new tbl_StockManager {
                                            AgentID = AgentID,
                                            ProductID = ID,
                                            ProductVariableID = 0,
                                            Quantity = Quantity,
                                            QuantityCurrent = 0,
                                            Type = 2,
                                            NoteID = "Xuất kho khi tạo đơn",
                                            OrderID = OrderID,
                                            Status = 3,
                                            SKU = SKU,
                                            CreatedDate = currentDate,
                                            CreatedBy = username,
                                            MoveProID = 0,
                                            ParentID = parentID,
                                        });
                                }
                                else
                                {
                                    string parentSKU = "";
                                    var productV = ProductVariableController.GetByID(ID);
                                    if (productV != null)
                                        parentSKU = productV.ParentSKU;
                                    if (!string.IsNullOrEmpty(parentSKU))
                                    {
                                        var product = ProductController.GetBySKU(parentSKU);
                                        if (product != null)
                                            parentID = product.ID;
                                    }

                                    StockManagerController.Insert(
                                        new tbl_StockManager {
                                            AgentID = AgentID,
                                            ProductID = 0,
                                            ProductVariableID = ID,
                                            Quantity = Quantity,
                                            QuantityCurrent = 0,
                                            Type = 2,
                                            NoteID = "Xuất kho khi tạo đơn",
                                            OrderID = OrderID,
                                            Status = 3,
                                            SKU = SKU,
                                            CreatedDate = currentDate,
                                            CreatedBy = username,
                                            MoveProID = 0,
                                            ParentID = parentID,
                                        });
                                }
                                totalQuantity += Quantity;
                            }
                        }

                        string refund = Request.Cookies["refundt"].Value;
                        if (refund != "1")
                        {
                            string[] RefundID = refund.Split('|');
                            var update = RefundGoodController.UpdateStatus(RefundID[0].ToInt(), username, 2);
                            var updateor = OrderController.UpdateRefund(OrderID, RefundID[0].ToInt(), username);
                        }

                        Response.Cookies["refundt"].Expires = DateTime.Now.AddDays(-1d);
                        Response.Cookies.Add(Response.Cookies["refundt"]);

                        PJUtils.ShowMessageBoxSwAlertCallFunction("Tạo đơn hàng thành công", "s", true, "redirectTo(" + OrderID + ")", Page);
                    }
                }
            }
        }
    }
}