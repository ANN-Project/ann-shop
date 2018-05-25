﻿using Bnails.Bussiness;
using IM_PJ.Controllers;
using IM_PJ.Models;
using MB.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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
                        CustomerEmail, TotalPrice.ToString(), TotalPrice.ToString(), PaymentStatus, ExcuteStatus, IsHidden, Wayin, currentDate, CreatedBy, 0, 0, "0",0,0,DateTime.Now.ToString(),0,0);
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
                                    InOutProductVariableController.Insert(AgentID, ProductID, 0, "", "", Quantity, 0, 2, false, 1, "", OrderID,
                                        0, 3, ProductName, SKU, ProductImageOrigin, ProductVariableSave, currentDate, CreatedBy, 0, ProductID);
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
                                    InOutProductVariableController.Insert(AgentID, 0, ProductVariableID, ProductVariableName, ProductVariableValue, Quantity, 0, 2,
                                        false, 2, "", OrderID, 0, 3, ProductName, SKU, ProductImageOrigin, ProductVariableSave, currentDate, CreatedBy, 0, parentID);
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
                        amount, totalDiscount, FeeShipping.ToString(), PaymentType, ShippingType,DateTime.Now.ToString(),0,0);
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
                        InOutProductVariableController.Insert(AgentID, ProductID, 0, "", "", Quantity, 0, 2, false, 1, "", OrderID,
                            0, 3, ProductName, SKU, ProductImageOrigin, ProductVariableSave, currentDate, CreatedBy, 0, ProductID);
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
                        InOutProductVariableController.Insert(AgentID, 0, ProductVariableID, ProductVariableName, ProductVariableValue, Quantity, 0, 2,
                            false, 2, "", OrderID, 0, 3, ProductName, SKU, ProductImageOrigin, ProductVariableSave, currentDate, CreatedBy, 0, parentID);
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
    }
}
