using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IM_PJ.Controllers;

namespace IM_PJ
{
    public partial class thong_ke_loi_nhuan : System.Web.UI.Page
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

            var reportModel = OrderController.GetProfitReport(fromdate, todate);

            double TotalRevenue = reportModel.TotalSales - reportModel.TotalRefund;

            double TotalCost = reportModel.TotalCostOfSales - reportModel.TotalCostOfRefund;
            
            double TotalProfit = TotalRevenue - TotalCost;

            double TotalProfitPerDay = TotalProfit / day;

            double TotalProfitPerOrder = 0;

            if (reportModel.TotalNumberOfOrder > 0)
            {
                TotalProfitPerOrder = Math.Ceiling(TotalProfit / reportModel.TotalNumberOfOrder);
            }
            

            ltrTotalRevenue.Text = string.Format("{0:N0}", TotalRevenue);
            ltrTotalCost.Text = string.Format("{0:N0}", reportModel.TotalCostOfSales);
            ltrTotalRefund.Text = string.Format("{0:N0}", reportModel.TotalRefund);
            ltrTotalProfit.Text += string.Format("{0:N0}", TotalProfit);

            ltrProfitPerDay.Text += string.Format("{0:N0}", TotalProfitPerDay);
            ltrProfitPerOrder.Text += string.Format("{0:N0}", TotalProfitPerOrder);

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string fromdate = rFromDate.SelectedDate.ToString();
            string todate = rToDate.SelectedDate.ToString();

            Response.Redirect("/thong-ke-loi-nhuan.aspx?fromdate=" + fromdate + "&todate=" + todate + "");
        }
    }
}