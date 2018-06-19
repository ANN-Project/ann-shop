using Bnails.Bussiness;
using IM_PJ.Controllers;
using IM_PJ.Models;
using MB.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using static IM_PJ.Controllers.ProductController;

namespace IM_PJ
{
    /// <summary>
    /// Summary description for annService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class annService : System.Web.Services.WebService
    {
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public void GetRootCategory()
        {
            var rs = new ResponseClass();
            var category = CategoryController.API_GetRootCategory();
            if (category.Count > 0)
            {
                rs.Code = APIUtils.GetResponseCode(APIUtils.ResponseCode.SUCCESS);
                rs.Status = APIUtils.ResponseMessage.Success.ToString();
                rs.Category = category;
            }
            else
            {
                rs.Code = APIUtils.GetResponseCode(APIUtils.ResponseCode.NotFound);
                rs.Status = APIUtils.ResponseMessage.Error.ToString();
                rs.Message = APIUtils.OBJ_DNTEXIST;
            }
            Context.Response.ContentType = "application/json";
            Context.Response.Write(JsonConvert.SerializeObject(rs, Formatting.Indented));
            Context.Response.Flush();
            Context.Response.End();
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public void GetAllCategory()
        {
            var rs = new ResponseClass();
            var category = CategoryController.API_GetAllCategory();
            if (category.Count > 0)
            {
                rs.Code = APIUtils.GetResponseCode(APIUtils.ResponseCode.SUCCESS);
                rs.Status = APIUtils.ResponseMessage.Success.ToString();
                rs.Category = category;
            }
            else
            {
                rs.Code = APIUtils.GetResponseCode(APIUtils.ResponseCode.NotFound);
                rs.Status = APIUtils.ResponseMessage.Error.ToString();
                rs.Message = APIUtils.OBJ_DNTEXIST;
            }
            Context.Response.ContentType = "application/json";
            Context.Response.Write(JsonConvert.SerializeObject(rs, Formatting.Indented));
            Context.Response.Flush();
            Context.Response.End();
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public void GetCategoryByParentID(int ParentID)
        {
            var rs = new ResponseClass();
            var category = CategoryController.API_GetByParentID(ParentID);
            if (category.Count > 0)
            {
                rs.Code = APIUtils.GetResponseCode(APIUtils.ResponseCode.SUCCESS);
                rs.Status = APIUtils.ResponseMessage.Success.ToString();
                rs.Category = category;
            }
            else
            {
                rs.Code = APIUtils.GetResponseCode(APIUtils.ResponseCode.NotFound);
                rs.Status = APIUtils.ResponseMessage.Error.ToString();
                rs.Message = APIUtils.OBJ_DNTEXIST;
            }
            Context.Response.ContentType = "application/json";
            Context.Response.Write(JsonConvert.SerializeObject(rs, Formatting.Indented));
            Context.Response.Flush();
            Context.Response.End();
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public void GetProductByCategory(int CategoryID)
        {
            var rs = new ResponseClass();
            var Product = ProductController.GetAllSql(CategoryID,"");
            if (Product.Count > 0)
            {
                rs.Code = APIUtils.GetResponseCode(APIUtils.ResponseCode.SUCCESS);
                rs.Status = APIUtils.ResponseMessage.Success.ToString();

                foreach (var item in Product)
                {
                    var productImage = ProductImageController.GetByProductID(item.ID);

                    item.ProductContent = String.Format("<p><img src='/wp-content/uploads/{0}' alt='{1}'/></p>", item.ProductImage.Split('/')[3], item.ProductTitle);
                    foreach (var image in productImage)
                    {
                        item.ProductImage += "|" + image.ProductImage;
                        item.ProductContent += String.Format("<p><img src='/wp-content/uploads/{0}' alt='{1}'/></p>", image.ProductImage.Split('/')[3], item.ProductTitle);
                    }
                }
                rs.Product = Product;
            }
            else
            {
                rs.Code = APIUtils.GetResponseCode(APIUtils.ResponseCode.NotFound);
                rs.Status = APIUtils.ResponseMessage.Error.ToString();
                rs.Message = APIUtils.OBJ_DNTEXIST;
            }
            Context.Response.ContentType = "application/json";
            Context.Response.Write(JsonConvert.SerializeObject(rs, Formatting.Indented));
            Context.Response.Flush();
            Context.Response.End();
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public void GetProductImageByProductID(int ProductID)
        {
            var rs = new ResponseClass();
            var ProductImage = ProductImageController.GetByProductID(ProductID);
            if (ProductImage.Count > 0)
            {
                rs.Code = APIUtils.GetResponseCode(APIUtils.ResponseCode.SUCCESS);
                rs.Status = APIUtils.ResponseMessage.Success.ToString();
                rs.ProductImage = ProductImage;
            }
            else
            {
                rs.Code = APIUtils.GetResponseCode(APIUtils.ResponseCode.NotFound);
                rs.Status = APIUtils.ResponseMessage.Error.ToString();
                rs.Message = APIUtils.OBJ_DNTEXIST;
            }
            Context.Response.ContentType = "application/json";
            Context.Response.Write(JsonConvert.SerializeObject(rs, Formatting.Indented));
            Context.Response.Flush();
            Context.Response.End();
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public void GetProductVariableByProductID(int ProductID)
        {
            var rs = new ResponseClass();
            var ProductVariable = ProductVariableController.GetProductID(ProductID);
            if (ProductVariable.Count > 0)
            {
                rs.Code = APIUtils.GetResponseCode(APIUtils.ResponseCode.SUCCESS);
                rs.Status = APIUtils.ResponseMessage.Success.ToString();
                rs.ProductVariable = ProductVariable;
            }
            else
            {
                rs.Code = APIUtils.GetResponseCode(APIUtils.ResponseCode.NotFound);
                rs.Status = APIUtils.ResponseMessage.Error.ToString();
                rs.Message = APIUtils.OBJ_DNTEXIST;
            }
            Context.Response.ContentType = "application/json";
            Context.Response.Write(JsonConvert.SerializeObject(rs, Formatting.Indented));
            Context.Response.Flush();
            Context.Response.End();
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public void GetProductVariableValueByProductVariableID(int ProductVariableID)
        {
            var rs = new ResponseClass();
            var ProductVariableValue = ProductVariableValueController.GetByProductVariableID(ProductVariableID);
            if (ProductVariableValue.Count > 0)
            {
                rs.Code = APIUtils.GetResponseCode(APIUtils.ResponseCode.SUCCESS);
                rs.Status = APIUtils.ResponseMessage.Success.ToString();
                rs.ProductVariableValue = ProductVariableValue;
            }
            else
            {
                rs.Code = APIUtils.GetResponseCode(APIUtils.ResponseCode.NotFound);
                rs.Status = APIUtils.ResponseMessage.Error.ToString();
                rs.Message = APIUtils.OBJ_DNTEXIST;
            }
            Context.Response.ContentType = "application/json";
            Context.Response.Write(JsonConvert.SerializeObject(rs, Formatting.Indented));
            Context.Response.Flush();
            Context.Response.End();
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public void LoginSystem(string username, string password)
        {
            var rs = new ResponseClass();
            var user = AccountController.Login(username.Trim().ToLower(), password);
            if (user != null)
            {
                rs.Code = APIUtils.GetResponseCode(APIUtils.ResponseCode.SUCCESS);
                rs.Status = APIUtils.ResponseMessage.Success.ToString();
                rs.User = user;
            }
            else
            {
                rs.Code = APIUtils.GetResponseCode(APIUtils.ResponseCode.NotFound);
                rs.Status = APIUtils.ResponseMessage.Error.ToString();
                rs.Message = APIUtils.OBJ_DNTEXIST;
            }
            Context.Response.ContentType = "application/json";
            Context.Response.Write(JsonConvert.SerializeObject(rs, Formatting.Indented));
            Context.Response.Flush();
            Context.Response.End();
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public void GetAgentCode(int AgentID)
        {
            var rs = new ResponseClass();
            var agent = AgentController.GetByID(AgentID);
            if (agent != null)
            {
                rs.Code = APIUtils.GetResponseCode(APIUtils.ResponseCode.SUCCESS);
                rs.Status = APIUtils.ResponseMessage.Success.ToString();
                rs.Agent = agent;
            }
            else
            {
                rs.Code = APIUtils.GetResponseCode(APIUtils.ResponseCode.NotFound);
                rs.Status = APIUtils.ResponseMessage.Error.ToString();
                rs.Message = APIUtils.OBJ_DNTEXIST;
            }
            Context.Response.ContentType = "application/json";
            Context.Response.Write(JsonConvert.SerializeObject(rs, Formatting.Indented));
            Context.Response.Flush();
            Context.Response.End();
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public void InserOrder1(string AgentAPIID, string AgentAPICode, int OrderType, string CustomerName, string CustomerPhone, string CustomerEmail,
            string CustomerAddress, double TotalPrice, int PaymentStatus, int ExcuteStatus, List<ProductOrder> ListProduct, string CreatedBy)
        {
            var rs = new ResponseClass();
            DateTime currentDate = DateTime.Now;
            var agent = AgentController.GetByAPICodeID(AgentAPIID, AgentAPICode);
            if (agent != null)
            {
                int AgentID = agent.ID;
                int CustomerID = 0;
                string AdditionFee = "0";
                string DisCount = "0";
                var checkphone = CustomerController.GetByPhone(CustomerPhone);
                if (checkphone != null)
                {
                    CustomerID = checkphone.ID;
                }
                else
                {
                    string kq = CustomerController.Insert(CustomerName, CustomerPhone, CustomerAddress, CustomerEmail, 0, 0, currentDate, CreatedBy, false, "", "", "","","");
                    if (kq.ToInt(0) > 0)
                    {
                        CustomerID = kq.ToInt(0);
                    }
                }
                bool IsHidden = false;
                int Wayin = 2;

                var ret = OrderController.Insert(AgentID, OrderType, AdditionFee, DisCount, CustomerID, CustomerName, CustomerPhone, CustomerAddress,
                        CustomerEmail, TotalPrice.ToString(), TotalPrice.ToString(), PaymentStatus, ExcuteStatus, IsHidden, Wayin, currentDate, CreatedBy, 0, 0, "0",0,0,DateTime.Now.ToString(),0,0, 0, 0);
                int OrderID = ret.ID;
                if (OrderID > 0)
                {
                    if (ListProduct.Count > 0)
                    {
                        foreach (var p in ListProduct)
                        {

                            int ProductID = 0;
                            int ProductVariableID = 0;

                            int ID = p.ID;
                            string SKU = p.SKU;
                            int producttype = p.ProductType;
                            if (producttype == 1)
                            {
                                ProductID = ID;
                                ProductVariableID = 0;
                            }
                            else
                            {
                                ProductID = 0;
                                ProductVariableID = ID;
                            }

                            string ProductVariableName = p.ProductVariableName;
                            string ProductVariableValue = p.ProductVariableValue;
                            double Quantity = Convert.ToDouble(p.Quantity);
                            string ProductName = p.ProductName;
                            string ProductImageOrigin = p.ProductImageOrigin;
                            double ProductPrice = p.Price;
                            string ProductVariableSave = p.ProductVariableDescription;


                            if (ExcuteStatus == 2 && PaymentStatus == 3)
                            {
                                OrderDetailController.Insert(AgentID, OrderID, SKU, ProductID, ProductVariableID, ProductVariableSave, Quantity,
                                ProductPrice, 1, 0, producttype, currentDate, CreatedBy, true);
                                if (producttype == 1)
                                {
                                    StockManagerController.Insert(
                                        new tbl_StockManager() {
                                            AgentID = AgentID,
                                            ProductID = ProductID,
                                            ProductVariableID = 0,
                                            Quantity = Quantity,
                                            QuantityCurrent = 0,
                                            Type = 2,
                                            NoteID = String.Empty,
                                            OrderID = OrderID,
                                            Status = 3,
                                            SKU = SKU,
                                            CreatedDate = currentDate,
                                            CreatedBy = CreatedBy,
                                            MoveProID = 0,
                                            ParentID = ProductID
                                        });
                                }
                                else
                                {
                                    int parentID = 0;
                                    string parentSKU = "";
                                    var productV = ProductVariableController.GetByID(ProductVariableID);
                                    if (productV != null)
                                        parentSKU = productV.ParentSKU;
                                    if (!string.IsNullOrEmpty(parentSKU))
                                    {
                                        var product = ProductController.GetBySKU(parentSKU);
                                        if (product != null)
                                            parentID = product.ID;
                                    }
                                    StockManagerController.Insert(
                                        new tbl_StockManager {
                                            AgentID = AgentID,
                                            ProductID = 0,
                                            ProductVariableID = ProductVariableID,
                                            Quantity = Quantity,
                                            QuantityCurrent = 0,
                                            Type = 2,
                                            NoteID = String.Empty,
                                            OrderID = OrderID,
                                            Status = 3,
                                            SKU = SKU,
                                            CreatedDate = currentDate,
                                            CreatedBy = CreatedBy,
                                            MoveProID = 0,
                                            ParentID = parentID,
                                        });
                                }
                            }
                            else
                            {
                                OrderDetailController.Insert(AgentID, OrderID, SKU, ProductID, ProductVariableID, ProductVariableSave, Quantity,
                                ProductPrice, 1, 0, producttype, currentDate, CreatedBy, false);
                            }
                        }
                    }
                    rs.Code = APIUtils.GetResponseCode(APIUtils.ResponseCode.SUCCESS);
                    rs.Status = APIUtils.ResponseMessage.Success.ToString();
                    rs.Message = "Tạo mới đơn hàng thành công";
                }
                else
                {
                    rs.Code = APIUtils.GetResponseCode(APIUtils.ResponseCode.NotFound);
                    rs.Status = APIUtils.ResponseMessage.Error.ToString();
                    rs.Message = "Có lỗi trong quá trình tạo mới đơn hàng, vui lòng thử lại sau.";
                }
            }
            else
            {
                rs.Code = APIUtils.GetResponseCode(APIUtils.ResponseCode.NotFound);
                rs.Status = APIUtils.ResponseMessage.Error.ToString();
                rs.Message = "Không tồn tại thông tin đại lý";
            }
            Context.Response.ContentType = "application/json";
            Context.Response.Write(JsonConvert.SerializeObject(rs, Formatting.Indented));
            Context.Response.Flush();
            Context.Response.End();
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public void InserOrder(string AgentAPIID, string AgentAPICode, string OrderType, string CustomerName, string CustomerPhone, string CustomerEmail,
            string CustomerAddress, string TotalPrice, string PaymentStatus, string ExcuteStatus, string CreatedBy, string productquantity,
            string FeeShipping, int PaymentType, int ShippingType)
        {
            var rs = new ResponseClass();
            DateTime currentDate = DateTime.Now;
            var agent = AgentController.GetByAPICodeID(AgentAPIID, AgentAPICode);
            if (agent != null)
            {
                int AgentID = agent.ID;
                int CustomerID = 0;
                string AdditionFee = "0";
                string DisCount = "0";
                var checkphone = CustomerController.GetByPhone(CustomerPhone);
                if (checkphone != null)
                {
                    CustomerID = checkphone.ID;
                }
                else
                {
                    string kq = CustomerController.Insert(CustomerName, CustomerPhone, CustomerAddress, CustomerEmail, 0, 0, currentDate, CreatedBy, false, "", "", "","","");
                    if (kq.ToInt(0) > 0)
                    {
                        CustomerID = kq.ToInt(0);
                    }
                }
                bool IsHidden = false;
                int Wayin = 2;

                double amount = 0;
                double totalDiscount = 0;
                double totalleft = 0;

                var d = DiscountCustomerController.getbyCustID(CustomerID);
                if (d.Count > 0)
                {
                    amount = d[0].DiscountAmount;
                }
                int pquantity = productquantity.ToInt(0);
                if (amount == 0)
                {
                    if (pquantity > 29 && pquantity <= 49)
                    {
                        amount = 3000;
                    }
                    else if (pquantity > 49 && pquantity <= 99)
                    {
                        amount = 5000;
                    }
                    else if (pquantity > 99 && pquantity <= 199)
                    {
                        amount = 7000;
                    }
                    else if (pquantity > 199)
                    {
                        amount = 8000;
                    }
                    else
                    {
                        amount = 0;
                    }
                }
                if (amount > 0)
                {
                    totalDiscount = amount * pquantity;
                    totalleft = Convert.ToDouble(TotalPrice) - totalDiscount;

                }
                else
                {
                    totalDiscount = 0;
                    totalleft = Convert.ToDouble(TotalPrice);
                }

                var ret = OrderController.Insert(AgentID, OrderType.ToInt(1), AdditionFee, DisCount, CustomerID, CustomerName, CustomerPhone, CustomerAddress,
                        CustomerEmail, totalleft.ToString(), TotalPrice.ToString(), PaymentStatus.ToInt(0), ExcuteStatus.ToInt(0), IsHidden, Wayin, currentDate, CreatedBy,
                        amount, totalDiscount, FeeShipping.ToString(), PaymentType, ShippingType,DateTime.Now.ToString(),0,0, 0, 0);
                int OrderID = ret.ID;
                if (OrderID > 0)
                {

                    rs.Code = APIUtils.GetResponseCode(APIUtils.ResponseCode.SUCCESS);
                    rs.Status = APIUtils.ResponseMessage.Success.ToString();
                    rs.OrderID = OrderID;
                    rs.Message = "Tạo mới đơn hàng thành công";
                }
                else
                {
                    rs.Code = APIUtils.GetResponseCode(APIUtils.ResponseCode.NotFound);
                    rs.Status = APIUtils.ResponseMessage.Error.ToString();
                    rs.Message = "Có lỗi trong quá trình tạo mới đơn hàng, vui lòng thử lại sau.";
                }
            }
            else
            {
                rs.Code = APIUtils.GetResponseCode(APIUtils.ResponseCode.NotFound);
                rs.Status = APIUtils.ResponseMessage.Error.ToString();
                rs.Message = "Không tồn tại thông tin đại lý";
            }
            Context.Response.ContentType = "application/json";
            Context.Response.Write(JsonConvert.SerializeObject(rs, Formatting.Indented));
            Context.Response.Flush();
            Context.Response.End();
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public void InserOrderDetail(string AgentAPIID, string AgentAPICode, int OrderID, int ID, string SKU, int ProductType,
            string ProductVariableName, string ProductVariableValue, double Quantity, string ProductName, string ProductImageOrigin,
            double ProductPrice, string ProductVariableSave, int ExcuteStatus, int PaymentStatus, string CreatedBy)
        {
            var rs = new ResponseClass();
            DateTime currentDate = DateTime.Now;
            var agent = AgentController.GetByAPICodeID(AgentAPIID, AgentAPICode);
            if (agent != null)
            {
                int AgentID = agent.ID;
                int ProductID = 0;
                int ProductVariableID = 0;
                if (ProductType == 1)
                {
                    ProductID = ID;
                    ProductVariableID = 0;
                }
                else
                {
                    ProductID = 0;
                    ProductVariableID = ID;
                }

                if (ExcuteStatus == 2 && PaymentStatus == 3)
                {
                    OrderDetailController.Insert(AgentID, OrderID, SKU, ProductID, ProductVariableID, ProductVariableSave, Quantity,
                    ProductPrice, 1, 0, ProductType, currentDate, CreatedBy, true);
                    if (ProductType == 1)
                    {
                        StockManagerController.Insert(
                            new tbl_StockManager {
                                AgentID = AgentID,
                                ProductID = ProductID,
                                ProductVariableID = 0,
                                Quantity = Quantity,
                                QuantityCurrent = 0,
                                Type = 2,
                                NoteID = String.Empty,
                                OrderID = OrderID,
                                Status = 3,
                                SKU = SKU,
                                CreatedDate = currentDate,
                                CreatedBy = CreatedBy,
                                MoveProID = 0,
                                ParentID = ProductID
                            });
                    }
                    else
                    {
                        int parentID = 0;
                        string parentSKU = "";
                        var productV = ProductVariableController.GetByID(ProductVariableID);
                        if (productV != null)
                            parentSKU = productV.ParentSKU;
                        if (!string.IsNullOrEmpty(parentSKU))
                        {
                            var product = ProductController.GetBySKU(parentSKU);
                            if (product != null)
                                parentID = product.ID;
                        }
                        StockManagerController.Insert(
                            new tbl_StockManager {
                                AgentID = AgentID,
                                ProductID = 0,
                                ProductVariableID = ProductVariableID,
                                Quantity = Quantity,
                                QuantityCurrent = 0,
                                Type = 2,
                                NoteID = String.Empty,
                                OrderID = OrderID,
                                Status = 3,
                                SKU = SKU,
                                CreatedDate = currentDate,
                                CreatedBy = CreatedBy,
                                MoveProID = 0,
                                ParentID = parentID
                            });
                    }
                }
                else
                {
                    OrderDetailController.Insert(AgentID, OrderID, SKU, ProductID, ProductVariableID, ProductVariableSave, Quantity,
                    ProductPrice, 1, 0, ProductType, currentDate, CreatedBy, false);
                }
                rs.Code = APIUtils.GetResponseCode(APIUtils.ResponseCode.SUCCESS);
                rs.Status = APIUtils.ResponseMessage.Success.ToString();
                rs.Message = "Tạo mới đơn hàng thành công";
            }
            else
            {
                rs.Code = APIUtils.GetResponseCode(APIUtils.ResponseCode.NotFound);
                rs.Status = APIUtils.ResponseMessage.Error.ToString();
                rs.Message = "Không tồn tại thông tin đại lý";
            }
            Context.Response.ContentType = "application/json";
            Context.Response.Write(JsonConvert.SerializeObject(rs, Formatting.Indented));
            Context.Response.Flush();
            Context.Response.End();
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = false)]
        public void GetQuantityCurrent()
        {
            var StockManager = StockManagerController.GetQuantityCurrent();
            if (StockManager.Count > 0)
            {
                var DataToExportToCSV = StockManager.Select(x => {
                    var quantityCurrent = 0D;

                    if (x.Type == 1)
                    {
                        quantityCurrent = x.QuantityCurrent.Value + x.Quantity.Value;
                    }
                    else
                    {
                        quantityCurrent = x.QuantityCurrent.Value + x.Quantity.Value;
                    }

                    return new StockManager()
                    {
                        SKU = x.SKU,
                        Quantity = quantityCurrent,
                        Status = quantityCurrent > 0 ? 1 : 0
                    };
                }).ToList();

                string attachment = "attachment; filename=StockManagerCSV.csv";
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ClearHeaders();
                HttpContext.Current.Response.ClearContent();
                HttpContext.Current.Response.AddHeader("content-disposition", attachment);
                HttpContext.Current.Response.ContentType = "text/csv";
                HttpContext.Current.Response.AddHeader("Pragma", "public");

                var sb = new StringBuilder();
                foreach (var line in DataToExportToCSV)
                    sb.AppendLine(String.Format("{0}, {1}, {2}", line.SKU, line.Quantity, line.Status));

                HttpContext.Current.Response.Write(sb.ToString());
            }

        }
        //[WebMethod]
        //[ScriptMethod(UseHttpGet = false)]
        //public void GetAllProduct()
        //{
        //    int categoryID = 1;
        //    string s = "";
        //    List<ProductSQL> products = new List<ProductSQL>();
        //    products = ProductController.GetAllSql(categoryID, s);
        //    string xml = "";
        //    if(products.Count > 0)
        //    {
        //        foreach (var item in products)
        //        {
        //            xml += "<product>";
        //            xml += "<product_sku>" + item.ProductSKU + "</product_sku>";
        //            xml += "<product_title>" + item.ProductTitle + "</product_title>";
        //            xml += "<product_regular_price>" + item.RegularPrice + "</product_regular_price>";
        //            xml += "<product_retail_price>" + item.RetailPrice + "</product_retail_price>";
        //            xml += "<product_category>" + item.CategoryName + "</product_category>";
        //            xml += "<product_type>" + item.ProductStyle + "</product_type>";
                    
        //            string stock = "0";
        //            string manager_stock = "0";
        //            if (item.ProductStyle == 1)
        //            {
        //                var ProductStock = ProductController.GetAllSql(0, item.ProductSKU);
        //                if (ProductStock.Count() > 0)
        //                {
        //                    foreach (var itemStock in ProductStock)
        //                    {
        //                        stock = itemStock.TotalProductInstockQuantityLeft.ToString();
        //                    }
        //                }
        //                manager_stock = "1";
        //            }
        //            xml += "<product_stock>" + stock + "</product_stock>";
        //            xml += "<product_manager_stock>" + manager_stock + "</product_manager_stock>";

        //            var productImage = ProductImageController.GetByProductID(item.ID);

        //            item.ProductContent = String.Format("<p><img src='/wp-content/uploads/{0}' alt='{1}'/></p>", item.ProductImage.Split('/')[3], item.ProductTitle);
        //            foreach (var image in productImage)
        //            {
        //                item.ProductImage += "|" + image.ProductImage;
        //                item.ProductContent += String.Format("<p><img src='/wp-content/uploads/{0}' alt='{1}'/></p>", image.ProductImage.Split('/')[3], item.ProductTitle);
        //            }
        //            xml += "<productimage>" + item.ProductImage + "</productimage>";
        //            xml += "<productcontent>" + item.ProductContent + "</productcontent>";

        //            // Nếu sản phẩm có biến thể thì hiển thị biến thể bên dưới...
        //            if (item.ProductStyle == 2)
        //            {
        //                xml += "<productvariable>";
                        
        //                var ProductVariable = ProductVariableController.GetProductID(item.ID);
        //                if (ProductVariable.Count > 0)
        //                {
        //                    foreach (var variable in ProductVariable)
        //                    {
        //                        xml += "<variable>";
        //                        xml += "<variable_sku>" + variable.SKU + "</variable_sku>";
        //                        xml += "<variable_regularprice>" + variable.Regular_Price + "</variable_regularprice>";
        //                        xml += "<variable_retailprice>" + variable.RetailPrice + "</variable_retailprice>";

        //                        string variable_stock = "0";
        //                        var VariableStock = ProductController.GetAllSql(0, variable.SKU);
        //                        if (VariableStock.Count() > 0)
        //                        {
        //                            foreach (var itemStock in VariableStock)
        //                            {
        //                                variable_stock = itemStock.TotalProductInstockQuantityLeft.ToString();
        //                            }
        //                        }
        //                        xml += "<variable_stock>" + variable_stock + "</variable_stock>";
        //                        xml += "<variable_manager_stock>1</variable_manager_stock>";

                                
        //                        var ProductVariableValue = ProductVariableValueController.GetByProductVariableID(variable.ID);
        //                        if (ProductVariableValue.Count > 0)
        //                        {
        //                            foreach (var variant in ProductVariableValue)
        //                            {
        //                                xml += "<" + variant.VariableName + ">" + variant.VariableValue + "</" + variant.VariableName + ">";
        //                            }
        //                        }

        //                        xml += "</variable>";

        //                    }
        //                }
                        
        //                xml += "</productvariable>";
        //            }

        //            xml += "</product>";
        //        }
        //    }
        //    HttpContext.Current.Response.Write(xml);
        //}

        public class ResponseClass
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string Code { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string Status { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string Message { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<tbl_Category> Category { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<ProductSQL> Product { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<tbl_ProductImage> ProductImage { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<tbl_ProductVariable> ProductVariable { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<tbl_ProductVariableValue> ProductVariableValue { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<StockManager> StockManager { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public tbl_Account User { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public tbl_Agent Agent { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int OrderID { get; set; }
        }
        public class ProductOrder
        {
            public int ProductType { get; set; }
            public int ID { get; set; }
            public string SKU { get; set; }
            public string ProductName { get; set; }
            public string ProductImageOrigin { get; set; }
            public string ProductVariableDescription { get; set; }
            public string ProductVariableName { get; set; }
            public string ProductVariableValue { get; set; }
            public double Quantity { get; set; }
            public double Price { get; set; }
        }

        public class StockManager
        {
            public string SKU { get; set; }
            public double Quantity { get; set; }
            public int Status { get; set; }
        }
    }
}
