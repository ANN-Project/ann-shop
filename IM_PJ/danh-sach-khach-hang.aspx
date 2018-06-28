<%@ Page Title="Danh sách khách hàng" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="danh-sach-khach-hang.aspx.cs" Inherits="IM_PJ.danh_sach_khach_hang" EnableSessionState="ReadOnly" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main id="main-wrap">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h3 class="page-title left">Danh sách khách hàng</h3>
                    <div class="right above-list-btn">
                        <a href="/them-moi-khach-hang" class="h45-btn primary-btn btn">Thêm mới</a>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="filter-above-wrap clear">
                        <div class="filter-control">
                            <div class="row">
                                <div class="col-md-5">
                                    <asp:TextBox ID="txtAgentName" runat="server" CssClass="form-control" placeholder="Tìm khách hàng" autocomplete="off"></asp:TextBox>
                                </div>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="ddlProvince" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="ddlCreateBy" runat="server" CssClass="form-control create"></asp:DropDownList>
                                </div>
                                <div class="col-md-1">
                                    <a href="javascript:;" onclick="searchAgent()" class="btn primary-btn h45-btn"><i class="fa fa-search"></i></a>
                                    <asp:Button ID="btnSearch" runat="server" CssClass="btn primary-btn h45-btn" OnClick="btnSearch_Click" Style="display: none" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel-table clear">
                        <div class="panel-footer clear">
                            <div class="pagination">
                                <%this.DisplayHtmlStringPaging1();%>
                            </div>
                        </div>
                        <div class="responsive-table">
                            <table class="table table-checkable table-product table-customer">
                                <tbody>
                                    <tr>
                                        <th class="image-column">Ảnh</th>
                                        <th class="name-column">Họ tên</th>
                                        <th class="nick-column">Nick</th>
                                        <th class="phone-column">Điện thoại</th>
                                        <th class="zalo-column">Zalo</th>
                                        <th class="facebook-column">FB</th>
                                        <th class="province-column">Tỉnh</th>
                                        <th class="buy-column">Đã mua</th>
                                        <th class="staff-column">Nhân viên</th>
                                        <th class="group-column">Nhóm</th>
                                        <th class="date-column">Ngày tạo</th>
                                        <th class="action-column"></th>
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
        </script>
    </main>
</asp:Content>
