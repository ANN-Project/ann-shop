// get highest customer discount
function getCustomerDiscount(custID) {
    $.ajax({
        type: "POST",
        url: "/pos.aspx/getCustomerDiscount",
        data: "{ID:'" + custID + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            var data = msg.d;
            if (data != 0) {
                $(".discount-info").html("<strong>Khách hàng được chiết khấu: " + formatThousands(data, ",") + " vnđ/sản phẩm.</strong>").show();
                $("input[id$='_hdfIsDiscount']").val("1");
                $("input[id$='_hdfDiscountAmount']").val(data);
            } else {
                $(".discount-info").hide();
                $("input[id$='_hdfIsDiscount']").val("0");
                $("input[id$='_hdfDiscountAmount']").val("0");
            }
            getAllPrice();
        },
        error: function (xmlhttprequest, textstatus, errorthrow) {
            alert('lỗi');
        }
    });
}

// view Customer detail by click button
function viewCustomerDetail(custID) {
    $.ajax({
        type: "POST",
        url: "/pos.aspx/getCustomerDetail",
        data: "{ID:'" + custID + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            if (msg.d != "null") {
                $("input[id$='_hdfCheckCustomer']").val("1");
                var alldata = JSON.parse(msg.d);

                var data = alldata.Customer;
                var dataDiscout = alldata.AllDiscount;
                var jsonDate = data.CreatedDate;
                var dateString = jsonDate.substr(6);
                var currentTime = new Date(parseInt(dateString));
                var month = currentTime.getMonth() + 1;
                var day = currentTime.getDate();
                var year = currentTime.getFullYear();
                var date = day + "/" + month + "/" + year;
                var html = "";
                html += "<div class=\"responsive-table\">";
                html += "<table class=\"table table-checkable table-product\">";
                html += "   <thead>";
                html += "       <tr>";
                html += "           <td style=\"width:25%;\">Khách hàng:</td>";
                html += "           <td>" + data.CustomerName + "</td>";
                html += "       </tr>";
                html += "       <tr>";
                html += "           <td style=\"width:25%;\">Nick đặt hàng:</td>";
                html += "           <td>" + data.Nick + "</td>";
                html += "       </tr>";
                html += "       <tr>";
                html += "           <td style=\"width:25%;\">Điện thoại</td>";
                html += "           <td>" + data.CustomerPhone + "</td>";
                html += "       </tr>";
                html += "       <tr>";
                html += "           <td style=\"width:25%;\">Địa chỉ</td>";
                html += "           <td>" + data.CustomerAddress + "</td>";
                html += "       </tr>";
                html += "       <tr>";
                html += "           <td style=\"width:25%;\">Email</td>";
                html += "           <td>" + data.CustomerEmail + "</td>";
                html += "       </tr>";
                html += "       <tr>";
                html += "           <td style=\"width:25%;\">Zalo</td>";
                html += "           <td>" + data.Zalo + "</td>";
                html += "       </tr>";
                html += "       <tr>";
                html += "           <td style=\"width:25%;\">Facebook</td>";
                html += "           <td>" + data.Facebook + "</td>";
                html += "       </tr>";
                html += "       <tr>";
                html += "           <td style=\"width:25%;\">Nhân viên phục vụ</td>";
                html += "           <td>" + data.CreatedBy + "</td>";
                html += "       </tr>";
                html += "       <tr>";
                html += "           <td style=\"width:25%;\">Ngày tạo</td>";
                html += "           <td>" + date + "</td>";
                html += "       </tr>";
                html += "   </thead>";
                html += "</table>";
                html += "</div>";

                var htmlDiscount = "";
                if (dataDiscout.length > 0) {
                    htmlDiscount += "<div class=\"responsive-table\">";
                    htmlDiscount += "<table class=\"table table-checkable table-product\">";
                    htmlDiscount += "       <tr>";
                    htmlDiscount += "           <td><strong>Tên nhóm</strong></td>";
                    htmlDiscount += "           <td><strong>Chiết khấu</strong></td>";
                    htmlDiscount += "       </tr>";
                    for (var i = 0; i < dataDiscout.length; i++) {
                        htmlDiscount += "       <tr>";
                        htmlDiscount += "           <td>" + dataDiscout[i].DiscountName + "</td>";
                        htmlDiscount += "           <td>" + formatThousands(dataDiscout[i].DiscountAmount, ",") + " vnđ/sản phẩm</td>";
                        htmlDiscount += "       </tr>";
                    }
                    htmlDiscount += "</table>";
                    htmlDiscount += "</div>";
                } else {
                    htmlDiscount += "<div class=\"responsive-table\">";
                    htmlDiscount += "<table class=\"table table-checkable table-product\">";
                    htmlDiscount += "       <tr>";
                    htmlDiscount += "           <td><strong>Hiện tại khách hàng chưa được chiết khấu</strong></td>";
                    htmlDiscount += "       </tr>";
                    htmlDiscount += "</table>";
                    htmlDiscount += "</div>";
                }

                showPopup(html + htmlDiscount);
            }
        },
        error: function (xmlhttprequest, textstatus, errorthrow) {
            //alert('lỗi 1');
        }
    });
}

// search Customer by name, nick, phone, zalo, facebook
function searchCustomer() {
    var html = "";
    html += "<div class=\"form-row\">";
    html += "<label>Tìm khách hàng: </label>";
    html += "<input id=\"txtSearchCustomer\" class=\"form-control fjx\"></input>";
    html += "<a href=\"javascript:;\" class=\"btn primary-btn float-right-btn link-btn\" onclick=\"showCustomerList()\"><i class=\"fa fa-search\" aria-hidden=\"true\"></i> Tìm</a>";
    html += "<div class=\"customer-list hide\">";
    html += "</div>";
    html += "</div>";
    showPopup(html);
    $("#txtSearchCustomer").focus();
    $('#txtSearchCustomer').keydown(function (event) {
        if (event.which === 13) {
            showCustomerList();
            event.preventDefault();
            return false;
        }
    });
}

// show customer list after search
function showCustomerList() {
    var textsearch = $("#txtSearchCustomer").val();
    var username = $("input[id$='_hdfUsername']").val();
    if (!isBlank(textsearch)) {
        $.ajax({
            type: "POST",
            url: "/pos.aspx/searchCustomerByText",
            data: "{textsearch:'" + textsearch + "', createdby:'" + username + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                var count = 0;
                var data = JSON.parse(msg.d);
                if (data.length > 0) {
                    var html = "";
                    var listGet = "";
                    html += ("<div class=\"form-row\">");
                    html += ("<table class=\"table table-checkable table-product\">");
                    html += ("<tbody>");
                    html += ("<tr>");
                    html += ("<th class=\"select-column\"></th>");
                    html += ("<th class=\"nick-column\">Nick đặt hàng</th>");
                    html += ("<th class=\"name-column\">Họ tên</th>");
                    html += ("<th class=\"phone-column\">Điện thoại</th>");
                    html += ("<th class=\"zalo-column\">Zalo</th>");
                    html += ("<th class=\"facebook-column\">Facebook</th>");
                    html += ("<th class=\"address-column\">Địa chỉ</th>");
                    html += ("<th class=\"province-column\">Tỉnh thành</th>");
                    html += ("</tr>");
                    
                    for (var i = 0; i < data.length; i++) {
                        var item = data[i];
                        html += ("<tr class=\"search-popup\" id=\"search-key\";>");
                        html += ("<td>");
                        html += ("<input id=\"" + item.ID + "\" name=\"cust\" type=\"radio\" class=\"check-popup\"  />");
                        html += ("</td>");

                        if (!isBlank(item.Nick)) {
                            html += ("<td class=\"nick nick-column\">" + item.Nick + "</td>");
                        } else {
                            html += ("<td class=\"nick nick-column\"></td>");
                        }
                        html += ("<td class=\"name name-column\">" + item.CustomerName + "</td>");
                        html += ("<td class=\"phone phone-column\">" + item.CustomerPhone + "</td>");
                        html += ("<td class=\"id\" style=\"display:none\">" + item.ID + "</td>");
                        if (!isBlank(item.Zalo)) {
                            html += ("<td class=\"zalo zalo-column\">" + item.Zalo + "</td>");
                        } else {
                            html += ("<td></td>");
                        }
                        if (!isBlank(item.Facebook)) {
                            html += ("<td class=\"facebook\" data-value=\"" + item.Facebook + "\"><a class=\"link\" href=\"" + item.Facebook + "\" target=\"_blank\">Xem</a></td>");
                        } else {
                            html += ("<td></td>");
                        }
                        if (!isBlank(item.CustomerAddress)) {
                            html += ("<td class=\"address address-column\">" + item.CustomerAddress + "</td>");
                        } else {
                            html += ("<td></td>");
                        }
                        if (!isBlank(item.Province)) {
                            html += ("<td class=\"province province-column\">" + item.Province + "</td>");
                        } else {
                            html += ("<td></td>");
                        }
                        html += ("</tr>");
                    }
                    html += ("</tbody>");
                    html += ("</table>");
                    html += ("</div>");
                    html += ("<div class=\"btn-content\">");
                    html += ("<a href=\"javascript:;\" class=\"btn primary-btn float-right-btn link-btn\" onclick=\"selectCustomer()\"><i class=\"fa fa-check-square-o\" aria-hidden=\"true\"></i> Chọn</a>");
                    html += ("</div>");
                    $("#txtSearchCustomer").val("");
                    $(".customer-list").html(html);
                    $(".customer-list").removeClass('hide').addClass('show');
                } else {
                    alert('Không tìm thấy khách hàng');
                }
            },
            error: function (xmlhttprequest, textstatus, errorthrow) {
                alert('lỗi');
            }
        });
    } else {
        alert('Vui lòng nhập nội dung tìm kiếm');
    }
}

// select a customer after show list
function selectCustomer() {
    $(".search-popup").each(function () {
        if ($(this).find(".check-popup").is(':checked')) {
            var phone = $(this).find("td.phone").html();
            var name = $(this).find("td.name").html();
            var nick = $(this).find("td.nick").html();
            var address = $(this).find("td.address").html();
            var zalo = $(this).find("td.zalo").html();
            var facebook = $(this).find("td.facebook").attr("data-value");
            var id = $(this).find("td.id").html();
            $("input[id$='_txtPhone']").val(phone).prop('disabled', true);
            $("input[id$='_txtFullname']").val(name).prop('disabled', true);
            $("input[id$='_txtNick']").val(nick).prop('disabled', true);
            $("input[id$='_txtAddress']").val(address).prop('disabled', true);
            $("input[id$='_txtZalo']").val(zalo).prop('disabled', true);
            $("input[id$='_txtFacebook']").parent().removeClass("width-100");
            $("input[id$='_txtFacebook']").val(facebook).prop('disabled', true);
            if (facebook == null) {
                $(".link-facebook").hide();
                $("input[id$='_txtFacebook']").parent().addClass("width-100");
            }
            else {
                $("input[id$='_txtFacebook']").parent().removeClass("width-100");
                $(".link-facebook").html("<a href=\"" + facebook + "\" class=\"btn primary-btn fw-btn not-fullwidth\" target=\"_blank\">Xem</a>").show();
            }
            $(".view-detail").html("<a href=\"javascript:;\" class=\"btn primary-btn fw-btn not-fullwidth\" onclick=\"viewCustomerDetail('" + id + "')\"><i class=\"fa fa-address-card-o\" aria-hidden=\"true\"></i> Xem chi tiết</a><a href=\"javascript:;\" class=\"btn primary-btn fw-btn not-fullwidth clear-btn\" onclick=\"clearCustomerDetail()\"><i class=\"fa fa-times\" aria-hidden=\"true\"></i> Bỏ qua</a>").show();
            getCustomerDiscount(id);
        }
    });
    closePopup();
}

// clear customer detail
function clearCustomerDetail() {
    $("input[id$='_hdfCheckCustomer']").val("0");
    $("input[id$='_txtPhone']").val("").prop('disabled', false);
    $("input[id$='_txtFullname']").val("").prop('disabled', false);
    $("input[id$='_txtNick']").val("").prop('disabled', false);
    $("input[id$='_txtAddress']").val("").prop('disabled', false);
    $("input[id$='_txtZalo']").val("").prop('disabled', false);
    $("input[id$='_txtFacebook']").val("").prop('disabled', false);
    $(".view-detail").html("").hide();
    $(".discount-info").html("").hide();
    $(".link-facebook").html("").hide();
    $("input[id$='_txtFacebook']").parent().addClass("width-100");
    $("input[id$='_txtFullname']").focus();
    getAllPrice();
}