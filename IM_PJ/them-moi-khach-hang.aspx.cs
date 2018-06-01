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
    public partial class them_moi_khach_hang : System.Web.UI.Page
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
                        if (acc.RoleID == 1)
                        {
                            Response.Redirect("/dang-nhap");
                        }
                    }
                }
                else
                {

                    Response.Redirect("/dang-nhap");
                }
                LoadProvince();
            }
        }

        public void LoadProvince()
        {
            var pro = ProvinceController.GetAll();
            ddlProvince.Items.Clear();
            ddlProvince.Items.Insert(0, new ListItem("Chọn tỉnh thành", "0"));
            if (pro.Count > 0)
            {
                foreach (var p in pro)
                {
                    ListItem listitem = new ListItem(p.ProvinceName, p.ID.ToString());
                    ddlProvince.Items.Add(listitem);
                }
                ddlProvince.DataBind();
            }
        }
       
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string username = Session["userLoginSystem"].ToString();
            var acc = AccountController.GetByUsername(username);
            if (acc != null)
            {
                if (acc.RoleID != 1)
                {
                    string phone = txtCustomerPhone.Text.ToLower().Trim();
                    var checkPhone = CustomerController.GetByPhone(phone);
                    if (checkPhone != null)
                    {
                        lblError.Text = "Số điện thoại đã tồn tại";
                        lblError.Visible = true;
                    }
                    else
                    {
                        lblError.Visible = false;
                        CustomerController.Insert(txtCustomerName.Text, txtCustomerPhone.Text, txtSupplierAddress.Text, txtSupplierEmail.Text, 0, 1,
                         DateTime.Now, username, chkIsHidden.Checked, txtZalo.Text, txtFacebook.Text, txtNote.Text,ddlProvince.SelectedValue,txtNick.Text);
                        PJUtils.ShowMessageBoxSwAlert("Thêm khách hàng thành công", "s", true, Page);
                    }
                }
            }
        }
    }
}