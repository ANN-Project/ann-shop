using IM_PJ.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IM_PJ
{
    public partial class bao_cao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!IsPostBack)
                {
                    if (Session["userLoginSystem"] != null)
                    {
                        string username = Session["userLoginSystem"].ToString();
                        var acc = AccountController.GetByUsername(username);
                        if (acc != null)
                        {
                            if(acc.RoleID != 0)
                            {
                                Response.Redirect("/dang-nhap");
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

    }
}