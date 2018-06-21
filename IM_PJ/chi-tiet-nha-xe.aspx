<%@ Page Title="Danh sách nhà xe" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="chi-tiet-nha-xe.aspx.cs" Inherits="IM_PJ.chi_tiet_nha_xe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main id="main-wrap">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h3 class="page-title left">Danh sách nhà xe</h3>
                    <div class="right above-list-btn">
                        <a href="/them-moi-noi-den-nha-xe/?id=<%=hdfID.Value%>" class="h45-btn primary-btn btn">Thêm nơi nhận</a>
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="form-row">
                        <div class="row-left">
                            Tên nhà xe
                        </div>
                        <div class="row-right">
                            <asp:TextBox ID="txtCompanyName" runat="server" CssClass="form-control" Enabled="false" TabIndex="1"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="row-left">
                            Điện thoại
                        </div>
                        <div class="row-right">
                            <asp:TextBox ID="txtCompanyPhone" runat="server" CssClass="form-control" Enabled="false" TabIndex="2"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="row-left">
                            Địa chỉ chành xe gửi ở TPHCM
                        </div>
                        <div class="row-right">
                            <asp:TextBox ID="txtCompanyAddress" runat="server" CssClass="form-control" Enabled="false" TabIndex="3"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-12">
                    <div class="panel-table clear">
                        <div class="responsive-table">
                            <table class="table table-checkable table-product" tabindex="4">
                                <tbody>
                                    <tr>
                                        <th>#</th>
                                        <th>Nơi nhận</th>
                                        <th>Địa chỉ chành</th>
                                        <th>Trả cước trước</th>
                                        <th>Thu hộ</th>
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
            <br />
            <div class="row">
                <div class="col-md-12">
                    <div class="form-row">
                        <a href="/danh-sach-nha-xe" class="btn primary-btn fw-btn not-fullwidth" tabindex="10">Trở về</a>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="hdfID" runat="server" />
        </div>
    </main>

</asp:Content>
