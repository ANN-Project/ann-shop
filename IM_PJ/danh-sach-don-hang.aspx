<%@ Page Title="Danh sách đơn hàng" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="danh-sach-don-hang.aspx.cs" Inherits="IM_PJ.danh_sach_don_hang" EnableSessionState="ReadOnly" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main id="main-wrap">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h3 class="page-title left">Danh sách đơn hàng <span>(<asp:Literal ID="ltrNumberOfOrder" runat="server" EnableViewState="false"></asp:Literal> đơn)</span></h3>
                    <div class="right above-list-btn">
                        <a href="/them-moi-don-hang" class="h45-btn primary-btn btn">Thêm mới</a>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="filter-above-wrap clear">
                        <div class="filter-control">
                            <div class="row">
                                <div class="col-md-5">
                                    <asp:TextBox ID="txtSearchOrder" runat="server" CssClass="form-control" placeholder="Tìm đơn hàng" autocomplete="off"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <asp:DropDownList ID="ddlDiscount" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="" Text="Chiết khấu"></asp:ListItem>
                                        <asp:ListItem Value="yes" Text="Có"></asp:ListItem>
                                        <asp:ListItem Value="no" Text="Không"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-2">
                                    <asp:DropDownList ID="ddlOtherFee" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="" Text="Phí khác"></asp:ListItem>
                                        <asp:ListItem Value="yes" Text="Có"></asp:ListItem>
                                        <asp:ListItem Value="no" Text="Không"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-2">
                                    <asp:DropDownList ID="ddlCreatedDate" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="" Text="Thời gian"></asp:ListItem>
                                        <asp:ListItem Value="today" Text="Hôm nay"></asp:ListItem>
                                        <asp:ListItem Value="yesterday" Text="Hôm qua"></asp:ListItem>
                                        <asp:ListItem Value="week" Text="Tuần này"></asp:ListItem>
                                        <asp:ListItem Value="month" Text="Tháng này"></asp:ListItem>
                                        <asp:ListItem Value="7days" Text="7 ngày"></asp:ListItem>
                                        <asp:ListItem Value="30days" Text="30 ngày"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-1">
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="filter-above-wrap clear">
                        <div class="filter-control">
                            <div class="row">
                                <div class="col-md-1">
                                    <asp:DropDownList ID="ddlOrderType" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="" Text="Loại"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Lẻ"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Sỉ"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-2">
                                    <asp:DropDownList ID="ddlExcuteStatus" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="" Text="Xử lý"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Đang xử lý"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Đã hoàn tất"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="Đã hủy"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-2">
                                    <asp:DropDownList ID="ddlPaymentStatus" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="" Text="Thanh toán"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Chưa thanh toán"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Thanh toán thiếu"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="Đã thanh toán"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-2">
                                    <asp:DropDownList ID="ddlPaymentType" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="" Text="Kiểu thanh toán"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Tiền mặt"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Chuyển khoản"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="Thu hộ"></asp:ListItem>
                                        <asp:ListItem Value="4" Text="Công nợ"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-2">
                                    <asp:DropDownList ID="ddlShippingType" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="" Text="Giao hàng"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Lấy trực tiếp"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Chuyển bưu điện"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="Chuyển GHTK"></asp:ListItem>
                                        <asp:ListItem Value="4" Text="Chuyển xe"></asp:ListItem>
                                        <asp:ListItem Value="5" Text="Nhân viên giao"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-2">
                                    <asp:DropDownList ID="ddlCreatedBy" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                                <div class="col-md-1">
                                    <a href="javascript:;" onclick="searchOrder()" class="btn primary-btn h45-btn"><i class="fa fa-search"></i></a>
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
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panelborderheading">
                        <div class="panel-heading clear">
                            <h3 class="page-title left not-margin-bot">Thống kê đơn hàng</h3>
                        </div>
                        <div class="panel-body">
                            <div class="row pad">
                                <div class="col-md-3">
                                    <label class="left pad10">Tổng số đơn hàng: </label>
                                    <div class="ordertype">
                                        <asp:Literal ID="ltrTotalOrders" runat="server"></asp:Literal>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <label class="left pad10">Số đơn hàng sỉ: </label>
                                    <div class="ordercreateby">
                                        <asp:Literal ID="ltrType2Orders" runat="server"></asp:Literal>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <label class="left pad10">Số đơn hàng lẻ: </label>
                                    <div class="ordercreatedate">
                                        <asp:Literal ID="ltrType1Orders" runat="server"></asp:Literal>
                                    </div>
                                </div>
                                <div class="col-md-3"> 
                                    <label class="left pad10">Tổng sản phẩm: </label>
                                    <div class="ordernote">
                                        <asp:Literal ID="ltrTotalProducts" runat="server"></asp:Literal>
                                    </div>
                                </div>
                            </div>
                            <div class="row pad">
                                <div class="col-md-3">
                                    <label class="left pad10">Tổng số tiền: </label>
                                    <div class="orderquantity">
                                        <asp:Literal ID="ltrTotalMoney" runat="server"></asp:Literal>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <label class="left pad10">Tổng chiết khấu: </label>
                                    <div class="ordertotalprice">
                                        <asp:Literal ID="ltrDiscount" runat="server"></asp:Literal>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <label class="left pad10">Tổng phí vận chuyển: </label>
                                    <div class="ordertotalprice">
                                        <asp:Literal ID="ltrFeeShipping" runat="server"></asp:Literal>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <label class="left pad10">Tổng phí khác: </label>
                                    <div class="ordertotalprice">
                                        <asp:Literal ID="ltrOtherFee" runat="server"></asp:Literal>
                                    </div>
                                </div>
                            </div>
                            <div class="row pad">
                                <div class="col-md-3">
                                    <label class="left pad10">Số đơn lấy trực tiếp: </label>
                                    <div class="orderquantity">
                                        <asp:Literal ID="ltrShippingType1" runat="server"></asp:Literal>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <label class="left pad10">Số đơn chuyển bưu điện: </label>
                                    <div class="ordertotalprice">
                                        <asp:Literal ID="ltrShippingType2" runat="server"></asp:Literal>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <label class="left pad10">Số đơn gửi dịch vụ: </label>
                                    <div class="orderstatus">
                                        <asp:Literal ID="ltrShippingType3" runat="server"></asp:Literal>
                                    </div>
                                </div>
                                <div class="col-md-3"> 
                                    <label class="left pad10">Số đơn chuyển xe: </label>
                                    <div class="ordernote">
                                        <asp:Literal ID="ltrShippingType4" runat="server"></asp:Literal>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        
        <asp:HiddenField ID="hdfcreate" runat="server" />
        <script type="text/javascript">
            function searchOrder() {
                $("#<%= btnSearch.ClientID%>").click();
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
