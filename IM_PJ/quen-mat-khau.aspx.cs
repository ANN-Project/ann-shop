using IM_PJ.Controllers;
using NHST.Bussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IM_PJ
{
    public partial class quen_mat_khau : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var user = AccountController.GetByEmail(txtEmail.Text.Trim());
            if (user != null)
            {
                string password = PJUtils.RandomStringWithText(10);
                //Send Email pass


                //Cập nhật pass mới cho user
                string kq = AccountController.UpdatePassword(Convert.ToInt32(user.ID), password);
                if (kq == "1")
                {
                    try
                    {
                        PJUtils.SendMailGmail("no-reply@mona-media.com", "demonhunterg", txtEmail.Text.Trim(), "Reset Mật khẩu trên ann.com.vn", "Mật khẩu mới của bạn trên hệ thống jek.vn: <strong>" + password + "</strong>", "");
                    }
                    catch
                    {

                    }
                    PJUtils.ShowMsg("Hệ thống đã gửi 1 email mật khẩu mới cho bạn, vui lòng kiểm tra email và đăng nhập lại.", true, Page);
                    Response.Redirect("/dang-nhap");
                }
            }
            else
            {
                lblError.Text = "Email không tồn tại trong hệ thống.";
                lblError.Visible = true;
            }
        }
    }
}