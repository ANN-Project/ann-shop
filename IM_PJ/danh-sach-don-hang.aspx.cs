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
    public partial class danh_sach_don_hang : System.Web.UI.Page
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
                    LoadCreatedBy(agent);
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
                            Response.Redirect("/dang-nhap");
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


            string username = Session["userLoginSystem"].ToString();
            var acc = AccountController.GetByUsername(username);
            if (acc != null)
            {
                int agentID = Convert.ToInt32(acc.AgentID);
                int orderType = 0;
                int paymentStatus = 0;
                int excuteStatus = 0;
                int payment = 0;
                int ship = 0;
                string s = "";
                string sku = "";
                int by = 0;

                if (Request.QueryString["o"] != null)
                {
                    orderType = Request.QueryString["o"].ToInt(0);
                }
                if (Request.QueryString["p"] != null)
                {
                    paymentStatus = Request.QueryString["p"].ToInt(0);
                }
                if (Request.QueryString["e"] != null)
                {
                    excuteStatus = Request.QueryString["e"].ToInt(0);
                }
                if (Request.QueryString["pay"] != null)
                {
                    payment = Request.QueryString["pay"].ToInt(0);
                }
                if (Request.QueryString["sh"] != null)
                {
                    ship = Request.QueryString["sh"].ToInt(0);
                }
                if (Request.QueryString["s"] != null)
                {
                    s = Request.QueryString["s"];
                }
                if (Request.QueryString["sku"] != null)
                {
                    sku = Request.QueryString["sku"];
                }
                if (Request.QueryString["sku"] != null)
                {
                    sku = Request.QueryString["sku"];
                }
                if (Request.QueryString["by"] != null)
                {
                    by = Request.QueryString["by"].ToInt(0);
                }
                txtAgentName.Text = s;
                txtSKU.Text = sku;
                ddlOrderType.SelectedValue = orderType.ToString();
                ddlExcuteStatus.SelectedValue = excuteStatus.ToString();
                ddlPaymentStatus.SelectedValue = paymentStatus.ToString();
                ddlPaymentType.SelectedValue = payment.ToString();
                ddlShippingType.SelectedValue = ship.ToString();
                ddlCreateBy.SelectedValue = by.ToString();

                if (acc.RoleID == 0 || acc.RoleID == 2)
                {

                    var rs = OrderController.SearchByStatical(orderType, paymentStatus, excuteStatus, s, agentID, payment, ship, sku);
                    if (rs.Count > 0)
                    {
                        if (acc.RoleID == 0)
                        {
                            hdfcreate.Value = "1";
                            if (by > 0)
                            {
                                var create = AccountController.GetByID(by);
                                if(create != null)
                                {
                                    pagingall(rs.Where(x=>x.CreatedBy == create.Username).ToList());
                                }
                            }
                            else
                            {
                                pagingall(rs);
                            }
                        }
                        else
                        {
                            pagingall(rs.Where(x => x.CreatedBy == acc.Username).ToList());
                        }
                    }
                }
                else
                {

                }
            }
        }

        public void LoadCreatedBy(int AgentID)
        {
            var CreateBy = AccountController.GetAllNotSearch();
            ddlCreateBy.Items.Clear();
            ddlCreateBy.Items.Insert(0, new ListItem("Nhân viên", "0"));
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
        #region Print
        [WebMethod]
        public static string getOrder(int ID)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string username = HttpContext.Current.Session["userLoginSystem"].ToString();
            var acc = AccountController.GetByUsername(username);
            if (acc != null)
            {
                int AgentID = Convert.ToInt32(acc.AgentID);
                var agent = AgentController.GetByID(AgentID);
                if (agent != null)
                {

                }
                //List<GetOutOrder> go = new List<GetOutOrder>();
                GetOutOrder getOrder = new GetOutOrder();
                var order = OrderController.GetByID(ID);
                if (order != null)
                {
                    var orderdetail = OrderDetailController.GetByOrderID(order.ID);
                    if (orderdetail != null)
                    {

                        getOrder.ListAgent += agent.AgentAddress + "|";
                        getOrder.ListAgent += agent.AgentPhone;
                        getOrder.TotalNotDiscount = Convert.ToInt32(order.TotalPriceNotDiscount);
                        getOrder.DiscountPerProduct = Convert.ToInt32(order.DiscountPerProduct);
                        getOrder.FeeShipping = Convert.ToInt32(order.FeeShipping);
                        getOrder.ID = order.ID;
                        getOrder.CustomerName = order.CustomerName;
                        getOrder.CustomerPhone = order.CustomerPhone;
                        //getOrder.CustomerEmail = order.CustomerEmail;
                        //getOrder.CustomerAddress = order.CustomerAddress;
                        getOrder.TotalPrice = string.Format("{0:N0}", Convert.ToDouble(order.TotalPrice));
                        //getOrder.GuestPaid = order.GuestPaid;
                        getOrder.CreatedBy = order.CreatedBy;
                        getOrder.CreateDate = string.Format("{0:dd/MM/yyyy}", order.CreatedDate);
                        getOrder.OrderNote = order.OrderNote;

                        getOrder.DateDone = string.Format("{0:dd/MM/yyyy}", order.DateDone);
                        getOrder.OrderType = order.OrderType.ToString();
                        int k = 0;
                        for (int i = 0; i < orderdetail.Count; i++)
                        {
                            getOrder.TotalProduct += Convert.ToInt32(orderdetail[i].Quantity);
                            k += Convert.ToInt32(orderdetail[i].Quantity);
                            getOrder.ProductQuantity += Convert.ToInt32(orderdetail[i].Quantity);
                            getOrder.ListProduct += orderdetail[i].SKU + ";";
                            var product = ProductVariableController.GetByID(orderdetail[i].ProductVariableID.Value);
                            if (product != null)
                            {
                                var pro = ProductController.GetByID(Convert.ToInt32(product.ProductID));
                                if (pro != null)
                                {
                                    getOrder.ListProduct += pro.ProductTitle + ";";
                                }
                            }
                            else
                            {
                                var product_simple = ProductController.GetByID(orderdetail[i].ProductID.Value);
                                if (product_simple != null)
                                {
                                    getOrder.ListProduct += product_simple.ProductTitle + ";";
                                }

                            }
                            getOrder.ListProduct += orderdetail[i].ProductVariableDescrition + ";" + orderdetail[i].Quantity + ";" + orderdetail[i].Price + "*";
                        }
                        getOrder.PriceSCK = Convert.ToInt32(order.TotalPriceNotDiscount) - (Convert.ToInt32(order.DiscountPerProduct) * k);
                        //go.Add(getOrder);
                    }
                }

                return serializer.Serialize(getOrder);
            }
            return serializer.Serialize(null);
        }

        public class GetOutOrder
        {
            public int ID { get; set; }
            public string CustomerName { get; set; }
            public string CustomerPhone { get; set; }
            public string CustomerAddress { get; set; }
            public string CustomerEmail { get; set; }
            public string TotalPrice { get; set; }
            public string GuestPaid { get; set; }
            public string CreateDate { get; set; }

            public string DateDone { get; set; }
            public string OrderType { get; set; }
            public string ListProduct { get; set; }
            public string ListAgent { get; set; }
            public int ProductQuantity { get; set; }
            public int TotalNotDiscount { get; set; }
            public int DiscountPerProduct { get; set; }
            public int FeeShipping { get; set; }
            public string CreatedBy { get; set; }
            public string OrderNote { get; set; }
            public int TotalProduct { get; set; }

            public int PriceSCK { get; set; }
        }
        #endregion
        #region Paging
        public void pagingall(List<tbl_Order> acs)
        {
            int PageSize = 20;
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
                    html.Append("   <td><a href=\"/thong-tin-don-hang.aspx?id=" + item.ID + "\">" + item.ID + "</a></td>");
                    html.Append("   <td>" + PJUtils.OrderTypeStatus(Convert.ToInt32(item.OrderType)) + "</td>");
                    html.Append("   <td>" + item.CustomerPhone + "</td>");
                    html.Append("   <td><a href=\"/thong-tin-don-hang.aspx?id=" + item.ID + "\">" + item.CustomerName + "</a></td>");
                    var orderdetails = OrderDetailController.GetByOrderID(item.ID);
                    int quantity = 0;
                    if (orderdetails.Count > 0)
                    {
                        foreach (var temp in orderdetails)
                        {
                            quantity += Convert.ToInt32(temp.Quantity);
                        }
                    }
                    html.Append("   <td>" + quantity + "</td>");
                    html.Append("   <td>" + PJUtils.OrderPaymentStatus(Convert.ToInt32(item.PaymentStatus)) + "</td>");
                    html.Append("   <td>" + PJUtils.OrderExcuteStatus(Convert.ToInt32(item.ExcuteStatus)) + "</td>");
                    html.Append("   <td>" + PJUtils.PaymentType(Convert.ToInt32(item.PaymentType)) + "</td>");
                    html.Append("   <td>" + PJUtils.ShippingType(Convert.ToInt32(item.ShippingType)) + "</td>");
                    html.Append("   <td>" + string.Format("{0:N0}", Convert.ToDouble(item.TotalPrice)) + "</td>");
                    string date = string.Format("{0:dd/MM/yyyy}", item.CreatedDate);
                    html.Append("   <td>" + date + "</td>");
                    string datedone = string.Format("{0:dd/MM/yyyy}", item.DateDone);
                    html.Append("   <td>" + datedone + "</td>");
                    html.Append("   <td>");
                    html.Append("       <a href=\"javascript:;\" onclick=\"printInvoice(" + item.ID + ")\" class=\"btn primary-btn h45-btn\">In</a>");
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
            string SKU = txtSKU.Text;
            Response.Redirect("/danh-sach-don-hang?s=" + search + "&o=" + ddlOrderType.SelectedValue + "&p=" + ddlPaymentStatus.SelectedValue + "&e=" + ddlExcuteStatus.SelectedValue + "&pay=" + ddlPaymentType.SelectedValue + "&sh=" + ddlShippingType.SelectedValue + "&sku=" + SKU + "&by=" + ddlCreateBy.SelectedValue + "");

        }
        public class danhmuccon1
        {
            public tbl_Category cate1 { get; set; }
            public string parentName { get; set; }
        }
    }
}