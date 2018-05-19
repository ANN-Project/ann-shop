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
                  <%--  <div class="filter-above-wrap clear" style="width: 100%;">

                        <div class="filter-control right" style="width: 100%; float: left;">

                            <asp:TextBox ID="txtAgentName" runat="server" CssClass="form-control" placeholder="Nhập tên tên sản phẩm / số đt khách để tìm"
                                Width="100%"></asp:TextBox>

                            <asp:TextBox ID="txtSKU" runat="server" CssClass="form-control" placeholder="Nhập SKU để tìm"
                                Width="100%"></asp:TextBox>


                            <asp:DropDownList ID="ddlOrderType" runat="server" CssClass="form-control wid">
                                <asp:ListItem Value="0" Text="Loại"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Lẻ"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Sỉ"></asp:ListItem>
                            </asp:DropDownList>



                            <asp:DropDownList ID="ddlPaymentStatus" runat="server" CssClass="form-control">
                                <asp:ListItem Value="0" Text="--Loại thanh toán--"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Chưa thanh toán"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Thanh toán thiếu"></asp:ListItem>
                                <asp:ListItem Value="3" Text="Đã thanh toán"></asp:ListItem>
                            </asp:DropDownList>

                            <asp:DropDownList ID="ddlExcuteStatus" runat="server" CssClass="form-control">
                                <asp:ListItem Value="0" Text="--Loại xử lý--"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Đang chờ xử lý"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Đã xử lý"></asp:ListItem>
                            </asp:DropDownList>



                            <asp:DropDownList ID="ddlPaymentType" runat="server" CssClass="form-control">
                                <asp:ListItem Value="0" Text="--Phương thức thanh toán--"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Tiền mặt"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Chuyển khoản"></asp:ListItem>
                                <asp:ListItem Value="3" Text="Thu hộ"></asp:ListItem>
                                <asp:ListItem Value="4" Text="Công nợ"></asp:ListItem>
                            </asp:DropDownList>



                            <asp:DropDownList ID="ddlShippingType" runat="server" CssClass="form-control">
                                <asp:ListItem Value="0" Text="--Phương thức giao hàng--"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Lấy trực tiếp"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Chuyển bưu điện"></asp:ListItem>
                                <asp:ListItem Value="3" Text="Chuyển proship"></asp:ListItem>
                                <asp:ListItem Value="4" Text="Chuyển xe"></asp:ListItem>
                            </asp:DropDownList>



                            <a href="javascript:;" onclick="searchAgent()" class="btn primary-btn h45-btn"><i class="fa fa-search"></i></a>
                            <asp:Button ID="btnSearch" runat="server" CssClass="btn primary-btn h45-btn" OnClick="btnSearch_Click" Style="display: none" />




                        </div>

                    </div>--%>
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
