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
using System.IO;

namespace IM_PJ
{
    public partial class thong_tin_san_pham : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["userLoginSystem"] != null)
                {
                    string username = Request.Cookies["userLoginSystem"].Value;
                    var acc = AccountController.GetByUsername(username);
                    if (acc != null)
                    {
                        if (acc.RoleID == 0)
                        {

                        }
                        else if (acc.RoleID == 1)
                        {

                        }
                        else
                        {
                            Response.Redirect("/trang-chu");
                        }

                        hdfUserRole.Value = acc.RoleID.ToString();
                    }
                }
                else
                {
                    Response.Redirect("/dang-nhap");
                }
                LoadSupplier();
                LoadCategory();
                LoadData();
            }
        }

        public void LoadCategory()
        {
            var category = CategoryController.GetAllWithIsHidden(false);
            ddlCategory.Items.Clear();
            ddlCategory.Items.Insert(0, new ListItem("Chọn danh mục sản phẩm", "0"));
            if (category.Count > 0)
            {
                addItemCategory(0, "");
                ddlCategory.DataBind();
            }
        }

        public void addItemCategory(int id, string h = "")
        {
            var categories = CategoryController.GetByParentID("", id);

            if (categories.Count > 0)
            {
                foreach (var c in categories)
                {
                    ListItem listitem = new ListItem(h + c.CategoryName, c.ID.ToString());
                    ddlCategory.Items.Add(listitem);

                    addItemCategory(c.ID, h + "---");
                }
            }
        }
        public void LoadSupplier()
        {
            var supplier = SupplierController.GetAllWithIsHidden(false);
            ddlSupplier.Items.Clear();
            ddlSupplier.Items.Insert(0, new ListItem("Chọn nhà cung cấp", "0"));
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
        public void LoadData()
        {
            int id = Request.QueryString["id"].ToInt(0);
            if (id > 0)
            {
                var p = ProductController.GetByID(id);
                if (p == null)
                {
                    PJUtils.ShowMessageBoxSwAlertError("Không tìm thấy sản phẩm " + id, "e", true, "/tat-ca-san-pham", Page);
                }
                else
                {
                    ViewState["ID"] = id;
                    ViewState["cateID"] = p.CategoryID;
                    ViewState["SKU"] = p.ProductSKU;
                    hdfParentID.Value = p.CategoryID.ToString();
                    ltrBack.Text = "<a href=\"/xem-san-pham.aspx?id=" + p.ID + "\" class=\"btn primary-btn fw-btn not-fullwidth\">Trở về</a>";
                    txtProductTitle.Text = p.ProductTitle;
                    pContent.Content = p.ProductContent;
                    lblSKU.Text = p.ProductSKU;

                    pRegular_Price.Text = p.Regular_Price.ToString();
                    pCostOfGood.Text = p.CostOfGood.ToString();
                    pRetailPrice.Text = p.Retail_Price.ToString();
                    chkIsHidden.Checked = Convert.ToBoolean(p.IsHidden);
                    ddlSupplier.SelectedValue = p.SupplierID.ToString();
                    ddlCategory.SelectedValue = p.CategoryID.ToString();
                    txtMaterials.Text = p.Materials;
                    pMinimumInventoryLevel.Text = p.MinimumInventoryLevel.ToString();
                    pMaximumInventoryLevel.Text = p.MaximumInventoryLevel.ToString();
                    if(p.ProductImage != null)
                    {
                        ListProductThumbnail.Value = p.ProductImage;
                        ProductThumbnail.ImageUrl = p.ProductImage;
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string username = Request.Cookies["userLoginSystem"].Value;
            var acc = AccountController.GetByUsername(username);
            int cateID = ViewState["cateID"].ToString().ToInt(0);
            int id = ViewState["ID"].ToString().ToInt(0);
            if (cateID > 0)
            {
                string ProductTitle = txtProductTitle.Text;
                string ProductContent = pContent.Content;
                string ProductSKU = ViewState["SKU"].ToString();
                double ProductStock = 0;
                int StockStatus = 0;
                bool ManageStock = true;
                double Regular_Price = Convert.ToDouble(pRegular_Price.Text);
                double CostOfGood = Convert.ToDouble(pCostOfGood.Text);
                double Retail_Price = Convert.ToDouble(pRetailPrice.Text);
                bool IsHidden = chkIsHidden.Checked;
                int CategoryID = hdfParentID.Value.ToInt();

                double MinimumInventoryLevel = 0;
                if(pMinimumInventoryLevel.Text != "")
                {
                    MinimumInventoryLevel = Convert.ToDouble(pMinimumInventoryLevel.Text);
                }

                double MaximumInventoryLevel = 0;
                if (pMaximumInventoryLevel.Text != "")
                {
                    MaximumInventoryLevel = Convert.ToDouble(pMaximumInventoryLevel.Text);
                }

                //Phần thêm ảnh đại diện sản phẩm
                string path = "/uploads/images/";
                string ProductImage = ListProductThumbnail.Value;
                if (ProductThumbnailImage.UploadedFiles.Count > 0)
                {
                    foreach (UploadedFile f in ProductThumbnailImage.UploadedFiles)
                    {
                        var o = path + Guid.NewGuid() + f.GetExtension();
                        try
                        {
                            f.SaveAs(Server.MapPath(o));
                            ProductImage = o;
                        }
                        catch { }
                    }
                }

                if(ProductImage != ListProductThumbnail.Value)
                {
                    if (File.Exists(Server.MapPath(ListProductThumbnail.Value)))
                    {
                        File.Delete(Server.MapPath(ListProductThumbnail.Value));
                    }
                }

                string kq = ProductController.Update(id, CategoryID, 0, ProductTitle, ProductContent, ProductSKU, ProductStock,
                    StockStatus, ManageStock, Regular_Price, CostOfGood, Retail_Price, ProductImage, 0,
                    IsHidden, DateTime.Now, username, ddlSupplier.SelectedValue.ToInt(0), ddlSupplier.SelectedItem.ToString(),
                    txtMaterials.Text, MinimumInventoryLevel, MaximumInventoryLevel);

                if (kq.ToInt(0) > 0)
                {
                    PJUtils.ShowMessageBoxSwAlert("Cập nhật sản phẩm thành công", "s", true, Page);
                }
            }
        }
    }
}