using IM_PJ.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IM_PJ
{
    public partial class thong_ke_doanh_thu : System.Web.UI.Page
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
            double day = (todate - fromdate).TotalDays;

            int tongdonhang = 0;
            int total = 0;

            var od = OrderController.Report(fromdate.ToString(), todate.ToString());

            if (od.Count() > 0)
            {
                tongdonhang = od.Count();
                foreach (var item in od)
                {
                    total += Convert.ToInt32(item.TotalPrice);
                }
            }

            int totalrefund = 0;
            var refund = RefundGoodController.TotalRefund(fromdate.ToString(), todate.ToString());
            if (refund.Count() > 0)
            {
                foreach (var temp in refund)
                {
                    totalrefund += Convert.ToInt32(temp.TotalPrice);
                }
            }

            int tong = total - totalrefund;
            ltrTotalNumberOfOrder.Text =  tongdonhang.ToString() + " đơn";
            ltrNumberOfOrderPerDay.Text = Convert.ToInt32(tongdonhang / day).ToString() + " đơn/ngày";
            ltrTotalRevenue.Text = string.Format("{0:N0}", tong) + "đ";
            ltrAverageRevenue.Text = string.Format("{0:N0}", tong / day) + "đ/ngày";
            if (tongdonhang == 0)
            {
                ltrRevenuePerOrder.Text = "0";
            }
            else
            {
                ltrRevenuePerOrder.Text = string.Format("{0:N0}", tong / tongdonhang) + "đ/đơn";
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string fromdate = rFromDate.SelectedDate.ToString();
            string todate = rToDate.SelectedDate.ToString();

            Response.Redirect("/thong-ke-doanh-thu.aspx?fromdate=" + fromdate + "&todate=" + todate + "");
        }
    }
}