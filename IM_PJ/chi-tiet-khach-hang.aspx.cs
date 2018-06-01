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
    public partial class chi_tiet_khach_hang : System.Web.UI.Page
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
                LoadData();
                LoadDLL();
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

        public void LoadDLL()
        {
            var agent = AccountController.GetAllNotSearch();
            ddlUser.Items.Clear();
            ddlUser.Items.Insert(0, new ListItem("Chọn nhân viên phụ trách", "0"));
            if (agent.Count > 0)
            {
                foreach (var p in agent)
                {
                    ListItem listitem = new ListItem(p.Username, p.ID.ToString());
                    ddlUser.Items.Add(listitem);
                }
                ddlUser.DataBind();
            }
        }

        public void LoadData()
        {
            int id = Request.QueryString["id"].ToInt(0);
            if (id > 0)
            {
                var d = CustomerController.GetByID(id);
                if (d != null)
                {
                    ViewState["ID"] = id;
                    txtCustomerName.Text = d.CustomerName;
                    lblCustomerPhone.Text = d.CustomerPhone;
                    txtSupplierAddress.Text = d.CustomerAddress;
                    txtSupplierEmail.Text = d.CustomerEmail;
                    txtNick.Text = d.Nick;
                    chkIsHidden.Checked = Convert.ToBoolean(d.IsHidden);
                    txtZalo.Text = d.Zalo;
                    txtFacebook.Text = d.Facebook;
                    if (!string.IsNullOrEmpty(d.ProvinceID.ToString()))
                        ddlProvince.SelectedValue = d.ProvinceID.ToString();
                    int UID = 0;
                    var acc = AccountController.GetByUsername(d.CreatedBy);
                    if (acc != null)
                        UID = acc.ID;
                    ddlUser.SelectedValue = UID.ToString();
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string username = Session["userLoginSystem"].ToString();
            var acc = AccountController.GetByUsername(username);
            if (acc != null)
            {
                if (acc.RoleID == 0 || acc.RoleID == 2)
                {
                    int id = ViewState["ID"].ToString().ToInt(0);
                    if (id > 0)
                    {
                        var d = CustomerController.GetByID(id);
                        if (d != null)
                        {
                            CustomerController.Update(id, txtCustomerName.Text, d.CustomerPhone, txtSupplierAddress.Text, txtSupplierEmail.Text, 0, 1,
                       ddlUser.SelectedItem.ToString(), DateTime.Now, username, chkIsHidden.Checked, txtZalo.Text, txtFacebook.Text, txtNote.Text, ddlProvince.SelectedValue,txtNick.Text);
                            PJUtils.ShowMessageBoxSwAlert("Cập nhật khách hàng thành công", "s", true, Page);
                        }
                    }
                }
            }
        }
    }
}