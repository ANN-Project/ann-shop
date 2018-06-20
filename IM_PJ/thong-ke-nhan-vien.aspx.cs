using IM_PJ.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IM_PJ
{
    public partial class thong_ke_nhan_vien : System.Web.UI.Page
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
                LoadAccountInfo();
                LoadData();
            }
        }

        public void LoadData()
        {
            string accountName = String.Empty;
            DateTime fromdate = DateTime.Today;
            DateTime todate = fromdate.AddDays(1).AddMinutes(-1);

            long totalSales = 0;
            double averageSales = 0D;
            long totalOutput = 0;
            double averageOutput = 0D;
            long totalRefund = 0;
            double averageRefund = 0D;
            double totalDays = 0D;

            if (!String.IsNullOrEmpty(Request.QueryString["accountName"]))
            {
                accountName = Request.QueryString["accountName"];
            }

            if (!String.IsNullOrEmpty(Request.QueryString["fromdate"]))
            {
                fromdate = Convert.ToDateTime(Request.QueryString["fromdate"]);
            }

            if (!String.IsNullOrEmpty(Request.QueryString["todate"]))
            {
                todate = Convert.ToDateTime(Request.QueryString["todate"]);

                if(fromdate == todate)
                {
                    todate = fromdate.AddDays(1).AddMinutes(-1);
                }
            }

            ddlAccountInfo.SelectedValue = accountName;
            rFromDate.SelectedDate = fromdate;
            rToDate.SelectedDate = todate;
            totalDays = (todate - fromdate).TotalDays;

            // Load trang lan dau hoac la chua chon nhan vien
            if (String.IsNullOrEmpty(accountName))
            {
                this.ltrTotalSales.Text = String.Empty;
                this.ltrAverageSales.Text = String.Empty;
                this.ltrTotalOutput.Text = String.Empty;
                this.ltrAverageOutput.Text = String.Empty;
                this.ltrTotalRefund.Text = String.Empty;
                this.ltrAverageRefund.Text = String.Empty;

                return;
            }


            totalSales = OrderController.GetTotalPriceByAccount(accountName, fromdate, todate);
            averageSales = Math.Ceiling(totalSales / totalDays);


            totalOutput = totalSales;
            averageOutput = averageSales;

            totalRefund = RefundGoodController.GetTotalRefundByAccount(accountName, fromdate, todate);
            averageRefund = Math.Ceiling(totalRefund / totalDays);


            ltrTotalSales.Text = String.Format("{0:N0}  đ", totalSales);
            ltrAverageSales.Text = String.Format("{0:N0}   đơn/ngày", averageSales);
            ltrTotalOutput.Text = String.Format("{0:N0}  đ", totalSales);
            ltrAverageOutput.Text = String.Format("{0:N0}   đơn/ngày", averageSales);
            ltrTotalRefund.Text = String.Format("{0:N0}  đ", totalSales);
            ltrAverageRefund.Text = String.Format("{0:N0}   đơn/ngày", averageSales);
        }

        /// <summary>
        /// Init drop down list account
        /// </summary>
        private void LoadAccountInfo()
        {
            var accounts = AccountInfoController.GetAll();

            this.ddlAccountInfo.Items.Add(new ListItem(String.Empty, String.Empty, true));

            foreach (var acc in accounts)
            {
                this.ddlAccountInfo.Items.Add(new ListItem(acc.Fullname, acc.Fullname.Trim()));
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string accountName = this.ddlAccountInfo.SelectedValue;
            string fromdate = rFromDate.SelectedDate.ToString();
            string todate = rToDate.SelectedDate.ToString();

            Response.Redirect(String.Format("/thong-ke-nhan-vien.aspx?accountName={0}&fromdate={1}&todate={2}", accountName,fromdate, todate));
        }
    }
}