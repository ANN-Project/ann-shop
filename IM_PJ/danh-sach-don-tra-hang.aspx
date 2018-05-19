<%@ Page Title="Danh sách đơn trả hàng" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="danh-sach-don-tra-hang.aspx.cs" Inherits="IM_PJ.danh_sach_don_tra_hang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main id="main-wrap">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h3 class="page-title left">Danh sách đơn hàng</h3>
                    <div class="right above-list-btn">
                        <a href="/them-don-tra-hang" class="h45-btn btn" style="background-color: #ff3f4c; float: right;">Thêm mới</a>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="filter-above-wrap clear">
                        <div class="right">
                            <div class="filter-control">
                                <asp:TextBox ID="txtAgentName" runat="server" CssClass="form-control" placeholder="Nhập tên tên sản phẩm / số đt khách để tìm"
                                    Width="210px"></asp:TextBox>
                                <asp:DropDownList ID="ddlAgentName" runat="server" CssClass="form-control"></asp:DropDownList>
                                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="0">Trạng thái</asp:ListItem>
                                    <asp:ListItem Value="1">Chưa trả tiền</asp:ListItem>
                                    <asp:ListItem Value="2">Đã trả tiền</asp:ListItem>
                                </asp:DropDownList>

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
                                        <th>ID</th>
                                        <%-- <th>Đại lý</th>--%>
                                        <th>Tên khách hàng</th>
                                        <th>Số ĐT</th>
                                        <th>Số lượng sản phẩm</th>
                                        <th>Phí đổi hàng</th>
                                        <th>Tổng tiền</th>
                                        <th>Trạng thái</th>
                                        <th>Nhân viên tạo đơn</th>
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
        </div>
        <div id="printOrder" style="display: none">
            <asp:Literal ID="ltrPrintOrder" runat="server"></asp:Literal>
        </div>
        <asp:HiddenField ID="hdfcreate" runat="server" />
        <script type="text/javascript">

            var list = document.getElementById('<%= hdfcreate.ClientID%>').defaultValue;
            if (list == "1") {
                $(".create").removeClass("hide");
            }

            function searchAgent() {
                $("#<%= btnSearch.ClientID%>").click();
            }

            function printDiv(divid) {
                var divToPrint = document.getElementById('' + divid + '');
                var newWin = window.open('', 'Print-Window');
                newWin.document.open();
                newWin.document.write('<html><head><link rel="stylesheet" href="/App_Themes/Ann/hoadon/hoadon.css" type="text/css"/><link rel="stylesheet" href="/App_Themes/Ann/barcode/style.css" type="text/css"/><link rel="stylesheet" href="/App_Themes/Ann/css/responsive.css" type="text/css"/></head><body onload="window.print()">' + divToPrint.innerHTML + '</body></html>');
                newWin.document.close();
                setTimeout(function () { newWin.close(); }, 10);
            }

            function printOrder(id) {
                $.ajax({
                    type: "POST",
                    url: "/danh-sach-don-tra-hang.aspx/getOrder",
                    data: "{ID:'" + id + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (msg) {
                        var data = JSON.parse(msg.d)
                        if (data != null) {
                            var productPrint = "";
                            var shtml = "";

                            productPrint += " <div class=\"body\">";
                            productPrint += " <div class=\"table-1\">";
                            productPrint += " <table>";
                            productPrint += "<colgroup >";
                            productPrint += "<col class=\"col-left\"/>";
                            productPrint += "<col class=\"col-right\"/>";
                            productPrint += "</colgroup>";
                            productPrint += " <tbody>";
                            productPrint += " <tr>";
                            productPrint += " <td>Mã đơn hàng</td>";
                            productPrint += " <td>" + data.ID + "</td>";
                            productPrint += " </tr>";
                            productPrint += "  <tr>";
                            productPrint += "  <td>Ngày tạo</td>";

                            productPrint += " <td>" + data.CreateDate + "</td>";
                            productPrint += "</tr>";

                            productPrint += "<tr>";
                            productPrint += "   <td>Trạng thái</td>";
                            if (data.Status != null)
                                productPrint += "<td>" + data.Status + "</td>";
                            else
                                productPrint += "<td></td>";

                            productPrint += "</tr>";

                            productPrint += " <tr>";
                            productPrint += " <td>Nhân viên</td>";
                            productPrint += " <td>" + data.CreatedBy + "</td>";
                            productPrint += "</tr>";
                            productPrint += "<tr>";
                            productPrint += "  <td>Khách hàng</td>";
                            productPrint += "  <td>" + data.CustomerName + "</td>";
                            productPrint += " </tr>";
                            productPrint += "<tr>";
                            productPrint += " <td>Điện thoại</td>";
                            productPrint += " <td>" + data.CustomerPhone + "</td>";
                            productPrint += "</tr>";

                            productPrint += " </tbody>";
                            productPrint += "</table>";
                            productPrint += "         </div>";

                            productPrint += "<div class=\"table-2\">";
                            productPrint += " <table>";
                            productPrint += " <colgroup>";
                            productPrint += "<col class=\"stt\" />";
                            productPrint += "<col class=\"sanpham\" />";
                            productPrint += "<col class=\"soluong\" />";
                            productPrint += "<col class=\"gia\" />";
                            productPrint += "<col class=\"phi\"/>";
                            productPrint += "<col class=\"tong\"/>";
                            productPrint += "</colgroup>";
                            productPrint += "<thead>";
                            productPrint += " <th>#</th>";
                            productPrint += "<th>Sản phẩm</th>";
                            productPrint += "<th>Số lượng</th>";
                            productPrint += "<th>Giá</th>";
                            productPrint += "<th>Phí</th>";
                            productPrint += "<th>Tổng</th>";
                            productPrint += " </thead>";
                            productPrint += "<tbody>";
                            var t = 0;

                            var listproduct = data.ListProduct.split('*');
                            for (var i = 0; i < listproduct.length - 1; i++) {
                                var value = listproduct[i].split(';');

                                //product
                                productPrint += "<tr>";
                                t += parseFloat(value[3]);
                                productPrint += "<td>" + (i + 1) + "</td>";
                                productPrint += "<td>" + value[0] + " - " + value[1] + " - " + value[2] + "</td> ";
                                productPrint += "<td>" + value[3] + "</td>";
                                productPrint += "<td>" + formatThousands(value[4], ",") + "</td>";
                                productPrint += "<td>" + formatThousands(value[5], ",") + "</td>";
                                var k = parseFloat(value[3]) * parseFloat(value[4]);
                                productPrint += "<td> " + formatThousands(k, ",") + "</td>";

                                productPrint += "</tr>";
                                //product

                            }



                            productPrint += "<td colspan =\"5\" > Số lượng </td>";
                            productPrint += "<td>" + data.TotalQuantity + "</td>";
                            productPrint += "</tr>";
                            productPrint += " <tr>";
                            productPrint += " <td colspan =\"5\"> Phí đổi hàng </td>";
                            productPrint += " <td>" + formatThousands(data.TotalRefundPrice, ",") + "</td>";
                            productPrint += " </tr>";

                            productPrint += " <tr>";
                            productPrint += "<td class=\"strong\" colspan=\"5\">Tổng tiền</td>";
                            productPrint += " <td class=\"strong\">" + formatThousands(data.TotalPrice, ",") + "</td>";
                            productPrint += " </tr>";
                            productPrint += "</tbody>";
                            productPrint += " </table>";
                            productPrint += "</div>";
                            productPrint += "         </div>";

                            shtml += "<div class=\"hoadon\">";
                            shtml += "<div class=\"all\">";
                            shtml += "<div class=\"head\">";
                            shtml += "     <div class=\"logo\"><div class=\"img\"><img src=\"App_Themes/Ann/image/logo.png\" alt=\"\" /></div></div>";
                            shtml += "<div class=\"info\">";
                            shtml += "<div class=\"ct\">";
                            var agent = data.ListAgent.split('|');
                            shtml += "<div class=\"ct-title\">Địa chỉ:</div>";
                            shtml += "<div class=\"ct-detail\">" + agent[0] + "</div>";
                            shtml += "<div class=\"ct\">";
                            shtml += "<div class=\"ct-title\">Điện thoại/ Zalo:</div>";
                            shtml += "<div class=\"ct-detail\">";

                            shtml += "<a href = \"tel:+\" >" + agent[1] + "</a></div>";
                            //html += "<a href=\"tel:+\">0913268406</a> -";
                            //html += "<a href = \"tel:+\" > 0936786404 </a>";

                            shtml += "<div class=\"ct\">";
                            shtml += "<div class=\"ct-title\">Facebook:</div>";
                            shtml += "<div class=\"ct-detail\">";
                            shtml += "<a href =\"https://facebook.com/bosiquanao.net\" target=\"_blank\" >https://facebook.com/bosiquanao.net</a>";
                            shtml += "</div>";
                            shtml += "</div>";
                            shtml += "<div class=\"ct\">";
                            shtml += "<div class=\"ct-title\">Website:</div>";
                            shtml += "<div class=\"ct-detail\">";
                            shtml += "<a href =\"\">ann.com.vn</a> ";
                            shtml += "</div> ";
                            shtml += "</div> ";
                            shtml += "</div> ";
                            shtml += "</div>";
                            shtml += "</div>";
                            shtml += "<div class=\"refund\">ĐƠN HÀNG TRẢ</div>";

                            shtml += productPrint;

                            shtml += "<div class=\"footer\"><h1> Cảm ơn quý khách </h ></div> ";
                            shtml += "</div>";

                            shtml += "</div>";

                        }
                        $("#printOrder").html(shtml);

                        printDiv('printOrder');

                    }
                });
            }

            var formatThousands = function (n, dp) {
                var s = '' + (Math.floor(n)), d = n % 1, i = s.length, r = '';
                while ((i -= 3) > 0) { r = ',' + s.substr(i, 3) + r; }
                return s.substr(0, i + 3) + r +
                    (d ? '.' + Math.round(d * Math.pow(10, dp || 2)) : '');
            };
        </script>
    </main>
</asp:Content>
