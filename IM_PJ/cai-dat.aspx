<%@ Page Title="Cài đặt" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="cai-dat.aspx.cs" Inherits="IM_PJ.cai_dat" %>
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
                                    <telerik:RadNumericTextBox runat="server" CssClass="form-control width-notfull" Skin="MetroTouch"
                                        ID="pNumOfDateToChangeProduct" MinValue="0" NumberFormat-GroupSizes="3" Width="100%" NumberFormat-DecimalDigits="0">
                                    </telerik:RadNumericTextBox>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="row-left">
                                    Số lượng sản phẩm được đổi trả
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="pNumOfProductCanChange" ForeColor="Red"
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
                                    Phí đổi trả
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="pFeeChangeProduct" ForeColor="Red"
                                        ErrorMessage="(*)" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                                <div class="row-right">
                                    <telerik:RadNumericTextBox runat="server" CssClass="form-control width-notfull" Skin="MetroTouch"
                                        ID="pFeeChangeProduct" MinValue="0" NumberFormat-GroupSizes="3" Width="100%" NumberFormat-DecimalDigits="0">
                                    </telerik:RadNumericTextBox>
                                </div>
                            </div>                            
                            <div class="form-row">
                                <div class="row-left">
                                    Nội quy đổi trả hàng
                                </div>
                                <div class="row-right">
                                    <telerik:RadEditor runat="server" ID="pContent" Width="100%"
                                        Height="600px" ToolsFile="~/FilesResources/ToolContent.xml" Skin="Metro"
                                        DialogHandlerUrl="~/Telerik.Web.UI.DialogHandler.axd" AutoResizeHeight="True">
                                        <ImageManager ViewPaths="~/Uploads/Images" UploadPaths="~/Uploads/Images" DeletePaths="~/Uploads/Images" />
                                    </telerik:RadEditor>
                                </div>
                            </div>
                            <div class="form-row">
                                <%--<a href="javascript:;" class="btn primary-btn fw-btn not-fullwidth" onclick="AddNewProduct()">Tạo mới sản phẩm</a>--%>
                                <asp:Button ID="btnLogin" runat="server" CssClass="btn primary-btn fw-btn not-fullwidth" Text="Cập nhật" OnClick="btnLogin_Click" />
                                <%--<a href="/quan-ly-dai-ly" class="btn primary-btn fw-btn not-fullwidth">Quay về danh sách</a>--%>
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
        <script>
            function isBlank(str) {
                return (!str || /^\s*$/.test(str));
            }
            function AddNewProduct() {
                if ($(".row-variable-selected").length > 0) {
                    var check = true;
                    var listva = "";
                    $(".row-variable-selected").each(function () {
                        var sku = $(this).find(".sku-variable").val();
                        if (!isBlank(sku)) {

                        }
                    });
                }
            }
            function addVariable() {
                var variable_selected = "";
                var valu_list = "";
                var select_count = 0;
                var current_selected = $("#<%= hdfTempVariable.ClientID%>").val();
                $(".variable-row").each(function () {
                    var v_name = $(this).find(".variable-name").attr("data-name");
                    var vl_id = $(this).find(".variable-value").val();
                    var vl_name = $(this).find(".variable-value :selected").text();

                    if (vl_id > 0) {
                        variable_selected += v_name + ":" + vl_name + ":" + vl_id + "|";
                        select_count++;
                    }
                });
                if (select_count > 0) {
                    var check = false;
                    var itemcur = current_selected.split(',');
                    if (itemcur.length - 1 > 0) {
                        for (var j = 0; j < itemcur.length - 1; j++) {
                            if (itemcur[j] == variable_selected)
                                check = true;
                        }
                    }
                    if (check == false) {
                        itemcur += variable_selected + ",";
                        $("#<%= hdfTempVariable.ClientID%>").val(itemcur);
                        var html = "";
                        var vs = variable_selected.split('|');
                        if (vs.length - 1 > 0) {
                            html += "<div class=\"row-variable-selected\">";
                            html += "   <div class=\"v-element\"><input type=\"text\" class=\"form-control sku-variable\" placeholder=\"SKU\"></div>";
                            html += "   <div class=\"v-element\"><input type=\"number\" min=\"0\" class=\"form-control stock-variable\" placeholder=\"Stock\"></div>";
                            html += "   <div class=\"v-element\"><select class=\"form-control stock-status\"><option value=\"1\">Instock</option><option value=\"2\">Out of stock</option></select></div>";
                            html += "   <div class=\"v-element\"><input type=\"number\" min=\"0\" class=\"form-control regularprice-variable\" placeholder=\"Regular Price\"></div>";
                            html += "   <div class=\"v-element\"><input type=\"number\" min=\"0\" class=\"form-control costofgood-variable\" placeholder=\"Cost Of Good\"></div>";
                            html += "   <div class=\"v-element\"><input type=\"checkbox\" class=\"form-control managestock-variable\"></div>";
                            html += "   <div class=\"v-element\"><input type=\"checkbox\" class=\"form-control managestock-variable\"></div>";
                            for (var i = 0; i < vs.length - 1; i++) {
                                var item = vs[i];
                                var item_element = item.split(':');
                                var v_name1 = item_element[0];
                                var vl_name1 = item_element[1];
                                var vl_id1 = item_element[2];
                                html += "<div class=\"v-element content-vari-value\" data-vname=\"" + v_name1 + "\" data-vl_name=\"" + vl_name1 + "\" data-vl_id=\"" + vl_id1 + "\">" + v_name1 + ": " + vl_name1 + "</div>";

                            }
                            html += "   <div class=\"v-element delete-value\"><a href=\"javascript:;\" onclick=\"deleterowva($(this))\" class=\"btn primary-btn fw-btn not-fullwidth\">Xóa</a></div>";
                            html += "</div>";
                        }
                        $(".variable-selected").append(html);
                    }


                }
                else {

                }


            }
            function deleterowva(obj) {
                var c = confirm("Bạn muốn xóa thuộc tính này?");
                if (c == true) {
                    obj.parent().parent().remove();
                    var newc = "";
                    $(".row-variable-selected").each(function () {
                        $(this).find(".content-vari-value").each(function () {
                            var vname = $(this).attr("data-vname");
                            var vl_name = $(this).attr("data-vl_name");
                            var vl_id = $(this).attr("data-vl_id");
                            newc += vname + ":" + vl_name + ":" + vl_id + "|";
                        });
                        newc += ",";
                    });
                    $("#<%=hdfTempVariable.ClientID%>").val(newc);
                }
            }
            <%--function DelRow(that, link) {

                $(that).parent().parent().remove();
                var myHidden = $("#<%= listImg.ClientID %>");
                var tempF = myHidden.value;
                myHidden.value = tempF.replace(link, '');
            }
            (function (global, undefined) {
                var textBox = null;

                function textBoxLoad(sender) {
                    textBox = sender;
                }

                function OpenFileExplorerDialog() {
                    global.radopen("/Dialogs/Dialog.aspx", "ExplorerWindow");
                }

                //This function is called from a code declared on the Explorer.aspx page
                function OnFileSelected(fileSelected) {
                    if (textBox) {
                        {
                            var myHidden = document.getElementById('<%= listImg.ClientID %>');
                            var tempF = myHidden.value;

                            tempF = tempF + '#' + fileSelected;
                            myHidden.value = tempF;

                            $('.hidImage').append('<tr><td><img height="100px" src="' + fileSelected + '"/></td><td style="text-align:center"><a class="btn btn-success" onclick="DelRow(this,\'' + fileSelected + '\')">Xóa</a></td></li>');
                            //alert(fileSelected);
                            textBox.set_value(fileSelected);
                        }
                    }
                }

                global.OpenFileExplorerDialog = OpenFileExplorerDialog;
                global.OnFileSelected = OnFileSelected;
                global.textBoxLoad = textBoxLoad;
            })(window);--%>
        </script>
    </telerik:RadCodeBlock>
</asp:Content>
