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
                if (Session["userLoginSystem"] != null)
                {
                    string username = Session["userLoginSystem"].ToString();
                    var acc = AccountController.GetByUsername(username);
                    if (acc != null)
                    {
                        if (acc.RoleID == 0)
                        {
                            hdfcost.Value = "ok";
                        }
                        else if (acc.RoleID == 1)
                        {

                        }
                        else
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
        public void LoadData()
        {
            int id = Request.QueryString["id"].ToInt(0);
            if (id > 0)
            {
                var p = ProductController.GetByID(id);
                if (p != null)
                {
                    ViewState["ID"] = id;
                    ViewState["cateID"] = p.CategoryID;
                    ViewState["SKU"] = p.ProductSKU;
                    ltrBack.Text = "<a href=\"/xem-san-pham.aspx?id=" + p.ID + "\" class=\"btn primary-btn fw-btn not-fullwidth\">Trở về</a>";
                    txtProductTitle.Text = p.ProductTitle;
                    pContent.Content = p.ProductContent;
                    lblSKU.Text = p.ProductSKU;

                    chkManageStock.Checked = Convert.ToBoolean(p.ManageStock);
                    pRegular_Price.Value = p.Regular_Price;
                    pCostOfGood.Value = p.CostOfGood;
                    pRetailPrice.Value = p.Retail_Price;
                    chkIsHidden.Checked = Convert.ToBoolean(p.IsHidden);
                    ddlSupplier.SelectedValue = p.SupplierID.ToString();
                    txtMaterials.Text = p.Materials;
                    pMinimumInventoryLevel.Value = p.MinimumInventoryLevel;
                    pMaximumInventoryLevel.Value = p.MaximumInventoryLevel;
                    if(p.ProductImage != null)
                    {
                        ListProductThumbnail.Value = p.ProductImage;
                        ProductThumbnail.ImageUrl = p.ProductImage;
                    }
                }
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
                    int cateID = ViewState["cateID"].ToString().ToInt(0);
                    int id = ViewState["ID"].ToString().ToInt(0);
                    if (cateID > 0)
                    {
                        string ProductTitle = txtProductTitle.Text;
                        string ProductContent = pContent.Content;
                        string ProductSKU = ViewState["SKU"].ToString();
                        double ProductStock = 0;
                        int StockStatus = 0;
                        bool ManageStock = chkManageStock.Checked;
                        double Regular_Price = Convert.ToDouble(pRegular_Price.Value);
                        double CostOfGood = Convert.ToDouble(pCostOfGood.Value);
                        double Retail_Price = Convert.ToDouble(pRetailPrice.Value);
                        bool IsHidden = chkIsHidden.Checked;

                        //Phần thêm ảnh đại diện sản phẩm
                        string path = "/Uploads/Images/";
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

                        string kq = ProductController.Update(id, cateID, 0, ProductTitle, ProductContent, ProductSKU, ProductStock,
                            StockStatus, ManageStock, Regular_Price, CostOfGood, Retail_Price, ProductImage, 0,
                            IsHidden, DateTime.Now, username, ddlSupplier.SelectedValue.ToInt(0), ddlSupplier.SelectedItem.ToString(),
                            txtMaterials.Text, Convert.ToDouble(pMinimumInventoryLevel.Value), Convert.ToDouble(pMaximumInventoryLevel.Value));
                        if (kq.ToInt(0) > 0)
                        {
                            //PJUtils.ShowMessageBoxSwAlert("Cập nhật sản phẩm thành công", "s", true, Page);
                            Response.Redirect("thong-tin-san-pham.aspx?id=" + id + "");
                        }
                    }
                }
            }

        }
    }
}