using IM_PJ.Controllers;
using MB.Extensions;
using NHST.Bussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace IM_PJ
{
    public partial class thong_tin_danh_muc_san_pham : System.Web.UI.Page
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
                            Response.Redirect("/trang-chu");
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
            int id = Request.QueryString["id"].ToInt(0);
            if (id > 0)
            {
                var a = CategoryController.GetByID(id);
                if (a != null)
                {
                    ViewState["ID"] = id;
                    txtCategoryName.Text = a.CategoryName;
                    txtCategoryDescription.Text = a.CategoryDescription;
                    if (a.IsHidden != null)
                        chkIsHidden.Checked = Convert.ToBoolean(a.IsHidden);
                }
            }
            else
            {
                Response.Redirect("/quan-ly-dai-ly");
            }

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            DateTime currentDate = DateTime.Now;
            if (Session["userLoginSystem"] != null)
            {
                string username = Session["userLoginSystem"].ToString();
                var acc = AccountController.GetByUsername(username);
                if (acc != null)
                {
                    if (acc.RoleID == 0)
                    {
                        int ID = ViewState["ID"].ToString().ToInt(0);
                        string kq = CategoryController.Update(ID, txtCategoryName.Text, txtCategoryDescription.Text, 0, 0, chkIsHidden.Checked,
                            currentDate, username);
                        if (kq.ToInt(0) > 0)
                        {
                            PJUtils.ShowMessageBoxSwAlert("Cập nhật thành công", "s", true, Page);
                        }
                    }
                }
            }
            else
            {
                Response.Redirect("/dang-nhap");
            }

        }
    }
}