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
                                <asp:Literal ID="ltrEdit1" runat="server"></asp:Literal>
                            </div>
                            <div class="form-row">
                                <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                            </div>
                            <div class="form-row">
                                <div class="row-left">
                                    Tên sản phẩm
                                </div>
                                <div class="row-right">
                                    <asp:Label ID="lbProductTitle" runat="server" CssClass="form-control"></asp:Label>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="row-left">
                                    Danh mục
                                </div>
                                <div class="row-right parent">
                                    <asp:DropDownList ID="ddlCategory" Enabled="false" runat="server" CssClass="form-control slparent" date-name="parentID" data-level="1" onchange="chooseParent($(this))">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="row-left">
                                    Mã sản phẩm
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
                                    <asp:Label ID="lbMaterials" runat="server" CssClass="form-control"></asp:Label>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="row-left">
                                    Số lượng
                                </div>
                                <div class="row-right">
                                    <asp:Label ID="lbProductStock" runat="server" CssClass="form-control"></asp:Label>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="row-left">
                                    Tồn kho ít nhất
                                </div>
                                <div class="row-right">
                                    <asp:Label ID="lbpMinimumInventoryLevel" runat="server" CssClass="form-control"></asp:Label>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="row-left">
                                    Tồn kho nhiều nhất
                                </div>
                                <div class="row-right">
                                    <asp:Label ID="lbpMaximumInventoryLevel" runat="server" CssClass="form-control"></asp:Label>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="row-left">
                                    Nhà cung cấp
                                </div>
                                <div class="row-right">
                                    <asp:DropDownList ID="ddlSupplier" runat="server" CssClass="form-control" Enabled="False">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="row-left">
                                    Trạng thái                                    
                                </div>
                                <div class="row-right">
                                    <asp:DropDownList ID="ddlStockStatus" runat="server" CssClass="form-control" Enabled="False">
                                        <asp:ListItem Text="Còn hàng" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Hết hàng" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Đang nhập hàng" Value="3"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="row-left">
                                    Giá sỉ
                                </div>
                                <div class="row-right">
                                    <asp:Label ID="lbRegularPrice" runat="server" CssClass="form-control"></asp:Label>
                                </div>
                            </div>
                             <div class="form-row cost hide">
                                <div class="row-left">
                                    Giá vốn
                                </div>
                                <div class="row-right">
                                    <asp:Label ID="lbpCostOfGood" runat="server" CssClass="form-control"></asp:Label>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="row-left">
                                    Giá lẻ
                                </div>
                                <div class="row-right">
                                    <asp:Label ID="lbRetailPrice" runat="server" CssClass="form-control"></asp:Label>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="row-left">
                                    Ảnh đại diện
                                </div>
                                <div class="row-right">
                                    <asp:Image runat="server" ID="ProductThumbnail" Width="200" />
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="row-left">
                                    Nội dung
                                </div>
                                <div class="row-right">
                                    <div class="content-box">
                                        <asp:Literal ID="pContent" runat="server"></asp:Literal>
                                    </div>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="row-left">
                                    Thư viện ảnh
                                </div>
                                <div class="row-right">
                                    <asp:Literal ID="imageGallery" runat="server"></asp:Literal>
                                </div>
                            </div>
                            <div class="form-row">
                                <asp:Literal ID="ltrEdit2" runat="server"></asp:Literal>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row tableview hide">
                <div class="col-md-12">
                    <div class="panel-table clear">
                        <div class="responsive-table">
                            <table class="table table-checkable table-product all-product-table">
                                <tbody>
                                    <tr>
                                        <th class="image-column">Ảnh</th>
                                        <th class="variable-column">Thuộc tính</th>
                                        <th class="sku-column">Mã</th>
                                        <th class="wholesale-price-column">Giá sỉ</th>
                                        <th class="cost-price-column cost hide">Giá vốn</th>
                                        <th class="retail-price-column">Giá lẻ</th>
                                        <th class="stock-column">Kho</th>
                                        <th class="stock-status-column">Trạng thái</th>
                                        <th class="date-column">Ngày tạo</th>
                                        <th class="hide-column">Ẩn</th>
                                        <th class="action-column">Thao tác</th>
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
