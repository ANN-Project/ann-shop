﻿<%@ Page Title="Chi tiết nhóm khách hàng" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="chi-tiet-giam-gia.aspx.cs" Inherits="IM_PJ.chi_tiet_giam_gia" %>
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
                            <h3 class="page-title left not-margin-bot">Thông tin nhóm khách hàng</h3>
                        </div>
                        <div class="panel-body">
                            <div class="form-row">
                                <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                            </div>
                            <div class="form-row">
                                <div class="row-left">
                                    Tên nhóm
                                    <asp:RequiredFieldValidator ID="rq" runat="server" ControlToValidate="txtDiscountName" ForeColor="Red" SetFocusOnError="true"
                                        ErrorMessage="(*)" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <div class="row-right">
                                    <asp:TextBox ID="txtDiscountName" runat="server" CssClass="form-control" placeholder="Tên nhóm"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="row-left">
                                    Chiết khấu mỗi cái
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="pDiscountAmount" ForeColor="Red"
                                        ErrorMessage="(*)" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                                <div class="row-right">
                                    <telerik:RadNumericTextBox runat="server" CssClass="form-control width-notfull" Skin="MetroTouch"
                                        ID="pDiscountAmount" MinValue="0" NumberFormat-GroupSizes="3" Width="100%" Value="0" NumberFormat-DecimalDigits="0">
                                    </telerik:RadNumericTextBox>
                                </div>
                            </div>
                            <div class="form-row" style="display:none">
                                <div class="row-left">
                                    Phần trăm chiết khấu
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="pDiscountAmountPercent" ForeColor="Red"
                                        ErrorMessage="(*)" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                                <div class="row-right">
                                    <telerik:RadNumericTextBox runat="server" CssClass="form-control width-notfull" Skin="MetroTouch"
                                        ID="pDiscountAmountPercent" MinValue="0" Width="100%" Value="0" NumberFormat-DecimalDigits="0">
                                    </telerik:RadNumericTextBox>
                                </div>
                            </div>
                            <div class="form-row" >
                                <div class="row-left">
                                    Phí đổi hàng mỗi cái
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="pDiscountAmountPercent" ForeColor="Red"
                                        ErrorMessage="(*)" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                                <div class="row-right">
                                    <telerik:RadNumericTextBox runat="server" CssClass="form-control width-notfull" Skin="MetroTouch"
                                        ID="rRefundGoods" MinValue="0" NumberFormat-GroupSizes="3" Width="100%" Value="0" NumberFormat-DecimalDigits="0">
                                    </telerik:RadNumericTextBox>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="row-left">
                                    Số ngày được đổi trả
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="pNumOfDateToChangeProduct" ForeColor="Red"
                                        ErrorMessage="(*)" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                                <div class="row-right">
                                    <telerik:RadNumericTextBox runat="server" CssClass="form-control width-notfull" Skin="MetroTouch"
                                        ID="pNumOfDateToChangeProduct" MinValue="0" NumberFormat-GroupSizes="3" Width="100%" NumberFormat-DecimalDigits="0">
                                    </telerik:RadNumericTextBox>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="row-left">
                                    Số lượng sản phẩm được đổi trả
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="pNumOfProductCanChange" ForeColor="Red"
                                        ErrorMessage="(*)" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                                <div class="row-right">
                                    <telerik:RadNumericTextBox runat="server" CssClass="form-control width-notfull" Skin="MetroTouch"
                                        ID="pNumOfProductCanChange" MinValue="0" NumberFormat-GroupSizes="3" Width="100%" NumberFormat-DecimalDigits="0">
                                    </telerik:RadNumericTextBox>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="row-left">
                                    Mô tả
                                </div>
                                <div class="row-right">
                                    <telerik:RadEditor runat="server" ID="pDiscountNote" Width="100%"
                                        Height="600px" ToolsFile="~/FilesResources/ToolContent.xml" Skin="Metro"
                                        DialogHandlerUrl="~/Telerik.Web.UI.DialogHandler.axd" AutoResizeHeight="False">
                                        <ImageManager ViewPaths="~/uploads/images" UploadPaths="~/uploads/images" DeletePaths="~/uploads/images" />
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
                                <asp:Button ID="btnLogin" runat="server" CssClass="btn primary-btn fw-btn not-fullwidth" Text="Cập nhật" OnClick="btnLogin_Click" />
                                <a href="/danh-sach-nhom-khach-hang" class="btn primary-btn fw-btn not-fullwidth">Trở về</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>
