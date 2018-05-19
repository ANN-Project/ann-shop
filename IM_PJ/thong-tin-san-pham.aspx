<%@ Page Title="Thông tin sản phẩm" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="thong-tin-san-pham.aspx.cs" Inherits="IM_PJ.thong_tin_san_pham" %>

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
                            <h3 class="page-title left not-margin-bot">Thông tin sản phẩm</h3>
                        </div>
                        <div class="panel-body">
                            <div class="form-row">
                                <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                            </div>
                            <div class="form-row">
                                <div class="row-left">
                                    Tên sản phẩm
                                    <asp:RequiredFieldValidator ID="rq" runat="server" ControlToValidate="txtProductTitle" ForeColor="Red" SetFocusOnError="true"
                                        ErrorMessage="(*)" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <div class="row-right">
                                    <asp:TextBox ID="txtProductTitle" runat="server" CssClass="form-control" placeholder="Tên sản phẩm"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-row">
                                <div class="row-left">
                                    SKU                                    
                                </div>
                                <div class="row-right">
                                    <asp:Label ID="lblSKU" runat="server" CssClass="form-control"></asp:Label>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="row-left">
                                    Chất liệu                                    
                                </div>
                                <div class="row-right">
                                    <asp:TextBox ID="txtMaterials" runat="server" CssClass="form-control" placeholder="Chất liệu"></asp:TextBox>
                                </div>
                            </div>
                           <%-- <div class="form-row">
                                <div class="row-left">
                                    Số lượng sản phẩm
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="pProductStock" ForeColor="Red"
                                        ErrorMessage="(*)" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                                <div class="row-right">
                                    <telerik:RadNumericTextBox runat="server" CssClass="form-control width-notfull" Skin="MetroTouch"
                                        ID="pProductStock" MinValue="0" NumberFormat-GroupSizes="3" Width="100%"  NumberFormat-DecimalDigits="0">
                                    </telerik:RadNumericTextBox>
                                </div>
                            </div>--%>
                            <div class="form-row">
                                <div class="row-left">
                                    Số lượng tồn kho ít nhất
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="pMinimumInventoryLevel" ForeColor="Red"
                                        ErrorMessage="(*)" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                                <div class="row-right">
                                    <telerik:RadNumericTextBox runat="server" CssClass="form-control width-notfull" Skin="MetroTouch"
                                        ID="pMinimumInventoryLevel" MinValue="0" NumberFormat-GroupSizes="3" Width="100%"  NumberFormat-DecimalDigits="0">
                                    </telerik:RadNumericTextBox>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="row-left">
                                    Số lượng tồn kho nhiều nhất
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="pMinimumInventoryLevel" ForeColor="Red"
                                        ErrorMessage="(*)" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                                <div class="row-right">
                                    <telerik:RadNumericTextBox runat="server" CssClass="form-control width-notfull" Skin="MetroTouch"
                                        ID="pMaximumInventoryLevel" MinValue="0" NumberFormat-GroupSizes="3" Width="100%"  NumberFormat-DecimalDigits="0">
                                    </telerik:RadNumericTextBox>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="row-left">
                                    Nhà cung cấp
                                </div>
                                <div class="row-right">
                                    <asp:DropDownList ID="ddlSupplier" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                            </div>
                           <%-- <div class="form-row">
                                <div class="row-left">
                                    Trạng thái                                    
                                </div>
                                <div class="row-right">
                                    <asp:DropDownList ID="ddlStockStatus" runat="server" CssClass="form-control">
                                        <asp:ListItem Text="Còn hàng" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Hết hàng" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>--%>
                            <div class="form-row">
                                <div class="row-left">
                                    Quản lý trong kho
                                </div>
                                <div class="row-right">
                                    <asp:CheckBox ID="chkManageStock" runat="server" />
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="row-left">
                                    Giá sỉ
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="pRegular_Price" ForeColor="Red"
                                        ErrorMessage="(*)" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                                <div class="row-right">
                                    <telerik:RadNumericTextBox runat="server" CssClass="form-control width-notfull" Skin="MetroTouch"
                                        ID="pRegular_Price" MinValue="0" NumberFormat-GroupSizes="3" Width="100%" Value="0" NumberFormat-DecimalDigits="0">
                                    </telerik:RadNumericTextBox>
                                </div>
                            </div>
                            <div class="form-row cost hide">
                                <div class="row-left">
                                    Giá vốn
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="pCostOfGood" ForeColor="Red"
                                        ErrorMessage="(*)" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                                <div class="row-right">
                                    <telerik:RadNumericTextBox runat="server" CssClass="form-control width-notfull" Skin="MetroTouch"
                                        ID="pCostOfGood" MinValue="0" NumberFormat-GroupSizes="3" Width="100%" Value="0" NumberFormat-DecimalDigits="0">
                                    </telerik:RadNumericTextBox>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="row-left">
                                    Giá bán lẻ
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="pRetailPrice" ForeColor="Red"
                                        ErrorMessage="(*)" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                                <div class="row-right">
                                    <telerik:RadNumericTextBox runat="server" CssClass="form-control width-notfull" Skin="MetroTouch"
                                        ID="pRetailPrice" MinValue="0" NumberFormat-GroupSizes="3" Width="100%" Value="0" NumberFormat-DecimalDigits="0">
                                    </telerik:RadNumericTextBox>
                                </div>
                            </div>
                            <%--<div class="form-row">
                                <div class="row-left">
                                    Ảnh sản phẩm
                                </div>
                                <div class="row-right">
                                    <telerik:RadAsyncUpload Skin="Metro" runat="server" ID="hinhDaiDien" ChunkSize="0"
                                        Localization-Select="Chọn ảnh" AllowedFileExtensions=".jpeg,.jpg,.png"
                                        MultipleFileSelection="Disabled" OnClientFileSelected="OnClientFileSelected">
                                    </telerik:RadAsyncUpload>
                                    <asp:Image runat="server" ID="imgDaiDien" Width="200" />
                                    <asp:HiddenField runat="server" ID="listImg" ClientIDMode="Static" />
                                    <div class="hidImage"></div>
                                </div>
                            </div>--%>
                            <div class="form-row">
                                <div class="row-left">
                                    Nội dung
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
                                <div class="row-left">
                                    Ẩn                   
                                </div>
                                <div class="row-right">
                                    <asp:CheckBox ID="chkIsHidden" runat="server" />
                                </div>
                            </div>
                            <%-- <div class="form-row" style="border: solid 1px #ccc; padding: 10px;">
                                <div class="form-row">
                                    <h3 class="no-margin">Thuộc tính sản phẩm</h3>
                                </div>
                                <asp:Literal ID="ltrVariable" runat="server"></asp:Literal>
                                <div class="form-row">
                                    <a href="javascript:;" onclick="addVariable()" class="btn primary-btn fw-btn not-fullwidth">Thêm thuộc tính</a>
                                </div>
                                <div class="form-row variable-selected">
                                </div>
                            </div>--%>
                            <div class="form-row">
                                <%--<a href="javascript:;" class="btn primary-btn fw-btn not-fullwidth" onclick="AddNewProduct()">Tạo mới sản phẩm</a>--%>
                                <asp:Button ID="btnLogin" runat="server" CssClass="btn primary-btn fw-btn not-fullwidth" Text="Cập nhật" OnClick="btnLogin_Click" />
                                <asp:Literal ID="ltrBack" runat="server"></asp:Literal>
                                <%--<a href="/quan-ly-dai-ly" class="btn primary-btn fw-btn not-fullwidth">Quay về danh sách</a>--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:HiddenField ID="hdfTempVariable" runat="server" />
        <asp:HiddenField ID="hdfVariableFull" runat="server" />
        <asp:HiddenField ID="hdfcost" runat="server" />
    </main>

    <telerik:RadCodeBlock runat="server">
        <script src="/App_Themes/NewUI/js/jquery.min.js"></script>
        <script>
            var cost = document.getElementById('<%= hdfcost.ClientID%>').defaultValue;
            if (cost == "ok") {
                $(".cost").removeClass("hide");
            }

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
