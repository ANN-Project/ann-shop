using IM_PJ.Controllers;
using IM_PJ.Models;
using MB.Extensions;
using Newtonsoft.Json;
using NHST.Bussiness;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using static IM_PJ.Controllers.DiscountCustomerController;

namespace IM_PJ
{
    public partial class tao_don_hang_doi_tra : System.Web.UI.Page
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
                        else if (acc.RoleID == 2)
                        {
                            hdfUsername.Value = acc.Username;
                        }
                        else
                        {
                            Response.Redirect("/trang-chu");
                        }

                        LoadData();
                    }
                }
                else
                {
                    Response.Redirect("/dang-nhap");
                }
            }
        }

        private void LoadData()
        {
            if (HttpContext.Current.Items["xem-don-hang-doi-tra"] != null)
            {
                this.hdfListProduct.Value = HttpContext.Current.Items["xem-don-hang-doi-tra"].ToString();
            }
        }

        [WebMethod]
        public static string checkphone(string phonefullname)
        {
            var customer = CustomerController.GetByPhone(phonefullname);

            if (customer != null)
            {
                return "OK";
            }
            else
            {
                return "nocustomer";
            }
        }

        public class RefundCust
        {
            public string CustName { get; set; }
            public string CustPhone { get; set; }
            public string CustAddress { get; set; }
            public string CustZalo { get; set; }
            public string CustFB { get; set; }
            public string CustleftCanchange { get; set; }
        }

        [WebMethod]
        public static string getProduct(string sku)
        {
            try
            {
                var freeChange = ConfigController.GetByTop1().FeeChangeProduct.Value;

                using (var con = new inventorymanagementEntities())
                {
                    var productTarget = con.tbl_Product
                        .GroupJoin(
                            con.tbl_ProductVariable,
                            product => new
                            {
                                ProductStyle = product.ProductStyle.Value,
                                ProductID = product.ID,
                            },
                            productVariable => new
                            {
                                ProductStyle = 2,
                                ProductID = productVariable.ProductID.Value,
                            },
                            (product, productVariable) => new {
                                product,
                                productVariable
                            })
                        .SelectMany(x => x.productVariable.DefaultIfEmpty(),
                                    (parent, child) => new RefundDetailModel
                                    {
                                        ProductID = parent.product.ID,
                                        ProductVariableID = parent.product.ProductStyle == 2 ? child.ID : 0,
                                        ProductStyle = parent.product.ProductStyle.Value,
                                        ProductImage = parent.product.ProductStyle == 2 ? child.Image : parent.product.ProductImage,
                                        ProductTitle = parent.product.ProductTitle,
                                        ParentSKU = parent.product.ProductSKU,
                                        ChildSKU = parent.product.ProductStyle == 2 ? child.SKU : String.Empty,
                                        Price = parent.product.ProductStyle == 2 ? child.Regular_Price.Value : parent.product.Regular_Price.Value,
                                        ReducedPrice = parent.product.ProductStyle == 2 ? child.Regular_Price.Value : parent.product.Regular_Price.Value,
                                        QuantityRefund = 1,
                                        ChangeType = 2,
                                        FeeRefund = freeChange,
                                        TotalFeeRefund = parent.product.ProductStyle == 2 ? child.Regular_Price.Value : parent.product.Regular_Price.Value
                                    })
                        .Where(x => x.ParentSKU == sku.Trim().ToUpper() || x.ChildSKU == sku.Trim().ToUpper())
                        .OrderBy(x => x.ProductID)
                        .ThenBy(x => x.ProductVariableID)
                        .ToList();

                    if (productTarget.Count > 1)
                    {
                        var variableValue = con.tbl_ProductVariableValue
                            .Where(x => x.ProductvariableSKU.Contains(sku.Trim().ToUpper()))
                            .OrderBy(x => x.ProductVariableID)
                            .ThenBy(x => x.ID)
                            .ToList();

                        productTarget = productTarget.Select(x => {
                            string properties = String.Empty;

                            variableValue
                                .Where(y => y.ProductVariableID == x.ProductVariableID)
                                .Select(y => {
                                    properties += String.Format("{0}: {1}<br/>", y.VariableName, y.VariableValue);
                                    return y;
                                })
                                .ToList();

                            return new RefundDetailModel
                            {

                                ProductID = x.ProductID,
                                ProductVariableID = x.ProductVariableID,
                                ProductStyle = x.ProductStyle,
                                ProductImage = x.ProductImage,
                                ProductTitle = x.ProductTitle,
                                ParentSKU = x.ParentSKU,
                                ChildSKU = x.ChildSKU,
                                VariableValue = properties,
                                Price = x.Price,
                                ReducedPrice = x.ReducedPrice,
                                QuantityRefund = x.QuantityRefund,
                                ChangeType = x.ChangeType,
                                FeeRefund = x.FeeRefund,
                                TotalFeeRefund = x.TotalFeeRefund
                            };
                        })
                        .ToList();
                    }

                    return new JavaScriptSerializer().Serialize(productTarget);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DateTime currentDate = DateTime.Now;
            int agentID = 0;
            string username = Request.Cookies["userLoginSystem"].Value;

            if (!string.IsNullOrEmpty(username))
            {
                var a = AccountController.GetByUsername(username);

                if (a != null)
                {
                    agentID = Convert.ToInt32(a.AgentID);
                    string phone = hdfPhone.Value;

                    if (!string.IsNullOrEmpty(phone))
                    {
                        var cust = CustomerController.GetByPhone(phone);

                        if (cust != null)
                        {
                            int custID = cust.ID;
                            double totalPrice = Convert.ToDouble(hdfTotalPrice.Value);
                            double totalQuantity = Convert.ToDouble(hdfTotalQuantity.Value);
                            double totalRefund = Convert.ToDouble(hdfTotalRefund.Value);
                            var agent = AgentController.GetByID(agentID);
                            string agentName = String.Empty;

                            if (agent != null)
                            {
                                agentName = agent.AgentName;
                            }

                            //insert ddlstatus, refundnote
                            int status = ddlRefundStatus.SelectedValue.ToInt();
                            string RefundsNote = txtRefundsNote.Text;
                            int rID = RefundGoodController.Insert(
                                new tbl_RefundGoods()
                                {
                                    AgentID = agentID,
                                    TotalPrice = totalPrice.ToString(),
                                    Status = status,
                                    CustomerID = custID,
                                    TotalQuantity = totalQuantity,
                                    TotalRefundFee = totalRefund.ToString(),
                                    CreatedDate = currentDate,
                                    CreatedBy = username,
                                    CustomerName = cust.CustomerName,
                                    CustomerPhone = cust.CustomerPhone,
                                    AgentName = agentName,
                                    RefundNote = RefundsNote
                                });

                            if (rID > 0)
                            {
                                RefundGoodModel refundModel = JsonConvert.DeserializeObject<RefundGoodModel>(hdfListProduct.Value);

                                foreach (RefundDetailModel item in refundModel.RefundDetails)
                                {
                                    int rdID = RefundGoodDetailController.Insert(
                                        new tbl_RefundGoodsDetails()
                                        {
                                            RefundGoodsID = rID,
                                            AgentID = agentID,
                                            OrderID = 0,
                                            ProductName = item.ProductTitle,
                                            CustomerID = custID,
                                            SKU = item.ProductStyle == 1 ? item.ParentSKU : item.ChildSKU,
                                            Quantity = item.QuantityRefund,
                                            QuantityMax = item.QuantityRefund,
                                            PriceNotFeeRefund = (item.QuantityRefund * item.ReducedPrice).ToString(),
                                            ProductType = item.ProductStyle,
                                            IsCount = true,
                                            RefundType = item.ChangeType,
                                            RefundFeePerProduct = item.ChangeType == 2 ? item.FeeRefund.ToString() : "0",
                                            TotalRefundFee = item.ChangeType == 2 ? (item.FeeRefund * item.QuantityRefund).ToString() : "0",
                                            GiavonPerProduct = item.Price.ToString(),
                                            DiscountPricePerProduct = (item.Price - item.ReducedPrice).ToString(),
                                            SoldPricePerProduct = item.ReducedPrice.ToString(),
                                            TotalPriceRow = item.TotalFeeRefund.ToString(),
                                            CreatedDate = currentDate,
                                            CreatedBy = username
                                        });
                                    
                                    if (rdID > 0)
                                    {
                                        if (item.ChangeType < 3)
                                        {
                                            int typeRe = 0;
                                            string note = "";

                                            if (item.ChangeType == 1)
                                            {
                                                note = "Đổi size";
                                                typeRe = 8;
                                            }
                                            else if (item.ChangeType == 2)
                                            {
                                                note = "Đổi sản phẩm";
                                                typeRe = 9;
                                            }

                                            if (item.ChangeType == 1 || item.ChangeType == 2)
                                            {
                                                StockManagerController.Insert(
                                                    new tbl_StockManager
                                                    {
                                                        AgentID = agentID,
                                                        ProductID = item.ProductID,
                                                        ProductVariableID = item.ProductVariableID,
                                                        Quantity = item.QuantityRefund,
                                                        QuantityCurrent = 0,
                                                        Type = 1,
                                                        NoteID = note,
                                                        OrderID = 0,
                                                        Status = typeRe,
                                                        SKU = item.ProductStyle == 1 ? item.ParentSKU : item.ChildSKU,
                                                        CreatedDate = currentDate,
                                                        CreatedBy = username,
                                                        MoveProID = 0,
                                                        ParentID = item.ProductID,
                                                    });
                                            }
                                        }
                                    }
                                    PJUtils.ShowMessageBoxSwAlertCallFunction("Tạo đơn hàng đổi trả thành công", "s", true, "redirectTo(" + rID + ")", Page);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}