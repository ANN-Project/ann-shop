<%@ Page Title="Danh sách đơn hàng" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="danh-sach-don-hang.aspx.cs" Inherits="IM_PJ.danh_sach_don_hang" %>

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
                    <div class="filter-above-wrap clear">
                        <div class="filter-control">
                            <div class="row">
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtAgentName" runat="server" CssClass="form-control" placeholder="Nhập tên tên sản phẩm / số đt khách để tìm" Width="100%"></asp:TextBox>
                                </div>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtSKU" runat="server" CssClass="form-control" placeholder="Nhập SKU để tìm" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-1">
                                    <asp:DropDownList ID="ddlOrderType" runat="server" CssClass="form-control wid">
                                        <asp:ListItem Value="0" Text="Loại"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Lẻ"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Sỉ"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-2">
                                    <asp:DropDownList ID="ddlPaymentStatus" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="0" Text="Trạng thái thanh toán"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Chưa thanh toán"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Thanh toán thiếu"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="Đã thanh toán"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-2">
                                    <asp:DropDownList ID="ddlExcuteStatus" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="0" Text="Xử lý"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Đang chờ xử lý"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Đã xử lý"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="Đã hủy"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-2">
                                    <asp:DropDownList ID="ddlPaymentType" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="0" Text="Cách thanh toán"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Tiền mặt"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Chuyển khoản"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="Thu hộ"></asp:ListItem>
                                        <asp:ListItem Value="4" Text="Công nợ"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-2">
                                    <asp:DropDownList ID="ddlShippingType" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="0" Text="Giao hàng"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Lấy trực tiếp"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Chuyển bưu điện"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="Chuyển proship"></asp:ListItem>
                                        <asp:ListItem Value="4" Text="Chuyển xe"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-2">
                                    <asp:DropDownList ID="ddlCreateBy" runat="server" CssClass="form-control create hide"></asp:DropDownList>
                                </div>
                                <div class="col-md-1">
                                    <a href="javascript:;" onclick="searchAgent()" class="btn primary-btn h45-btn"><i class="fa fa-search"></i></a>
                                    <asp:Button ID="btnSearch" runat="server" CssClass="btn primary-btn h45-btn" OnClick="btnSearch_Click" Style="display: none" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel-table clear">
                        <div class="panel-footer clear">
                            <div class="pagination">
                                <%this.DisplayHtmlStringPaging1();%>
                            </div>
                        </div>
                        <div class="responsive-table">
                            <table class="table table-checkable table-product">
                                <tbody>
                                    <tr>
                                        <th>Mã</th>
                                        <th>Loại</th>
                                        <th>Điện thoại</th>
                                        <th>Tên khách</th>
                                        <th>Số lượng</th>
                                        <th>Thanh toán</th>
                                        <th>Xử lý</th>
                                        <th>Thanh toán</th>
                                        <th>Giao hàng</th>
                                        <th>Tổng tiền</th>
                                        <th>Ngày tạo</th>
                                        <th>Hoàn tất</th>
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
        <div id="printInvoice" style="display: none">
        </div>
        <asp:HiddenField ID="hdfcreate" runat="server" />
        <script type="text/javascript">
            function searchAgent() {
                $("#<%= btnSearch.ClientID%>").click();
            }

            var list = document.getElementById('<%= hdfcreate.ClientID%>').defaultValue;
            if (list == "1")
            {
                $(".create").removeClass("hide");
            }

            var formatThousands = function (n, dp) {
                var s = '' + (Math.floor(n)), d = n % 1, i = s.length, r = '';
                while ((i -= 3) > 0) { r = ',' + s.substr(i, 3) + r; }
                return s.substr(0, i + 3) + r +
                    (d ? '.' + Math.round(d * Math.pow(10, dp || 2)) : '');
            };
        </script>
        <style>
            .wid {
                width: 80px;
            }
        </style>
    </main>
</asp:Content>
