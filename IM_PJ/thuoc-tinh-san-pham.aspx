<%@ Page Title="Thuộc tính sản phẩm" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="thuoc-tinh-san-pham.aspx.cs" Inherits="IM_PJ.thuoc_tinh_san_pham" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main id="main-wrap">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h3 class="page-title left">
                        <asp:Label ID="lblCategoryName" runat="server"></asp:Label></h3>
                    <div class="right above-list-btn">
                        <asp:Literal ID="ltrBack" runat="server"></asp:Literal>
                        <asp:Literal ID="ltrAddnew" runat="server"></asp:Literal>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="filter-above-wrap clear">
                        <div class="right">
                            <div class="filter-control right" style="display: inline-flex">
                                <%--  <asp:DropDownList ID="ddlSize" runat="server" CssClass="form-control size hide"></asp:DropDownList>
                                 <asp:DropDownList ID="ddlColor" runat="server" CssClass="form-control color hide"></asp:DropDownList>
                                 <asp:DropDownList ID="ddlForm" runat="server" CssClass="form-control form hide"></asp:DropDownList>--%>
                                <asp:TextBox ID="txtAgentName" runat="server" CssClass="form-control" placeholder="Nhập SKU để tìm"
                                    Width="210px"></asp:TextBox>
                                <a href="javascript:;" onclick="searchAgent()" class="btn primary-btn h45-btn"><i class="fa fa-search"></i></a>
                                <asp:Button ID="btnSearch" runat="server" CssClass="btn primary-btn h45-btn" OnClick="btnSearch_Click" Style="display: none" />
                            </div>
                        </div>
                    </div>
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
                                        <th>Ẩn</th>
                                        <th>Thao tác</th>
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
        <asp:HiddenField ID="hdfcost" runat="server" />
        <asp:HiddenField ID="hdfSearch" runat="server" />
        <script type="text/javascript">
            function searchAgent() {
                $("#<%= btnSearch.ClientID%>").click();
            }


            var cost = document.getElementById('<%= hdfcost.ClientID%>').defaultValue;
            if (cost == "ok") {
                $(".cost").removeClass("hide");
            }
         <%--   var search = document.getElementById('<%= hdfSearch.ClientID%>').defaultValue;
            var list = search.split('|');
            for (var i = 0; i < list.length - 1; i++) {
                if (list[i] == "Color")
                {
                    $(".color").removeClass("hide").addClass("show");
                }
                if (list[i] == "Size")
                {
                    $(".size").show();
                }
                if (list[i] == "Mẫu")
                {
                    $("form").show();
                }
            }--%>
            //alert(list);
        </script>


    </main>

</asp:Content>
