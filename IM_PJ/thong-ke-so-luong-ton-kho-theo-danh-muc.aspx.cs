using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IM_PJ.Controllers;
using NHST.Bussiness;

namespace IM_PJ
{
    public partial class thong_ke_so_luong_ton_kho_theo_danh_muc : System.Web.UI.Page
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
            var cate = CategoryController.API_GetAllCategory();
            ltrList.Text = "";
            if (cate.Count > 0)
            {
                foreach (var item in cate)
                {
                    ltrList.Text += "<tr>";

                    int quantity = 0;
                    int totalprice = 0;
                    var list = ProductController.GetAllSql(item.ID, "");
                    {
                        foreach (var temp in list)
                        {
                            quantity += Convert.ToInt32(temp.TotalProductInstockQuantityLeft);
                            totalprice += Convert.ToInt32(temp.CostOfGood) * Convert.ToInt32(temp.TotalProductInstockQuantityLeft);
                        }
                    }
                    ltrList.Text += "<td style=\"text-align:center\">" + item.CategoryName + ": " + quantity +" sản phẩm"+ "</td>";
                    ltrList.Text += "<td>" + item.CategoryName + ": " + string.Format("{0:N0}", totalprice) + " VNĐ" + "</td>";
                    ltrList.Text += "</tr>";
                }
            }
        }
    }
}