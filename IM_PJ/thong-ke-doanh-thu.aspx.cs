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
                if (Session["userLoginSystem"] != null)
                {
                    string username = Session["userLoginSystem"].ToString();
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
            DateTime now = DateTime.Now;
            var start = new DateTime(now.Year, now.Month, 1, 0, 0, 0);
            string fromdate = start.ToString();
            string todate = "";

            if (Request.QueryString["fromdate"] != null)
            {
                fromdate = Request.QueryString["fromdate"];
            }
            if (Request.QueryString["todate"] != null)
            {
                todate = Request.QueryString["todate"];
            }

            rFromDate.SelectedDate = Convert.ToDateTime(fromdate);

            if (!string.IsNullOrEmpty(todate))
            {
                rToDate.SelectedDate = Convert.ToDateTime(todate);
                todate = Convert.ToDateTime(todate).AddHours(24).ToString();
            }
            else
            {
                rToDate.SelectedDate = now;
                todate = now.ToString();
            }

            int tongdonhang = 0;
            int total = 0;
            int day = 1;

            var od = OrderController.Report(fromdate, todate);
            if (od.Count() > 0)
            {
                DateTime st = new DateTime();
                DateTime end = new DateTime();

                if (!string.IsNullOrEmpty(fromdate))
                {
                    st = Convert.ToDateTime(fromdate);
                }

                if (!string.IsNullOrEmpty(todate))
                {
                    end = Convert.ToDateTime(todate);
                }
                else
                {
                    end = Convert.ToDateTime(DateTime.Now);
                }

                TimeSpan time = end.Subtract(st);
                day += time.Days;

                tongdonhang = od.Count();
                foreach (var item in od)
                {
                    total += Convert.ToInt32(item.TotalPrice);
                }

            }

            int totalrefund = 0;
            var refund = RefundGoodController.TotalRefund(fromdate, todate);
            if (refund.Count() > 0)
            {
                foreach (var temp in refund)
                {
                    totalrefund += Convert.ToInt32(temp.TotalPrice);
                }
            }

            int tong = total - totalrefund;
            ltrTotalNumberOfOrder.Text =  tongdonhang.ToString() + " đơn";
            ltrNumberOfOrderPerDay.Text = (tongdonhang / day).ToString() + " đơn/ngày";
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