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
    public partial class print_invoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userLoginSystem"] != null)
                {
                    LoadData();
                }
                else
                {
                    Response.Redirect("/dang-nhap");
                }
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
                    string Print = "";

                    double TotalQuantity = 0;

                    var orderdetails = OrderDetailController.GetByOrderID(ID);
                    if (orderdetails.Count > 0)
                    {

                        int t = 0;
                        foreach (var item in orderdetails)
                        {
                            TotalQuantity += Convert.ToDouble(item.Quantity);

                            int ProductType = Convert.ToInt32(item.ProductType);
                            double ItemPrice = Convert.ToDouble(item.Price);
                            string SKU = item.SKU;
                            string ProductName = "";
                            int SubTotal = Convert.ToInt32(ItemPrice) * Convert.ToInt32(item.Quantity);

                            t++;
                            Print += " <tr>";
                            Print += "<td>" + t + "</td>";

                            if (ProductType == 1)
                            {
                                var product = ProductController.GetBySKU(SKU);
                                if (product != null)
                                {
                                    ProductName = product.ProductTitle;
                                    Print += "<td>" + SKU + " - " + ProductName + "</td> ";
                                }
                            }
                            else
                            {
                                var productvariable = ProductVariableController.GetBySKU(SKU);
                                if (productvariable != null)
                                {
                                    var parent_product = ProductController.GetByID(Convert.ToInt32(productvariable.ProductID));
                                    if (parent_product != null)
                                    {
                                        ProductName = parent_product.ProductTitle;
                                    }
                                    Print += "<td>" + SKU + " - " + ProductName + " - " + item.ProductVariableDescrition.Replace("|", ", ") + "</td> ";
                                }
                            }

                            Print += "<td>" + item.Quantity + "</td>";
                            Print += "<td>" + string.Format("{0:N0}", ItemPrice) + "</td>";
                            Print += "<td> " + string.Format("{0:N0}", SubTotal) + "</td>";
                            Print += "</tr>";

                        }
                        string productPrint = "";
                        string shtml = "";

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
                        productPrint += " <td>" + order.ID + "</td>";
                        productPrint += " </tr>";
                        productPrint += "  <tr>";
                        productPrint += "  <td>Ngày tạo</td>";
                        string date = string.Format("{0:dd/MM/yyyy HH:mm}", order.CreatedDate);
                        productPrint += " <td>" + date + "</td>";
                        productPrint += "</tr>";
                        productPrint += "<tr>";
                        productPrint += "<td>Ngày hoàn tất</td>";
                        if (!string.IsNullOrEmpty(order.DateDone.ToString()))
                        {
                            string datedone = string.Format("{0:dd/MM/yyyy HH:mm}", order.DateDone);
                            productPrint += "<td>" + datedone + "</td>";
                        }
                        else
                            productPrint += "<td></td>";
                        productPrint += " </tr>";
                        productPrint += " <tr>";
                        productPrint += "<td>Loại đơn</td>";
                        if (order.OrderType == 1)
                            productPrint += "<td>Đơn lẻ</td>";
                        if (order.OrderType == 2)
                            productPrint += "  <td>Đơn sỉ</td>";
                        productPrint += "</tr>";
                        productPrint += " <tr>";
                        productPrint += " <td>Nhân viên</td>";
                        productPrint += " <td>" + order.CreatedBy + "</td>";
                        productPrint += "</tr>";
                        productPrint += "<tr>";
                        productPrint += "  <td>Khách hàng</td>";
                        productPrint += "  <td>" + order.CustomerName + "</td>";
                        productPrint += " </tr>";
                        productPrint += "<tr>";
                        productPrint += " <td>Điện thoại</td>";
                        productPrint += " <td>" + order.CustomerPhone + "</td>";
                        productPrint += "</tr>";
                        productPrint += "<tr>";
                        productPrint += "   <td>Ghi chú</td>";
                        productPrint += "<td>" + order.OrderNote + "</td>";
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
                        productPrint += "<th>Số lượng</th>";
                        productPrint += "<th>Giá</th>";
                        productPrint += "<th>Tổng</th>";
                        productPrint += " </thead>";
                        productPrint += "<tbody>";
                        productPrint += Print;
                        productPrint += "<tr>";
                        productPrint += "<td colspan =\"4\" > Số lượng </td>";
                        productPrint += "<td>" + TotalQuantity + "</td>";
                        productPrint += "</tr>";
                        productPrint += " <tr>";
                        productPrint += " <td colspan =\"4\"> Thành tiền </td>";
                        productPrint += " <td>" + string.Format("{0:N0}", Convert.ToDouble(order.TotalPriceNotDiscount)) + "</td>";
                        productPrint += " </tr>";
                        productPrint += " <tr>";
                        productPrint += "  <td colspan =\"4\"> Chiết khấu mỗi cái </td>";
                        productPrint += " <td>" + string.Format("{0:N0}", Convert.ToDouble(order.DiscountPerProduct)) + "</td>";
                        productPrint += " </tr>";
                        productPrint += "<tr>";
                        productPrint += " <td colspan =\"4\" > Sau chiết khấu</ td >";

                        productPrint += " <td>" + string.Format("{0:N0}", Convert.ToDouble((Convert.ToDouble(order.TotalPriceNotDiscount) - (Convert.ToDouble(order.DiscountPerProduct) * Convert.ToDouble(TotalQuantity))))) + "</ td >";
                        productPrint += " </tr>";
                        productPrint += " <tr>";
                        productPrint += " <td colspan =\"4\" > Phí vận chuyển</ td >";
                        productPrint += " <td>" + string.Format("{0:N0}", Convert.ToDouble(order.FeeShipping)) + "</ td >";
                        productPrint += " </tr>";
                        productPrint += " <tr>";
                        productPrint += "<td class=\"strong\" colspan=\"4\">Tổng cộng</td>";
                        productPrint += " <td class=\"strong\">" + string.Format("{0:N0}", Convert.ToDouble(order.TotalPrice)) + "</td>";
                        productPrint += " </tr>";
                        productPrint += "</tbody>";
                        productPrint += " </table>";
                        productPrint += "</div>";
                        productPrint += "</div>";


                        string address = "";
                        string phone = "";
                        string facebook = "";
                        var agent = AgentController.GetByID(Convert.ToInt32(order.AgentID));
                        if (agent != null)
                        {
                            address = agent.AgentAddress;
                            phone = agent.AgentPhone;
                            facebook = agent.AgentFacebook;
                        }

                        string dateOrder = string.Format("{0:dd/MM/yyyy HH:mm}", order.DateDone);

                        shtml += "<div class=\"hoadon\">";
                        shtml += "<div class=\"all\">";
                        shtml += "<div class=\"head\">";
                        shtml += "     <div class=\"logo\"><div class=\"img\"><img src=\"App_Themes/Ann/image/logo.png\" /></div></div>";
                        shtml += "<div class=\"info\">";
                        shtml += "<div class=\"ct\">";
                        shtml += "<div class=\"ct-title\">Địa chỉ:</div>";
                        shtml += "<div class=\"ct-detail\">" + address + "</div>";
                        shtml += "<div class=\"ct\">";
                        shtml += "<div class=\"ct-title\">Điện thoại/ Zalo:</div>";
                        shtml += "<div class=\"ct-detail\">";

                        shtml += "<a href = \"tel:+\" >" + phone + "</a></div>";

                        shtml += "<div class=\"ct\">";
                        shtml += "<div class=\"ct-title\">Facebook:</div>";
                        shtml += "<div class=\"ct-detail\">";
                        shtml += "<a href =\"" + facebook + "\" target =\"_blank\" >" + facebook + "</a>";
                        shtml += "</div>";
                        shtml += "</div>";
                        shtml += "<div class=\"ct\">";
                        shtml += "<div class=\"ct-title\">Website:</div>";
                        shtml += "<div class=\"ct-detail\">";
                        shtml += "<a href =\"\">ann.com.vn</a> ";
                        shtml += "</div> ";
                        shtml += "</div> ";
                        shtml += "</div> ";
                        shtml += "</div>";
                        shtml += "</div>";

                        shtml += productPrint;

                        shtml += "<div class=\"footer\"><h1> Cảm ơn quý khách </h ></div> ";
                        shtml += "</div>";

                        shtml += "</div>";

                        ltrPrintInvoice.Text = shtml;
                    }
                }
            }
        }
    }
}