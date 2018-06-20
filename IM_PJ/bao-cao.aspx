<%@ Page Language="C#" Title="Báo cáo - Thống kê" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="bao-cao.aspx.cs" Inherits="IM_PJ.bao_cao" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main id="main-wrap">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h3 class="page-title left">Báo cáo - Thống kê</h3>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel-table clear">
                        <div class="responsive-table">
                            <table class="table table-checkable table-product center-txt">
                                <tbody>
                                    <tr>
                                        <th>Loại báo cáo - thống kê</th>
                                        <th>Thao tác</th>
                                    </tr>
                                    <tr>
                                        <td>Doanh thu</td>
                                        <td><a href="thong-ke-doanh-thu" class="btn primary-btn h45-btn">Chi tiết</a></td>
                                    </tr>
                                    <tr>
                                        <td>Lợi nhuận</td>
                                        <td><a href="thong-ke-loi-nhuan" class="btn primary-btn h45-btn">Chi tiết</a></td>
                                    </tr>
                                    <tr>
                                        <td>Số lượng bán ra</td>
                                        <td><a href="thong-ke-so-luong-san-pham-ban-ra" class="btn primary-btn h45-btn">Chi tiết</a></td>
                                    </tr>
                                    <tr>
                                        <td>Số lượng đổi trả</td>
                                        <td><a href="thong-ke-so-luong-hang-doi-tra" class="btn primary-btn h45-btn">Chi tiết</a></td>
                                    </tr>
                                     <tr>
                                        <td>Phí vận chuyển</td>
                                        <td><a href="thong-ke-phi-van-chuyen" class="btn primary-btn h45-btn">Chi tiết</a></td>
                                    </tr>
                                     <tr>
                                        <td>Chiết khấu</td>
                                        <td><a href="thong-ke-chiet-khau" class="btn primary-btn h45-btn">Chi tiết</a></td>
                                    </tr>
                                     <tr>
                                        <td>Tồn kho</td>
                                        <td><a href="thong-ke-so-luong-ton-kho-theo-danh-muc" class="btn primary-btn h45-btn">Chi tiết</a></td>
                                    </tr>
                                    <tr>
                                        <td>Nhân viên</td>
                                        <td><a href="thong-ke-nhan-vien" class="btn primary-btn h45-btn">Chi tiết</a></td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>
