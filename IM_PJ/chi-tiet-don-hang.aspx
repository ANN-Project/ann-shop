<%@ Page Title="Chi tiết đơn hàng" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="chi-tiet-don-hang.aspx.cs" Inherits="IM_PJ.chi_tiet_don_hang" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main id="main-wrap">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h3 class="page-title left">Danh sách đơn hàng</h3>
                    <div class="right above-list-btn">
                        <a href="/them-moi-don-hang" class="h45-btn btn" style="background-color: #ff3f4c">Thêm mới</a>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel-table clear">
                        <div class="responsive-table">
                            <table class="table table-checkable table-product">
                                <tbody>
                                    <tr>
                                        <th>ID</th>
                                        <th>Loại</th>
                                        <th>Số đt khách</th>
                                        <th>Tên khách</th>
                                        <th>Trạng thái thanh toán</th>
                                        <th>Trạng thái xử lý</th>
                                        <th>Phương thức thanh toán</th>
                                        <th>Phương thức giao hàng</th>
                                        <th>Tổng tiền</th>
                                        <th>Ngày tạo</th>
                                        <th>Ngày hoàn tất</th>
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
        <script type="text/javascript">
           <%-- function searchAgent() {
                $("#<%= btnSearch.ClientID%>").click();
            }--%>

            function printDiv() {
                var html = "";

                $('link').each(function () { // find all <link tags that have
                    if ($(this).attr('rel').indexOf('stylesheet') != -1) { // rel="stylesheet"
                        html += '<link rel="stylesheet" href="' + $(this).attr("href") + '" />';
                    }
                });
                html += '<body onload="window.focus(); window.print()">' + $("#printOrder").html() + '</body>';
                var w = window.open("", "print");
                if (w) { w.document.write(html); w.document.close() }
            }

            function printOrder(id) {
                $.ajax({
                    type: "POST",
                    url: "/danh-sach-don-hang.aspx/getOrder",
                    data: "{ID:'" + custID + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (msg) {

                        ltrPrintOrder.Text += "";
                        ltrPrintOrder.Text += "<table width=\"220px\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"no-padding\">";
                        ltrPrintOrder.Text += "<tbody>";
                        ltrPrintOrder.Text += "<tr><td align=\"center\" style=\"font-size: 16px\"><strong>HÓA ĐƠN</strong></td></tr>";
                        ltrPrintOrder.Text += "<tr>";
                        ltrPrintOrder.Text += "<td style=\"text-align: center; font-size: 14px\"><span style=\"padding-left: 20px;\">Mã Hóa Đơn " + t.RoomTransactionCode + "</span><br><em>Ngày " + string.Format("{0:dd/MM/yyyy}", DateTime.Now) + "</em> ";
                        ltrPrintOrder.Text += "</td>";
                        ltrPrintOrder.Text += "</tr>";
                        ltrPrintOrder.Text += "<tr><td>&nbsp;</td></tr>";
                        ltrPrintOrder.Text += "<tr height=\"30px\"><td align=\"center\"><strong>PHÒNG " + t.RoomNumber + "</strong></td></tr>";
                        ltrPrintOrder.Text += "<tr>";
                        ltrPrintOrder.Text += "<td>";
                        ltrPrintOrder.Text += "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"font-size: 14px;\" class=\"no-padding\">";
                        ltrPrintOrder.Text += "<tbody>";
                        ltrPrintOrder.Text += "<tr><td colspan=\"2\"><img src=\"/App_Themes/Hotel/NewUI/images/line.gif\" alt=\"\"></td></tr>";
                        ltrPrintOrder.Text += "<tr><td width=\"100\">Số người:</td><td>" + t.NumberOfPerson + "</td></tr>";
                        ltrPrintOrder.Text += "<tr><td width=\"100\">Thời gian vào:</td><td>" + string.Format("{0:HH:mm dd/MM/yyyy}", t.DateIn) + "</td></tr>";
                        ltrPrintOrder.Text += "<tr><td colspan=\"2\"><img src=\"/App_Themes/Hotel/NewUI/images/line.gif\" alt=\"\"></td></tr>";
                        ltrPrintOrder.Text += "<tr><td>Thời gian ra: </td><td>" + string.Format("{0:HH:mm dd/MM/yyyy}", t.DateOut) + "</td></tr>";
                        ltrPrintOrder.Text += "<tr><td colspan=\"2\"><img src=\"/App_Themes/Hotel/NewUI/images/line.gif\" alt=\"\"></td></tr>";
                        ltrPrintOrder.Text += "</tbody>";
                        ltrPrintOrder.Text += "</table>";
                        ltrPrintOrder.Text += "</td>";
                        ltrPrintOrder.Text += "</tr>";
                        ltrPrintOrder.Text += "<tr height=\"30px\"><td align=\"center\"><strong>THÔNG TIN TẠM TÍNH</strong></td></tr>";
                        ltrPrintOrder.Text += "<tr>";
                        ltrPrintOrder.Text += "<td>";
                        ltrPrintOrder.Text += "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"font-size: 14px;\"  class=\"no-padding\">";
                        ltrPrintOrder.Text += "<tbody>";
                    }
                });
            }
        </script>
        <style>
            .wid {
                width: 80px;
            }
        </style>
    </main>
</asp:Content>
