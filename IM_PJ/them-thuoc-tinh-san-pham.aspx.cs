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
    public partial class them_thuoc_tinh_san_pham : System.Web.UI.Page
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
                LoadSupplier();
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
                    ViewState["productsku"] = product.ProductSKU;
                    ltrBack.Text = "<a href=\"/thuoc-tinh-san-pham.aspx?id=" + product.ID + "\" class=\"btn primary-btn fw-btn not-fullwidth\">Trở về</a>";
                }
            }
        }
        public void LoadSupplier()
        {
            var supplier = SupplierController.GetAllWithIsHidden(false);
            ddlSupplier.Items.Clear();
            ddlSupplier.Items.Insert(0, new ListItem("-- Chọn nhà cung cấp --", "0"));
            if (supplier.Count > 0)
            {
                foreach (var p in supplier)
                {
                    ListItem listitem = new ListItem(p.SupplierName, p.ID.ToString());
                    ddlSupplier.Items.Add(listitem);
                }
                ddlSupplier.DataBind();
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
                    bool check = true;
                    string SKU = txtSKU.Text.Trim().ToUpper();
                    var productcheck = ProductController.GetBySKU(SKU);
                    if (productcheck != null)
                    {
                        check = false;
                    }
                    else
                    {
                        var productvariable = ProductVariableController.GetBySKU(SKU);
                        if (productvariable != null)
                            check = false;
                    }
                    if (check == false)
                    {
                        PJUtils.ShowMessageBoxSwAlert("Trùng mã SKU vui lòng kiểm tra lại", "e", false, Page);
                    }
                    else
                    {
                        string parentSKU = ViewState["productsku"].ToString();
                        int productID = ViewState["productid"].ToString().ToInt(0);

                        bool isHidden = chkIsHidden.Checked;

                        double Stock = Convert.ToDouble(pStock.Value);
                        double Regular_Price = Convert.ToDouble(pRegular_Price.Value);
                        double CostOfGood = Convert.ToDouble(pCostOfGood.Value);
                        double RetailPrice = Convert.ToDouble(pRetailPrice.Value);
                        int StockStatus = Convert.ToInt32(ddlStockStatus.SelectedValue);
                        bool ManageStock = chkManageStock.Checked;
                        ///Lưu ảnh
                        string duongdan = "/Uploads/Images/";
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
                                }
                                catch { }
                            }
                        }
                        ProductVariableController.Insert(productID, parentSKU, SKU, Stock, StockStatus, Regular_Price,
                            CostOfGood, RetailPrice, IMG, ManageStock, isHidden, currentDate, username, ddlSupplier.SelectedValue.ToInt(0),
                            ddlSupplier.SelectedItem.ToString(), Convert.ToDouble(pMinimumInventoryLevel.Value),
                            Convert.ToDouble(pMaximumInventoryLevel.Value));
                        PJUtils.ShowMessageBoxSwAlert("Thêm thuộc tính thành công", "s", true, Page);
                    }
                }
            }
        }
    }
}