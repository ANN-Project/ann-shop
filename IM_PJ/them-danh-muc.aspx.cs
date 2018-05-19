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
    public partial class them_danh_muc : System.Web.UI.Page
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
            var cate = CategoryController.GetAllByLevel();
            ddlCategory.Items.Clear();
            ddlCategory.Items.Insert(0, new ListItem("-- Không có danh mục cha --", "0"));
            if (cate.Count > 0)
            {
                foreach (var p in cate)
                {
                    ListItem listitem = new ListItem(p.CategoryName, p.ID.ToString());
                    ddlCategory.Items.Add(listitem);
                }
                ddlCategory.DataBind();
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
                        int id = ddlCategory.SelectedValue.ToInt();
                        var check = CategoryController.GetByID(id);
                        if (check != null)
                        {
                            if(check.CategoryLevel == 0)
                            {
                                string kq = CategoryController.Insert(txtCategoryName.Text, txtCategoryDescription.Text, 1,
                               check.ID, chkIsHidden.Checked, currentDate, username);
                                if (kq.ToInt(0) > 0)
                                {
                                    PJUtils.ShowMessageBoxSwAlert("Tạo mới thành công", "s", true, Page);
                                    Response.Redirect("quan-ly-danh-muc-san-pham.aspx");
                                }
                            }

                             if(check.CategoryLevel == 1)
                            {
                                string kq = CategoryController.Insert(txtCategoryName.Text, txtCategoryDescription.Text, 2,
                              check.ID, chkIsHidden.Checked, currentDate, username);
                                if (kq.ToInt(0) > 0)
                                {
                                    PJUtils.ShowMessageBoxSwAlert("Tạo mới thành công", "s", true, Page);
                                    Response.Redirect("quan-ly-danh-muc-san-pham.aspx");
                                }
                            }
                        }
                        else
                        {
                            string kq = CategoryController.Insert(txtCategoryName.Text, txtCategoryDescription.Text, 0,
                             0, chkIsHidden.Checked, currentDate, username);
                            if (kq.ToInt(0) > 0)
                            {
                                PJUtils.ShowMessageBoxSwAlert("Tạo mới thành công", "s", true, Page);
                                Response.Redirect("quan-ly-danh-muc-san-pham.aspx");
                            }
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