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
using static IM_PJ.Controllers.ProductController;

namespace IM_PJ
{
    public partial class tat_ca_san_pham : System.Web.UI.Page
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
                        LoadData();
                        LoadCategory();
                    }
                }
                else
                {
                    Response.Redirect("/dang-nhap");
                }
            }
        }
        public void LoadCategory()
        {
            var category = CategoryController.GetAllWithIsHidden(false);
            ddlCategory.Items.Clear();
            ddlCategory.Items.Insert(0, new ListItem("Danh mục sản phẩm", "0"));
            if (category.Count > 0)
            {
                addItemCategory(0, "");
                ddlCategory.DataBind();
            }
        }

        public void addItemCategory(int id, string h = "")
        {
            var categories = CategoryController.GetByParentID("", id);

            if (categories.Count > 0)
            {
                foreach (var c in categories)
                {
                    ListItem listitem = new ListItem(h + c.CategoryName, c.ID.ToString());
                    ddlCategory.Items.Add(listitem);

                    addItemCategory(c.ID, h + "---");
                }
            }
        }
        public void LoadData()
        {
            string s = "";
            int categoryID = 0;
            int type = 0;
            if (Request.QueryString["s"] != null)
                s = Request.QueryString["s"].Trim();
            if (Request.QueryString["type"] != null)
                type = Request.QueryString["type"].ToInt(0);
            if (Request.QueryString["categoryid"] != null)
                categoryID = Request.QueryString["categoryid"].ToInt(0);

            txtSearchProduct.Text = s;
            ddlCategory.SelectedValue = categoryID.ToString();
            ddlType.SelectedValue = type.ToString();

            List<ProductSQL> a = new List<ProductSQL>();
            a = ProductController.GetAllSql(categoryID, s);
            if (type != 0)
            {
                a = a.Where(p => p.StockStatus == type).ToList();
            }
            pagingall(a);
        }
        #region Paging
        public void pagingall(List<ProductSQL> acs)
        {
            string username = Session["userLoginSystem"].ToString();

            var acc = AccountController.GetByUsername(username);

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
                html.Append("<tr>");
                html.Append("    <th class='image-column'>Ảnh</th>");
                html.Append("    <th class='name-column'>Sản phẩm</th>");
                html.Append("    <th class='sku-column'>Mã</th>");
                html.Append("    <th class='wholesale-price-column'>Giá sỉ</th>");
                if(acc.RoleID == 0)
                {
                    html.Append("    <th class='cost-price-column'>Giá vốn</th> ");
                }
                html.Append("    <th class='retail-price-column'>Giá lẻ</th>");
                html.Append("    <th class='stock-column'>Kho</th>");
                html.Append("    <th class='stock-status-column'>Trạng thái</th>");
                html.Append("    <th class='category-column'>Danh mục</th>");
                html.Append("    <th class='date-column'>Ngày tạo</th>");
                html.Append("    <th class='action-column'></th>");
                html.Append("</tr>");
                for (int i = FromRow; i < ToRow + 1; i++)
                {
                    var item = acs[i];
                    html.Append("<tr>");
                    html.Append("   <td><a href=\"/xem-san-pham.aspx?id=" + item.ID + "\"><img src=\"" + item.ProductImage + "\"/></a></td>");
                    html.Append("   <td><a href=\"/xem-san-pham.aspx?id=" + item.ID + "\">" + item.ProductTitle + "</a></td>");
                    html.Append("   <td>" + item.ProductSKU + "</td>");
                    html.Append("   <td>" + string.Format("{0:N0}", item.RegularPrice) + "</td>");
                    if (acc.RoleID == 0)
                    {
                        html.Append("   <td>" + string.Format("{0:N0}", item.CostOfGood) + "</td>");
                    }
                    html.Append("   <td>" + string.Format("{0:N0}", item.RetailPrice) + "</td>");
                    html.Append("   <td>" + string.Format("{0:N0}", item.TotalProductInstockQuantityLeft) + "</td>");
                    html.Append("   <td>" + item.ProductInstockStatus + "</td>");
                    html.Append("   <td>" + item.CategoryName + "</td>");
                    string date = string.Format("{0:dd/MM/yyyy}", item.CreatedDate);
                    html.Append("   <td>" + date + "</td>");
                    html.Append("   <td>");
                    html.Append("       <a href=\"/danh-sach-anh-san-pham.aspx?id=" + item.ID + "\" title=\"Xem hình ảnh\" class=\"btn primary-btn h45-btn\"><i class=\"fa fa-file-image-o\" aria-hidden=\"true\"></i></a>");
                    if (item.ProductStyle == 2)
                    {
                        html.Append(" <a href=\"/thuoc-tinh-san-pham.aspx?id=" + item.ID + "\" title=\"Xem thuộc tính\" class=\"btn primary-btn btn-black h45-btn\"><i class=\"fa fa-cogs\" aria-hidden=\"true\"></i></a>");
                    }

                    html.Append("  </td>");
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
            string search = txtSearchProduct.Text;
            Response.Redirect("/tat-ca-san-pham?s=" + search + "&type=" + ddlType.SelectedValue + "&categoryid=" + ddlCategory.SelectedValue + "");
        }
        public class danhmuccon1
        {
            public tbl_Category cate1 { get; set; }
            public string parentName { get; set; }
        }
    }
}