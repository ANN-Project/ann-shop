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
    public partial class print_shipping_note : System.Web.UI.Page
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
            string error = "";
            ltrPrintEnable.Text = "";
            int ID = Request.QueryString["id"].ToInt(0);
            int mergeprint = 0;
            if (Request.QueryString["merge"] != null)
            {
                mergeprint = Request.QueryString["merge"].ToInt(0);
            }
            String rowHtml = String.Empty;
            if (ID > 0)
            {
                var order = OrderController.GetByID(ID);
                
                if (order != null)
                {
                    if(order.ExcuteStatus != 2)
                    {
                        error += "<p>- Đơn hàng này <strong>chưa hoàn tất</strong>!</p>";
                    }

                    if(order.ShippingType == 1)
                    {
                        error += "<p>- Đơn hàng này đang có phương thức giao hàng: <strong>Lấy trực tiếp</strong>. Hãy chuyển sang phương thức khác!</p>";
                    }

                    string address = "";
                    string phone = "";
                    string leader = "";
                    var agent = AgentController.GetByID(Convert.ToInt32(order.AgentID));
                    
                    if (agent != null)
                    {
                        address = agent.AgentAddress;
                        phone = agent.AgentPhone;
                        leader = agent.AgentLeader;
                    }

                    rowHtml += Environment.NewLine + String.Format("<div class=\"table\">");
                    rowHtml += Environment.NewLine + String.Format("    <div class=\"top-left\">");
                    rowHtml += Environment.NewLine + String.Format("        <p><span>Người gửi: <span class=\"name\">{0}</span></span></p>", leader);
                    rowHtml += Environment.NewLine + String.Format("        <p><span>{0}</span></p>", phone);
                    rowHtml += Environment.NewLine + String.Format("        <p><span>{0}</span></p>", address);
                    rowHtml += Environment.NewLine + String.Format("        <p><span class=\"web\">ANN.COM.VN</span></p>");
                    rowHtml += Environment.NewLine + String.Format("    </div>");
                    rowHtml += Environment.NewLine + String.Format("    <div class=\"bottom-left\">");
                    if(order.PaymentType == 3)
                    {
                        rowHtml += Environment.NewLine + String.Format("        <p><span class=\"cod\">Thu hộ: {0}</span></p>", string.Format("{0:N0}", Convert.ToDouble(order.TotalPrice)));
                    }
                    else
                    {
                        rowHtml += Environment.NewLine + String.Format("        <p><span class=\"cod\">Thu hộ: KHÔNG</span></p>");
                    }

                    rowHtml += Environment.NewLine + String.Format("        <p><span>Mã đơn hàng: {0}</span></p>", order.ID);
                    rowHtml += Environment.NewLine + String.Format("        <p><span>Nhân viên: {0}</span></p>", order.CreatedBy);

                    rowHtml += Environment.NewLine + String.Format("    </div>");
                    rowHtml += Environment.NewLine + String.Format("    <div class=\"top-right\">");
                    rowHtml += Environment.NewLine + String.Format("        <img class=\"img\" src=\"https://ann.com.vn/wp-content/uploads/ANN-logo-3.png\">");

                    var company = TransportCompanyController.GetTransportCompanyByID(Convert.ToInt32(order.TransportCompanyID));
                    string transportCompany = "";
                    string CustomerAddress = order.CustomerAddress;
                    if (company != null)
                    {
                        transportCompany = "<strong>" + company.CompanyName + "</strong>";

                        var subID = Convert.ToInt32(order.TransportCompanySubID);
                        var shipto = TransportCompanyController.GetReceivePlaceByID(company.ID, subID);
                        if (shipto != null && subID > 0)
                        {
                            CustomerAddress = "<span class=\"phone\">" + shipto.ShipTo + "</span>";
                        }
                        else
                        {
                            error += "- Đơn hàng này gửi chành xe " + transportCompany + " nhưng <strong>chưa chọn Nơi nhận</strong>!";
                        }
                    }

                    if (order.ShippingType == 2)
                    {
                        if(!string.IsNullOrEmpty(order.ShippingCode))
                        {
                            rowHtml += Environment.NewLine + String.Format("        <p class=\"delivery\"><span><strong>Gửi Bưu điện:</strong> {0}</span></p>", order.ShippingCode);
                        }
                        else
                        {
                            error += "- Đơn hàng này <strong>gửi Bưu điện</strong> nhưng <strong>chưa nhập</strong> MÃ VẬN ĐƠN!";
                        }
                    }
                    else if(order.ShippingType == 3)
                    {
                        rowHtml += Environment.NewLine + String.Format("        <p class=\"delivery\"><span>PROSHIP</span></p>");
                        if (!string.IsNullOrEmpty(order.ShippingCode))
                        {
                            rowHtml += Environment.NewLine + String.Format("        <p class=\"delivery\"><span>{0}</span></p>", order.ShippingCode);
                        }
                    }
                    else if(order.ShippingType == 4)
                    {
                        if (transportCompany == "")
                        {
                            error += "- Đơn hàng này <strong>gửi xe</strong> nhưng <strong>chưa chọn Chành xe</strong> nào!";
                        }
                        else
                        {
                            rowHtml += Environment.NewLine + String.Format("        <p class=\"delivery\"><span>Gửi xe: {0}</span></p>", transportCompany);
                        }
                    }

                    if (order.PaymentType == 3)
                    {
                        rowHtml += Environment.NewLine + String.Format("        <p><span class=\"cod\">Thu hộ: {0}</span></p>", string.Format("{0:N0}", Convert.ToDouble(order.TotalPrice)));
                    }
                    else
                    {
                        rowHtml += Environment.NewLine + String.Format("        <p><span class=\"cod\">Thu hộ: KHÔNG</span></p>");
                    }
                    rowHtml += Environment.NewLine + String.Format("    </div>");
                    rowHtml += Environment.NewLine + String.Format("    <div class=\"bottom-right\">");
                    rowHtml += Environment.NewLine + String.Format("        <p><span>Người nhận: <span class=\"name\">{0}</span></span></p>", order.CustomerName);
                    rowHtml += Environment.NewLine + String.Format("        <p><span>Điện thoại: <span class=\"phone\">{0}</span></span></p>", order.CustomerPhone);
                    rowHtml += Environment.NewLine + String.Format("        <p><span>Địa chỉ: <span class=\"address\">{0}</span></span></p>", CustomerAddress);
                    rowHtml += Environment.NewLine + String.Format("    </div>");
                    rowHtml += Environment.NewLine + String.Format("</div>");
                    
                }
                else
                {
                    error += "Không tìm thấy đơn hàng!";
                }
            }
            else
            {
                error += "Không tìm thấy đơn hàng!";
            }

            if(error != "")
            {
                ltrShippingNote.Text = "<h1>Lỗi:</h1>" + error;
            }
            else
            {
                ltrShippingNote.Text = rowHtml;
                ltrPrintEnable.Text = "<div class=\"print-enable true\"></div>";
            }
        }
    }
}