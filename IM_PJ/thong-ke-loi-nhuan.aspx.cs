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

            int TotalCostOfSales = 0;
            int TotalNumberOfOrder = 0;
            int TotalSales = 0;
            var od = OrderController.Report(fromdate.ToString(), todate.ToString());
            if (od != null)
            {
                TotalNumberOfOrder = od.Count();
                foreach (var item in od)
                {
                    TotalSales += Convert.ToInt32(item.TotalPrice);
                    var orderItems = OrderDetailController.GetByOrderID(item.ID);
                    if (orderItems != null)
                    {
                        foreach (var t in orderItems)
                        {
                            var productVariable = ProductVariableController.GetBySKU(t.SKU);
                            if (productVariable != null)
                            {
                                TotalCostOfSales += Convert.ToInt32(productVariable.CostOfGood) * Convert.ToInt32(t.Quantity);
                            }
                            else
                            {
                                var productSimple = ProductController.GetBySKU(t.SKU);
                                if (productSimple != null)
                                {
                                    TotalCostOfSales += Convert.ToInt32(productSimple.CostOfGood) * Convert.ToInt32(t.Quantity);
                                }
                            }
                        }
                    }
                }
            }

            int TotalRefund = 0;
            int TotalCostOfRefund = 0;
            var refund = RefundGoodController.TotalRefund(fromdate.ToString(), todate.ToString());
            if (refund.Count() > 0)
            {
                foreach (var temp in refund)
                {
                    TotalRefund += Convert.ToInt32(temp.TotalPrice);
                    var redetail = RefundGoodDetailController.GetByRefundGoodsID(temp.ID);
                    if (redetail.Count() > 0)
                    {
                        foreach (var vl in redetail)
                        {
                            var pr = ProductVariableController.GetBySKU(vl.SKU);
                            if (pr != null)
                            {
                                TotalCostOfRefund += Convert.ToInt32(pr.CostOfGood) * Convert.ToInt32(vl.Quantity);
                            }
                        }
                    }

                }
            }

            int TotalRevenue = TotalSales - TotalRefund;

            int TotalCost = TotalCostOfSales - TotalCostOfRefund;
            
            int TotalProfit = TotalRevenue - TotalCost;

            double TotalProfitPerDay = TotalProfit / day;

            int TotalProfitPerOrder = 0;

            if (TotalNumberOfOrder > 0)
            {
                TotalProfitPerOrder = TotalProfit / TotalNumberOfOrder;
            }
            

            ltrTotalRevenue.Text = string.Format("{0:N0}", TotalRevenue);
            ltrTotalCost.Text = string.Format("{0:N0}", TotalCostOfSales);
            ltrTotalRefund.Text = string.Format("{0:N0}", TotalRefund);
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