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
            
            int TotalCostOfSales = 0;
            int TotalNumberOfOrder = 0;
            int TotalSales = 0;
            int day = 0;
            var od = OrderController.Report(fromdate, todate);
            if (od != null)
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
            var refund = RefundGoodController.TotalRefund(fromdate, todate);
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

            int TotalProfitPerDay = TotalProfit / day;

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