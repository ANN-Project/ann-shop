<%@ Page Title="Tạo sản phẩm" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="tao-san-pham.aspx.cs" Inherits="IM_PJ.tao_san_pham" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .variableselect {
            float: left;
            width: 100%;
            clear: both;
            margin: 10px 0;
        }

        .variable-select {
            float: left;
            width: 30%;
            margin-bottom: 10px;
            border: solid 1px #4a4a4a;
            margin-left: 10px;
        }

            .variable-select .variablename {
                float: left;
                width: 100%;
                margin-right: 10px;
                background: blue;
                color: #fff;
                text-align: center;
                padding: 10px 0;
                line-height: 40px;
            }

            .variable-select .variablevalue {
                float: left;
                width: 100%;
                padding: 10px;
            }

                .variable-select .variablevalue .variablevalue-item {
                    float: left;
                    width: 100%;
                    clear: both;
                    margin-bottom: 10px;
                    border-bottom: solid 1px #ccc;
                    padding-bottom: 5px;
                }

                    .variable-select .variablevalue .variablevalue-item:last-child {
                        border: none;
                    }

                    .variable-select .variablevalue .variablevalue-item .v-value {
                        float: left;
                        width: 78%;
                        line-height: 40px;
                    }

                    .variable-select .variablevalue .variablevalue-item .v-delete {
                        float: left;
                        width: 20%;
                    }

        #selectvariabletitle {
            float: left;
            width: 70%;
            clear: both;
            font-weight: bold;
            margin: 20px 0;
            display: none;
        }

        #generateVariable {
            float: right;
            display: block;
        }

        .width {
            width: calc(100% - 100px);
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main id="main-wrap">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panelborderheading">
                        <div class="panel-heading clear">
                            <h3 class="page-title left not-margin-bot">Thêm sản phẩm</h3>
                        </div>
                        <div class="panel-body">
                            <div class="form-row">
                                <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                            </div>

                            <div class="form-row">
                                <div class="row-left">
                                    Danh mục
                                </div>
                                <div class="row-right parent">
                                    <select id="ddlCategory" date-name="parentID" style="margin-bottom: 15px;" runat="server" class="form-control slparent" data-level="1" onchange="chooseParent($(this))"></select>
                                </div>
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
                                    Mã sản phẩm
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtProductSKU" ForeColor="Red" ErrorMessage="(*)" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                                <div class="row-right" style="display: inline-flex">
                                    <asp:TextBox ID="txtProductSKU" runat="server" CssClass="form-control" onblur="CheckSKU()" placeholder="SKU"></asp:TextBox>
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

                            <div class="form-row">
                                <div class="row-left">
                                    Loại sản phẩm
                                </div>
                                <div class="row-right">
                                    <select id="ddlProductStyle" class="form-control" onchange="choosetype()">
                                        <option value="1">Đơn giản</option>
                                        <option value="2">Có biến thể</option>
                                    </select>
                                </div>
                            </div>

                            <div class="form-row" id="Minimum">
                                <div class="row-left">
                                    Tồn kho ít nhất
                                </div>
                                <div class="row-right">
                                    <asp:TextBox type="number" min="0" ID="pMinimumInventoryLevel" runat="server" CssClass="form-control" placeholder="Số lượng tồn kho ít nhất"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-row" id="Maximum">
                                <div class="row-left">
                                    Tồn kho nhiều nhất
                                </div>
                                <div class="row-right">
                                    <asp:TextBox type="number" min="0" ID="pMaximumInventoryLevel" runat="server" CssClass="form-control" placeholder="Số lượng tồn kho nhiều nhất"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-row" id="ManageStock">
                                <div class="row-left">
                                    Quản lý kho
                                </div>
                                <div class="row-right">
                                    <asp:CheckBox ID="chkManageStock" runat="server" Checked="true" />
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
                            <div class="form-row">
                                <div class="row-left">
                                    Giá sỉ
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="pRegular_Price" ForeColor="Red" ErrorMessage="(*)" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                                <div class="row-right">
                                    <asp:TextBox type="number" min="0" ID="pRegular_Price" runat="server" CssClass="form-control" placeholder="Giá sỉ"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="row-left">
                                    Giá vốn
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="pCostOfGood" ForeColor="Red" ErrorMessage="(*)" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                                <div class="row-right">
                                    <asp:TextBox type="number" min="0" ID="pCostOfGood" runat="server" CssClass="form-control" placeholder="Giá vốn"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="row-left">
                                    Giá lẻ
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="pRetailPrice" ForeColor="Red" ErrorMessage="(*)" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </div>
                                <div class="row-right">
                                    <asp:TextBox type="number" min="0" ID="pRetailPrice" runat="server" CssClass="form-control" placeholder="Giá lẻ"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="row-left">
                                    Ảnh sản phẩm
                                </div>
                                <div class="row-right">
                                    <telerik:RadAsyncUpload Skin="Metro" runat="server" ID="hinhDaiDien" ChunkSize="0"
                                        Localization-Select="Chọn ảnh" AllowedFileExtensions=".jpeg,.jpg,.png"
                                        MultipleFileSelection="Automatic" OnClientFileSelected="OnClientFileSelected1">
                                    </telerik:RadAsyncUpload>
                                    <asp:Image runat="server" ID="imgDaiDien" Width="200" />
                                    <asp:HiddenField runat="server" ID="listImg" ClientIDMode="Static" />
                                    <div class="hidImage"></div>
                                </div>
                            </div>
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
                            <div class="form-row variable" style="display: none">
                                <div class="row-left">
                                    Thuộc tính
                                </div>
                                <div class="row-right">
                                    <asp:UpdatePanel ID="up" runat="server">
                                        <ContentTemplate>
                                            <div style="float: left; width: 30%; margin-left: 10px;">
                                                <asp:DropDownList runat="server" ID="ddlVariablename" CssClass="form-control" DataTextField="VariableName"
                                                    DataValueField="ID" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddlVariablename_SelectedIndexChanged" />
                                            </div>
                                            <div style="float: left; width: 30%; margin-left: 10px;">
                                                <asp:DropDownList runat="server" ID="ddlVariableValue" CssClass="form-control" DataTextField="VariableValue"
                                                    DataValueField="ID" AppendDataBoundItems="True" AutoPostBack="True" />
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <div style="float: left; width: 30%; margin-left: 10px;">
                                        <a href="javascript:;" onclick="chooseVariable()" class="btn primary-btn fw-btn not-fullwidth">Chọn</a>
                                    </div>

                                    <div class="variableselect" style="float: left; width: 100%">
                                        <span id="selectvariabletitle">Các thuộc tính đã chọn: 
                                            <a href="javascript:;" onclick="generateVariable()" id="generateVariable" class="btn primary-btn fw-btn not-fullwidth">Thiết lập thuộc tính</a></span>
                                    </div>
                                    <div class="numbertype" style="float: left; width: 100%; display: none">
                                        <span id="settype">Thêm nhanh: 
                                           
                                        </span>
                                        <br />
                                        <div class="form-row">
                                            <div class="row-left">
                                                Tồn kho nhiều nhất:
                                            </div>
                                            <div class="row-right">
                                                <input class="form-control maxquantity" type="text" value="0" />
                                            </div>
                                        </div>
                                        <div class="form-row">
                                            <div class="row-left">
                                                Tồn kho ít nhất:
                                            </div>
                                            <div class="row-right">
                                                <input class="form-control miniquantity" type="text" value="0" />
                                            </div>
                                        </div>
                                        <div class="form-row">
                                            <div class="row-left">
                                                <a href="javascript:;" onclick="setMax()" id="setMax"
                                                    class="btn primary-btn fw-btn not-fullwidth">Thêm</a>
                                            </div>
                                        </div>
                                    </div>
                                    <style>
                                        .generat-variable-content {
                                            float: left;
                                            width: 100%;
                                            margin: 20px 0;
                                            display: none;
                                        }

                                            .generat-variable-content .item-var-gen {
                                                float: left;
                                                width: 100%;
                                                margin: 20px 0;
                                                border: dotted 1px #ccc;
                                                padding: 20px;
                                            }
                                    </style>
                                    <div class="generat-variable-content">
                                        <div class="row">
                                            <div class="col-md-10">
                                                <h3>Danh sách thuộc tính sản phẩm</h3>
                                            </div>
                                            <div class="col-md-2 delete" style="display: none;">
                                                <a href="javascript:;" onclick="deleteAll()" id="delete"
                                                    class="btn primary-btn fw-btn not-fullwidth">Xóa</a>
                                            </div>
                                        </div>
                                        <div class="list-item-genred">
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="form-row">
                                <a href="javascript:;" class="btn primary-btn fw-btn not-fullwidth" onclick="addNewProduct()">Tạo mới</a>
                                <asp:Button ID="btnLogin" runat="server" CssClass="btn primary-btn fw-btn not-fullwidth" Text="Tạo mới" OnClick="btnLogin_Click" Style="display: none" />
                                <asp:Literal ID="ltrBack" runat="server"></asp:Literal>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:HiddenField ID="hdfTempVariable" runat="server" />
        <asp:HiddenField ID="hdfVariableFull" runat="server" />
        <asp:HiddenField ID="hdfVariableListInsert" runat="server" />
        <asp:HiddenField ID="hdfGiasi" runat="server" />
        <asp:HiddenField ID="hdfsetStyle" runat="server" />
        <asp:HiddenField ID="hdfMaximum" runat="server" />
        <asp:HiddenField ID="hdfMinimum" runat="server" />
        <asp:HiddenField ID="hdfParentID" runat="server" />
    </main>

    <telerik:RadCodeBlock runat="server">
        <script src="/App_Themes/NewUI/js/jquery.min.js"></script>
        <script type="text/javascript">
            function chooseVariable() {
                var vName = $("#<%=ddlVariablename.ClientID%> option:selected").val();
                var vName_text = $("#<%=ddlVariablename.ClientID%> option:selected").text();
                var vValue = $("#<%=ddlVariableValue.ClientID%> option:selected").val();
                var vValue_text = $("#<%=ddlVariableValue.ClientID%> option:selected").text();
                if (vName != 0) {
                    if (vValue != 0) {
                        if ($(".variable-select").length > 0) {
                            var isExistParent = false;
                            $(".variable-select").each(function () {
                                var currentVname1 = $(this).attr("data-id");
                                if (currentVname1 == vName) {
                                    isExistParent = true;
                                }
                            });
                            if (isExistParent == true) {
                                $(".variable-select").each(function () {
                                    var currentVname = $(this).attr("data-id");
                                    if (currentVname == vName) {
                                        var vValueContentChild = $(this).find(".variablevalue");
                                        var vValueChild = $(this).find(".variablevalue").find(".variablevalue-item");
                                        if (vValueChild.length > 0) {
                                            var checkIsExist = false;
                                            vValueChild.each(function () {
                                                if ($(this).attr("data-valueid") == vValue) {
                                                    checkIsExist = true;
                                                }
                                            });
                                            if (checkIsExist == false) {
                                                var html = "";
                                                html += "<div class=\"variablevalue-item\" data-valueid=\"" + vValue + "\" data-valuename=\"" + vValue_text + "\">";
                                                html += "<span class=\"v-value\">" + vValue_text + "</span>";
                                                html += "<a href=\"javascript:;\" class=\"btn primary-btn fw-btn not-fullwidth v-delete\" onclick=\"deleteValueInGroup($(this))\">Xóa</a>";
                                                html += "</div>";
                                                vValueContentChild.append(html);
                                            }
                                        }
                                    }
                                });
                            }
                            else {
                                var html = "";
                                html += "<div class=\"variable-select\" data-name=\"" + vName_text + "\" data-id=\"" + vName + "\">";
                                html += "   <div class=\"variablename\" data-name=\"" + vName_text + "\" data-id=\"" + vName + "\"><strong>" + vName_text + "</strong><a href=\"javascript:;\" style=\"float:right;margin-right:13px;\" class=\"btn primary-btn fw-btn not-fullwidth v-delete\" onclick=\"deleteGroup($(this))\">Xóa</a></div>";
                                html += "   <div class=\"variablevalue\">";
                                html += "       <div class=\"variablevalue-item\" data-valueid=\"" + vValue + "\" data-valuename=\"" + vValue_text + "\">";
                                html += "           <span class=\"v-value\">" + vValue_text + "</span>";
                                html += "           <a href=\"javascript:;\" class=\"btn primary-btn fw-btn not-fullwidth v-delete\" onclick=\"deleteValueInGroup($(this))\">Xóa</a>";
                                html += "       </div>";
                                html += "   </div>";
                                html += "</div>";
                                $(".variableselect").append(html);
                            }
                        }
                        else {
                            var html = "";
                            html += "<div class=\"variable-select\" data-name=\"" + vName_text + "\" data-id=\"" + vName + "\">";
                            html += "   <div class=\"variablename\" data-name=\"" + vName_text + "\" data-id=\"" + vName + "\"><strong>" + vName_text + "</strong><a href=\"javascript:;\" style=\"float:right;margin-right:13px;\" class=\"btn primary-btn fw-btn not-fullwidth v-delete\" onclick=\"deleteGroup($(this))\">Xóa</a></div>";
                            html += "   <div class=\"variablevalue\">";
                            html += "       <div class=\"variablevalue-item\" data-valueid=\"" + vValue + "\" data-valuename=\"" + vValue_text + "\">";
                            html += "           <span class=\"v-value\">" + vValue_text + "</span>";
                            html += "           <a href=\"javascript:;\" class=\"btn primary-btn fw-btn not-fullwidth v-delete\" onclick=\"deleteValueInGroup($(this))\">Xóa</a>";
                            html += "       </div>";
                            html += "   </div>";
                            html += "</div>";
                            $(".variableselect").append(html);
                        }
                    }
                    $("#selectvariabletitle").show();
                }
            }

            function deleteValueInGroup(obj) {
                var c = confirm('Bạn muốn xóa giá trị này phải không?');
                if (c == true) {
                    var root = obj.parent().parent().parent();
                    var parent_content = obj.parent().parent();
                    var valueContent = obj.parent();
                    valueContent.remove();
                    if (parent_content.find(".variablevalue-item").length == 0) {
                        root.remove();
                    }
                    if ($(".variable-select").length == 0) {
                        $("#selectvariabletitle").hide();
                    }
                }
            }

            function deleteGroup(obj) {
                var c = confirm('Bạn muốn xóa thuộc tính này phải không?');
                if (c == true) {
                    obj.parent().parent().remove();
                    if ($(".variable-select").length == 0) {
                        $("#selectvariabletitle").hide();
                    }
                }
            }

            function chooseParent(obj) {
                var parentID = obj.val();
                $("#<%=hdfParentID.ClientID%>").val(parentID);
                var lv = parseFloat(obj.attr('data-level'));
                var level = lv + 1;
                $(".slparent").each(function () {
                    var lev = $(this).attr('data-level');
                    if (lv < lev) {
                        $(this).remove();
                    }
                })
                $.ajax({
                    type: "POST",
                    url: "/tao-san-pham.aspx/getParent",
                    data: "{parent:'" + parentID + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (msg) {
                        var data = JSON.parse(msg.d);
                        var html = "";
                        //var sl = "";
                        if (data.length > 0) {
                            html += "<select class=\"form-control slparent\" style=\"margin-bottom:15px;\" data-level=" + level + "  onchange=\"chooseParent($(this))\">";
                            html += "<option  value=\"0\">--Chọn danh mục--</option>";
                            for (var i = 0; i < data.length; i++) {
                                html += "<option value=\"" + data[i].ID + "\">" + data[i].CategoryName + "</option>";
                            }
                            html += "</select>";
                        }
                        $(".parent").append(html);
                    }
                })
            }

            function choosetype() {
                var vl = $("#ddlProductStyle").val();
                $("#<%=hdfsetStyle.ClientID%>").val(vl);
                if (vl == 2) {
                    $("#Minimum").hide(1);
                    $("#Maximum").hide(1);
                    $("#ManageStock").hide(1);
                    $(".variable").show();
                }
                else {
                    $("#Minimum").show();
                    $("#Maximum").show();
                    $("#ManageStock").show();
                    $(".variable").hide();
                }
            }

            function setMax() {
                var value = $(".numbertype").find(".maxquantity").val();
                var value1 = $(".numbertype").find(".miniquantity").val();

                $(".item-var-gen").each(function () {
                    $(".maximum").val(value);
                    $(".minimum").val(value1);
                });
            }

            function generateVariable() {
                var giasi = $("#<%=pRegular_Price.ClientID%>").val();
                var giavon = $("#<%=pCostOfGood.ClientID%>").val();
                var giale = $("#<%=pRetailPrice.ClientID%>").val();
                var SKU = $("#<%=txtProductSKU.ClientID%>").val();

                var checkError = false;
                if (giasi == 0 || giavon == 0 || giale == 0 || isBlank(SKU)) {
                    checkError = true;
                }

                if (parseFloat(giasi) < parseFloat(giavon)) {
                    swal("Thông báo", "Gía sỉ không được thấp hơn giá vốn", "error");
                } else if (parseFloat(giasi) > parseFloat(giale)) {
                    swal("Thông báo", "Giá lẻ không được thấp hơn giá sỉ ", "error");
                }
                else {

                    if (checkError == true) {
                        alert('Vui lòng kiểm tra lại không để thông tin thuộc tính bị rỗng.');
                    }
                    else {
                        if ($(".variablevalue-item").length > 0) {
                            var parentnameid = "";
                            var listname = "";
                            var listname_id = "";
                            var listvalue = "";
                            var listvalue_id = "";

                            if ($(".variable-select").length > 0) {
                                $(".variable-select").each(function () {
                                    parentnameid += $(this).attr("data-name") + ":";
                                    //listname += $(this).attr("data-name") + "|";
                                    //listname_id += $(this).attr("data-id") + "|";
                                    $(this).find(".variablevalue").find(".variablevalue-item").each(function () {
                                        parentnameid += $(this).attr("data-valueid") + "-" + $(this).attr("data-valuename") + ";"
                                        //listvalue += $(this).attr("data-valuename") + "|";
                                        //listvalue_id += $(this).attr("data-valueid") + "|";
                                    });
                                    parentnameid += "|";
                                });
                            }
                            var parent = parentnameid.split('|');
                            parent.sort();
                            var parentlist = "";
                            for (var j = 1; j < parent.length; j++) {
                                parentlist += parent[j] + "|";
                            }

                        }
                    }
                    $.ajax({
                        type: "POST",
                        url: "/tao-san-pham.aspx/getVariable",
                        data: "{list:'" + parentlist + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (msg) {
                            var data = JSON.parse(msg.d);
                            if (data.length > 0) {
                                var html = "";
                                for (var i = 0; i < data.length; i++) {
                                    var item = data[i];
                                    var temp1 = item.ProductVariableName.split('|');
                                    var a = $("#<%= hdfsetStyle.ClientID%>").val();

                                if (a == 2) {
                                    $(".numbertype").show();
                                    $(".delete").show();
                                    html += "<div class=\"item-var-gen\" data-name-id=\"" + item.VariableListValue
                                        + "|\" data-value-id=\"" + item.VariableValue
                                        + "|\" data-name-text=\"" + item.VariableNameList
                                        + "|\" data-value-text=\"" + item.VariableValueName
                                        + "\" data-name-value=\"" + item.ProductVariable + "\">";
                                    html += "<div class=\"form-row\">";
                                    html += "<div class=\"row-left\">Thông tin</div>";
                                    html += "<div class=\"row-right\">";
                                    for (var j = 0; j < temp1.length - 1; j++) {
                                        html += "<p><strong>" + temp1[j] + " </strong></p>";
                                    }
                                    html += "</div>";
                                    html += "</div>";
                                    html += "<div class=\"form-row\">";
                                    html += "<div class=\"row-left\">SKU</div>";
                                    html += "<div class=\"row-right\"><input type=\"text\" class=\"form-control productvariablesku\" value=\"" + SKU + item.VariableSKUText + "\" /></div>";
                                    html += "</div>";
                                    html += "<div class=\"form-row\">";
                                    html += "<div class=\"row-left\">Giá sỉ</div>";
                                    html += "<div class=\"row-right\"><input class=\"form-control regularprice\" type=\"text\" value=\"" + giasi + "\" /> </div>";
                                    html += "</div>";
                                    html += "<div class=\"form-row\">";
                                    html += "<div class=\"row-left\">Giá vốn</div>";
                                    html += "<div class=\"row-right\"><input class=\"form-control costofgood\" type=\"text\"  value=\"" + giavon + "\" /></div>";
                                    html += "</div>";
                                    html += "<div class=\"form-row\">";
                                    html += "<div class=\"row-left\">Giá bán lẻ</div>";
                                    html += "<div class=\"row-right\"><input class=\"form-control retailprice\" type=\"text\"  value=\"" + giale + "\" /></div>";
                                    html += "</div>";
                                    html += "<div class=\"form-row\">";
                                    html += "<div class=\"row-left\">Tồn kho nhiều nhất</div>";
                                    html += "<div class=\"row-right\"><input class=\"form-control maximum\" type=\"text\"  value=\"" + 0 + "\" /></div>";
                                    html += "</div>";
                                    html += "<div class=\"form-row\">";
                                    html += "<div class=\"row-left\">Tồn kho ít nhất</div>";
                                    html += "<div class=\"row-right\"><input class=\"form-control minimum\" type=\"text\"  value=\"" + 0 + "\" /></div>";
                                    html += "</div>";
                                    html += "<div class=\"form-row\">";
                                    html += "<div class=\"row-left\">Trạng thái</div>";
                                    html += "<div class=\"row-right\">";
                                    html += "<select id=\"ddlStockStatus\" class=\"form-control\">";
                                    html += "<option value=\"1\">Còn hàng</option>";
                                    html += "<option value=\"2\">Hết hàng</option>";
                                    html += "</select>";
                                    html += "</div >";
                                    html += "</div>";
                                    html += "<div class=\"form-row\">";
                                    html += "<div class=\"row-left\">Quản lý trong kho</div>";
                                    html += "<div class=\"row-right\"><input class=\"managestock\" type=\"checkbox\" Checked=\"true\" ></div>";
                                    html += "</div>";
                                    html += "<div class=\"form-row\">";
                                    html += "<input type='file' class=\"productVariableImage\" onchange=\"imagepreview(this,$(this));\" name=\"" + item.ProductVariable + "\"/>";
                                    html += "<img class=\"imgpreview\" src=\"#\" style=\"width: 40%;\"  />";
                                    html += "<span class=\"remove\" style=\"display:none\">Xóa</span>";
                                    html += "</div>";
                                    html += "<div class=\"form-row\">";
                                    html += "<div class=\"row-left\"><a href=\"javascript:;\" onclick=\"deleteItemGen($(this))\" class=\"btn primary-btn fw-btn not-fullwidth\">Xóa</a></div>";
                                    html += "<div class=\"row-right\">";
                                    html += "</div>";
                                    html += "</div>";
                                    html += "</div>";
                                }
                                else {
                                    var maximum = $("#<%=pMaximumInventoryLevel.ClientID%>").val();
                                    var minimum = $("#<%=pMinimumInventoryLevel.ClientID%>").val();
                                    html += "<div class=\"item-var-gen\" data-name-id=\"" + item.VariableListValue
                                        + "|\" data-value-id=\"" + item.VariableValue
                                        + "|\" data-name-text=\"" + item.VariableNameList
                                        + "|\" data-value-text=\"" + item.VariableValueName
                                        + "\" data-name-value=\"" + item.ProductVariable + "\">";
                                    html += "<div class=\"form-row\">";
                                    html += "<div class=\"row-left\">Thông tin</div>";
                                    html += "<div class=\"row-right\">";
                                    for (var j = 0; j < temp1.length - 1; j++) {
                                        html += "<p><strong>" + temp1[j] + " </strong></p>";
                                    }
                                    html += "</div>";
                                    html += "</div>";
                                    html += "<div class=\"form-row\">";
                                    html += "<div class=\"row-left\">SKU</div>";
                                    html += "<div class=\"row-right\"><input type=\"text\" class=\"form-control productvariablesku\" value=\"" + SKU + item.VariableSKUText + "\" /></div>";
                                    html += "</div>";
                                    html += "<div class=\"form-row\">";
                                    html += "<div class=\"row-left\">Giá sỉ</div>";
                                    html += "<div class=\"row-right\"><input class=\"form-control regularprice\" type=\"text\" value=\"" + giasi + "\" /> </div>";
                                    html += "</div>";
                                    html += "<div class=\"form-row\">";
                                    html += "<div class=\"row-left\">Giá vốn</div>";
                                    html += "<div class=\"row-right\"><input class=\"form-control costofgood\" type=\"text\"  value=\"" + giavon + "\" /></div>";
                                    html += "</div>";
                                    html += "<div class=\"form-row\">";
                                    html += "<div class=\"row-left\">Giá lẻ</div>";
                                    html += "<div class=\"row-right\"><input class=\"form-control retailprice\" type=\"text\"  value=\"" + giale + "\" /></div>";
                                    html += "</div>";
                                    html += "<div class=\"form-row\">";
                                    html += "<div class=\"row-left\">Tồn kho nhiều nhất</div>";
                                    html += "<div class=\"row-right\"><input class=\"form-control maximum\" type=\"text\"  value=\"" + maximum + "\" /></div>";
                                    html += "</div>";
                                    html += "<div class=\"form-row\">";
                                    html += "<div class=\"row-left\">Tồn kho ít nhất</div>";
                                    html += "<div class=\"row-right\"><input class=\"form-control minimum\" type=\"text\"  value=\"" + minimum + "\" /></div>";
                                    html += "</div>";
                                    html += "<div class=\"form-row\">";
                                    html += "<div class=\"row-left\">Trạng thái</div>";
                                    html += "<div class=\"row-right\">";
                                    html += "<select id=\"ddlStockStatus\" class=\"form-control\">";
                                    html += "<option value=\"1\">Còn hàng</option>";
                                    html += "<option value=\"2\">Hết hàng</option>";
                                    html += "</select>";
                                    html += "</div >";
                                    html += "</div>";
                                    html += "<div class=\"form-row\">";
                                    html += "<input type='file' class=\"productVariableImage\" onchange=\"imagepreview(this,$(this));\" name=\"" + item.ProductVariable + "\"/>";
                                    html += "<img class=\"imgpreview\" src=\"#\" style=\"width: 40%;\"/>";
                                    html += "<span class=\"remove\" style=\"display:none\">Xóa</span>";
                                    html += "</div>";
                                    html += "<div class=\"form-row\">";
                                    html += "<div class=\"row-left\"><a href=\"javascript:;\" onclick=\"deleteItemGen($(this))\" class=\"btn primary-btn fw-btn not-fullwidth\">Xóa</a></div>";
                                    html += "<div class=\"row-right\">";
                                    html += "</div>";
                                    html += "</div>";
                                    html += "</div>";
                                }
                            }
                            $(".list-item-genred").append(html);
                        }
                        $(".generat-variable-content").show();
                    },
                    error: function (xmlhttprequest, textstatus, errorthrow) {
                        alert('lỗi');
                    }
                });
                }
            }

            function imagepreview(input, obj) {
                if (input.files && input.files[0]) {
                    var reader = new FileReader();

                    reader.onload = function (e) {
                        obj.parent().find('.imgpreview').attr('src', e.target.result);
                        //$('.imgpreview').attr('src', e.target.result);

                        $(".remove").show();
                        obj.parent().find(".remove").click(function () {
                            obj.parent().find('.imgpreview').attr('src', "");
                            obj.parent().find('input:file').val("");
                            $(".remove").hide();
                        });
                    }

                    reader.readAsDataURL(input.files[0]);
                }
            }

            function deleteItemGen(obj) {
                var c = confirm("Bạn muốn xóa thuộc tính này?");
                if (c == true) {
                    obj.parent().parent().parent().remove();
                }
            }

            function deleteAll() {
                var c = confirm("Bạn muốn xóa tất cả thuộc tính này?");
                if (c == true) {
                    //$(".generat-variable-content").remove();
                    $(".list-item-genred").remove();
                    var html = "<div class=\"list-item-genred\"></div>";
                    $(".generat-variable-content").append(html);
                    $(".numbertype").hide();
                }
            }

            function addNewProduct() {
                var listv = "";
                var a = $("#<%= hdfsetStyle.ClientID%>").val();
                var parent = $("#<%=hdfParentID.ClientID%>").val();
                if (a == 2) {
                    if ($(".item-var-gen").length > 0) {
                        var checkError = false;
                        $(".item-var-gen").each(function () {
                            var productvariablesku = $(this).find(".productvariablesku").val();
                            var regularprice = $(this).find(".regularprice").val();
                            var costofgood = $(this).find(".costofgood").val();
                            var retailprice = $(this).find(".retailprice").val();
                            var image = $(this).find(".productVariableImage").attr("name");
                            if (isBlank(productvariablesku) || isBlank(regularprice) || isBlank(costofgood) || isBlank(retailprice)) {
                                checkError = true;
                            }

                        });
                        if (checkError == true) {
                            alert('Vui lòng kiểm tra lại không để thông tin thuộc tính bị rỗng.');
                        }
                        //else if (parseFloat(regularprice) < parseFloat(costofgood)) {
                        //    swal("Thông báo", "Gía sỉ không được thấp hơn giá vốn", "error");
                        //}
                        //else if (parseFloat(regularprice) > parseFloat(retailprice)) {
                        //    swal("Thông báo", "Giá lẻ không được thấp hơn giá sỉ", "error");
                        //}
                        else {

                            $(".item-var-gen").each(function () {
                                var datanameid = $(this).attr("data-name-id");
                                var datavalueid = $(this).attr("data-value-id");
                                var datanametext = $(this).attr("data-name-text");
                                var datavaluetext = $(this).attr("data-value-text");
                                var productvariablesku = $(this).find(".productvariablesku").val();
                                var regularprice = $(this).find(".regularprice").val();
                                var costofgood = $(this).find(".costofgood").val();
                                var retailprice = $(this).find(".retailprice").val();
                                var datanamevalue = $(this).attr("data-name-value");
                                var image = $(this).find(".productVariableImage").attr("name");
                                var max = $(this).find(".maximum").val();
                                var min = $(this).find(".minimum").val();
                                var StockStatus = $("#ddlStockStatus").val();
                                if ($(this).find(".managestock").is(':checked')) {
                                    var checked = true;
                                }
                                else {
                                    var checked = false;
                                }

                                if (parent == "") {
                                    swal("Thông báo", "Chưa chọn danh mục sản phẩm", "error");
                                } else if (parseFloat(regularprice) < parseFloat(costofgood)) {
                                    swal("Thông báo", "Gía sỉ không được thấp hơn giá vốn", "error");
                                } else if (parseFloat(regularprice) > parseFloat(retailprice)) {
                                    swal("Thông báo", "Giá lẻ không được thấp hơn giá sỉ ", "error");
                                }
                                else {
                                    if (!isBlank(productvariablesku) && !isBlank(regularprice) && !isBlank(costofgood) && !isBlank(retailprice) && max > 0 && min > 0 && !isBlank(StockStatus)) {
                                        listv += datanameid + ";" + datavalueid + ";" + datanametext + ";" + datavaluetext + ";" + productvariablesku + ";" +
                                            regularprice.replace(",", "") + ";" + costofgood.replace(",", "") + ";" + retailprice.replace(",", "") + ";" + datanamevalue + ";" + max + ";" + min + ";" + StockStatus + ";" + checked + ",";
                                        $("#<%=hdfVariableListInsert.ClientID%>").val(listv);
                                        $("#<%=btnLogin.ClientID%>").click();
                                    }
                                    else {
                                        alert("Vui lòng kiểm tra lại các biến thể!")
                                    }
                                }
                            });
                        }
                    }
                }
                else {
                    var title = $("#<%=txtProductTitle.ClientID%>").val();
                    var SKU = $("#<%=txtProductSKU.ClientID%>").val();
                    var materials = $("#<%=txtMaterials.ClientID%>").val();
                    var maximum = $("#<%=pMaximumInventoryLevel.ClientID%>").val();
                    var minimum = $("#<%=pMinimumInventoryLevel.ClientID%>").val();
                    var giasi = $("#<%=pRegular_Price.ClientID%>").val();
                    var giavon = $("#<%=pCostOfGood.ClientID%>").val();
                    var giale = $("#<%=pRetailPrice.ClientID%>").val();


                    if (parent == "") {
                        swal("Thông báo", "Chưa chọn danh mục sản phẩm", "error");
                    }
                    else if (parseFloat(giasi) < parseFloat(giavon)) {
                        swal("Thông báo", "Gía sỉ không được thấp hơn giá vốn", "error");
                    } else if (parseFloat(giasi) > parseFloat(giale)) {
                        swal("Thông báo", "Giá lẻ không được thấp hơn giá sỉ", "error");
                    }
                    else {
                        if (!isBlank(title) && !isBlank(SKU) && !isBlank(materials) && !isBlank(maximum) && !isBlank(minimum) && !isBlank(giasi) && !isBlank(giavon) && !isBlank(giale)) {
                            listv = "";
                            $("#<%=hdfVariableListInsert.ClientID%>").val(listv);
                            $("#<%=btnLogin.ClientID%>").click();
                        }
                        else {
                            alert("Vui lòng kiểm tra lại không để thông tin thuộc tính bị rỗng.")
                        }
                    }
                }

            }
</script>
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

            function CheckSKU() {
                var sku = $("#<%=txtProductSKU.ClientID%>").val();
                $.ajax({
                    type: "POST",
                    url: "/tao-san-pham.aspx/CheckSKU",
                    data: "{SKU:'" + sku + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (msg) {
                        if (msg.d != "ok") {
                            swal("Thông báo", "Trùng mã SKU vui lòng kiểm tra lại :)", "error");
                            $("#<%=txtProductSKU.ClientID%>").focus();
                        }

                    }
                })
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


            function OnClientFileSelected1(sender, args) {
                if ($telerik.isIE) return;
                else {
                    truncateName(args);
                    var file = args.get_fileInputField().files.item(args.get_rowIndex());
                    //var file = args.get_fileInputField().files.item(0);
                    showThumbnail(file, args);
                }
            }
            function DelRow(that, link) {

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
            })(window);

        </script>
    </telerik:RadCodeBlock>
</asp:Content>
