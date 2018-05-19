<%@ Page Title="Quản lý danh mục sản phẩm" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="quan-ly-danh-muc-san-pham.aspx.cs" Inherits="IM_PJ.quan_ly_danh_muc_san_pham" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/App_Themes/NewUI/css/jstree.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main id="main-wrap">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h3 class="page-title left">Danh sách danh mục sản phẩm</h3>
                    <div class="right above-list-btn">
                        <a href="/them-danh-muc" class="h45-btn btn" style="background-color: #ff3f4c">Thêm mới</a>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panelborderheading">
                        <div class="panel-body">
                            <div id="tree_1" class="tree-demo">
                                <asp:Literal ID="ltrTree" runat="server"></asp:Literal>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row" style="display:none">
                <div class="col-md-12">
                    <div class="filter-above-wrap clear">
                        <div class="right">
                            <div class="filter-control right">
                                <asp:TextBox ID="txtAgentName" runat="server" CssClass="form-control" placeholder="Nhập tên danh mục để tìm"
                                    Width="210px"></asp:TextBox>
                                <a href="javascript:;" onclick="searchAgent()" class="btn primary-btn h45-btn no-margin-bottom"><i class="fa fa-search"></i></a>
                                <asp:Button ID="btnSearch" runat="server" CssClass="btn primary-btn h45-btn" OnClick="btnSearch_Click" Style="display: none" />
                            </div>
                        </div>
                    </div>
                    <div class="panel-table clear">
                        <div class="responsive-table">
                            <table class="table table-checkable table-product">
                                <tbody>
                                    <tr>
                                        <th>Tên</th>
                                        <th>Ngày tạo</th>
                                        <th>Ẩn</th>
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

        <script src="/App_Themes/NewUI/js/jquery-ui/jquery-ui.min.js" type="text/javascript"></script>
        <script src="/App_Themes/NewUI/js/app.js"></script>
        <script src="/App_Themes/NewUI/js/jstree.min.js"></script>
        <script src="/App_Themes/NewUI/js/ui-tree.js"></script>
        <script type="text/javascript">
            function editCategory(ID) {
                var win = window.open("/thong-tin-danh-muc-san-pham.aspx?id=" + ID + "", '_blank');
                //win.focus();
                //window.location = "/admin/categoryinfo.aspx?ID=" + ID + "";
            }
            function AddChildCategory(ID) {
                var win = window.open("/danh-sach-san-pham.aspx?categoryid=" + ID + "", '_blank');
                //win.focus();
                //window.location = "/admin/addChildCategory.aspx?ID=" + ID + "";
            }

            function searchAgent() {
                $("#<%= btnSearch.ClientID%>").click();
            }
        </script>
    </main>
    <style>
        .register-link {
            color: blue;
            text-decoration: underline;
            font-style: italic;
        }
    </style>
</asp:Content>
