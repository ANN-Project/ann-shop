<%@ Page Title="Danh sách khách hàng" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="danh-sach-khach-hang.aspx.cs" Inherits="IM_PJ.danh_sach_khach_hang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main id="main-wrap">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h3 class="page-title left">Danh sách khách hàng</h3>
                    <div class="right above-list-btn">
                        <a href="/them-moi-khach-hang" class="h45-btn btn" style="background-color: #ff3f4c">Thêm mới</a>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="filter-above-wrap clear">
                        <div class="right">
                            <div class="filter-control right">

                                <asp:TextBox ID="txtAgentName" runat="server" CssClass="form-control" placeholder="Nhập tên khách hàng/số đt/zalo/facebook để tìm"
                                    Width="210px"></asp:TextBox>

                                <asp:DropDownList ID="ddlProvince" runat="server" CssClass="form-control"></asp:DropDownList>

                              <%--  <asp:DropDownList ID="ddlDiscount" runat="server" CssClass="form-control hide"></asp:DropDownList>--%>


                                <asp:DropDownList ID="ddlCreateBy" runat="server" CssClass="form-control create hide"></asp:DropDownList>


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
                                        <%--<th>ID</th>--%>
                                        <th>Tên</th>
                                        <th>Nick</th>
                                        <th>Phone</th>
                                        <th>Zalo</th>
                                        <th>Facebook</th>
                                        <th>Tỉnh thành</th>
                                        <th>Số sản phẩm đã mua</th>
                                        <%--<th>Email</th>--%>
                                        <th>Nhân viên phục vụ</th>
                                        <th>Nhóm khách hàng</th>
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
          <asp:HiddenField ID="hdfcreate" runat="server" />
        <script type="text/javascript">
            function searchAgent() {
                $("#<%= btnSearch.ClientID%>").click();
            }
            var list = document.getElementById('<%= hdfcreate.ClientID%>').defaultValue;
            if (list == "1") {
                $(".create").removeClass("hide");
            }
        </script>
    </main>


</asp:Content>
