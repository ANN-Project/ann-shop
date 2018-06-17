using IM_PJ.Controllers;
using IM_PJ.Models;
using MB.Extensions;
using NHST.Bussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace IM_PJ
{
    public partial class cai_dat : System.Web.UI.Page
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
            var p = ConfigController.GetByTop1();
            if (p != null)
            {
                pNumOfDateToChangeProduct.Value = Convert.ToDouble(p.NumOfDateToChangeProduct);
                pNumOfProductCanChange.Value = Convert.ToDouble(p.NumOfProductCanChange);
                pFeeChangeProduct.Value = Convert.ToDouble(p.FeeChangeProduct);
                pContent.Content = p.ChangeGoodsRule;
            }
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = Session["userLoginSystem"].ToString();
            var acc = AccountController.GetByUsername(username);
            if (acc != null)
            {
                if (acc.RoleID == 0)
                {
                    ConfigController.Update(1, Convert.ToDouble(pNumOfDateToChangeProduct.Value), Convert.ToDouble(pNumOfProductCanChange.Value),
                         Convert.ToDouble(pFeeChangeProduct.Value), 0, pContent.Content, DateTime.Now, username);
                    PJUtils.ShowMessageBoxSwAlert("Cập nhật thành công", "s", true, Page);
                }
            }

        }
    }
}