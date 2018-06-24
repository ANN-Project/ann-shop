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
using static IM_PJ.pos;

namespace IM_PJ
{
    public partial class thong_tin_don_hang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.GetCurrent(this).AsyncPostBackTimeout = 600;

            if (!IsPostBack)
            {
                if (Session["userLoginSystem"] != null)
                {
                    string username = Session["userLoginSystem"].ToString();
                    var acc = AccountController.GetByUsername(username);
                    if (acc != null)
                    {
                        
                        Session["refund"] = "1";
                        var agent = acc.AgentID;
                        if (agent == 1)
                        {
                            hdfIsMain.Value = "1";
                        }
                        else
                        {
                            hdfIsMain.Value = "0";
                        }

                        if (acc.RoleID == 0)
                        {

                        }
                        else if (acc.RoleID == 2)
                        {
                            hdfUsername.Value = acc.Username;
                        }
                        else
                        {
                            Response.Redirect("/dang-nhap");
                        }
                    }
                }
                else
                {
                    Response.Redirect("/dang-nhap");
                }
                LoadTransportCompany();
                LoadData();
            }
        }
        public void LoadData()
        {
            int ID = Request.QueryString["id"].ToInt(0);
            if (ID > 0)
            {
                var order = OrderController.GetByID(ID);
                if (order != null)
                {
                    string username = HttpContext.Current.Session["userLoginSystem"].ToString();
                    var acc = AccountController.GetByUsername(username);
                    if(acc.RoleID != 0)
                    {
                        if (order.CreatedBy != acc.Username)
                        {
                            Response.Redirect("/danh-sach-don-hang");
                        }
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
                    ViewState["ID"] = ID;
                    Session["odid"] = ID;
                    int AgentID = Convert.ToInt32(order.AgentID);
                    txtPhone.Text = order.CustomerPhone;
                    txtFullname.Text = order.CustomerName;
                    txtAddress.Text = order.CustomerAddress;
                    var cus = CustomerController.GetByID(order.CustomerID.Value);
                    if (cus != null)
                    {
                        txtNick.Text = cus.Nick;
                        if (string.IsNullOrEmpty(cus.Nick))
                        {
                            txtNick.Enabled = true;
                        }
                        
                        txtZalo.Text = cus.Zalo;
                        if (string.IsNullOrEmpty(cus.Zalo))
                        {
                            txtZalo.Enabled = true;
                        }

                        txtFacebook.Text = cus.Facebook;
                        if (!string.IsNullOrEmpty(cus.Facebook))
                        {
                            ltrFb.Text += "<a href =\"" + cus.Facebook + "\" class=\"btn primary-btn fw-btn not-fullwidth\" target=\"_blank\">Xem</a>";
                        }
                        else
                        {
                            txtFacebook.Enabled = true;
                        }
                    }
                    int customerID = Convert.ToInt32(order.CustomerID);
                    ltrViewDetail.Text = "<a href=\"javascript:;\" class=\"btn primary-btn fw-btn not-fullwidth\" onclick=\"viewCustomerDetail('" + customerID + "')\"><i class=\"fa fa-address-card-o\" aria-hidden=\"true\"></i> Xem chi tiết</a>";
                    ltrViewDetail.Text += "<a href=\"chi-tiet-khach-hang?id=" + customerID + "\" class=\"btn primary-btn fw-btn not-fullwidth edit-customer-btn\" target=\"_blank\"><i class=\"fa fa-pencil-square-o\" aria-hidden=\"true\"></i> Chỉnh sửa</a>";
                    ltrViewDetail.Text += "<a href=\"javascript:;\" class=\"btn primary-btn fw-btn not-fullwidth clear-btn\" onclick=\"clearCustomerDetail()\"><i class=\"fa fa-times\" aria-hidden=\"true\"></i> Bỏ qua</a>";
                    var d = DiscountCustomerController.getbyCustID(customerID);
                    if (d.Count > 0)
                    {
                        var da = d[0].DiscountAmount;
                        hdfIsDiscount.Value = "1";
                        hdfDiscountAmount.Value = da.ToString();
                        ltrDiscountInfo.Text = "<strong>Khách hàng được chiết khấu: " + string.Format("{0:N0}", Convert.ToDouble(da)) + " vnđ/sản phẩm.</strong>";
                    }
                    else
                    {
                        hdfIsDiscount.Value = "0";
                        hdfDiscountAmount.Value = "0";
                    }
                    int customerType = Convert.ToInt32(order.OrderType);
                    ltrCustomerType.Text = "";
                    ltrCustomerType.Text += "<select class=\"form-control customer-type\" onchange=\"getProductPrice($(this))\">";
                    if (customerType == 1)
                    {
                        ltrCustomerType.Text += "<option value=\"2\">Khách mua sỉ</option>";
                        ltrCustomerType.Text += "<option value=\"1\" selected>Khách mua lẻ</option>";

                    }
                    else
                    {
                        ltrCustomerType.Text += "<option value=\"2\" selected>Khách mua sỉ</option>";
                        ltrCustomerType.Text += "<option value=\"1\">Khách mua lẻ</option>";

                    }
                    ltrCustomerType.Text += "</select>";


                    double ProductQuantity = 0;
                    double totalPrice = Convert.ToDouble(order.TotalPrice);
                    double totalPriceNotDiscount = Convert.ToDouble(order.TotalPriceNotDiscount);

                    hdfcheckR.Value = "";
                    
                    int totalrefund = 0;
                    if (order.RefundsGoodsID > 0)
                    {
                        var re = RefundGoodController.GetByID(order.RefundsGoodsID.Value);
                        if (re != null)
                        {
                            totalrefund = Convert.ToInt32(re.TotalPrice);
                            hdfcheckR.Value = order.RefundsGoodsID.ToString() + "," + re.TotalPrice;
                        }
                       
                        ltrtotalpricedetail.Text = string.Format("{0:N0}", totalPrice - totalrefund);

                        ltrTotalPriceRefund.Text = string.Format("{0:N0}", totalrefund);
                    }

                    hdfDiscountInOrder.Value = "";

                    if (order.DiscountPerProduct > 0)
                    {
                        hdfDiscountInOrder.Value = order.DiscountPerProduct.ToString();
                    }

                    int paymentStatus = Convert.ToInt32(order.PaymentStatus);
                    int excuteStatus = Convert.ToInt32(order.ExcuteStatus);
                    int shipping = Convert.ToInt32(order.ShippingType);
                    int TransportCompanyID = Convert.ToInt32(order.TransportCompanyID);
                    int TransportCompanySubID = Convert.ToInt32(order.TransportCompanySubID);
                    int paymenttype = Convert.ToInt32(order.PaymentType);
                    #region Lấy danh sách sản phẩm
                    var orderdetails = OrderDetailController.GetByOrderID(ID);
                    string html = "";
                    string Print = "";
                    if (orderdetails.Count > 0)
                    {
                        int t = 0;
                        int orderitem = 0;
                        foreach (var item in orderdetails)
                        {
                            ProductQuantity += Convert.ToDouble(item.Quantity);

                            int ProductType = Convert.ToInt32(item.ProductType);
                            int ProductID = Convert.ToInt32(item.ProductID);
                            int ProductVariableID = Convert.ToInt32(item.ProductVariableID);
                            double ItemPrice = Convert.ToDouble(item.Price);
                            string SKU = item.SKU;
                            double Giabansi = 0;
                            double Giabanle = 0;
                            string stringGiabansi = "";
                            string stringGiabanle = "";
                            double QuantityInstock = 0;
                            string ProductImageOrigin = "";
                            string ProductVariable = "";
                            string ProductName = "";
                            int PID = 0;
                            string ProductVariableName = "";
                            string ProductVariableValue = "";
                            string ProductVariableSave = "";
                            double QuantityMainInstock = 0;
                            string ProductImage = "";
                            string QuantityMainInstockString = "";
                            string QuantityInstockString = "";
                            string productVariableDescription = item.ProductVariableDescrition;

                            if (ProductType == 1)
                            {
                                PID = ProductID;
                                var product = ProductController.GetBySKU(SKU);
                                if (product != null)
                                {
                                    double mainstock = PJUtils.TotalProductQuantityInstock(1, SKU);

                                    if (customerType == 1)
                                    {
                                        Giabansi = Convert.ToDouble(product.Regular_Price);
                                        Giabanle = ItemPrice;
                                    }
                                    else
                                    {
                                        Giabansi = ItemPrice;
                                        Giabanle = Convert.ToDouble(product.Retail_Price);
                                    }
                                    stringGiabansi = string.Format("{0:N0}", Giabansi);
                                    stringGiabanle = string.Format("{0:N0}", Giabanle);
                                    string variablename = "";
                                    string variablevalue = "";
                                    string variable = "";

                                    

                                    QuantityInstock = mainstock;
                                    QuantityInstockString = string.Format("{0:N0}", mainstock);

                                    var img = ProductImageController.GetFirstByProductID(product.ID);
                                    if (!string.IsNullOrEmpty(product.ProductImage))
                                    {
                                        ProductImage = "<img src=\"" + product.ProductImage + "\" />";
                                        ProductImageOrigin = product.ProductImage;
                                    }
                                    else if (img.ProductImage != null)
                                    {
                                        ProductImage = "<img src=\"" + img.ProductImage + "\" />";
                                        ProductImageOrigin = img.ProductImage;
                                    }
                                    else
                                    {
                                        ProductImage = "<img src=\"/App_Themes/Ann/image/placeholder.png\" />";
                                        ProductImageOrigin = "";
                                    }
                                    ProductVariable = variable;
                                    ProductName = product.ProductTitle;

                                    QuantityMainInstock = mainstock;
                                    QuantityMainInstockString = string.Format("{0:N0}", mainstock);
                                    ProductVariableSave = item.ProductVariableDescrition;

                                    ProductVariableName = variablename;
                                    ProductVariableValue = variablevalue;
                                }
                            }
                            else
                            {
                                PID = ProductVariableID;
                                var productvariable = ProductVariableController.GetBySKU(SKU);
                                if (productvariable != null)
                                {
                                    SKU = productvariable.SKU.Trim().ToUpper();

                                    double mainstock = PJUtils.TotalProductQuantityInstock(1, SKU);

                                    if (customerType == 1)
                                    {
                                        Giabansi = Convert.ToDouble(productvariable.Regular_Price);
                                        Giabanle = ItemPrice;
                                    }
                                    else
                                    {
                                        Giabansi = ItemPrice;
                                        Giabanle = Convert.ToDouble(productvariable.RetailPrice);
                                    }
                                    stringGiabansi = string.Format("{0:N0}", Giabansi);
                                    stringGiabanle = string.Format("{0:N0}", Giabanle);


                                    string variablename = "";
                                    string variablevalue = "";
                                    string variable = "";

                                    string[] vs = productVariableDescription.Split('|');
                                    if (vs.Length - 1 > 0)
                                    {
                                        for (int i = 0; i < vs.Length - 1; i++)
                                        {
                                            string[] items = vs[i].Split(':');
                                            variable += items[0] + ":" + items[1] + "<br/>";
                                            variablename += items[0] + "|";
                                            variablevalue += items[1] + "|";
                                        }
                                    }

                                    QuantityInstock = mainstock;
                                    QuantityInstockString = string.Format("{0:N0}", mainstock);

                                    var _product = ProductController.GetByID(Convert.ToInt32(productvariable.ProductID));

                                    if (!string.IsNullOrEmpty(productvariable.Image))
                                    {
                                        ProductImage = "<img src=\"" + productvariable.Image + "\" />";
                                        ProductImageOrigin = productvariable.Image;
                                    }
                                    else if (!string.IsNullOrEmpty(_product.ProductImage))
                                    {
                                        ProductImage = "<img src=\"" + _product.ProductImage + "\" />";
                                        ProductImageOrigin = _product.ProductImage;
                                    }
                                    else
                                    {
                                        ProductImage = "<img src=\"/App_Themes/Ann/image/placeholder.png\" />";
                                        ProductImageOrigin = "";
                                    }

                                    ProductVariable = variable;

                                    if (_product != null)
                                        ProductName = _product.ProductTitle;

                                    QuantityMainInstock = mainstock;
                                    QuantityMainInstockString = string.Format("{0:N0}", mainstock);
                                    ProductVariableSave = item.ProductVariableDescrition;

                                    ProductVariableName = variablename;
                                    ProductVariableValue = variablevalue;
                                }
                            }
                            orderitem++;
                            html += "<tr class=\"product-result\" data-orderdetailid=\"" + item.ID + "\" data-giabansi=\"" + Giabansi + "\" data-giabanle=\"" + Giabanle + "\" " +
                                                "data-quantityinstock=\"" + QuantityInstock + "\" data-productimageorigin=\"" + ProductImageOrigin + "\" " +
                                                "data-productvariable=\"" + ProductVariable + "\" data-productname=\"" + ProductName + "\" " +
                                                "data-sku=\"" + SKU + "\" data-producttype=\"" + ProductType + "\" data-id=\"" + PID + "\" " +
                                                "data-productnariablename=\"" + ProductVariableName + "\" " +
                                                "data-productvariablevalue =\"" + ProductVariableValue + "\" " +
                                                "data-productvariablesave =\"" + ProductVariableSave + "\" " +
                                                "data-quantitymaininstock=\"" + QuantityMainInstock + "\">";
                            html += "   <td class=\"order-item\">" + orderitem + "";
                            html += "   <td class=\"image-item\">" + ProductImage + "";
                            html += "   <td class=\"name-item\">" + ProductName + "</td>";
                            html += "   <td class=\"sku-item\">" + SKU + "</td>";
                            html += "   <td class=\"variable-item\">" + ProductVariable + "</td>";
                            html += "   <td class=\"price-item gia-san-pham\" data-price=\"" + ItemPrice + "\">" + string.Format("{0:N0}", ItemPrice) + "</td>";
                            html += "   <td class=\"quantity-item soluong\">" + QuantityInstockString + "</td>";
                            html += "   <td class=\"quantity-item\"><input data-quantity=\"" + item.Quantity + "\" value=\"" + item.Quantity + "\" type=\"text\" max=\"" + QuantityInstock + "\" class=\"form-control in-quanlity\" value=\"1\" onblur=\"checkQuantiy($(this))\" onkeypress='return event.charCode >= 48 && event.charCode <= 57'/></td>";
                            int k = Convert.ToInt32(ItemPrice) * Convert.ToInt32(item.Quantity);
                            html += "<td class=\"total-item totalprice-view\">" + string.Format("{0:N0}", k) + "</td>";
                            html += "   <td class=\"trash-item\"><a href=\"javascript:;\" class=\"link-btn\" onclick=\"deleteRow($(this))\"><i class=\"fa fa-trash\"></i></a>    </td>";

                            html += "</tr>";


                            Print += " <tr>";
                            t++;
                            Print += "<td>" + t + "</td>";
                            Print += "<td>" + SKU + " - " + ProductName + " - " + ProductVariableSave.Replace("|", ", ") + "</td> ";
                            Print += "<td>" + item.Quantity + "</td>";
                            Print += "<td>" + string.Format("{0:N0}", ItemPrice) + "</td>";

                            Print += "<td> " + string.Format("{0:N0}", k) + "</td>";

                            Print += "</tr>";

                        }
                        ltrProducts.Text = html;

                    }
                    #endregion
                    #region HiddenField
                    hdfCheckCustomer.Value = "1";
                    hdfOrderType.Value = customerType.ToString();
                    hdfTotalPrice.Value = totalPrice.ToString();
                    hdfTotalPriceNotDiscount.Value = totalPriceNotDiscount.ToString();
                    hdfPaymentStatus.Value = paymentStatus.ToString();
                    hdfExcuteStatus.Value = excuteStatus.ToString();
                    hdftotal.Value = ProductQuantity.ToString();

                    #endregion
                    ddlPaymentStatus.SelectedValue = paymentStatus.ToString();
                    ddlExcuteStatus.SelectedValue = excuteStatus.ToString();
                    ddlPaymentType.SelectedValue = paymenttype.ToString();
                    ddlShippingType.SelectedValue = shipping.ToString();

                    LoadTransportCompanySubID(TransportCompanyID);
                    ddlTransportCompanyID.SelectedValue = TransportCompanyID.ToString();
                    ddlTransportCompanySubID.SelectedValue = TransportCompanySubID.ToString();

                    txtShippingCode.Text = order.ShippingCode;
                    txtOrderNote.Text = order.OrderNote;

                    ltrProductQuantity.Text = string.Format("{0:N0}", ProductQuantity) + " sản phẩm";
                    ltrTotalNotDiscount.Text = string.Format("{0:N0}", Convert.ToDouble(order.TotalPriceNotDiscount));
                    ltrTotalprice.Text = string.Format("{0:N0}", Convert.ToDouble(order.TotalPrice));
                    pDiscount.Value = order.DiscountPerProduct;
                    pFeeShip.Value = Convert.ToDouble(order.FeeShipping);

                    ltrOtherFeeName.Text = order.OtherFeeName;
                    txtOtherFeeName.Text = order.OtherFeeName;
                    pOtherFee.Value = Convert.ToDouble(order.OtherFeeValue);

                    ltrTotalAfterCK.Text = string.Format("{0:N0}", (Convert.ToDouble(order.TotalPriceNotDiscount) - Convert.ToDouble(order.TotalDiscount)));
                    ltrOrderID.Text = ID.ToString();
                    ltrCreateBy.Text = order.CreatedBy;
                    ltrCreateDate.Text = order.CreatedDate.ToString();
                    ltrDateDone.Text = "Chưa hoàn tất";
                    if (order.DateDone != null && order.ExcuteStatus == 2)
                    {
                        ltrDateDone.Text = order.DateDone.ToString();
                    }
                    ltrOrderNote.Text = order.OrderNote;
                    ltrOrderQuantity.Text = ProductQuantity.ToString();
                    ltrOrderTotalPrice.Text = string.Format("{0:N0}", Convert.ToDouble(order.TotalPrice));
                    ltrOrderStatus.Text = PJUtils.OrderExcuteStatus(Convert.ToInt32(order.ExcuteStatus));

                    ltrOrderType.Text = PJUtils.OrderType(Convert.ToInt32(order.OrderType));
                    ltrPrint.Text = "<a href=\"/print-invoice.aspx?id=" + ID + "\" target=\"_blank\" class=\"btn primary-btn fw-btn not-fullwidth\"><i class=\"fa fa-print\" aria-hidden=\"true\"></i> In hóa đơn</a>";
                    ltrPrint.Text += "<a href=\"/print-invoice.aspx?id=" + ID + "&merge=1\" target=\"_blank\" class=\"btn primary-btn fw-btn not-fullwidth print-invoice-merged\"><i class=\"fa fa-print\" aria-hidden=\"true\"></i> In hóa đơn gộp</a>";
                    ltrPrint.Text += "<a href=\"javascript:;\" onclick=\"warningGetOrderImage(" + ID + ")\" target=\"_blank\" class=\"btn primary-btn fw-btn not-fullwidth print-invoice-merged\"><i class=\"fa fa-picture-o\" aria-hidden=\"true\"></i> Lấy ảnh đơn hàng</a>";
                    ltrPrint.Text += "<a href=\"/print-shipping-note?id=" + ID + "\" target=\"_blank\" class=\"btn primary-btn fw-btn not-fullwidth print-invoice-merged\"><i class=\"fa fa-file-text-o\" aria-hidden=\"true\"></i> In phiếu gửi hàng</a>";
                }
            }
        }

        public void LoadTransportCompany()
        {
            var TransportCompany = TransportCompanyController.GetTransportCompany();
            ddlTransportCompanyID.Items.Clear();
            ddlTransportCompanyID.Items.Insert(0, new ListItem("Chọn chành xe", "0"));
            if (TransportCompany.Count > 0)
            {
                foreach (var p in TransportCompany)
                {
                    ListItem listitem = new ListItem(p.CompanyName, p.ID.ToString());
                    ddlTransportCompanyID.Items.Add(listitem);
                }
                ddlTransportCompanyID.DataBind();
            }
        }

        public void LoadTransportCompanySubID(int ID)
        {
            ddlTransportCompanySubID.Items.Clear();
            ddlTransportCompanySubID.Items.Insert(0, new ListItem("Chọn nơi nhận", "0"));
            if (ID > 0)
            {
                var ShipTo = TransportCompanyController.GetReceivePlace(ID); ;

                if (ShipTo.Count > 0)
                {
                    foreach (var p in ShipTo)
                    {
                        ListItem listitem = new ListItem(p.ShipTo, p.SubID.ToString());
                        ddlTransportCompanySubID.Items.Add(listitem);
                    }
                }
                ddlTransportCompanySubID.DataBind();
            }
        }

        protected void ddlTransportCompanyID_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTransportCompanySubID(ddlTransportCompanyID.SelectedValue.ToInt(0));
        }

        [WebMethod]
        public static string getProduct(string textsearch, int gettotal)
        {
            List<ProductGetOut> ps = new List<ProductGetOut>();
            string username = HttpContext.Current.Session["userLoginSystem"].ToString();
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

        [WebMethod]
        public static string findReturnOrder(string order, string remove)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            if (remove.ToInt() == 0)
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
                HttpContext.Current.Session["refund"] = 0;
                return serializer.Serialize(null);
            }
        }

        [WebMethod]
        public static string UpdateStatus()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string username = HttpContext.Current.Session["userLoginSystem"].ToString();
            var acc = AccountController.GetByUsername(username);
            string orderid = HttpContext.Current.Session["odid"].ToString();
            var order = OrderController.GetByID(orderid.ToInt());
            if (order != null)
            {
                int i = OrderController.UpdateExcuteStatus(order.ID, acc.Username);
                if (i > 0)
                {
                    return serializer.Serialize(i);
                }
                else
                {
                    return serializer.Serialize(null);
                }
            }
            else
                return serializer.Serialize(null);

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

        [WebMethod]
        public static void Delete(List<tbl_OrderDetail> listOrderDetail)
        {
            DateTime currentDate = DateTime.Now;
            string username = HttpContext.Current.Session["userLoginSystem"].ToString();
            var acc = AccountController.GetByUsername(username);
            if (listOrderDetail != null && listOrderDetail.Count > 0)
            {
                foreach (var orderDetail in listOrderDetail)
                {
                    int AgentID = Convert.ToInt32(acc.AgentID);
                    int OrderID = orderDetail.ID;
                    string OrderSKU = orderDetail.SKU;
                    int ProductID = orderDetail.ProductID.Value;
                    double quantitynew = orderDetail.Quantity.Value;
                    string ord = OrderDetailController.Delete(OrderID, OrderSKU);

                    var parent = ProductVariableController.GetBySKU(OrderSKU);

                    if (parent != null)
                    {
                        StockManagerController.Insert(
                            new tbl_StockManager
                            {
                                AgentID = AgentID,
                                ProductID = 0,
                                ProductVariableID = ProductID,
                                Quantity = quantitynew,
                                QuantityCurrent = 0,
                                Type = 1,
                                NoteID = "Nhập kho khi xóa sản phẩm trong sửa đơn",
                                OrderID = OrderID,
                                Status = 10,
                                SKU = OrderSKU,
                                CreatedDate = currentDate,
                                CreatedBy = username,
                                MoveProID = 0,
                                ParentID = parent.ProductID
                            });
                    }
                    else
                    {
                        StockManagerController.Insert(
                            new tbl_StockManager
                            {
                                AgentID = AgentID,
                                ProductID = ProductID,
                                ProductVariableID = 0,
                                Quantity = quantitynew,
                                QuantityCurrent = 0,
                                Type = 1,
                                NoteID = "Nhập kho khi xóa sản phẩm trong sửa đơn",
                                OrderID = OrderID,
                                Status = 10,
                                SKU = OrderSKU,
                                CreatedDate = currentDate,
                                CreatedBy = username,
                                MoveProID = 0,
                                ParentID = ProductID
                            });
                    }
                }
            }
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
                    int OrderID = ViewState["ID"].ToString().ToInt(0);
                    if (OrderID > 0)
                    {
                        var order = OrderController.GetByID(OrderID);
                        if (order != null)
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

                            int PaymentType = ddlPaymentType.SelectedValue.ToInt(0);
                            int ShippingType = ddlShippingType.SelectedValue.ToInt(0);
                            int TransportCompanyID = ddlTransportCompanyID.SelectedValue.ToInt(0);
                            int TransportCompanySubID = ddlTransportCompanySubID.SelectedValue.ToInt(0);


                            var Customer = CustomerController.GetByPhone(CustomerPhone);
                            if (Customer != null)
                            {
                                CustomerID = Customer.ID;
                                string kq = CustomerController.Update(CustomerID, CustomerName, CustomerPhone, CustomerAddress, "", Convert.ToInt32(Customer.CustomerLevelID), Convert.ToInt32(Customer.Status), Customer.CreatedBy, currentDate, username, false, Zalo, Facebook, Customer.Note, Customer.ProvinceID.ToString(), Nick, Customer.Avatar, ShippingType, PaymentType, TransportCompanyID, TransportCompanySubID);
                            }
                            else
                            {
                                string kq = CustomerController.Insert(CustomerName, CustomerPhone, CustomerAddress, "", 0, 0, currentDate, username, false, Zalo, Facebook, "", "", Nick, "", ShippingType, PaymentType, TransportCompanyID, TransportCompanySubID);
                                if (kq.ToInt(0) > 0)
                                {
                                    CustomerID = kq.ToInt(0);
                                }
                            }


                            string totalPrice = hdfTotalPrice.Value.ToString();

                            string totalPriceNotDiscount = hdfTotalPriceNotDiscount.Value;
                            int PaymentStatusOld = Convert.ToInt32(order.PaymentStatus);
                            int ExcuteStatusOld = Convert.ToInt32(order.ExcuteStatus);
                            int PaymentStatus = ddlPaymentStatus.SelectedValue.ToInt(0);
                            int ExcuteStatus = ddlExcuteStatus.SelectedValue.ToInt(0);
                            
                            string ShippingCode = txtShippingCode.Text;
                            string OrderNote = txtOrderNote.Text;

                            double DiscountPerProduct = 0;
                            if (!string.IsNullOrEmpty(hdfDiscountAmount.Value))
                                DiscountPerProduct = Convert.ToDouble(hdfDiscountAmount.Value);
                            string sl = hdftotal.Value;
                            if (!string.IsNullOrEmpty(hdfTotalQuantity.Value))
                            {
                                sl = hdfTotalQuantity.Value;
                            }
                            double TotalDiscount = Convert.ToDouble(pDiscount.Value) * Convert.ToDouble(sl);
                            string FeeShipping = pFeeShip.Value.ToString();

                            string datedone = "";
                            if (order.DateDone != null)
                            {
                                datedone = order.DateDone.ToString();
                            }

                            if (order.ExcuteStatus != 2)
                            {
                                if (ExcuteStatus == 2)
                                {
                                    if (string.IsNullOrEmpty(order.DateDone.ToString()))
                                    {
                                        datedone = DateTime.Now.ToString();
                                    }
                                }
                            }
                            else
                            {
                                if (ExcuteStatus == 2)
                                {
                                    DateTime old = Convert.ToDateTime(order.DateDone).Date;
                                    if (old == DateTime.Now.Date)
                                    {
                                        datedone = DateTime.Now.ToString();
                                    }
                                }
                            }

                            string OtherFeeName = txtOtherFeeName.Text;
                            double OtherFeeValue = Convert.ToDouble(pOtherFee.Value);

                            string ret = OrderController.UpdateOnSystem(OrderID, OrderType, AdditionFee, DisCount, CustomerID, CustomerName, CustomerPhone,
                                CustomerAddress, "", totalPrice, totalPriceNotDiscount, PaymentStatus, ExcuteStatus, currentDate, username,
                                Convert.ToDouble(pDiscount.Value), TotalDiscount, FeeShipping, Convert.ToDouble(order.GuestPaid), Convert.ToDouble(order.GuestChange), PaymentType, ShippingType, OrderNote, datedone, 0, ShippingCode, TransportCompanyID, TransportCompanySubID, OtherFeeName, OtherFeeValue);

                            // Xử lý hủy hàng
                            if (ExcuteStatus == 3)
                            {
                                var productRefund = OrderDetailController.GetByOrderID(order.ID);

                                foreach(tbl_OrderDetail product in productRefund)
                                {
                                    int parentID = 0;

                                    if (product.ProductID != 0)
                                    {
                                        parentID = product.ProductID.Value;
                                    }
                                    else
                                    {
                                        parentID = ProductVariableController.GetByID(product.ProductVariableID.Value).ProductID.Value;
                                    }

                                    StockManagerController.Insert(
                                        new tbl_StockManager {
                                            AgentID = product.AgentID,
                                            ProductID = product.ProductID,
                                            ProductVariableID = product.ProductVariableID,
                                            Quantity = product.Quantity,
                                            QuantityCurrent = 0,
                                            Type = 1,
                                            NoteID = "Nhập kho do hủy đơn hàng",
                                            OrderID = product.OrderID,
                                            Status = 4,
                                            SKU = product.SKU,
                                            CreatedDate = currentDate,
                                            CreatedBy = product.CreatedBy,
                                            MoveProID = 0,
                                            ParentID = parentID
                                        });
                                }

                                PJUtils.ShowMessageBoxSwAlertCallFunction("Hủy đơn hàng thành công", "s", true, "addPayAllClicked()", Page);

                                Response.Redirect("/danh-sach-don-hang.aspx");
                                return;
                            }

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
                                        int OrderDetailID = itemValue[11].ToInt(0);
                                        
                                        // Xử lý với trạng thái của đơn hàng đã hy
                                        if (ExcuteStatusOld == 3)
                                        {
                                            var orderDetail = OrderDetailController.GetByID(OrderDetailID);

                                            if(orderDetail != null)
                                            {
                                                OrderDetailController.UpdateQuantity(OrderDetailID, Quantity, currentDate, username);
                                            }
                                            else
                                            {
                                                OrderDetailController.Insert(new tbl_OrderDetail()
                                                {
                                                    AgentID = AgentID,
                                                    OrderID = OrderID,
                                                    SKU = SKU,
                                                    ProductID = ProductID,
                                                    ProductVariableID = ProductVariableID,
                                                    ProductVariableDescrition = ProductVariableSave,
                                                    Quantity = Quantity,
                                                    Price = Price,
                                                    Status = 1,
                                                    DiscountPrice = 0,
                                                    ProductType = 2,
                                                    CreatedDate = currentDate,
                                                    CreatedBy = username,
                                                    IsCount = true
                                                });
                                            }

                                            StockManagerController.Insert(
                                                new tbl_StockManager {
                                                    AgentID = AgentID,
                                                    ProductID = ProductID,
                                                    ProductVariableID = ProductVariableID,
                                                    Quantity = Quantity,
                                                    QuantityCurrent = 0,
                                                    Type = 2,
                                                    NoteID = "Xuất kho khi chuyển trạng từ trạng thái hủy đơn hàng sang trạng thái khác",
                                                    OrderID = OrderID,
                                                    Status = 4,
                                                    SKU = SKU,
                                                    CreatedDate = currentDate,
                                                    CreatedBy = username,
                                                    MoveProID = 0,
                                                    ParentID = parentID,
                                                });

                                            continue;
                                        }

                                        // kiểm tra sản phẩm này đã có trong đơn chưa?
                                        // nếu sản phẩm này có trong đơn có rồi thì chỉnh sửa
                                        if (OrderDetailID > 0)
                                        {
                                            var od = OrderDetailController.GetByID(OrderDetailID);
                                            
                                            if (od != null)
                                            {
                                                if (od.IsCount == true)
                                                {
                                                    double quantityOld = Convert.ToDouble(od.Quantity);
                                                    if (producttype == 1)
                                                    {
                                                        if (quantityOld > Quantity)
                                                        {
                                                            //cộng vô kho
                                                            double quantitynew = quantityOld - Quantity;
                                                            StockManagerController.Insert(
                                                                new tbl_StockManager {
                                                                    AgentID = AgentID,
                                                                    ProductID = ID,
                                                                    ProductVariableID = 0,
                                                                    Quantity = quantitynew,
                                                                    QuantityCurrent = 0,
                                                                    Type = 1,
                                                                    NoteID = "Nhập kho khi giảm số lượng trong sửa đơn",
                                                                    OrderID = OrderID,
                                                                    Status = 4,
                                                                    SKU = SKU,
                                                                    CreatedDate = currentDate,
                                                                    CreatedBy = username,
                                                                    MoveProID = 0,
                                                                    ParentID = parentID,
                                                                });
                                                        }
                                                        else if (quantityOld < Quantity)
                                                        {
                                                            // tính số lượng kho cần xuất thêm
                                                            double quantitynew = Quantity - quantityOld;

                                                            //trừ tiếp trong kho
                                                            StockManagerController.Insert(
                                                                new tbl_StockManager {
                                                                    AgentID = AgentID,
                                                                    ProductID = ID,
                                                                    ProductVariableID = 0,
                                                                    Quantity = quantitynew,
                                                                    QuantityCurrent = 0,
                                                                    Type = 2,
                                                                    NoteID = "Xuất kho khi tăng số lượng trong sửa đơn",
                                                                    OrderID = OrderID,
                                                                    Status = 3,
                                                                    SKU = SKU,
                                                                    CreatedDate = currentDate,
                                                                    CreatedBy = username,
                                                                    MoveProID = 0,
                                                                    ParentID = parentID,
                                                                });
                                                        }
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
                                                        if (quantityOld > Quantity)
                                                        {
                                                            //cộng vô kho
                                                            double quantitynew = quantityOld - Quantity;
                                                            StockManagerController.Insert(
                                                                new tbl_StockManager {
                                                                    AgentID = AgentID,
                                                                    ProductID = 0,
                                                                    ProductVariableID = ID,
                                                                    Quantity = quantitynew,
                                                                    QuantityCurrent = 0,
                                                                    Type = 1,
                                                                    NoteID = "Nhập kho khi giảm số lượng trong sửa đơn",
                                                                    OrderID = OrderID,
                                                                    Status = 4,
                                                                    SKU = SKU,
                                                                    CreatedDate = currentDate,
                                                                    CreatedBy = username,
                                                                    MoveProID = 0,
                                                                    ParentID = parentID,
                                                                });
                                                        }
                                                        else if (quantityOld < Quantity)
                                                        {
                                                            // tính số lượng kho cần xuất thêm
                                                            double quantitynew = Quantity - quantityOld;

                                                            //trừ tiếp trong kho
                                                            StockManagerController.Insert(
                                                                new tbl_StockManager {
                                                                    AgentID = AgentID,
                                                                    ProductID = 0,
                                                                    ProductVariableID = ID,
                                                                    Quantity = quantitynew,
                                                                    QuantityCurrent = 0,
                                                                    Type = 2,
                                                                    NoteID = "Xuất kho khi tăng số lượng trong sửa đơn",
                                                                    OrderID = OrderID,
                                                                    Status = 3,
                                                                    SKU = SKU,
                                                                    CreatedDate = currentDate,
                                                                    CreatedBy = username,
                                                                    MoveProID = 0,
                                                                    ParentID = parentID,
                                                                });
                                                        }
                                                    }
                                                }
                                                else
                                                {
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
                                                                NoteID = "Xuất kho thêm mới sản phẩm khi sửa đơn",
                                                                OrderID = OrderID,
                                                                Status = 3,
                                                                SKU = SKU,
                                                                CreatedDate = currentDate,
                                                                CreatedBy = username,
                                                                MoveProID = 0,
                                                                ParentID = ID,
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
                                                                NoteID = "Xuất kho thêm mới sản phẩm khi sửa đơn",
                                                                OrderID = OrderID,
                                                                Status = 3,
                                                                SKU = SKU,
                                                                CreatedDate = currentDate,
                                                                CreatedBy = username,
                                                                MoveProID = 0,
                                                                ParentID = parentID,
                                                            });
                                                    }
                                                    OrderDetailController.UpdateIsCount(OrderDetailID, true);
                                                }

                                                // cập nhật số lượng sản phẩm trong đơn hàng
                                                OrderDetailController.UpdateQuantity(OrderDetailID, Quantity, currentDate, username);
                                            }
                                        }
                                        // nếu sản phẩm này chưa có trong đơn thì thêm vào
                                        else
                                        {
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
                                                        NoteID = "Xuất kho khi thêm sản phẩm mới trong sửa đơn",
                                                        OrderID = OrderID,
                                                        Status = 3,
                                                        SKU = SKU,
                                                        CreatedDate = currentDate,
                                                        CreatedBy = username,
                                                        MoveProID = 0,
                                                        ParentID = ID,
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
                                                        NoteID = "Xuất kho khi thêm sản phẩm mới trong sửa đơn",
                                                        OrderID = OrderID,
                                                        Status = 3,
                                                        SKU = SKU,
                                                        CreatedDate = currentDate,
                                                        CreatedBy = username,
                                                        MoveProID = 0,
                                                        ParentID = parentID,
                                                    });
                                            }
                                        }
                                    }
                                }

                                // thêm đơn hàng đổi trả
                                string refund = HttpContext.Current.Session["refund"].ToString();
                                if (refund == "0")
                                {
                                    if (hdfcheckR.Value != "")
                                    {
                                        string[] b = hdfcheckR.Value.Split(',');
                                        var update_returnorder = RefundGoodController.UpdateStatus(b[0].ToInt(), acc.Username, 1);
                                        var update_order = OrderController.UpdateRefund(OrderID, 0, acc.Username);
                                    }
                                }
                                else if (refund != "1")
                                {
                                    string[] RefundID = refund.Split('|');
                                    var update_returnorder = RefundGoodController.UpdateStatus(RefundID[0].ToInt(), acc.Username, 2);
                                    var update_order = OrderController.UpdateRefund(OrderID, RefundID[0].ToInt(), acc.Username);

                                    if(hdfcheckR.Value != "")
                                    {
                                        string[] k = hdfcheckR.Value.Split(',');
                                        if (k[0] != RefundID[0])
                                        {
                                            var update_oldreturnorder = RefundGoodController.UpdateStatus(k[0].ToInt(), acc.Username, 1);
                                        }
                                    }
                                }

                                HttpContext.Current.Session.Remove("refund");

                                PJUtils.ShowMessageBoxSwAlertCallFunction("Cập nhật đơn hàng thành công", "s", true, "addPayAllClicked()", Page);
                            }
                        }
                    }
                }
            }
        }
    }
}