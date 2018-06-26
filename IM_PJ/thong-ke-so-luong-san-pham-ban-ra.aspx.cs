using IM_PJ.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IM_PJ
{
    public partial class thong_ke_so_luong_san_pham_ban_ra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Request.Cookies["userLoginSystem"] != null)
                {
                    string username = Request.Cookies["userLoginSystem"].Value;
                    var acc = AccountController.GetByUsername(username);
                    if (acc != null)
                    {
                        if (acc.RoleID != 0)
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
            DateTime fromdate = DateTime.Today;
            DateTime todate = fromdate.AddDays(1).AddMinutes(-1);

            if (!String.IsNullOrEmpty(Request.QueryString["fromdate"]))
            {
                fromdate = Convert.ToDateTime(Request.QueryString["fromdate"]);
            }

            if (!String.IsNullOrEmpty(Request.QueryString["todate"]))
            {
                todate = Convert.ToDateTime(Request.QueryString["todate"]);

                if (fromdate == todate)
                {
                    todate = fromdate.AddDays(1).AddMinutes(-1);
                }
            }
            rFromDate.SelectedDate = fromdate;
            rToDate.SelectedDate = todate;

            var od = OrderDetailController.Report(fromdate.ToString(), todate.ToString());
            int tongbanra = 0;
            if (od != null)
            {
                foreach (var item in od)
                {
                    tongbanra += Convert.ToInt32(item.Quantity);
                }
            }

            int totalrefund = 0;

            var refund = RefundGoodController.TotalRefund(fromdate.ToString(), todate.ToString());
            if (refund.Count() > 0)
            {
                foreach (var vl in refund)
                {
                    totalrefund += Convert.ToInt32(vl.TotalQuantity);
                }
            }

            ltrList.Text += "<tr>";
            ltrList.Text += "<td>"+tongbanra+"</td>";
            ltrList.Text += "<td>" + totalrefund + "</td>";
            ltrList.Text += "<td>" + (tongbanra - totalrefund) + "</td>";
          
            ltrList.Text += "</tr>";

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string fromdate = rFromDate.SelectedDate.ToString();
            string todate = rToDate.SelectedDate.ToString();

            Response.Redirect("/thong-ke-so-luong-san-pham-ban-ra.aspx?fromdate=" + fromdate + "&todate=" + todate + "");
        }
    }
}