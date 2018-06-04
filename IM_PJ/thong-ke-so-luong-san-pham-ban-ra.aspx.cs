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
                todate = Convert.ToDateTime(todate).AddHours(24).ToString();
            }


            var od = OrderController.Report(fromdate, todate);
            int tongbanra = 0;
            if (od != null)
            {
                foreach (var item in od)
                {
                    var oddetail = OrderDetailController.GetByOrderID(item.ID);
                    if (oddetail != null)
                    {
                        foreach (var temp in oddetail)
                        {
                            tongbanra += Convert.ToInt32(temp.Quantity);
                        }
                    }
                }
            }

            int totalrefund = 0;
            var refund = RefundGoodController.TotalRefund(fromdate, todate);
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