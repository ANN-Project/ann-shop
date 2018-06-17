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
    public partial class them_anh_san_pham : System.Web.UI.Page
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
            int productid = Request.QueryString["productid"].ToInt(0);
            if (productid > 0)
            {

                var product = ProductController.GetByID(productid);
                if (product != null)
                {
                    ViewState["productid"] = productid;
                    ltrBack.Text = "<a href=\"/danh-sach-anh-san-pham.aspx?id=" + product.ID + "\" class=\"btn primary-btn fw-btn not-fullwidth\">Trở về</a>";
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            DateTime currentDate = DateTime.Now;
            string username = Session["userLoginSystem"].ToString();
            var acc = AccountController.GetByUsername(username);
            if (acc != null)
            {
                if (acc.RoleID == 0)
                {
                    int productID = ViewState["productid"].ToString().ToInt(0);
                    bool isHidden = chkIsHidden.Checked;
                    ///Lưu ảnh
                    string duongdan = "/uploads/images/";
                    string IMG = "";
                    if (hinhDaiDien.UploadedFiles.Count > 0)
                    {
                        foreach (UploadedFile f in hinhDaiDien.UploadedFiles)
                        {
                            var o = duongdan + Guid.NewGuid() + f.GetExtension();
                            try
                            {
                                f.SaveAs(Server.MapPath(o));
                                IMG = o;
                                ProductImageController.Insert(productID, IMG, isHidden, currentDate, username);
                            }
                            catch { }
                        }
                        
                        PJUtils.ShowMessageBoxSwAlert("Thêm hình ảnh thành công", "s", true, Page);
                    }
                    else
                    {
                        PJUtils.ShowMessageBoxSwAlert("Vui lòng chọn hình ảnh", "e", true, Page);
                    }
                }
            }
        }
    }
}