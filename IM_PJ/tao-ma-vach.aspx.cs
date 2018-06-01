using IM_PJ.Controllers;
using IM_PJ.Models;
using MB.Extensions;
using NHST.Bussiness;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using static IM_PJ.Controllers.DiscountCustomerController;

namespace IM_PJ
{
    public partial class tao_ma_vach : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Session["userLoginSystem"] = "admin";
                if (Session["userLoginSystem"] != null)
                {
                    string username = Session["userLoginSystem"].ToString();
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
                            Response.Redirect("/dang-nhap");
                        }
                    }
                }
                else
                {
                    Response.Redirect("/dang-nhap");
                }
                //LoadData();
            }
        }

        [WebMethod]
        public static string getProduct(string textsearch)
        {
            List<ProductGetOut> ps = new List<ProductGetOut>();
            string username = HttpContext.Current.Session["userLoginSystem"].ToString();
            var acc = AccountController.GetByUsername(username);
            if (acc != null)
            {
                int AgentID = Convert.ToInt32(acc.AgentID);
                var product = ProductController.GetBySKU(textsearch.Trim());
                if (product != null)
                {
                    var productvariable = ProductVariableController.GetProductID(product.ID);
                    if (productvariable.Count > 0)
                    {
                        foreach (var pv in productvariable)
                        {
                            string SKU = pv.SKU.Trim().ToUpper();
                            var check = StockManagerController.GetBySKU(AgentID, SKU);
                            if (check.Count > 0)
                            {
                                double total = PJUtils.TotalProductQuantityInstock(AgentID, SKU);

                                if (total > 0)
                                {
                                    var variables = ProductVariableValueController.GetByProductVariableID(pv.ID);
                                    if (variables.Count > 0)
                                    {
                                        string variablename = "";
                                        string variablevalue = "";
                                        string variable = "";
                                        string variablesave = "";
                                        foreach (var v in variables)
                                        {
                                            variable += v.VariableName.Trim() + ":" + v.VariableValue.Trim() + "<br/>";
                                            variablesave += v.VariableName.Trim() + ":" + v.VariableValue.Trim() + "|";
                                            variablename += v.VariableName.Trim() + "|";
                                            variablevalue += v.VariableValue.Trim() + "|";
                                        }

                                        ProductGetOut p = new ProductGetOut();
                                        p.ID = pv.ID;
                                        p.ProductName = product.ProductTitle;
                                        p.ProductVariable = variable;
                                        p.ProductVariableSave = variablesave;
                                        p.ProductVariableName = variablename;

                                        p.ProductVariableValue = variablevalue;
                                        p.ProductType = 2;
                                        p.ProductImage = "<img src=\"" + pv.Image + "\" alt=\"\" style=\"width: 50px\"  />";
                                        p.ProductImageOrigin = pv.Image;
                                        p.QuantityInstock = total;
                                        p.QuantityInstockString = string.Format("{0:N0}", total);
                                        p.SKU = SKU;
                                        p.Giabansi = Convert.ToDouble(pv.Regular_Price);
                                        p.stringGiabansi = string.Format("{0:N0}", pv.Regular_Price);
                                        p.Giabanle = Convert.ToDouble(pv.RetailPrice);
                                        p.stringGiabanle = string.Format("{0:N0}", pv.RetailPrice);
                                        ps.Add(p);
                                    }
                                }
                            }

                        }
                    }
                    else
                    {
                        string SKU = product.ProductSKU.Trim().ToUpper();
                        var check = StockManagerController.GetBySKU(AgentID, SKU);
                        if (check.Count > 0)
                        {
                            double total = PJUtils.TotalProductQuantityInstock(AgentID, SKU);
                            if (total > 0)
                            {
                                string variablename = "";
                                string variablevalue = "";
                                string variable = "";

                                ProductGetOut p = new ProductGetOut();
                                p.ID = product.ID;
                                p.ProductName = product.ProductTitle;
                                p.ProductVariable = variable;
                                p.ProductVariableSave = "";
                                p.ProductVariableName = variablename;
                                p.ProductVariableValue = variablevalue;
                                p.ProductType = 1;
                                var img = ProductImageController.GetFirstByProductID(product.ID);
                                if (img != null)
                                {
                                    p.ProductImage = "<img src=\"" + img.ProductImage + "\" alt=\"\" style=\"width: 50px\"  />";
                                    p.ProductImageOrigin = img.ProductImage;
                                }
                                else
                                {
                                    p.ProductImage = "";
                                    p.ProductImageOrigin = "";
                                }
                                p.SKU = SKU;
                                p.QuantityInstock = total;
                                p.QuantityInstockString = string.Format("{0:N0}", total);
                                p.Giabansi = Convert.ToDouble(product.Regular_Price);
                                p.stringGiabansi = string.Format("{0:N0}", product.Regular_Price);
                                p.Giabanle = Convert.ToDouble(product.Retail_Price);
                                p.stringGiabanle = string.Format("{0:N0}", product.Retail_Price);
                                ps.Add(p);
                            }
                        }

                    }
                }
                else
                {
                    var productvariable = ProductVariableController.GetAllBySKU(textsearch);
                    if (productvariable != null)
                    {
                        foreach (var value in productvariable)
                        {

                            string SKU = value.SKU.Trim().ToUpper();
                            var check = StockManagerController.GetBySKU(AgentID, SKU);
                            if (check.Count > 0)
                            {
                                double total = PJUtils.TotalProductQuantityInstock(AgentID, SKU);
                                if (total > 0)
                                {
                                    var variables = ProductVariableValueController.GetByProductVariableID(value.ID);

                                    if (variables.Count > 0)
                                    {
                                        string variablename = "";
                                        string variablevalue = "";
                                        string variable = "";
                                        string variablesave = "";

                                        foreach (var v in variables)
                                        {
                                            variable += v.VariableName + ":" + v.VariableValue + "<br/>";
                                            variablesave += v.VariableName.Trim() + ":" + v.VariableValue.Trim() + "|";
                                            variablename += v.VariableName + "|";
                                            variablevalue += v.VariableValue + "|";
                                        }

                                        ProductGetOut p = new ProductGetOut();
                                        p.ID = value.ID;
                                        var product1 = ProductController.GetByID(Convert.ToInt32(value.ProductID));
                                        if (product1 != null)
                                            p.ProductName = product1.ProductTitle;
                                        p.ProductVariable = variable;
                                        p.ProductVariableSave = variablesave;
                                        p.ProductVariableName = variablename;
                                        p.ProductVariableValue = variablevalue;
                                        p.ProductType = 2;
                                        p.ProductImage = "<img src=\"" + value.Image + "\" alt=\"\" style=\"width:50px;\" />";
                                        p.ProductImageOrigin = value.Image;
                                        p.SKU = value.SKU.Trim().ToUpper();
                                        p.QuantityInstock = total;
                                        p.QuantityInstockString = string.Format("{0:N0}", total);
                                        p.Giabansi = Convert.ToDouble(value.Regular_Price);
                                        p.stringGiabansi = string.Format("{0:N0}", value.Regular_Price);
                                        p.Giabanle = Convert.ToDouble(value.Regular_Price);
                                        p.stringGiabanle = string.Format("{0:N0}", value.Regular_Price);
                                        ps.Add(p);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(ps);
        }
        [WebMethod]
        public static string findcustomer(string phone)
        {
            var customer = CustomerController.GetByPhone(phone);
            if (customer != null)
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                return serializer.Serialize(customer);
            }
            else
            {
                return "0";
            }

        }
        [WebMethod]
        public static string getcustomerdetail(int ID)
        {
            var customer = CustomerController.GetByID(ID);
            if (customer != null)
            {
                var ci = new CustomerInfoWithDiscount();
                ci.Customer = customer;
                //ci.CreatedDate = string.Format("{0:dd/MM/yyyy}", customer.CreatedDate);
                ci.CreatedDate = customer.CreatedDate.ToString();
                List<DiscountCustomerGet> dc = new List<DiscountCustomerGet>();
                var d = DiscountCustomerController.getbyCustID(ID);
                if (d.Count > 0)
                {
                    dc = d;
                }
                ci.AllDiscount = dc;
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                return serializer.Serialize(ci);
            }
            else
            {
                return "null";
            }
        }
        [WebMethod]
        public static string gethightdiscount(int ID)
        {
            var d = DiscountCustomerController.getbyCustID(ID);
            if (d.Count > 0)
            {
                var da = d[0].DiscountAmount;
                return da.ToString();
            }
            else
            {
                return "0";
            }

        }

        public class ProductGetOut
        {
            public int ID { get; set; }
            public string ProductName { get; set; }
            public string ProductVariable { get; set; }
            public string ProductVariableSave { get; set; }
            public string ProductVariableName { get; set; }
            public string ProductVariableValue { get; set; }
            public int ProductType { get; set; }
            public string ProductImage { get; set; }
            public string ProductImageOrigin { get; set; }
            public string QuantityInstockString { get; set; }
            public double QuantityInstock { get; set; }
            public string SKU { get; set; }
            public double Giabanle { get; set; }
            public string stringGiabanle { get; set; }
            public double Giabansi { get; set; }
            public string stringGiabansi { get; set; }
        }
        public class CustomerInfoWithDiscount
        {
            public tbl_Customer Customer { get; set; }
            public string CreatedDate { get; set; }
            public List<DiscountCustomerGet> AllDiscount { get; set; }
        }
        protected void btnImport_Click(object sender, EventArgs e)
        {

        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {
            string barcode = "";
            string productPrint = "";
            string barcodeIMG = "";
            string[] list = hdfListProduct.Value.Split(';');
            if (list.Count() > 0)
            {
                productPrint += "<div class=\"qcode\">";
                for (int i = 0; i < list.Length - 1; i++)
                {
                  
                    string[] list2 = list[i].Split(',');
                    int quantity = list2[2].ToInt();
                    //productPrint += "<div style=\"width:12%\">";
                    for (int j = 0; j < quantity; j++)
                    {
                        barcode = list2[1];
                        //string QRIMG = PJUtils.GenQRCode(barcode);
                        barcodeIMG = "/Uploads/Images/" + barcode + ".Png";
                        System.Drawing.Image barCode = PJUtils.MakeBarcodeImage(barcode,2,true);

                        barCode.Save(HttpContext.Current.Server.MapPath("" + barcodeIMG + ""), ImageFormat.Png);
                       
                        productPrint += "<div class=\"item\">";
                        productPrint += "<div class=\"img\"><img src =\"" + barcodeIMG + "\" alt=\"\"></div>";
                        productPrint += "<div><h1>" + barcode + "</h1></div>";
                        productPrint += "</div>";

                        //productPrint += "<div style=\"padding-bottom:7px\">";
                        //productPrint += "<div style=\"padding-bottom:7px;width: 189px;height: 70px;text-align:center;\"><img alt\"barcode\" src=\"" + barcodeIMG + "\" />" + barcode + "</div>";
                        //productPrint += "<span style=\"text-align:center;margin-top: -5px;\">" + barcode + "</span>";
                        //productPrint += "";
                        // OrderController.UpdateQRCodeIMGQRCodeIMGBarcode(order.ID, barcode, QRIMG, barcodeIMG);
                    }
                  
                    //productPrint += "</div>";
                    //ProductImageController.Insert(1, barcodeIMG, false, DateTime.Now, "admin");
                }
                productPrint += "</div>";
                string html = "";
                html += productPrint;
                ltrprint.Text = html;
                PJUtils.ShowMessageBoxSwAlertCallFunction("In mã vạch thành công", "s", true, "printPhieuchi()", Page);
            }
        }
    }
}