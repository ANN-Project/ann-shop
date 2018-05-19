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
            string fromdate = "";
            string todate = "";

            if (Request.QueryString["fromdate"] != null)
            {
                fromdate = Request.QueryString["fromdate"];
            }
            if (Request.QueryString["todate"] != null)
            {
                todate = Request.QueryString["todate"];
            }

            DateTime now = DateTime.Now;
            var start = new DateTime(now.Year, now.Month, 1, 0, 0, 0);
            if (!string.IsNullOrEmpty(fromdate))
            {
                rFromDate.SelectedDate = Convert.ToDateTime(fromdate);
            }
            else
            {
                fromdate = start.ToString();
            }
            if (!string.IsNullOrEmpty(todate))
            {
                rToDate.SelectedDate = Convert.ToDateTime(todate);
            }
            int donhangban = 0;
            int donhangtra = 0;
            int tongvondonhangban = 0;
            int tongdonhang = 0;
            int total = 0;
            int day = 0;
            var od = OrderController.Report(fromdate, todate);
            if (od != null)
            {
                var o = od.FirstOrDefault();
                DateTime st = new DateTime();
                DateTime end = new DateTime();
                if (!string.IsNullOrEmpty(fromdate))
                {
                    st = Convert.ToDateTime(fromdate);
                }
                else
                {
                    st = Convert.ToDateTime(o.CreatedDate);
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
                 day = time.Days;
                int hours = time.Hours;
                if (hours >= 20)
                {
                    day++;
                }
                tongdonhang = od.Count();
                foreach (var item in od)
                {
                   
                    total += Convert.ToInt32(item.TotalPrice);
                    var oddetail = OrderDetailController.GetByOrderID(item.ID);
                    if (oddetail != null)
                    {
                        foreach (var temp in oddetail)
                        {
                       
                            var pr = ProductVariableController.GetBySKU(temp.SKU);
                            if (pr != null)
                            {
                                tongvondonhangban += Convert.ToInt32(pr.CostOfGood) * Convert.ToInt32(temp.Quantity);
                            }
                        }
                    }
                }
            }

            int totalrefund = 0;
            var refund = RefundGoodController.TotalRefund(fromdate, todate);
            if (refund.Count() > 0)
            {
                foreach (var temp in refund)
                {
                    totalrefund += Convert.ToInt32(temp.TotalPrice);
                    var redetail = RefundGoodDetailController.GetByRefundGoodsID(temp.ID);
                    if (redetail.Count() > 0)
                    {
                        foreach (var vl in redetail)
                        {
                            var pr = ProductVariableController.GetBySKU(vl.SKU);
                            if (pr != null)
                            {
                                donhangtra += Convert.ToInt32(pr.CostOfGood) * Convert.ToInt32(vl.Quantity);
                            }
                        }
                    }

                }
            }

            int tong = total - totalrefund;
            int tongvon = tongvondonhangban - donhangtra;
            int totalperday = (tong - tongvon) / day;
            int totalperorder = (tong - tongvon) / tongdonhang;

            ltrList.Text += "<tr>";
            //ltrList.Text += "<td style=\"text-align:center;\">" + string.Format("{0:N0}", tongvondonhangban) + "</td>";
            //ltrList.Text += "<td>" + string.Format("{0:N0}", donhangtra) + "</td>";
            //ltrList.Text += "<td>" + string.Format("{0:N0}", tongvondonhangban - donhangtra) + "</td>";
            //ltrList.Text += "<td>" + string.Format("{0:N0}", tong) + "</td>";
           
            ltrList.Text += "<td>" + string.Format("{0:N0}", tong - tongvon) + "</td>";

            ltrList.Text += "<td>" + string.Format("{0:N0}", totalperday) + "</td>";
            ltrList.Text += "<td>" + string.Format("{0:N0}", totalperorder) + "</td>";

            ltrList.Text += "</tr>";

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string fromdate = rFromDate.SelectedDate.ToString();
            string todate = rToDate.SelectedDate.ToString();

            Response.Redirect("/thong-ke-loi-nhuan.aspx?fromdate=" + fromdate + "&todate=" + todate + "");
        }
    }
}