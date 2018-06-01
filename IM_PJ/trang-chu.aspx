<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="trang-chu.aspx.cs" Inherits="IM_PJ.trang_chu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main id="main-wrap">
        <div class="container">
            <h3 class="page-title">Xin chào!</h3>
            <div class="row">
                <div class="col-md-12">
                    <table data-toggle="table" id="table-student">
                        <thead>
                            <tr>
                                <th>Khách hàng</th>
                                <th>Đã mua</th>
                                <th>Zalo</th>
                                <th>Facebook</th>
                                <th>Nhân viên phụ trách</th>
                            </tr>
                        </thead>
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
    </main>
    <style>
        .fixed-table-body {
            overflow-x: hidden;
            overflow-y: hidden;
            height: 100%;
        }
    </style>
</asp:Content>
