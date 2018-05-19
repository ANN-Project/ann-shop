using IM_PJ.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace IM_PJ
{
    public partial class thong_ke_phi_van_chuyen : System.Web.UI.Page
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

            int tongdonhang = 0;
            int totalshipping = 0;
            var od = OrderController.Report(fromdate, todate);
            if (od.Count() > 0)
            {
                //var t = od.LastOrDefault();
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
                
                TimeSpan total = end.Subtract(st);
                int day = total.Days;
                int hours = total.Hours;
                if (hours >= 20)
                {
                    day++;
                }
                foreach (var item in od)
                {
                    totalshipping += Convert.ToInt32(item.FeeShipping);
                }
                tongdonhang = totalshipping / day;
            }




            ltrList.Text += "<tr>";
            ltrList.Text += "<td style=\"text-align:center;\">" + string.Format("{0:N0}", totalshipping) + " vnđ"+ "</td>";
            ltrList.Text += "<td>" + string.Format("{0:N0}", tongdonhang) + " vnđ" + "</td>";
            ltrList.Text += "</tr>";

        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string fromdate = rFromDate.SelectedDate.ToString();
            string todate = rToDate.SelectedDate.ToString();

            Response.Redirect("/thong-ke-phi-van-chuyen.aspx?fromdate=" + fromdate + "&todate=" + todate + "");
        }
    }
}