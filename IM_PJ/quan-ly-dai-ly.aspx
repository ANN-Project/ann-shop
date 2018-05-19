<%@ Page Title="Quản lý đại lý" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="quan-ly-dai-ly.aspx.cs" Inherits="IM_PJ.quan_ly_dai_ly" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main id="main-wrap">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h3 class="page-title left">Danh sách đại lý</h3>
                    <div class="right above-list-btn">
                        <a href="/them-dai-ly" class="h45-btn btn" style="background-color: #ff3f4c">Thêm mới</a>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <%--<div class="above-tab-links clear">
                        <a href="#" class="link active"><span class="txt">Tất cả</span>
                             <span class="count">(3,204)</span></a><span class="link-seperator">|</span><a href="#" class="link"><span class="txt">Đã đăng</span> <span class="count">(3,204)</span></a>
                    </div>--%>
                    <div class="filter-above-wrap clear">
                        <%-- <div class="left">
                            <div class="filter-control">
                                <select class="form-control" style="width: 210px;">
                                    <option>Tác vụ</option>
                                </select>
                                <a href="#" class="btn primary-btn h45-btn">Áp dụng</a>
                            </div>
                            <div class="filter-control">
                                <select class="form-control" style="width: 210px;">
                                    <option>Filter by category</option>
                                </select>
                                <select class="form-control" style="width: 210px;">
                                    <option>Filter by product type</option>
                                </select>
                                <a href="#" class="btn primary-btn h45-btn">Lọc</a>
                            </div>
                        </div>--%>
                        <div class="right">
                            <div class="filter-control right">
                                <asp:TextBox ID="txtAgentName" runat="server" CssClass="form-control" placeholder="Nhập tên đại lý để tìm"
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
                                        <th>Tên</th>
                                        <%--<th>Chủ đại lý</th>--%>
                                        <th>Số đt</th>
                                        <th>Địa chỉ</th>
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
        <script type="text/javascript">
            function searchAgent() {
                $("#<%= btnSearch.ClientID%>").click();
            }
        </script>
    </main>
</asp:Content>
