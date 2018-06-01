<%@ Page Title="Thêm mới khách hàng" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="them-moi-khach-hang.aspx.cs" Inherits="IM_PJ.them_moi_khach_hang" %>

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
                            <h3 class="page-title left not-margin-bot">Thêm khách hàng</h3>
                        </div>
                        <div class="panel-body">
                            <div class="form-row">
                                <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                            </div>
                            <div class="form-row">
                                <div class="row-left">
                                    Họ tên
                                    <asp:RequiredFieldValidator ID="rq" runat="server" ControlToValidate="txtCustomerName" ForeColor="Red" SetFocusOnError="true" ErrorMessage="(*)" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <div class="row-right">
                                    <asp:TextBox ID="txtCustomerName" runat="server" CssClass="form-control" placeholder="Họ tên khách hàng"></asp:TextBox>
                                </div>
                            </div>
                              <div class="form-row">
                                <div class="row-left">
                                    Nick đặt hàng
                                </div>
                                <div class="row-right">
                                    <asp:TextBox ID="txtNick" runat="server" CssClass="form-control" placeholder="Nick đặt hàng"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="row-left">
                                    Điện thoại
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCustomerPhone" ForeColor="Red" SetFocusOnError="true" ErrorMessage="(*)" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <div class="row-right">
                                    <asp:TextBox ID="txtCustomerPhone" runat="server" CssClass="form-control" placeholder="Số điện thoại"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="row-left">
                                    Zalo
                                </div>
                                <div class="row-right">
                                    <asp:TextBox ID="txtZalo" runat="server" CssClass="form-control" placeholder="Số điện thoại Zalo"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="row-left">
                                    Facebook
                                </div>
                                <div class="row-right">
                                    <asp:TextBox ID="txtFacebook" runat="server" CssClass="form-control" placeholder="Link Facebook"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="row-left">
                                    Địa chỉ
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSupplierAddress" ForeColor="Red" SetFocusOnError="true" ErrorMessage="(*)" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <div class="row-right">
                                    <asp:TextBox ID="txtSupplierAddress" runat="server" CssClass="form-control" placeholder="Địa chỉ"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-row">
                                <div class="row-left">
                                    Email
                                </div>
                                <div class="row-right">
                                    <asp:TextBox ID="txtSupplierEmail" runat="server" CssClass="form-control" placeholder="Email"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-row">
                                <div class="row-left">
                                    Tỉnh thành
                                </div>
                                <div class="row-right">
                                    <asp:DropDownList ID="ddlProvince" runat="server" CssClass="form-control" AutoPostBack="True">
                                    </asp:DropDownList>
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
                                <div class="row-left">
                                    Ghi chú
                                </div>
                                <div class="row-right">
                                    <asp:TextBox ID="txtNote" runat="server" CssClass="form-control" placeholder="Ghi chú" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-row">
                                <asp:Button ID="btnSubmit" runat="server" CssClass="btn primary-btn fw-btn not-fullwidth" Text="Tạo mới" OnClick="btnSubmit_Click" />
                                <a href="/danh-sach-khach-hang" class="btn primary-btn fw-btn not-fullwidth">Trở về</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>