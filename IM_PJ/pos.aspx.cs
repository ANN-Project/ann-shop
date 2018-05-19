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
    public partial class pos : System.Web.UI.Page
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
                        if(acc.RoleID == 0)
                        {

                        }
                        else if(acc.RoleID == 2)
                        {

                        }
                        else
                        {
                            Response.Redirect("/trang-chu");
                        }
                        Session["refund"] = "1";
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
        public static string getProduct(string textsearch)
        {
            List<ProductGetOut> ps = new List<ProductGetOut>();
            string username = HttpContext.Current.Session["userLoginSystem"].ToString();
            var acc = AccountController.GetByUsername(username);
            if (acc != null)
            {
                int AgentID = Convert.ToInt32(acc.AgentID);
                var product = ProductController.GetBySKU(textsearch.Trim());
                if (product != null)
                {
                    var productvariable = ProductVariableController.GetProductID(product.ID);
                    if (productvariable.Count > 0)
                    {
                        foreach (var pv in productvariable)
                        {
                            string SKU = pv.SKU.Trim().ToUpper();
                            var check = InOutProductVariableController.GetBySKU(AgentID, SKU);
                            if (check.Count > 0)
                            {
                                double total = PJUtils.TotalProductQuantityInstock(AgentID, SKU);

                                var variables = ProductVariableValueController.GetByProductVariableID(pv.ID);
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
                                        
                                    if (p.ProductImage == null)
                                    {
                                        p.ProductImage = "<img src=\"" + pv.Image + "\" />";
                                    }
                                    else
                                    {
                                        p.ProductImage = "<img src=\"/App_Themes/Ann/image/placeholder.png\" />";
                                    }

                                    p.ProductImageOrigin = pv.Image;
                                    p.QuantityInstock = total;
                                    p.QuantityInstockString = string.Format("{0:N0}", total);
                                    p.SKU = SKU;
                                    p.Giabansi = Convert.ToDouble(pv.Regular_Price);
                                    p.stringGiabansi = string.Format("{0:N0}", pv.Regular_Price);
                                    p.Giabanle = Convert.ToDouble(pv.RetailPrice);
                                    p.stringGiabanle = string.Format("{0:N0}", pv.RetailPrice);
                                    ps.Add(p);
                                }
                            }
                        }
                    }
                    else
                    {
                        string SKU = product.ProductSKU.Trim().ToUpper();
                        var check = InOutProductVariableController.GetBySKU(AgentID, SKU);
                        if (check.Count > 0)
                        {
                            double total = PJUtils.TotalProductQuantityInstock(AgentID, SKU);

                            string variablename = "";
                            string variablevalue = "";
                            string variable = "";

                            ProductGetOut p = new ProductGetOut();
                            p.ID = product.ID;
                            p.ProductName = product.ProductTitle;
                            p.ProductVariable = variable;
                            p.ProductVariableSave = "";
                            p.ProductVariableName = variablename;
                            p.ProductVariableValue = variablevalue;
                            p.ProductType = 1;

                            var img = ProductImageController.GetFirstByProductID(product.ID);
                            if (img != null)
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
                            p.QuantityInstock = total;
                            p.QuantityInstockString = string.Format("{0:N0}", total);
                            p.Giabansi = Convert.ToDouble(product.Regular_Price);
                            p.stringGiabansi = string.Format("{0:N0}", product.Regular_Price);
                            p.Giabanle = Convert.ToDouble(product.Retail_Price);
                            p.stringGiabanle = string.Format("{0:N0}", product.Retail_Price);
                            ps.Add(p);

                        }

                    }
                }
                else
                {
                    var productvariable = ProductVariableController.GetBySKU(textsearch);
                    if (productvariable != null)
                    {
                        string SKU = productvariable.SKU.Trim().ToUpper();
                        var check = InOutProductVariableController.GetBySKU(AgentID, SKU);
                        if (check.Count > 0)
                        {
                            double total = PJUtils.TotalProductQuantityInstock(AgentID, SKU);
                            if (total > 0)
                            {
                                var variables = ProductVariableValueController.GetByProductVariableID(productvariable.ID);

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
                                    p.ID = productvariable.ID;
                                    var product1 = ProductController.GetByID(Convert.ToInt32(productvariable.ProductID));
                                    if (product1 != null)
                                        p.ProductName = product1.ProductTitle;
                                    p.ProductVariable = variable;
                                    p.ProductVariableSave = variablesave;
                                    p.ProductVariableName = variablename;
                                    p.ProductVariableValue = variablevalue;
                                    p.ProductType = 2;
                                    
                                    if (p.ProductImage == null)
                                    {
                                        p.ProductImage = "<img src=\"" + productvariable.Image + "\" />";
                                    }
                                    else
                                    {
                                        p.ProductImage = "<img src=\"/App_Themes/Ann/image/placeholder.png\" />";
                                    }

                                    p.ProductImageOrigin = productvariable.Image;
                                    p.SKU = productvariable.SKU.Trim().ToUpper();
                                    p.QuantityInstock = total;
                                    p.QuantityInstockString = string.Format("{0:N0}", total);
                                    p.Giabansi = Convert.ToDouble(productvariable.Regular_Price);
                                    p.stringGiabansi = string.Format("{0:N0}", productvariable.Regular_Price);
                                    p.Giabanle = Convert.ToDouble(productvariable.Regular_Price);
                                    p.stringGiabanle = string.Format("{0:N0}", productvariable.Regular_Price);
                                    ps.Add(p);
                                }
                            }
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
        public static string searchCustomerByText(string textsearch)
        {
            var customer = CustomerController.Find(textsearch);
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
                    HttpContext.Current.Session["refund"] = or.ID + "|" + or.TotalPrice;
                    return serializer.Serialize(or);
                }
                else
                {
                    return serializer.Serialize(null);
                }
            }
            else
            {
                HttpContext.Current.Session["refund"] = 1;
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
                //ci.CreatedDate = string.Format("{0:dd/MM/yyyy}", customer.CreatedDate);
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
            public int ID { get; set; }
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
        public class CustomerInfoWithDiscount
        {

            public tbl_Customer Customer { get; set; }
            public string CreatedDate { get; set; }
            public string ProvinceName { get; set; }
            public List<DiscountCustomerGet> AllDiscount { get; set; }
        }
        protected void btnImport_Click(object sender, EventArgs e)
        {

        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {
            DateTime currentDate = DateTime.Now;
            string username = Session["userLoginSystem"].ToString();
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
                    string CustomerNick = txtNick.Text.Trim();
                    string CustomerEmail = txtEmail.Text.Trim();
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
                    string OrderNote = "";
                    bool IsHidden = false;
                    int WayIn = 1;

                    double DiscountPerProduct = 0;
                    if (!string.IsNullOrEmpty(hdfDiscountAmount.Value))
                        DiscountPerProduct = Convert.ToDouble(hdfDiscountAmount.Value);

                    double TotalDiscount = Convert.ToDouble(pDiscount.Value) * Convert.ToDouble(hdfTotalQuantity.Value);
                    string FeeShipping = pFeeShip.Value.ToString();
                    double GuestPaid = Convert.ToDouble(pGuestPaid.Value);
                    double GuestChange = Convert.ToDouble(totalPrice) - GuestPaid;


                    var ret = OrderController.InsertOnSystem(AgentID, OrderType, AdditionFee, DisCount, CustomerID, CustomerName, CustomerPhone, CustomerAddress,
                       CustomerEmail, totalPrice, totalPriceNotDiscount, PaymentStatus, ExcuteStatus, IsHidden, WayIn, currentDate, username, DiscountPerProduct,
                       TotalDiscount, FeeShipping, GuestPaid, GuestChange, PaymentType, ShippingType, OrderNote, DateTime.Now);
                    int OrderID = ret.ID;
                    string productPrint = "";
                    string Print = "";
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
                                int parentID = 0;
                                var parent = ProductVariableController.GetByID(ID);
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
                                string Price = itemValue[9];
                                string ProductVariableSave = itemValue[10];

                                OrderDetailController.Insert(AgentID, OrderID, SKU, ProductID, ProductVariableID, ProductVariableSave, Quantity, Price, 1, "0",
                                    producttype, currentDate, username, true);


                                if (producttype == 1)
                                {
                                    double _Total = PJUtils.TotalProductQuantityInstock(AgentID, SKU);

                                    if (_Total < Quantity)
                                    {
                                        double _InputStock = Quantity - _Total;

                                        InOutProductVariableController.Insert(
                                            AgentID,
                                            ID,
                                            0,
                                            "",
                                            "",
                                            _InputStock,
                                            0,
                                            1,
                                            false,
                                            1,
                                            "Lech kho khi ban POS",
                                            OrderID,
                                            0,
                                            3,
                                            ProductName,
                                            SKU,
                                            ProductImageOrigin,
                                            ProductVariable,
                                            currentDate,
                                            username,
                                            0,
                                            parentID);
                                    }

                                    InOutProductVariableController.Insert(AgentID, ID, 0, "", "", Quantity, 0, 2, false, 1, "POS", OrderID,
                                        0, 3, ProductName, SKU, ProductImageOrigin, ProductVariable, currentDate, username, 0, parentID);
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

                                    double _Total = PJUtils.TotalProductQuantityInstock(AgentID, SKU);

                                    if (_Total < Quantity)
                                    {
                                        double _InputStock = Quantity - _Total;

                                        InOutProductVariableController.Insert(
                                            AgentID,
                                            0,
                                            ID,
                                            ProductVariableName,
                                            ProductVariableValue,
                                            _InputStock,
                                            0,
                                            1,
                                            false,
                                            2,
                                            "Lech kho khi ban POS",
                                            OrderID,
                                            0,
                                            3,
                                            ProductName,
                                            SKU,
                                            ProductImageOrigin,
                                            ProductVariable,
                                            currentDate,
                                            username,
                                            0,
                                            parentID);
                                    }

                                    InOutProductVariableController.Insert(AgentID, 0, ID, ProductVariableName, ProductVariableValue, Quantity, 0, 2,
                                        false, 2, "POS", OrderID, 0, 3, ProductName, SKU, ProductImageOrigin, ProductVariable,
                                        currentDate, username, 0, parentID);
                                }

                                totalQuantity += Quantity;

                                //table2
                                Print += " <tr>";
                                Print += "<td>" + (i + 1) + "</td>";
                                Print += "<td>" + SKU + " - " + ProductName + " - " + ProductVariableSave.Replace("|", ", ") + "</td> ";
                                Print += "<td>" + Quantity + "</td>";
                                Print += "<td>" + string.Format("{0:N0}", Convert.ToDouble(Price)) + "</td>";

                                Print += "<td> " + string.Format("{0:N0}", (Convert.ToInt32(Quantity) * Convert.ToInt32(Price))) + "</td>";

                                Print += "</tr>";

                                //table2
                            }
                        }

                        productPrint += " <div class=\"body\">";
                        productPrint += " <div class=\"table-1\">";
                        productPrint += " <table>";
                        productPrint += "<colgroup >";
                        productPrint += "<col class=\"col-left\"/>";
                        productPrint += "<col class=\"col-right\"/>";
                        productPrint += "</colgroup>";
                        productPrint += " <tbody>";
                        productPrint += " <tr>";
                        productPrint += " <td>Mã đơn hàng</td>";
                        productPrint += " <td>" + OrderID + "</td>";
                        productPrint += " </tr>";
                        productPrint += "  <tr>";
                        productPrint += "  <td>Ngày tạo</td>";
                        string date = string.Format("{0:dd/MM/yyyy HH:mm}", currentDate);
                        productPrint += " <td>" + date + "</td>";
                        productPrint += "</tr>";
                        productPrint += "<tr>";
                        productPrint += "<td>Ngày hoàn tất</td>";
                        if (!string.IsNullOrEmpty(ret.DateDone.ToString()))
                        {
                            string datedone = string.Format("{0:dd/MM/yyyy HH:mm}", ret.DateDone);
                            productPrint += "<td>" + datedone + "</td>";
                        }
                        else
                            productPrint += "<td></td>";
                        productPrint += " </tr>";
                        productPrint += " <tr>";
                        productPrint += "<td>Loại đơn</td>";
                        if (ret.OrderType == 1)
                            productPrint += "<td>Đơn lẻ</td>";
                        if (ret.OrderType == 2)
                            productPrint += "  <td>Đơn sỉ</td>";
                        productPrint += "</tr>";
                        productPrint += " <tr>";
                        productPrint += " <td>Nhân viên</td>";
                        productPrint += " <td>" + ret.CreatedBy + "</td>";
                        productPrint += "</tr>";
                        productPrint += "<tr>";
                        productPrint += "  <td>Khách hàng</td>";
                        productPrint += "  <td>" + ret.CustomerName + "</td>";
                        productPrint += " </tr>";
                        productPrint += "<tr>";
                        productPrint += " <td>Điện thoại</td>";
                        productPrint += " <td>" + ret.CustomerPhone + "</td>";
                        productPrint += "</tr>";
                        productPrint += "<tr>";
                        productPrint += "   <td>Ghi chú</td>";
                        productPrint += "<td>" + ret.OrderNote + "</td>";
                        productPrint += "</tr>";
                        productPrint += " </tbody>";
                        productPrint += "</table>";
                        productPrint += "         </div>";

                        productPrint += "<div class=\"table-2\">";
                        productPrint += " <table>";
                        productPrint += " <colgroup>";
                        productPrint += "<col class=\"stt\" />";
                        productPrint += "<col class=\"sanpham\" />";
                        productPrint += "<col class=\"soluong\" />";
                        productPrint += "<col class=\"gia\" />";
                        productPrint += "<col class=\"tong\"/>";
                        productPrint += "</colgroup>";
                        productPrint += "<thead>";
                        productPrint += " <th>#</th>";
                        productPrint += "<th>Sản phẩm</th>";
                        productPrint += "<th>SL</th>";
                        productPrint += "<th>Giá</th>";
                        productPrint += "<th>Tổng</th>";
                        productPrint += " </thead>";
                        productPrint += "<tbody>";
                        productPrint += Print;
                        productPrint += "<tr>";
                        productPrint += "<td colspan =\"4\" > Số lượng </td>";
                        productPrint += "<td>" + totalQuantity + "</td>";
                        productPrint += "</tr>";
                        productPrint += " <tr>";
                        productPrint += " <td colspan =\"4\"> Thành tiền </td>";
                        productPrint += " <td>" + string.Format("{0:N0}", Convert.ToDouble(ret.TotalPriceNotDiscount)) + "</td>";
                        productPrint += " </tr>";
                        if(pDiscount.Value > 0)
                        {
                            productPrint += " <tr>";
                            productPrint += "  <td colspan =\"4\"> Chiết khấu mỗi cái </td>";
                            productPrint += " <td>" + string.Format("{0:N0}", Convert.ToDouble(pDiscount.Value)) + "</td>";
                            productPrint += " </tr>";
                            productPrint += "<tr>";
                            productPrint += " <td colspan =\"4\" > Sau chiết khấu</ td >";
                            productPrint += " <td>" + string.Format("{0:N0}", Convert.ToDouble((Convert.ToDouble(ret.TotalPriceNotDiscount) - Convert.ToDouble(ret.TotalDiscount)))) + "</ td >";
                            productPrint += " </tr>";
                        }

                        
                        if(Convert.ToDouble(ret.FeeShipping) > 0)
                        {
                            productPrint += " <tr>";
                            productPrint += " <td colspan =\"4\" > Phí vận chuyển</ td >";
                            productPrint += " <td>" + string.Format("{0:N0}", Convert.ToDouble(ret.FeeShipping)) + "</ td >";
                            productPrint += " </tr>";
                        }

                        string refund = HttpContext.Current.Session["refund"].ToString();
                        if (refund != "1")
                        {
                            string[] RefundID = refund.Split('|');
                            var update = RefundGoodController.UpdateStatus(RefundID[0].ToInt(), acc.Username,2);
                            var updateor = OrderController.UpdateRefund(OrderID, RefundID[0].ToInt(), acc.Username);
                            productPrint += " <tr>";
                            productPrint += " <td colspan =\"4\" > Mã đơn hàng trả</td>";
                            productPrint += " <td>" + RefundID[0] + "</td>";
                            productPrint += " </tr>";

                            productPrint += " <tr>";
                            productPrint += " <td colspan =\"4\" > Tổng tiền còn lại</td>";
                            productPrint += " <td>" + string.Format("{0:N0}", Convert.ToDouble(hdfTongTienConLai.Value)) + "</ td >";
                            productPrint += " </tr>";
                        }
                        productPrint += " <tr>";
                        productPrint += "<td class=\"strong\" colspan=\"4\">Tổng cộng</td>";
                        productPrint += " <td class=\"strong\">" + string.Format("{0:N0}", Convert.ToDouble(totalPrice)) + "</td>";
                        productPrint += " </tr>";
                        productPrint += "</tbody>";
                        productPrint += " </table>";
                        productPrint += "</div>";
                        productPrint += "         </div>";

                        HttpContext.Current.Session.Remove("refund");
                        string address = "K4C Bửu Long, Phường 15, Quận 10, TP. HCM";
                        string phone = "";
                        var agent = AgentController.GetByID(AgentID);
                        if (agent != null)
                        {
                            address = agent.AgentAddress;
                            phone = agent.AgentPhone;
                        }

                        string dateOrder = string.Format("{0:dd/MM/yyyy HH:mm}", currentDate);


                        string html = "";

                        html += "<div class=\"hoadon\">";
                        html += "<div class=\"all\">";
                        html += "<div class=\"head\">";
                        html += "<div class=\"logo\"><div class=\"img\"><img src=\"App_Themes/Ann/image/logo.png\" /></div></div>";
                        html += "<div class=\"info\">";
                        html += "<div class=\"ct\">";
                        html += "<div class=\"ct-title\">Địa chỉ:</div>";
                        html += "<div class=\"ct-detail\">" + address + "</div>";
                        html += "<div class=\"ct\">";
                        html += "<div class=\"ct-title\">Điện thoại/ Zalo:</div>";
                        html += "<div class=\"ct-detail\">";

                        html += "<a href = \"tel:+\" >" + phone + "</a></div>";

                        html += "<div class=\"ct\">";
                        html += "<div class=\"ct-title\">Facebook:</div>";
                        html += "<div class=\"ct-detail\">";
                        html += "<a href =\"https://facebook.com/bosiquanao.net\" target=\"_blank\" >https://facebook.com/bosiquanao.net</a>";
                        html += "</div>";
                        html += "</div>";
                        html += "<div class=\"ct\">";
                        html += "<div class=\"ct-title\">Website:</div>";
                        html += "<div class=\"ct-detail\">";
                        html += "<a href =\"\">ann.com.vn</a> ";
                        html += "</div> ";
                        html += "</div> ";
                        html += "</div> ";
                        html += "</div>";
                        html += "</div>";

                        html += productPrint;

                        html += "<div class=\"footer\"><h1> Cảm ơn quý khách </h ></div> ";
                        html += "</div>";

                        html += "</div>";
                        ltrprint.Text = html;
                        PJUtils.ShowMessageBoxSwAlertCallFunction("Tạo mới đơn hàng thành công", "s", true, "printInvoice()", Page);
                    }

                }
            }
        }
    }
}