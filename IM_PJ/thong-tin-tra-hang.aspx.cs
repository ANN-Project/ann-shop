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
    public partial class thong_tin_tra_hang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
                LoadData();
            }
        }
        public void LoadData()
        {
            string username = Session["userLoginSystem"].ToString();
            var acc = AccountController.GetByUsername(username);
            if (acc != null)
            {
                int AgentID = Convert.ToInt32(acc.AgentID);
                int ID = Request.QueryString["id"].ToInt(0);
                if (ID > 0)
                {
                    ViewState["ID"] = ID;
                    var r = RefundGoodController.GetByIDAndAgentID(ID, AgentID);
                    if (r != null)
                    {
                        ltrInfo.Text += "<div class=\"form-row\">Tên khách hàng</div>";
                        ltrInfo.Text += "<div class=\"form-row\"><span class=\"form-control\">" + r.CustomerName + "</span></div>";
                        ltrInfo.Text += "<div class=\"form-row\">Số điện thoại</div>";
                        ltrInfo.Text += "<div class=\"form-row\"><span class=\"form-control\">" + r.CustomerPhone + "</span></div>";
                       
                        var cus = CustomerController.GetByID(r.CustomerID.Value);
                        if (cus != null)
                        {
                            ltrInfo.Text += "<div class=\"form-row\">Địa chỉ</div>";
                            ltrInfo.Text += "<div class=\"form-row\"><span class=\"form-control\">" + cus.CustomerAddress + "</span></div>";
                            ltrInfo.Text += "<div class=\"form-row\">Zalo</div>";
                            ltrInfo.Text += "<div class=\"form-row\"><span class=\"form-control\">" + cus.Zalo + "</span></div>";
                            ltrInfo.Text += "<div class=\"form-row\">Facebook</div>";
                            ltrInfo.Text += "<div class=\"form-row\"><span class=\"form-control\">" + cus.Facebook + "</span></div>";
                        }
                        ltrTotal.Text = string.Format("{0:N0}", Convert.ToDouble(r.TotalPrice));
                        ltrQuantity.Text = string.Format("{0:N0}", Convert.ToDouble(r.TotalQuantity));
                        ltrRefund.Text = string.Format("{0:N0}", Convert.ToDouble(r.TotalRefundFee));
                        var rds = RefundGoodDetailController.GetByRefundGoodsID(ID);
                        if (rds.Count > 0)
                        {
                            string html = "";
                            foreach (var item in rds)
                            {
                                html += "<tr class=\"product-result\" data-sku=\"" + item.SKU + "\" data-orderID=\"" + item.OrderID
                                                    + "\" data-ProductName=\"" + item.ProductName
                                                    + "\" data-ProductType=\"" + item.ProductType + "\" data-Giagoc=\"" + item.GiavonPerProduct
                                                    + "\" data-Giadaban=\"" + item.SoldPricePerProduct
                                                    + "\" data-TienGiam=\"" + item.DiscountPricePerProduct
                                                    + "\" data-Soluongtoida=\"" + item.QuantityMax + "\" data-RefundFee=\"" + item.RefundFeePerProduct + "\"  >";
                                html += "   <td>" + item.OrderID + "</td>";
                                html += "   <td>" + item.ProductName + "</td>";
                                html += "   <td>" + item.SKU + "</td>";
                                html += "   <td class=\"giagoc\" data-giagoc=\"" + item.GiavonPerProduct + "\">" + string.Format("{0:N0}", Convert.ToDouble(item.GiavonPerProduct)) + "</td>";
                                html += "   <td class=\"giadaban\" data-giadaban=\"" + item.SoldPricePerProduct + "\">" + item.SoldPricePerProduct + " ( CK: " + string.Format("{0:N0}", Convert.ToDouble(item.DiscountPricePerProduct)) + ")</td>";
                                html += "   <td class=\"sltoida\" data-soluongtoida=\"" + item.QuantityMax + "\">" + item.QuantityMax + "</td>";
                                html += "   <td class=\"slcandoi\">" + item.Quantity + "</td>";
                                html += "   <td>";
                                int refundType = Convert.ToInt32(item.RefundType);
                                string refuntTypeName = "";
                                if (item.RefundType == 1)
                                    refuntTypeName = "Đổi size";
                                else if (item.RefundType == 2)
                                    refuntTypeName = "Đổi sản phẩm khác";
                                else
                                    refuntTypeName = "Đổi hàng lỗi";
                                html += refuntTypeName;
                                html += "    </td>";
                                html += "   <td class=\"phidoihang\">" + string.Format("{0:N0}", Convert.ToDouble(item.RefundFeePerProduct)) + "</td>";
                                html += "   <td class=\"thanhtien\">" + string.Format("{0:N0}", Convert.ToDouble(item.TotalPriceRow)) + "</td>";
                                html += "</tr>";
                                
                            }
                            ddlRefundStatus.SelectedValue = r.Status.ToString();
                            txtRefundsNote.Text = r.RefundNote;
                            ltrList.Text = html;

                        }
                    }
                }
            }

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            string username = Session["userLoginSystem"].ToString();
            var a = AccountController.GetByUsername(username);
            if (a != null)
            {
                var re = RefundGoodController.updatestatus((ViewState["ID"].ToString()).ToInt(), Convert.ToInt32(ddlRefundStatus.SelectedValue),DateTime.Now, a.Username,txtRefundsNote.Text);
                if(re != null)
                {
                    PJUtils.ShowMessageBoxSwAlert("Cập nhật đơn trả hàng thành công", "s", true, Page);
                }
                else
                {
                    PJUtils.ShowMessageBoxSwAlert("Thất bại", "e", false, Page);
                }
            }
        }
    }
}