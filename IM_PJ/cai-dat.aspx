<%@ Page Title="Cài đặt hệ thống" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="cai-dat.aspx.cs" Inherits="IM_PJ.cai_dat" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main id="main-wrap">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panelborderheading">
                        <div class="panel-heading clear">
                            <h3 class="page-title left not-margin-bot">Cài đặt hệ thống</h3>
                        </div>
                        <div class="panel-body">
                            <div class="form-row">
                                <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                            </div>
                           
                            <div class="form-row">
                                <div class="row-left">
                                    Số ngày được đổi trả
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="pNumOfDateToChangeProduct" ForeColor="Red"
                                        ErrorMessage="(*)" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                                <div class="row-right">
                                    <telerik:RadNumericTextBox runat="server" CssClass="form-control width-notfull" Skin="MetroTouch" ID="pNumOfDateToChangeProduct" MinValue="0" NumberFormat-GroupSizes="3" Width="100%" NumberFormat-DecimalDigits="0">
                                    </telerik:RadNumericTextBox>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="row-left">
                                    Số lượng sản phẩm được đổi trả
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="pNumOfProductCanChange" ForeColor="Red" ErrorMessage="(*)" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                                <div class="row-right">
                                    <telerik:RadNumericTextBox runat="server" CssClass="form-control width-notfull" Skin="MetroTouch" ID="pNumOfProductCanChange" MinValue="0" NumberFormat-GroupSizes="3" Width="100%" NumberFormat-DecimalDigits="0">
                                    </telerik:RadNumericTextBox>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="row-left">
                                    Phí đổi trả
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="pFeeChangeProduct" ForeColor="Red" ErrorMessage="(*)" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                                <div class="row-right">
                                    <telerik:RadNumericTextBox runat="server" CssClass="form-control width-notfull" Skin="MetroTouch" ID="pFeeChangeProduct" MinValue="0" NumberFormat-GroupSizes="3" Width="100%" NumberFormat-DecimalDigits="0">
                                    </telerik:RadNumericTextBox>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="row-left">
                                    Nội quy đổi trả hàng
                                </div>
                                <div class="row-right">
                                    <telerik:RadEditor runat="server" ID="pContent" Width="100%" Height="600px" ToolsFile="~/FilesResources/ToolContent.xml" Skin="Metro" DialogHandlerUrl="~/Telerik.Web.UI.DialogHandler.axd" AutoResizeHeight="True">
                                        <ImageManager ViewPaths="~/Uploads/Images" UploadPaths="~/Uploads/Images" DeletePaths="~/Uploads/Images" />
                                    </telerik:RadEditor>
                                </div>
                            </div>
                            <div class="form-row">
                                <asp:Button ID="btnLogin" runat="server" CssClass="btn primary-btn fw-btn not-fullwidth" Text="Cập nhật" OnClick="btnLogin_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:HiddenField ID="hdfTempVariable" runat="server" />
        <asp:HiddenField ID="hdfVariableFull" runat="server" />
    </main>

    <telerik:RadCodeBlock runat="server">
        <script src="/App_Themes/NewUI/js/jquery.min.js"></script>
    </telerik:RadCodeBlock>
</asp:Content>
