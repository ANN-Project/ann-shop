using IM_PJ.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IM_PJ
{
    public partial class dang_nhap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userLoginSystem"] == null)
                {
                   
                }
                else
                {
                    Response.Redirect("/trang-chu");
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            var ac = AccountController.Login(username.Trim().ToLower(), password.Trim());
            if (ac != null)
            {
                if (ac.Status == 1)
                {
                    Session["userLoginSystem"] = username;
                    Response.Redirect("/trang-chu.aspx");
                }
                else
                {
                    lblError.Text = "Tài khoản của bạn đã bị khóa.";
                    lblError.Visible = true;
                }
            }
            else
            {
                lblError.Text = "Sai Username hoặc Password, vui lòng kiểm tra lại.";
                lblError.Visible = true;
            }
        }
    }
}