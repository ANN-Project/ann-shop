﻿using IM_PJ.Controllers;
using NHST.Bussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
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
        [WebMethod]
        public static string CheckSecurityCode(string code)
        {
            string SecurityCode = PJUtils.Encrypt("scode", code);

            var p = ConfigController.GetByTop1();

            if (SecurityCode == p.SecurityCode)
            {
                HttpContext.Current.Session["securityCode"] = SecurityCode;
                return "ok";
            }
            else
            {
                return "null";
            }
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string SecurityCode = "";
            if (Session["securityCode"] != null)
            {
                SecurityCode = Session["securityCode"].ToString();
            }

            var p = ConfigController.GetByTop1();

            if (SecurityCode == p.SecurityCode)
            {
                string username = txtUsername.Text;
                string password = txtPassword.Text;
                var ac = AccountController.Login(username.Trim(), password.Trim());
                if (ac != null)
                {
                    if (ac.Status == 1)
                    {
                        Session["userLoginSystem"] = username;
                        Response.Redirect("/trang-chu");
                    }
                    else
                    {
                        lblError.Text = "Tài khoản của bạn đã bị khóa!";
                        lblError.Visible = true;
                    }
                }
                else
                {
                    lblError.Text = "Sai thông tin đăng nhập, hãy kiểm tra lại!";
                    lblError.Visible = true;
                }
            }
            else
            {
                lblError.Text = "Sai mã bảo mật!";
                lblError.Visible = true;
            }
            
        }
    }
}