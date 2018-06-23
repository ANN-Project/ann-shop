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
using System.Web.UI;
using System.Web.UI.WebControls;
using static IM_PJ.Controllers.CustomerController;

namespace IM_PJ
{
    public partial class danh_sach_khach_hang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userLoginSystem"] != null)
                {
                    string username = Session["userLoginSystem"].ToString();
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
                            Response.Redirect("/dang-nhap");
                        }
                    }
                }
                else
                {
                    Response.Redirect("/dang-nhap");
                }
                LoadData();
                LoadProvince();
            }
        }

        public void LoadProvince()
        {
            var pro = ProvinceController.GetAll();
            ddlProvince.Items.Clear();
            ddlProvince.Items.Insert(0, new ListItem("Tỉnh thành", "0"));
            if (pro.Count > 0)
            {
                foreach (var p in pro)
                {
                    ListItem listitem = new ListItem(p.ProvinceName, p.ID.ToString());
                    ddlProvince.Items.Add(listitem);
                }
                ddlProvince.DataBind();
            }
        }
        public void LoadData()
        {
            string s = "";
            int by = 0;
            string createby = "";
            int p = 0;

            if (Request.QueryString["s"] != null)
                s = Request.QueryString["s"];
            if (Request.QueryString["by"] != null)
                by = Request.QueryString["by"].ToInt();
            if (Request.QueryString["p"] != null)
                p = Request.QueryString["p"].ToInt();

            var acc = AccountController.GetByID(by);
            if (acc != null)
            {
                createby = acc.Username;
            }

            txtAgentName.Text = s;
            ddlCreateBy.SelectedValue = by.ToString();
            ddlProvince.SelectedValue = p.ToString();
            List<CustomerOut> get = new List<CustomerOut>();

            var orders = CustomerController.GetKH(s, createby, p);
            if (orders.Count > 0)
            {
                foreach (var item in orders)
                {
                    var discount = DiscountCustomerController.getbyCustID(item.ID);
                    if (discount != null)
                    {
                        foreach (var temp in discount)
                        {
                            item.DiscountName += temp.DiscountName + "|";
                            item.DisID += temp.DiscountGroupID + "|";
                        }

                    }
                    get.Add(item);

                }
            }

            if (get.Count() > 0)
            {
                string username = Session["userLoginSystem"].ToString();
                var aclog = AccountController.GetByUsername(username);
                if (aclog.RoleID != 0)
                {
                    var d = get.Where(x => x.CreatedBy == aclog.Username).OrderByDescending(x => x.CreatedDate).ToList();
                    pagingall(d);
                }
                else
                {
                    hdfcreate.Value = "1";
                    pagingall(get.OrderByDescending(x=>x.CreatedDate).ToList());
                }

            }


        }
        public void LoadCreatedBy(int AgentID, tbl_Account acc = null)
        {
            if(acc != null)
            {
                ddlCreateBy.Items.Clear();
                ddlCreateBy.Items.Insert(0, new ListItem(acc.Username, acc.ID.ToString()));
            }
            else
            {
                var CreateBy = AccountController.GetAllNotSearch();
                ddlCreateBy.Items.Clear();
                ddlCreateBy.Items.Insert(0, new ListItem("Nhân viên phụ trách", "0"));
                if (CreateBy.Count > 0)
                {
                    foreach (var p in CreateBy)
                    {
                        ListItem listitem = new ListItem(p.Username, p.ID.ToString());
                        ddlCreateBy.Items.Add(listitem);
                    }
                    ddlCreateBy.DataBind();
                }
            }
            
        }
        #region Paging
        public void pagingall(List<CustomerOut> acs)
        {
            int PageSize = 30;
            StringBuilder html = new StringBuilder();
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
                    //html.Append("   <td>" + item.ID + "</td>");
                    var order = OrderController.GetByCustomerID(item.ID);
                    int TotalQuantity = 0;
                    if (order != null)
                    {

                        foreach (var temp in order)
                        {
                            var detail = OrderDetailController.GetByOrderID(temp.ID);
                            if (detail != null)
                            {
                                foreach (var vl in detail)
                                {
                                    TotalQuantity += Convert.ToInt32(vl.Quantity);
                                }
                            }
                        }
                    }
                    html.Append("   <td><a href=\"/chi-tiet-khach-hang?id=" + item.ID + "\"><img src=\"" + item.Avatar + "\"/></a></td>");
                    html.Append("   <td><a class=\"capitalize\" href=\"/chi-tiet-khach-hang?id=" + item.ID + "\">" + item.CustomerName + "</a></td>");
                    html.Append("   <td class=\"capitalize\">" + item.Nick + "</td>");
                    html.Append("   <td>" + item.CustomerPhone + "</td>");
                    html.Append("   <td>" + item.Zalo + "</td>");
                    if (!string.IsNullOrEmpty(item.Facebook))
                    {
                        html.Append("   <td><a class=\"link\" href=\"" + item.Facebook + "\" target=\"_blank\">Xem</a></td>");
                    }
                       else
                    {
                        html.Append("   <td></td>");
                    }
                    if (!string.IsNullOrEmpty(item.Province))
                    {
                        var pro = ProvinceController.GetByID(item.Province.ToInt());
                        if (pro != null)
                        {
                            html.Append("   <td>" + pro.ProvinceName + "</td>");
                        }
                        else
                        {
                            html.Append("   <td></td>");
                        }
                    }
                    else
                    {
                        html.Append("   <td></td>");
                    }
                    if (TotalQuantity > 0)
                        html.Append("   <td>" + TotalQuantity + "</td>");
                    else
                        html.Append("   <td></td>");
                    html.Append("   <td>" + item.CreatedBy + "</td>");
                    if (!string.IsNullOrEmpty(item.DiscountName))
                    {
                        string[] dis = item.DiscountName.Split('|');
                        if (dis.Count() > 1)
                            html.Append("   <td>" + dis[0] + "</br>" + dis[1] + "</td>");
                    }
                    else
                        html.Append("   <td>" + item.DiscountName + "</td>");
                    string date = string.Format("{0:dd/MM/yyyy}", item.CreatedDate);
                    html.Append("   <td>" + date + "</td>");
                    string ishidden = "";
                    if (item.IsHidden != null)
                    {
                        bool IsHidden = Convert.ToBoolean(item.IsHidden);
                        ishidden = PJUtils.IsHiddenStatus(IsHidden);
                    }
                    else
                    {
                        ishidden = PJUtils.IsHiddenStatus(false);
                    }

                    html.Append("   <td>");

                    html.Append("       <a href=\"/danh-sach-don-hang?s=" + item.CustomerPhone + "\" title=\"Xem đơn hàng\" class=\"btn primary-btn h45-btn\"><i class=\"fa fa-shopping-cart\" aria-hidden=\"true\"></i></a>");
                    html.Append("   </td>");
                    html.Append("</tr>");
                }
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
            string search = txtAgentName.Text;

            Response.Redirect("/danh-sach-khach-hang?s=" + search + "&by=" + ddlCreateBy.SelectedValue + "&p=" + ddlProvince.SelectedValue + "");

        }
    }
}