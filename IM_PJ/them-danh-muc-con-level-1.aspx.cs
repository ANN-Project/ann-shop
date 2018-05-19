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
    public partial class them_danh_muc_con_level_1 : System.Web.UI.Page
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
            int pid = Request.QueryString["pid"].ToInt(0);
            if (pid > 0)
            {
                ViewState["PID"] = pid;
                var parent = CategoryController.GetByID(pid);
                if (parent != null)
                {
                    if (parent.CategoryLevel == 0)
                    {
                        lblParentName.Text = parent.CategoryName;
                        ltrBack.Text = "<a href=\"/danh-muc-con-level-1?pid=" + pid + "\" class=\"btn primary-btn fw-btn not-fullwidth\">Quay về danh sách</a>";
                    }
                    else
                    {
                        Response.Redirect("/danh-muc-con-level-1?pid=" + pid + "");
                    }
                }
                else
                {
                    Response.Redirect("/danh-muc-con-level-1?pid=" + pid + "");
                }
            }
            else
            {
                Response.Redirect("/danh-muc-con-level-1?pid=" + pid + "");
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
                        int PID = ViewState["PID"].ToString().ToInt(0);
                        string kq = CategoryController.Insert(txtCategoryName.Text, txtCategoryDescription.Text, 1,
                            PID, chkIsHidden.Checked, currentDate, username);
                        if (kq.ToInt(0) > 0)
                        {
                            PJUtils.ShowMessageBoxSwAlert("Tạo mới thành công", "s", true, Page);
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