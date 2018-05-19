<%@ Page Title="Tất cả sản phẩm" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="tat-ca-san-pham.aspx.cs" Inherits="IM_PJ.tat_ca_san_pham" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main id="main-wrap">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h3 class="page-title left">Danh sách sản phẩm</h3>
                    <div class="right above-list-btn">
                        <asp:Literal ID="ltrBack" runat="server"></asp:Literal>
                        <a href="/tao-san-pham" class="h45-btn btn" style="background-color: #ff3f4c">Thêm mới</a>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="filter-above-wrap clear">
                        <div style="float: right!important">
                            <div class="filter-control right">
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtAgentName" runat="server" CssClass="form-control" placeholder="Nhập tên sản phẩm hoặc SKU để tìm"
                                        Width=""></asp:TextBox>

                                </div>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="0" Text="Tất cả"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Còn hàng"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Hết hàng"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="Đang chờ nhập hàng"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-1">
                                    <a href="javascript:;" onclick="searchAgent()" class="btn primary-btn h45-btn"><i class="fa fa-search"></i></a>
                                    <asp:Button ID="btnSearch" runat="server" CssClass="btn primary-btn h45-btn" OnClick="btnSearch_Click" Style="display: none" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel-footer clear" style="height: 55px; padding: 0px 15px;">
                        <div class="pagination">
                            <%this.DisplayHtmlStringPaging1();%>
                        </div>
                    </div>
                    <div class="panel-table clear">
                        <div class="responsive-table">
                            <table class="table table-checkable table-product">
                                <tbody>
                                    <tr>
                                        <th>Ảnh</th>
                                        <th>Tên sản phẩm</th>
                                        <th>SKU</th>
                                        <th>Giá sỉ</th>
                                        <th class="cost hide">Giá vốn</th> 
                                        <th>Giá bán lẻ</th>
                                        <th>Số lượng</th>
                                        <th>Kho</th>
                                        <th>Danh mục</th>
                                        <th>Ngày tạo</th>
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
        <script type="text/javascript">
            function searchAgent() {
                $("#<%= btnSearch.ClientID%>").click();
            }

            var cost = document.getElementById('<%= hdfcost.ClientID%>').defaultValue;
            if (cost == "ok")
            {
                $(".cost").removeClass("hide");
            }
        </script>
    </main>
</asp:Content>
