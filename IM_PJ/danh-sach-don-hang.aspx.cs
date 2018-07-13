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
using static IM_PJ.Controllers.OrderController;

namespace IM_PJ
{
    public partial class danh_sach_don_hang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["userLoginSystem"] != null)
                {
                    string username = Request.Cookies["userLoginSystem"].Value;
                    var acc = AccountController.GetByUsername(username);
                    int agent = acc.AgentID.ToString().ToInt();

                    if (acc != null)
                    {
                        if (acc.RoleID == 0)
                        {
                            LoadCreatedBy(agent);
                        }
                        else if (acc.RoleID == 2)
                        {
                            LoadCreatedBy(agent, acc);
                        }
                        else
                        {
                            Response.Redirect("/trang-chu");
                        }
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
            string username = Request.Cookies["userLoginSystem"].Value;
            var acc = AccountController.GetByUsername(username);
            if (acc != null)
            {
                int OrderType = 0;
                int PaymentStatus = 0;
                int ExcuteStatus = 0;
                int PaymentType = 0;
                int ShippingType = 0;
                string TextSearch = "";
                string CreatedBy = "0";
                string ProductSKU = "";
                string CreatedDate = "0";
                
                if (Request.QueryString["ordertype"] != null)
                {
                    OrderType = Request.QueryString["ordertype"].ToInt(0);
                }
                if (Request.QueryString["paymentstatus"] != null)
                {
                    PaymentStatus = Request.QueryString["paymentstatus"].ToInt(0);
                }
                if (Request.QueryString["excutestatus"] != null)
                {
                    ExcuteStatus = Request.QueryString["excutestatus"].ToInt(0);
                }
                if (Request.QueryString["paymenttype"] != null)
                {
                    PaymentType = Request.QueryString["paymenttype"].ToInt(0);
                }
                if (Request.QueryString["shippingtype"] != null)
                {
                    ShippingType = Request.QueryString["shippingtype"].ToInt(0);
                }
                if (Request.QueryString["textsearch"] != null)
                {
                    TextSearch = Request.QueryString["textsearch"];
                }
                if (Request.QueryString["createdby"] != null)
                {
                    CreatedBy = Request.QueryString["createdby"];
                }
                if (Request.QueryString["productsku"] != null)
                {
                    ProductSKU = Request.QueryString["productsku"];
                }
                if (Request.QueryString["createdby"] != null)
                {
                    CreatedBy = Request.QueryString["createdby"];
                }
                if(Request.QueryString["createddate"] != null)
                {
                    CreatedDate = Request.QueryString["createddate"];
                }

                
                txtSKU.Text = ProductSKU;
                txtSearchOrder.Text = TextSearch;
                ddlOrderType.SelectedValue = OrderType.ToString();
                ddlExcuteStatus.SelectedValue = ExcuteStatus.ToString();
                ddlPaymentStatus.SelectedValue = PaymentStatus.ToString();
                ddlPaymentType.SelectedValue = PaymentType.ToString();
                ddlShippingType.SelectedValue = ShippingType.ToString();
                ddlCreatedBy.SelectedValue = CreatedBy.ToString();
                ddlCreatedDate.SelectedValue = CreatedDate.ToString();

                List<OrderList> rs = new List<OrderList>();
                rs = OrderController.Filter(TextSearch, OrderType, ExcuteStatus, PaymentStatus, PaymentType, ShippingType, CreatedBy, ProductSKU, CreatedDate);
                if (acc.RoleID == 0)
                {
                    hdfcreate.Value = "1";
                    if (CreatedBy != "0")
                    {
                        pagingall(rs.Where(x => x.CreatedBy == CreatedBy && x.ExcuteStatus != 4).ToList());
                    }
                    else
                    {
                        pagingall(rs.Where(x => x.ExcuteStatus != 4).ToList());
                    }
                }
                else
                {
                    pagingall(rs.Where(x => x.CreatedBy == acc.Username && x.ExcuteStatus != 4).ToList());
                }

                ltrNumberOfOrder.Text = rs.Count().ToString();
            }
        }

        public void LoadCreatedBy(int AgentID, tbl_Account acc = null)
        {
            if (acc != null)
            {
                ddlCreatedBy.Items.Clear();
                ddlCreatedBy.Items.Insert(0, new ListItem(acc.Username, acc.Username));
            }
            else
            {
                var CreateBy = AccountController.GetAllNotSearch();
                ddlCreatedBy.Items.Clear();
                ddlCreatedBy.Items.Insert(0, new ListItem("Nhân viên", "0"));
                if (CreateBy.Count > 0)
                {
                    foreach (var p in CreateBy)
                    {
                        ListItem listitem = new ListItem(p.Username, p.Username);
                        ddlCreatedBy.Items.Add(listitem);
                    }
                    ddlCreatedBy.DataBind();
                }
            }
        }

        #region Paging
        public void pagingall(List<OrderList> acs)
        {
            string username = Request.Cookies["userLoginSystem"].Value;
            var acc = AccountController.GetByUsername(username);

            int PageSize = 30;

            StringBuilder html = new StringBuilder();
            html.Append("<tr>");
            html.Append("    <th>Mã</th>");
            html.Append("    <th>Loại</th>");
            html.Append("    <th>Khách hàng</th>");
            html.Append("    <th>Mua</th>");
            html.Append("    <th>Xử lý</th>");
            html.Append("    <th>Thanh toán</th>");
            html.Append("    <th>Thanh toán</th>");
            html.Append("    <th>Giao hàng</th>");
            html.Append("    <th>Tổng tiền</th>");
            if (acc.RoleID == 0)
            {
                html.Append("    <th>Nhân viên</th>");
            }
            html.Append("    <th>Ngày tạo</th>");
            html.Append("    <th>Hoàn tất</th>");
            html.Append("    <th></th>");
            html.Append("</tr>");

            if (acs.Count > 0)
            {
                int TotalItems = acs.Count;
                if (TotalItems % PageSize == 0)
                    PageCount = TotalItems / PageSize;
                else
                    PageCount = TotalItems / PageSize + 1;

                Int32 Page = GetIntFromQueryString("Page");

                if (Page == -1) Page = 1;
                int FromRow = (Page - 1) * PageSize;
                int ToRow = Page * PageSize - 1;
                if (ToRow >= TotalItems)
                    ToRow = TotalItems - 1;

                
                for (int i = FromRow; i < ToRow + 1; i++)
                {
                    var item = acs[i];
                    html.Append("<tr>");
                    html.Append("   <td><a href=\"/thong-tin-don-hang.aspx?id=" + item.ID + "\">" + item.ID + "</a></td>");
                    html.Append("   <td>" + PJUtils.OrderTypeStatus(Convert.ToInt32(item.OrderType)) + "</td>");

                    if (!string.IsNullOrEmpty(item.Nick))
                    {
                        html.Append("   <td><a class=\"customer-name-link capitalize\" href=\"/thong-tin-don-hang.aspx?id=" + item.ID + "\">" + item.Nick + "</a><br><span class=\"name-bottom-nick\">(" + item.CustomerName + ")</span></td>");
                    }
                    else
                    {
                        html.Append("   <td><a class=\"customer-name-link capitalize\" href=\"/thong-tin-don-hang.aspx?id=" + item.ID + "\">" + item.CustomerName + "</a></td>");
                    }

                    html.Append("   <td>" + item.Quantity + "</td>");
                    html.Append("   <td>" + PJUtils.OrderExcuteStatus(Convert.ToInt32(item.ExcuteStatus)) + "</td>");
                    html.Append("   <td>" + PJUtils.OrderPaymentStatus(Convert.ToInt32(item.PaymentStatus)) + "</td>");
                    html.Append("   <td>" + PJUtils.PaymentType(Convert.ToInt32(item.PaymentType)) + "</td>");
                    html.Append("   <td>" + PJUtils.ShippingType(Convert.ToInt32(item.ShippingType)) + "</td>");
                    html.Append("   <td><strong>" + string.Format("{0:N0}", Convert.ToDouble(item.TotalPrice)) + "</strong></td>");

                    if (acc.RoleID == 0)
                    {
                        html.Append("   <td>" + item.CreatedBy + "</td>");
                    }

                    string date = string.Format("{0:dd/MM}", item.CreatedDate);
                    html.Append("   <td>" + date + "</td>");

                    string datedone = "";
                    if (item.ExcuteStatus == 2)
                    {
                        datedone = string.Format("{0:dd/MM}", item.DateDone);
                    }
                    html.Append("   <td>" + datedone + "</td>");

                    html.Append("   <td>");
                    html.Append("       <a href=\"/print-invoice.aspx?id=" + item.ID + "\" title=\"In hóa đơn\" target=\"_blank\" class=\"btn primary-btn h45-btn\"><i class=\"fa fa-print\" aria-hidden=\"true\"></i></a>");
                    html.Append("       <a href=\"/print-shipping-note.aspx?id=" + item.ID + "\" title=\"In phiếu gửi hàng\" target=\"_blank\" class=\"btn primary-btn btn-red h45-btn\"><i class=\"fa fa-file-text-o\" aria-hidden=\"true\"></i></a>");
                    html.Append("       <a href=\"/chi-tiet-khach-hang.aspx?id=" + item.CustomerID + "\" title=\"Thông tin khách hàng " + item.CustomerName + "\" target=\"_blank\" class=\"btn primary-btn btn-black h45-btn\"><i class=\"fa fa-user-circle\" aria-hidden=\"true\"></i></a>");
                    html.Append("   </td>");
                    html.Append("</tr>");
                }
            }
            else
            {
                html.Append("<tr><td colspan=\"13\">Không tìm thấy đơn hàng...</td></tr>");
            }
            ltrList.Text = html.ToString();
        }
        public static Int32 GetIntFromQueryString(String key)
        {
            Int32 returnValue = -1;
            String queryStringValue = HttpContext.Current.Request.QueryString[key];
            try
            {
                if (queryStringValue == null)
                    return returnValue;
                if (queryStringValue.IndexOf("#") > 0)
                    queryStringValue = queryStringValue.Substring(0, queryStringValue.IndexOf("#"));
                returnValue = Convert.ToInt32(queryStringValue);
            }
            catch
            { }
            return returnValue;
        }
        private int PageCount;
        protected void DisplayHtmlStringPaging1()
        {

            Int32 CurrentPage = Convert.ToInt32(Request.QueryString["Page"]);
            if (CurrentPage == -1) CurrentPage = 1;
            string[] strText = new string[4] { "Trang đầu", "Trang cuối", "Trang sau", "Trang trước" };
            if (PageCount > 1)
                Response.Write(GetHtmlPagingAdvanced(6, CurrentPage, PageCount, Context.Request.RawUrl, strText));

        }
        private static string GetPageUrl(int currentPage, string pageUrl)
        {
            pageUrl = Regex.Replace(pageUrl, "(\\?|\\&)*" + "Page=" + currentPage, "");
            if (pageUrl.IndexOf("?") > 0)
            {
                pageUrl += "&Page={0}";
            }
            else
            {
                pageUrl += "?Page={0}";
            }
            return pageUrl;
        }
        public static string GetHtmlPagingAdvanced(int pagesToOutput, int currentPage, int pageCount, string currentPageUrl, string[] strText)
        {
            //Nếu Số trang hiển thị là số lẻ thì tăng thêm 1 thành chẵn
            if (pagesToOutput % 2 != 0)
            {
                pagesToOutput++;
            }

            //Một nửa số trang để đầu ra, đây là số lượng hai bên.
            int pagesToOutputHalfed = pagesToOutput / 2;

            //Url của trang
            string pageUrl = GetPageUrl(currentPage, currentPageUrl);


            //Trang đầu tiên
            int startPageNumbersFrom = currentPage - pagesToOutputHalfed; ;

            //Trang cuối cùng
            int stopPageNumbersAt = currentPage + pagesToOutputHalfed; ;

            StringBuilder output = new StringBuilder();

            //Nối chuỗi phân trang
            //output.Append("<div class=\"paging\">");
            output.Append("<ul>");

            //Link First(Trang đầu) và Previous(Trang trước)
            if (currentPage > 1)
            {
                output.Append("<li><a title=\"" + strText[0] + "\" href=\"" + string.Format(pageUrl, 1) + "\">Trang đầu</a></li>");
                output.Append("<li><a title=\"" + strText[1] + "\" href=\"" + string.Format(pageUrl, currentPage - 1) + "\">Trang trước</a></li>");
                //output.Append("<li class=\"UnselectedPrev\" ><a title=\"" + strText[1] + "\" href=\"" + string.Format(pageUrl, currentPage - 1) + "\"><i class=\"fa fa-angle-left\"></i></a></li>");

                //output.Append("<span class=\"Unselect_prev\"><a href=\"" + string.Format(pageUrl, currentPage - 1) + "\"></a></span>");
            }

            /******************Xác định startPageNumbersFrom & stopPageNumbersAt**********************/
            if (startPageNumbersFrom < 1)
            {
                startPageNumbersFrom = 1;

                //As page numbers are starting at one, output an even number of pages.  
                stopPageNumbersAt = pagesToOutput;
            }

            if (stopPageNumbersAt > pageCount)
            {
                stopPageNumbersAt = pageCount;
            }

            if ((stopPageNumbersAt - startPageNumbersFrom) < pagesToOutput)
            {
                startPageNumbersFrom = stopPageNumbersAt - pagesToOutput;
                if (startPageNumbersFrom < 1)
                {
                    startPageNumbersFrom = 1;
                }
            }
            /******************End: Xác định startPageNumbersFrom & stopPageNumbersAt**********************/

            //Các dấu ... chỉ những trang phía trước  
            if (startPageNumbersFrom > 1)
            {
                output.Append("<li><a href=\"" + string.Format(GetPageUrl(currentPage - 1, pageUrl), startPageNumbersFrom - 1) + "\">&hellip;</a></li>");
            }

            //Duyệt vòng for hiển thị các trang
            for (int i = startPageNumbersFrom; i <= stopPageNumbersAt; i++)
            {
                if (currentPage == i)
                {
                    output.Append("<li class=\"current\" ><a >" + i.ToString() + "</a> </li>");
                }
                else
                {
                    output.Append("<li><a href=\"" + string.Format(pageUrl, i) + "\">" + i.ToString() + "</a> </li>");
                }
            }

            //Các dấu ... chỉ những trang tiếp theo  
            if (stopPageNumbersAt < pageCount)
            {
                output.Append("<li><a href=\"" + string.Format(pageUrl, stopPageNumbersAt + 1) + "\">&hellip;</a></li>");
            }

            //Link Next(Trang tiếp) và Last(Trang cuối)
            if (currentPage != pageCount)
            {
                //output.Append("<span class=\"Unselect_next\"><a href=\"" + string.Format(pageUrl, currentPage + 1) + "\"></a></span>");
                //output.Append("<li class=\"UnselectedNext\" ><a title=\"" + strText[2] + "\" href=\"" + string.Format(pageUrl, currentPage + 1) + "\"><i class=\"fa fa-angle-right\"></i></a></li>");
                output.Append("<li><a title=\"" + strText[2] + "\" href=\"" + string.Format(pageUrl, currentPage + 1) + "\">Trang sau</a></li>");
                output.Append("<li><a title=\"" + strText[3] + "\" href=\"" + string.Format(pageUrl, pageCount) + "\">Trang cuối</a></li>");
            }
            output.Append("</ul>");
            //output.Append("</div>");
            return output.ToString();
        }
        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string search = txtSearchOrder.Text;
            string SKU = txtSKU.Text;
            string request = "/danh-sach-don-hang?";

            if (search != "")
            {
                request += "&textsearch=" + search;
            }

            if(ddlOrderType.SelectedValue != "0")
            {
                request += "&ordertype=" + ddlOrderType.SelectedValue;
            }

            if (ddlPaymentStatus.SelectedValue != "0")
            {
                request += "&paymentstatus=" + ddlPaymentStatus.SelectedValue;
            }

            if (ddlExcuteStatus.SelectedValue != "0")
            {
                request += "&excutestatus=" + ddlExcuteStatus.SelectedValue;
            }

            if (ddlPaymentType.SelectedValue != "0")
            {
                request += "&paymenttype=" + ddlPaymentType.SelectedValue;
            }

            if (ddlShippingType.SelectedValue != "0")
            {
                request += "&shippingtype=" + ddlShippingType.SelectedValue;
            }

            if (SKU != "")
            {
                request += "&productsku=" + SKU;
            }

            if (ddlCreatedBy.SelectedValue != "0")
            {
                request += "&createdby=" + ddlCreatedBy.SelectedValue;
            }

            if (ddlCreatedDate.SelectedValue != "0")
            {
                request += "&createddate=" + ddlCreatedDate.SelectedValue;
            }

            Response.Redirect(request);
        }
        public class danhmuccon1
        {
            public tbl_Category cate1 { get; set; }
            public string parentName { get; set; }
        }
    }
}