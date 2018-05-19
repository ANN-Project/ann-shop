<%@ Page Language="C#" Title="Xem sản phẩm" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="xem-san-pham.aspx.cs" Inherits="IM_PJ.xem_san_pham" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main id="main-wrap">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panelborderheading">
                        <div class="panel-heading clear">
                            <h3 class="page-title left not-margin-bot">Thông tin sản phẩm</h3>
                        </div>
                        <div class="panel-body">
                            <div class="form-row">
                                <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                            </div>
                            <div class="form-row">
                                <div class="row-left">
                                    Tên sản phẩm
                                    <asp:RequiredFieldValidator ID="rq" runat="server" ControlToValidate="txtProductTitle" ForeColor="Red" SetFocusOnError="true"
                                        ErrorMessage="(*)" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <div class="row-right">
                                    <asp:TextBox ID="txtProductTitle" Enabled="false" runat="server" CssClass="form-control" placeholder="Tên sản phẩm"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-row">
                                <div class="row-left">
                                    SKU                                    
                                </div>
                                <div class="row-right">
                                    <asp:Label ID="lblSKU" runat="server" CssClass="form-control"></asp:Label>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="row-left">
                                    Chất liệu                                    
                                </div>
                                <div class="row-right">
                                    <asp:TextBox ID="txtMaterials" runat="server" Enabled="false" CssClass="form-control" placeholder="Chất liệu"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="row-left">
                                    Số lượng sản phẩm
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="pProductStock" ForeColor="Red"
                                        ErrorMessage="(*)" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                                <div class="row-right">
                                    <telerik:RadNumericTextBox runat="server" CssClass="form-control width-notfull" Skin="MetroTouch"
                                        ID="pProductStock" Enabled="false" MinValue="0" NumberFormat-GroupSizes="3" Width="100%" NumberFormat-DecimalDigits="0">
                                    </telerik:RadNumericTextBox>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="row-left">
                                    Số lượng tồn kho ít nhất
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="pMinimumInventoryLevel" ForeColor="Red"
                                        ErrorMessage="(*)" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                                <div class="row-right">
                                    <telerik:RadNumericTextBox runat="server" CssClass="form-control width-notfull" Skin="MetroTouch"
                                        ID="pMinimumInventoryLevel" Enabled="false" MinValue="0" NumberFormat-GroupSizes="3" Width="100%" NumberFormat-DecimalDigits="0">
                                    </telerik:RadNumericTextBox>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="row-left">
                                    Số lượng tồn kho nhiều nhất
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="pMinimumInventoryLevel" ForeColor="Red"
                                        ErrorMessage="(*)" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                                <div class="row-right">
                                    <telerik:RadNumericTextBox runat="server" CssClass="form-control width-notfull" Skin="MetroTouch"
                                        ID="pMaximumInventoryLevel" Enabled="false" MinValue="0" NumberFormat-GroupSizes="3" Width="100%" NumberFormat-DecimalDigits="0">
                                    </telerik:RadNumericTextBox>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="row-left">
                                    Nhà cung cấp
                                </div>
                                <div class="row-right">
                                    <asp:DropDownList ID="ddlSupplier" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="row-left">
                                    Trạng thái                                    
                                </div>
                                <div class="row-right">
                                    <asp:DropDownList ID="ddlStockStatus" runat="server" CssClass="form-control">
                                        <asp:ListItem Text="Còn hàng" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Hết hàng" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="row-left">
                                    Quản lý trong kho
                                </div>
                                <div class="row-right">
                                    <asp:CheckBox ID="chkManageStock" runat="server" />
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="row-left">
                                    Giá sỉ
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="pRegular_Price" ForeColor="Red"
                                        ErrorMessage="(*)" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                                <div class="row-right">
                                    <telerik:RadNumericTextBox runat="server" CssClass="form-control width-notfull" Skin="MetroTouch"
                                        ID="pRegular_Price" MinValue="0" Enabled="false" NumberFormat-GroupSizes="3" Width="100%" Value="0" NumberFormat-DecimalDigits="0">
                                    </telerik:RadNumericTextBox>
                                </div>
                            </div>
                             <div class="form-row cost hide">
                                <div class="row-left">
                                    Giá vốn
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="pCostOfGood" ForeColor="Red"
                                        ErrorMessage="(*)" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                                <div class="row-right">
                                    <telerik:RadNumericTextBox runat="server" CssClass="form-control width-notfull" Skin="MetroTouch"
                                        ID="pCostOfGood" MinValue="0" Enabled="false" NumberFormat-GroupSizes="3" Width="100%" Value="0" NumberFormat-DecimalDigits="0">
                                    </telerik:RadNumericTextBox>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="row-left">
                                    Giá bán lẻ
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="pRetailPrice" ForeColor="Red"
                                        ErrorMessage="(*)" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                                <div class="row-right">
                                    <telerik:RadNumericTextBox runat="server" CssClass="form-control width-notfull" Skin="MetroTouch"
                                        ID="pRetailPrice" MinValue="0" Enabled="false" NumberFormat-GroupSizes="3" Width="100%" Value="0" NumberFormat-DecimalDigits="0">
                                    </telerik:RadNumericTextBox>
                                </div>
                            </div>

                            <%-- <div class="form-row">
                                <div class="row-left">
                                    Màu
                                </div>
                                <div class="row-right">
                                    <input class="form-control" />
                                </div>
                            </div>--%>

                            <div class="form-row">
                                <div class="row-left">
                                    Nội dung
                                </div>
                                <div class="row-right">
                                    <telerik:RadEditor runat="server" ID="pContent" Width="100%"
                                        Height="600px" ToolsFile="~/FilesResources/ToolContent.xml" Skin="Metro"
                                        DialogHandlerUrl="~/Telerik.Web.UI.DialogHandler.axd" AutoResizeHeight="True">
                                        <ImageManager ViewPaths="~/Uploads/Images" UploadPaths="~/Uploads/Images" DeletePaths="~/Uploads/Images" />
                                    </telerik:RadEditor>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="row-left">
                                    Ẩn                   
                                </div>
                                <div class="row-right">
                                    <asp:CheckBox ID="chkIsHidden" runat="server" />
                                </div>
                            </div>

                            <div class="form-row">
                                <%--<a href="javascript:;" class="btn primary-btn fw-btn not-fullwidth" onclick="AddNewProduct()">Tạo mới sản phẩm</a>--%>
                                <asp:Literal ID="ltrBack" runat="server"></asp:Literal>
                                <asp:Literal ID="ltrEdit" runat="server"></asp:Literal>
                                <%--<a href="/quan-ly-dai-ly" class="btn primary-btn fw-btn not-fullwidth">Quay về danh sách</a>--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row tableview hide">
                <div class="panel-table clear">
                    <div class="responsive-table">
                        <table class="table table-checkable table-product">
                            <tbody>
                                <tr>
                                    <th>Ảnh</th>
                                    <th>SKU</th>
                                    <th>Giá sỉ</th>
                                    <th class="cost hide">Giá vốn</th>
                                    <th>Giá lẻ</th>
                                    <th>Thuộc tính</th>
                                    <th>Kho</th>
                                    <th>Trạng thái</th>
                                    <th>Ngày tạo</th>
                                </tr>
                                <asp:Literal ID="ltrList" runat="server" EnableViewState="false"></asp:Literal>
                            </tbody>
                        </table>
                    </div>
                    <div class="panel-footer clear">
                        <div class="pagination">
                            <%this.DisplayHtmlStringPaging1();%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:HiddenField ID="hdfTempVariable" runat="server" />
        <asp:HiddenField ID="hdfVariableFull" runat="server" />
        <asp:HiddenField ID="hdfTable" runat="server" />
        <asp:HiddenField ID="hdfcost" runat="server" />
    </main>

    <telerik:RadCodeBlock runat="server">
        <script src="/App_Themes/NewUI/js/jquery.min.js"></script>
        <script>
            var bt = document.getElementById('<%= hdfTable.ClientID%>').defaultValue;
            if (bt == "2") {
                $(".tableview").removeClass('hide').add('show');
            }

            var cost = document.getElementById('<%= hdfcost.ClientID%>').defaultValue;
            if (cost == "ok") {
                $(".cost").removeClass("hide");
            }
        </script>
    </telerik:RadCodeBlock>
</asp:Content>
